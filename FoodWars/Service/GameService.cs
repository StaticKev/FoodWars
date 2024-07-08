using FoodWars.Entity.CustomerRole;
using FoodWars.Entity.CustomerSubtype;
using FoodWars.Repository;
using FoodWars.Utilities;
using FoodWars.Values;
using System;
using System.Collections.Generic;
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
        private Customers nextCustomer; // Diinisialisasi setelah CustomerQueue digenerate
        private int dailyRevenue; // Diinisialisasi saat saat service dibuat. Saat game berakhir, tambahkan pada totalRevenue milik player, kemudian reset menjadi 0.
        private Time openDuration; // ============================== BELOM DIINSTANSIASI ==============================

        // Buat satu data member untuk menghitung interval antar customer sesuai aturan yang berlaku
        private Time customerInterval;

        // Ini ndak perlu property
        private IngredientsMap availableIngredients; // Untuk menentukan bahan apa saja yang tersedia.
        private BeverageType[] availableBeverages; // Untuk menentukan minuman apa saja yang tersedia.
        private Items chosenItem; // Item yang dipilih untuk diberikan kepada pelanggan. 
        private Foods foodBeingPrepared; // Makanan yang sedang disiapkan di meja penyajian.
        private Beverages beveragesBeingPrepared; // Minuman yang sedang disiapkan pada dispenser minuman.
        #endregion

        #region Constructors
        public GameService(PlayerRepo repo)
        {
            this.repo = repo;
        }
        #endregion

        #region Properties
        public Players Player { get => player; set => player = value; }
        private CustomerQueue CustomerQueue { get => customerQueue; set => customerQueue = value; }
        private Customers[] Chairs 
        { 
            get => chairs; 
            set => chairs = value;
        }
        private Customers NextCustomer { get => nextCustomer; set => nextCustomer = value; }
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
        public Time CustomerInterval 
        { 
            get => customerInterval; 
            set
            {
                if (value == null) throw new ArgumentNullException("Argument can't be null!");
                else customerInterval = value;
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
        public Items ChosenItem 
        { 
            get => chosenItem;
            set => chosenItem = value;
        }
        public Foods FoodsBeingPrepared 
        { 
            get => foodBeingPrepared; 
            private set => foodBeingPrepared = value;
        }
        public Beverages BeveragesBeingPrepared 
        { 
            get => beveragesBeingPrepared; 
            private set => beveragesBeingPrepared = value;
        }
        #endregion

        #region Methods
        public void ResetGameState()
        {
            CustomerQueue = null;
            Chairs = null;
            NextCustomer = null;
            DailyRevenue = 0;
            OpenDuration = null;
            CustomerInterval = new Time(0, 0, 5);

            availableIngredients = null;
            availableBeverages = null;
            chosenItem = null;
            foodBeingPrepared = null;
            beveragesBeingPrepared = null;

        }
        public void StartGame()
        {
            Chairs = new Customers[3];
            OpenDuration = new Time(0, 0, 1);
            CustomerInterval = new Time(0, 0, 5);
            // =================================== JANGAN LUPA ISI PICTURE! ===================================
            List<Ingredients> riceIngredients = new List<Ingredients>
            {
                new Ingredients("Regular Rice", 50, IngredientCategory.RICE, null),
                new Ingredients("Brown Rice", 100, IngredientCategory.RICE, null),
                new Ingredients("Corn Rice", 70, IngredientCategory.RICE, null)
            };
            List<Ingredients> proteinIngredients = new List<Ingredients>
            {
                new Ingredients("Tonkatsu", 300, IngredientCategory.PROTEIN, null),
                new Ingredients("Karage", 200, IngredientCategory.PROTEIN, null),
                new Ingredients("Ebi Furai", 250, IngredientCategory.PROTEIN, null)
            };
            List<Ingredients> vegetableIngredients = vegetableIngredients = new List<Ingredients>
            {
                new Ingredients("Pickled Radish", 50, IngredientCategory.VEGETABLES, null),
                new Ingredients("Edamame", 50, IngredientCategory.VEGETABLES, null),
                new Ingredients("Hibiki Salad", 60, IngredientCategory.VEGETABLES, null)
            };
            List<Ingredients> sideDishesIngredients = sideDishesIngredients = new List<Ingredients>
            {
                new Ingredients("Sunomono", 70, IngredientCategory.SIDE_DISHES, null),
                new Ingredients("Nimono", 80, IngredientCategory.SIDE_DISHES, null),
                new Ingredients("Korokke", 100, IngredientCategory.SIDE_DISHES, null)
            };

            AvailableIngredients = new IngredientsMap();
            AvailableBeverages = new BeverageType[] { BeverageType.WATER, BeverageType.OCHA, BeverageType.SAKE };
            Merchandise[] merch = new Merchandise[]
            {
                new Merchandise("Keychain", 700, 2, null),
                new Merchandise("T-Shirt", 900, 3, null),
                new Merchandise("Action Figure", 1200, 1, null)
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
                int tempLevel = 0;
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
            allowedBeverages = Player.Level / 50 + 1;

            AvailableIngredients.Add(IngredientCategory.RICE, riceIngredients, allowedRice);
            AvailableIngredients.Add(IngredientCategory.PROTEIN, proteinIngredients, allowedProtein);
            AvailableIngredients.Add(IngredientCategory.VEGETABLES, vegetableIngredients, allowedVegetable);
            AvailableIngredients.Add(IngredientCategory.SIDE_DISHES, sideDishesIngredients, allowedSideDishes);

            customerQueue = GenerateQueue();

            // Mulai tempatkan pengunjung pada kursi yang tersedia, update tampilan 

            // Menyimpan customer yang akan masuk berikutnya untuk ditampilkan
            nextCustomer = customerQueue.Peek();

            CustomerQueue GenerateQueue()
            {
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

                // Menghitung jumlah customer berdasarkan 
                int customerAmount;
                if (Player.Level <= 100) customerAmount = 5 + Player.Level / 5;
                else customerAmount = 30;

                // Menentukan 80% customer yang akan mengikuti rasio level, dan 20% customer yang akan diacak
                int randomizedRoleCustomer = (int)(customerAmount * 0.2);
                int fixedRoleCustomer = customerAmount - randomizedRoleCustomer;

                // Menentukan rasio dari 80% customer
                List<int> customerRoleRatio = new List<int>();
                if (Player.Level > 30)
                {
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.35));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.1));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.05));

                    if (customerRoleRatio.Sum() < fixedRoleCustomer) customerRoleRatio[0]++;
                }
                else if (Player.Level > 20)
                {
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.4));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.1));
                }
                else if (Player.Level > 10)
                {
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.5));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                    customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                }
                else if (Player.Level > 5)
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

                // Mengisi queue sesuai dengan aturan
                for (int i = fixedRoleCustomer; i > 0; i--)
                {
                    while (true)
                    {
                        int randomIndex = Randomizer.Generate(availableRole.Count);
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

                return customerQueue;

                // Membuat customer sesuai dengan spesifikasi yang diberikan
                Customers GenerateRandomCustomer(int itemCount, CustomerType customerType, int chosenRole)
                {
                    Customers customer;

                    // JANGAN LUPA ISI PICTURE! (Yang ini pake pengecekan, bergantung pada type, dan role)
                    if (chosenRole == 0)
                    {
                        customer = new Folk(customerType, null);
                        // Pengecekan untuk image
                    }
                    else if (chosenRole == 1)
                    {
                        customer = new BusinessMan(customerType, null);
                        // Pengecekan untuk image
                    }
                    else if (chosenRole == 2)
                    {
                        customer = new Samurai(customerType, null);
                        // Pengecekan untuk image
                    }
                    else if (chosenRole == 3)
                    {
                        customer = new Nobleman(customerType, null);
                        // Pengecekan untuk image
                    }
                    else
                    {
                        customer = new RoyalFamily(customerType, null);
                        // Pengecekan untuk image
                    }

                    int availableItems = 3;

                    for (int i = 0; i < itemCount; i++)
                    {
                        int option = Randomizer.Generate(availableItems);
                        if (option == 0)
                        {
                            // JANGAN LUPA ISI PICTURE!
                            Foods food = new Foods("", null);

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
                            Beverages beverage = new Beverages("", isCold, beverageType, glassSize, null);

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
                                foreach (Merchandise m in merch)
                                {
                                    totalMerchStock += m.Stock;
                                }

                                if (totalMerchStock > 0)
                                {
                                    int chosenMerch = Randomizer.Generate(merch.Length);
                                    while (true)
                                    {
                                        if (merch[chosenMerch].Stock > 0)
                                        {
                                            customer.AddOrder(merch[chosenMerch]);
                                            merch[chosenMerch].Stock--;
                                            totalMerchStock--;
                                            break;
                                        }
                                        else
                                        {
                                            if (totalMerchStock > 0)
                                            {
                                                chosenMerch = Randomizer.Generate(merch.Length);
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
                    OpenDuration.Add(customer.Timer.GetDurationInSecond());

                    return customer;
                }

            }
        }

        public void AddPlayer(Players player)
        {
            repo.AddPlayer(player);
        }

        public List<Players> GetPlayers()
        {
            return repo.ListPlayers;
        }
        #endregion
    }
}