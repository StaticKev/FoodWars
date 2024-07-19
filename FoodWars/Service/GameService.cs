using FoodWars.Entity.CustomerRole;
using FoodWars.Entity.CustomerSubtype;
using FoodWars.Properties;
using FoodWars.Repository;
using FoodWars.Utilities;
using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace FoodWars.Service
{
    public class GameService
    {
        #region Data Members
        // Persist during the entire application lifetime!
        private PlayerRepo repo; // Memang tidak diberi property
        private Players player; // Menyimpan status player yang sedang bermain saat ini.

        // Game components (Reinitialized during a new game)
        private CustomerQueue customerQueue;
        private Customers[] chairs;
        private int dailyRevenue; // Diinisialisasi saat saat service dibuat. Saat game berakhir, tambahkan pada totalRevenue milik player, kemudian reset menjadi 0.
        private Time openDuration;
        private int servedCustomer;

        private Time[] chairsPendingInterval;

        // Ini ndak perlu property
        private IngredientsMap availableIngredients; // Untuk menentukan bahan apa saja yang tersedia.
        private BeverageType[] availableBeverages; // Untuk menentukan minuman apa saja yang tersedia.
        private Merchandise[] merch; // Khusus ini perlu property, soalnya user harus tau stock nya.
        private Items selectedItem; // Item yang dipilih untuk diberikan kepada pelanggan. 
        private Foods foodBeingPrepared; // Makanan yang sedang disiapkan di meja penyajian.
        private Beverages beveragesBeingPrepared; // Minuman yang sedang disiapkan pada dispenser minuman.
        #endregion

        #region Constructors
        public GameService(PlayerRepo repo)
        {
            this.GameRepo = repo;
        }
        #endregion

        #region Properties
        private PlayerRepo GameRepo {
            get => repo;
            set
            {
                if (value == null) throw new ArgumentException("No repo specified!");
                else repo = value;
            }
        }
        public Players Player { get => player; set => player = value; }
        private CustomerQueue CustomerQueue { get => customerQueue; set => customerQueue = value; }
        public Customers[] Chairs
        {
            get => chairs;
            private set => chairs = value;
        }
        public int DailyRevenue
        {
            get => dailyRevenue;
            private set
            {
                if (value < 0) throw new ArgumentException("Daily revenue can't be negative!");
                else dailyRevenue = value;
            }
        }
        public Time OpenDuration
        {
            get => openDuration;
            private set => openDuration = value;
        }
        private Time[] ChairsPendingInterval
        {
            get => chairsPendingInterval;
            set
            {
                if (value == null) throw new ArgumentNullException("Value can't be null!");
                else chairsPendingInterval = value;
            }
        }
        public IngredientsMap AvailableIngredients
        {
            get => availableIngredients;
            private set => availableIngredients = value;
        }
        public BeverageType[] AvailableBeverages
        {
            get => availableBeverages;
            private set => availableBeverages = value;
        }
        private Merchandise[] Merch
        {
            get => merch;
            set
            {
                if (value == null) throw new ArgumentException("Value can't be null!");
                else merch = value;
            }
        }
        public Items SelectedItem
        {
            get => selectedItem;
            set => selectedItem = value;
        }
        public Foods FoodsBeingPrepared
        {
            get => foodBeingPrepared;
            set => foodBeingPrepared = value;
        }
        public Beverages BeveragesBeingPrepared
        {
            get => beveragesBeingPrepared;
            set => beveragesBeingPrepared = value;
        }
        #endregion

        #region Methods
        public void ResetGameState()
        {
            CustomerQueue = null;
            Chairs = null;
            DailyRevenue = 0;
            OpenDuration = null;

            availableIngredients = null;
            availableBeverages = null;
            selectedItem = null;
            foodBeingPrepared = null;
            beveragesBeingPrepared = null;

        }

        public void StartGame()
        {
            Chairs = new Customers[3];
            OpenDuration = new Time(0, 0, 0);
            ChairsPendingInterval = new Time[3];
            ChairsPendingInterval[0] = new Time(0, 0, 0);
            ChairsPendingInterval[1] = new Time(0, 0, 0);
            ChairsPendingInterval[2] = new Time(0, 0, 0);
            servedCustomer = 0;

            // Menghitung jumlah customer 
            int customerAmount;
            if (Player.Level <= 100) customerAmount = 3 + Player.Level / 5;
            else customerAmount = 25;

            // =================================== JANGAN LUPA ISI PICTURE! ===================================
            List<Ingredients> riceIngredients = new List<Ingredients>
            {
                new Ingredients("Regular Rice", 50, IngredientCategory.RICE, Resources.rice_regular),
                new Ingredients("Brown Rice", 100, IngredientCategory.RICE, Resources.rice_brown),
                new Ingredients("Corn Rice", 70, IngredientCategory.RICE, Resources.rice_corn)
            };
            List<Ingredients> proteinIngredients = new List<Ingredients>
            {
                new Ingredients("Tonkatsu", 300, IngredientCategory.PROTEIN, Resources.protein_tonkatsu),
                new Ingredients("Tofu", 150, IngredientCategory.PROTEIN, Resources.protein_tofu),
                new Ingredients("Ebi Furai", 250, IngredientCategory.PROTEIN, Resources.protein_ebi)
            };
            List<Ingredients> vegetableIngredients = vegetableIngredients = new List<Ingredients>
            {
                new Ingredients("Edamame", 50, IngredientCategory.VEGETABLES, Resources.veggie_edamame),
                new Ingredients("Pickled Raddish", 50, IngredientCategory.VEGETABLES, Resources.veggie_pickle),
                new Ingredients("Hibiki Salad", 60, IngredientCategory.VEGETABLES, Resources.veggie_hibiki)
            };
            List<Ingredients> sideDishesIngredients = sideDishesIngredients = new List<Ingredients>
            {
                new Ingredients("Sunomono", 70, IngredientCategory.SIDE_DISHES, Resources.side_sunomono),
                new Ingredients("Nimono", 80, IngredientCategory.SIDE_DISHES, Resources.side_nimono),
                new Ingredients("Korokke", 100, IngredientCategory.SIDE_DISHES, Resources.side_korokke)
            };

            AvailableIngredients = new IngredientsMap();
            AvailableBeverages = new BeverageType[] { BeverageType.WATER, BeverageType.OCHA, BeverageType.SAKE };
            Merch = new Merchandise[]
            {
                new Merchandise("Tumbler", 700, 0, Resources.merch_tumbler),
                new Merchandise("Fan", 900, 0, Resources.merch_fan),
                new Merchandise("Action Figure", 1200, 0, Resources.merch_actionFigure)
            };
            CustomerType[] customerTypes = customerTypes = new CustomerType[] { CustomerType.MALE, CustomerType.FEMALE, CustomerType.CHILD };

            // Parameter ketiga itu batasan jenis yang tersedia pada level tertentu dihitung sesuai level!!
            // Kalau sudah level 100 keatas buat = count.
            int allowedRice = 1;
            int allowedProtein = 1;
            int allowedVegetable = 1;
            int allowedSideDishes = 1;
            int allowedBeverages = 1;

            // Pengecekan untuk batasan bahan
            if (Player.Level >= 100) {
                allowedRice = riceIngredients.Count;
                allowedProtein = proteinIngredients.Count;
                allowedVegetable = vegetableIngredients.Count;
                allowedSideDishes = sideDishesIngredients.Count;
                allowedBeverages = AvailableBeverages.Count();
            }
            else
            {
                int tempLevel = Player.Level;
                for (int i = 0; i < 1; i++)
                {
                    if (tempLevel >= 10)
                    {
                        allowedProtein++;
                        if (tempLevel >= 20)
                        {
                            allowedVegetable++;
                            if (tempLevel >= 30)
                            {
                                allowedRice++;
                                if (tempLevel >= 40)
                                {
                                    allowedSideDishes++;
                                }
                            }
                        }
                    }
                    if (tempLevel > 50) tempLevel %= 50;
                    else break;
                }
            }
            if (Player.Level >= 100) allowedBeverages = 3;
            else allowedBeverages = Player.Level / 50 + 1;

            AvailableIngredients.Add(IngredientCategory.RICE, riceIngredients, allowedRice);
            AvailableIngredients.Add(IngredientCategory.PROTEIN, proteinIngredients, allowedProtein);
            AvailableIngredients.Add(IngredientCategory.VEGETABLES, vegetableIngredients, allowedVegetable);
            AvailableIngredients.Add(IngredientCategory.SIDE_DISHES, sideDishesIngredients, allowedSideDishes);

            // Menghitung jumlah merch
            int totalMerchCount = customerAmount / 5;
            for (int i = 0; i < totalMerchCount; i++)
            {
                totalMerchCount--;
                Merch[Randomizer.Generate(3)].Stock++;
            }

            customerQueue = GenerateQueue();

            CustomerQueue GenerateQueue()
            {
                Merchandise[] tempMerch= new Merchandise[]
                {
                    new Merchandise("Tumbler", 140, Merch[0].Stock, Resources.merch_tumbler),
                    new Merchandise("Fan", 180, Merch[1].Stock, Resources.merch_fan),
                    new Merchandise("Action Figure", 240, Merch[2].Stock, Resources.merch_actionFigure)
                };

                // Menentukan peran apa saja yang diizinkan muncul pada level tertentu
                List<int> availableRole = new List<int>();
                if (Player.Level >= 1)
                {
                    availableRole.Add(0);

                    if (Player.Level >= 5)
                    {
                        availableRole.Add(1);

                        if (Player.Level >= 10)
                        {
                            availableRole.Add(2);

                            if (Player.Level >= 20)
                            {
                                availableRole.Add(3);

                                if (Player.Level >= 30)
                                {
                                    availableRole.Add(4);
                                }
                            }
                        }
                    }
                }

                // Menentukan batasan jumlah produk yang diizinkan pada level tertentu
                int minProduct = 1;
                int maxProduct = 1;
                if (Player.Level >= 5)
                {
                    maxProduct++;

                    if (Player.Level >= 20)
                    {
                        maxProduct++;

                        if (Player.Level >= 50)
                        {
                            minProduct++;
                            if (Player.Level >= 90)
                            {
                                minProduct++;
                            }
                        }
                    }
                }

                // Menentukan 80% customer yang akan mengikuti rasio level, dan 20% customer yang akan diacak
                int randomizedRoleCustomer = (int)(customerAmount * 0.2);
                int fixedRoleCustomer = customerAmount - randomizedRoleCustomer;

                // Menentukan rasio dari 80% customer
                List<int> customerRoleRatio = new List<int>();
                if (Player.Level >= 30)
                {
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.35));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.1));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.05));

                    if (customerRoleRatio.Sum() < fixedRoleCustomer) customerRoleRatio[0]++;
                }
                else if (Player.Level >= 20)
                {
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.4));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.1));
                }
                else if (Player.Level >= 10)
                {
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.5));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                }
                else if (Player.Level >= 5)
                {
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.7));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                }
                else
                {
                    customerRoleRatio.Add(fixedRoleCustomer);
                }

                // Queue yang akan dikembalikan
                CustomerQueue customerQueue = new CustomerQueue(customerAmount);

                // Mencatat durasi pelayanan dari tiap customer
                List<int> totalServingDuration = new List<int>();

                // Mengisi queue sesuai dengan aturan
                for (int i = fixedRoleCustomer; i > 0; i--)
                {
                    while (true)
                    {
                        int randomIndex = Randomizer.Generate(availableRole.Count);
                        Console.WriteLine(customerRoleRatio.Count);
                        if (customerRoleRatio[randomIndex] > 0)
                        {
                            customerQueue.EnQueue(GenerateRandomCustomer(
                                Randomizer.Generate(minProduct, maxProduct),
                                customerTypes[Randomizer.Generate(customerTypes.Length)],
                                availableRole[randomIndex]
                                ));
                            customerRoleRatio[randomIndex]--;
                            break;
                        }
                    }
                }
                for (int i = 0; i < randomizedRoleCustomer; i++)
                {
                    customerQueue.EnQueue(GenerateRandomCustomer(
                        Randomizer.Generate(minProduct, maxProduct),
                        customerTypes[Randomizer.Generate(customerTypes.Length)],
                        availableRole[Randomizer.Generate(availableRole.Count)]
                        ));
                }

                // Mencari durasi maksimum untuk melayani seluruh customer pada 3 kursi.
                // Durasi maksimum pelayanan seluruh customer = lama permainan. 
                OpenDuration.Add(GetMaximumServingDuration());

                return customerQueue;

                // Membuat customer sesuai dengan spesifikasi yang diberikan
                Customers GenerateRandomCustomer(int itemCount, CustomerType customerType, int chosenRole)
                {
                    Customers customer;
                    Image picture = null;
                    int availableItems = 3;

                    if (chosenRole == 0)
                    {
                        if (customerType == CustomerType.MALE) picture = Resources.folk_male;
                        else if (customerType == CustomerType.FEMALE) picture = Resources.folk_female;
                        else picture = Resources.folk_child;
                        customer = new Folk(customerType, picture);
                    }
                    else if (chosenRole == 1)
                    {
                        if (customerType == CustomerType.MALE) picture = Resources.businessMan_male;
                        else if (customerType == CustomerType.FEMALE) picture = Resources.businessMan_female;
                        else picture = Resources.businessMan_child;
                        customer = new BusinessMan(customerType, picture);
                    }
                    else if (chosenRole == 2)
                    {
                        if (customerType == CustomerType.MALE) picture = Resources.samurai_male;
                        else if (customerType == CustomerType.FEMALE) picture = Resources.samurai_female;
                        else picture = Resources.samurai_child;
                        customer = new Samurai(customerType, picture);
                    }
                    else if (chosenRole == 3)
                    {
                        if (customerType == CustomerType.MALE) picture = Resources.nobleman_male;
                        else if (customerType == CustomerType.FEMALE) picture = Resources.nobleman_female;
                        else picture = Resources.nobleman_child;
                        customer = new Nobleman(customerType, picture);
                    }
                    else
                    {
                        if (customerType == CustomerType.MALE) picture = Resources.royalFamily_male;
                        else if (customerType == CustomerType.FEMALE) picture = Resources.royalFamily_female;
                        else picture = Resources.royalFamily_child;
                        customer = new RoyalFamily(customerType, picture);
                    }

                    for (int i = 0; i < itemCount; i++)
                    {
                        int option = Randomizer.Generate(availableItems);
                        if (option == 0)
                        {
                            Foods food = new Foods("", Resources.plate);

                            food.AddIngredient(AvailableIngredients.GetRandomIngredient(IngredientCategory.RICE));
                            food.AddIngredient(AvailableIngredients.GetRandomIngredient(IngredientCategory.PROTEIN));
                            food.AddIngredient(AvailableIngredients.GetRandomIngredient(IngredientCategory.VEGETABLES));
                            food.AddIngredient(AvailableIngredients.GetRandomIngredient(IngredientCategory.SIDE_DISHES));
                            try
                            {
                                customer.AddOrder(food);
                            }
                            catch (Exception ex) { }
                        }
                        else if (option == 1)
                        {
                            int glassOption = Randomizer.Generate(3);
                            GlassSize glassSize = GlassSize.SMALL;
                            if (glassOption == 1) glassSize = GlassSize.MEDIUM;
                            else if (glassOption == 2) glassSize = GlassSize.LARGE;

                            bool isCold = false;
                            if (Randomizer.Generate(2) == 1) isCold = true;

                            BeverageType beverageType = AvailableBeverages[Randomizer.Generate(allowedBeverages)];

                            // JANGAN LUPA ISI PICTURE! (Yang ini pake pengecekan, bergantung pada isCold, beverageType, dan glassSize)
                            if (beverageType == BeverageType.WATER)
                            {
                                if (isCold)
                                {
                                    if (glassSize == GlassSize.SMALL) picture = Resources.Bev_water_S_Cold; // Air kecil dingin
                                    else if (glassSize == GlassSize.MEDIUM) picture = Resources.Bev_water_M_Cold; // Air sedang dingin
                                    else picture = Resources.Bev_water_L_Cold; // Air besar dingin
                                }
                                else
                                {
                                    if (glassSize == GlassSize.SMALL) picture = Resources.Bev_water_S; // Air kecil
                                    else if (glassSize == GlassSize.MEDIUM) picture = Resources.Bev_water_M; // Air sedang
                                    else picture = Resources.Bev_water_L; // Air besar
                                }
                            }
                            else if (beverageType == BeverageType.OCHA)
                            {
                                if (isCold)
                                {
                                    if (glassSize == GlassSize.SMALL) picture = Resources.Bev_ocha_S_Cold; // Ocha kecil dingin
                                    else if (glassSize == GlassSize.MEDIUM) picture = Resources.Bev_ocha_M_Cold; // Ocha sedang dingin
                                    else picture = Resources.Bev_ocha_L_Cold; // Ocha besar dingin
                                }
                                else
                                {
                                    if (glassSize == GlassSize.SMALL) picture = Resources.Bev_ocha_S; // Ocha kecil
                                    else if (glassSize == GlassSize.MEDIUM) picture = Resources.Bev_ocha_M; // Ocha sedang
                                    else picture = Resources.Bev_ocha_L; // Ocha besar
                                }
                            }
                            else
                            {
                                if (isCold)
                                {
                                    if (glassSize == GlassSize.SMALL) picture = Resources.Bev_sake_S_Cold; // Sake kecil dingin
                                    else if (glassSize == GlassSize.MEDIUM) picture = Resources.Bev_sake_M_Cold; // Sake sedang dingin
                                    else picture = Resources.Bev_sake_L_Cold; // Sake besar dingin
                                }
                                else
                                {
                                    if (glassSize == GlassSize.SMALL) picture = Resources.Bev_sake_S; // Sake kecil
                                    else if (glassSize == GlassSize.MEDIUM) picture = Resources.Bev_sake_M; // Sake sedang
                                    else picture = Resources.Bev_sake_L; // Sake besar
                                }
                            }

                            Beverages beverage = new Beverages("", isCold, beverageType, glassSize, picture);

                            try
                            {
                                customer.AddOrder(beverage);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            try
                            {
                                int totalMerchStock = 0;
                                // Cek apakah ada merch yang dapat dijual (semua stok merch != 0), kalau tidak ada, availableItems--, i--, kembali ke awal.
                                foreach (Merchandise m in tempMerch)
                                {
                                    totalMerchStock += m.Stock;
                                }

                                if (totalMerchStock > 0)
                                {
                                    int chosenMerch = Randomizer.Generate(tempMerch.Length);
                                    while (true)
                                    {
                                        if (tempMerch[chosenMerch].Stock > 0)
                                        {
                                            customer.AddOrder(tempMerch[chosenMerch]);
                                            tempMerch[chosenMerch].Stock--;
                                            totalMerchStock--;
                                            break;
                                        }
                                        else
                                        {
                                            if (totalMerchStock > 0)
                                            {
                                                chosenMerch = Randomizer.Generate(tempMerch.Length);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    availableItems--;
                                    i--;
                                }
                            }
                            catch (Exception ex) { }
                        }
                    }

                    // Menambahkan durasi permainan sesuai dengan durasi pelayanan tiap customer 
                    customer.SetTimer();
                    totalServingDuration.Add(customer.WaitingDuration.GetSecond());

                    return customer;
                }

                int GetMaximumServingDuration()
                {
                    int maximumServingDuration = 0;
                    int[] timeline = new int[3];

                    for (int i = 0; i < totalServingDuration.Count; i++)
                    {
                        // Mencari indeks dengan durasi terpendek
                        int smallestElement = int.MaxValue;
                        int smallestElementIndex = 0;
                        for (int j = 0; j < timeline.Length; j++)
                        {
                            if (timeline[j] < smallestElement)
                            {
                                smallestElement = timeline[j];
                                smallestElementIndex = j;
                            }
                        }

                        if (smallestElement == 0)
                        {
                            timeline[smallestElementIndex] += totalServingDuration[i] + smallestElementIndex * (11 - smallestElementIndex + 1);
                        }
                        else timeline[smallestElementIndex] += totalServingDuration[i] + 3;
                    }

                    foreach (int max in timeline)
                    {
                        Console.Write(max + ", ");
                        if (max > maximumServingDuration) maximumServingDuration = max;
                    }
                    Console.WriteLine(maximumServingDuration);

                    return maximumServingDuration;
                }
            }
        }

        // Fungsi untuk mengupdate seluruh customer 
        public void UpdateAllCustomer(int chairIndex)
        {
            // Mengupdate pending interval sebuah kursi 
            if (ChairsPendingInterval[chairIndex].GetSecond() > 0) ChairsPendingInterval[chairIndex].Add(-1);

            // Update waktu tunggu semua customer dan keluarkan customer yang sudah selesai
            if (Chairs[chairIndex] != null)
            {
                Chairs[chairIndex].WaitingDuration.Add(-1);
                if (Chairs[chairIndex].WaitingDuration.GetSecond() == 0)
                {
                    // Hitung makanan yang telah dijual
                    Chairs[chairIndex] = null;
                    ChairsPendingInterval[chairIndex].Add(3);
                }
                else if (Chairs[chairIndex].Orders.Count == 0)
                {
                    // Sebelum dikeluarkan, simpan sisa waktu tunggu
                    int remainingWaitingTime = Chairs[chairIndex].WaitingDuration.GetSecond();

                    // Hitung makanan yang telah dijual dan tambahkan ke daily income 
                    DailyRevenue += Chairs[chairIndex].CountTotalPrice();
                    servedCustomer++;

                    // Keluarkan customer 
                    Chairs[chairIndex] = null;

                    // Jika sisa waktu tunggu kurang dari 10 detik, maka interval pelanggan berikutnya = sisa waktu tunggu
                    // Jika sisa waktu tunggu lebih dari 10 detik, maka interval pelanggan berikutnya = 10 detik
                    if (remainingWaitingTime < 10) ChairsPendingInterval[chairIndex].Add(remainingWaitingTime);
                    else ChairsPendingInterval[chairIndex].Add(10);
                }
            }

            // Menugaskan customer kedalam kursi yang masih kosong dan memberi pending interval 10 detik pada 3 customer pertama
            if (Chairs[chairIndex] == null && ChairsPendingInterval[chairIndex].GetSecond() == 0 && CustomerQueue.CustomerLeft() > 0)
            {
                Chairs[chairIndex] = CustomerQueue.DeQueue(); // Tugaskan customer pada kursi kosong (dari depan)

                if (CustomerQueue.Size - CustomerQueue.CustomerLeft() < 4)
                {
                    for (int i = ChairsPendingInterval.Length - (ChairsPendingInterval.Length - chairIndex - 1); i < ChairsPendingInterval.Length; i++)
                    {
                        ChairsPendingInterval[i].Add(10);
                    }
                }
            }
        }

        public void CreateNewFood() 
        {
            FoodsBeingPrepared = new Foods("", Resources.plate);
        }

        public void CreateNewBeverage(GlassSize glassSize) 
        {
            if (glassSize == GlassSize.SMALL) BeveragesBeingPrepared = new Beverages("", Resources.glass_S, glassSize);
            else if (glassSize == GlassSize.SMALL) BeveragesBeingPrepared = new Beverages("", Resources.glass_M, glassSize);
            else BeveragesBeingPrepared = new Beverages("", Resources.glass_L, glassSize);
        }

        public bool SelectMerch(int merchIndex)
        {
            if (Merch[merchIndex].Stock != 0)
            {
                SelectedItem = Merch[merchIndex];
                return true;
            }
            else return false;
        }

        // Fungsi untuk mengecek apakah pesanan sesuai
        public bool CheckOrder(int chairIndex)
        {
            // Cek jika item yang dipilih adalah merch maka, kurangi stoknya.
            if (SelectedItem is Merchandise)
            {
                foreach (Merchandise m in merch)
                {
                    if (SelectedItem.Name == m.Name)
                    {
                        m.Stock--;
                        break;
                    }
                }
            }

            foreach (Items order in Chairs[chairIndex].Orders)
            {
                if (order.GetType() == SelectedItem.GetType())
                {
                    Console.WriteLine(order.Name + " | " + SelectedItem.Name);
                    if (order.Name == SelectedItem.Name)
                    {
                        // Panggil method untuk memasukkan order ke list lain di customer
                        Chairs[chairIndex].MarkCompleteOrder(order);
                        if (SelectedItem is Foods) FoodsBeingPrepared = null;
                        else if (SelectedItem is Beverages) BeveragesBeingPrepared = null;
                        return true;
                    }
                }
            }

            // Jika orderMatch salah maka, buat message bubble menjadi merah, dan hapus dari selected item.
            SelectedItem = null;
            return false;
        }

        // Fungsi untuk mengecek jika game sudah selesai (customer habis atau waktu habis)
        public bool FinishGame()
        {
            bool queueIsEmpty = CustomerQueue.CustomerLeft() == 0;
            bool chairsAreEmpty = Chairs[0] == null && Chairs[1] == null && Chairs[2] == null;
            bool isClosed = OpenDuration.GetSecond() == 0;

            return (queueIsEmpty && chairsAreEmpty) || isClosed; ;

        }

        public void AddPlayer(Players player)
        {
            GameRepo.AddPlayer(player);
        }

        public List<Players> GetPlayers()
        {
            return GameRepo.ListPlayers;
        }

        public void UpdatePlayerData()
        {
            Player.TotalIncome += dailyRevenue;
            Player.Level++;
            if (Player.BestIncome < dailyRevenue) Player.BestIncome = dailyRevenue;
            if (Player.BestTime.GetSecond() > OpenDuration.GetSecond() || Player.BestTime.GetSecond() == 0) Player.BestTime = OpenDuration;
            repo.UpdatePlayer(Player);
        }

        public bool AllCustomerServed()
        {
            return !(CustomerQueue.Size > servedCustomer);
        }
        #endregion
    }
}