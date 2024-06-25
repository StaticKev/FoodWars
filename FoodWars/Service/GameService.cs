using FoodWars.Entity.CustomerRole;
using FoodWars.Entity.CustomerSubtype;
using FoodWars.Repository;
using FoodWars.Utilities;
using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FoodWars.Service
{
    public class GameService
    {
        private PlayerRepo repo;
        private Players player; // Menyimpan status player yang sedang bermain saat ini. (Player cuma satu kah?)

        private List<Ingredients> riceIngredients;
        private List<Ingredients> proteinIngredients;
        private List<Ingredients> vegetableIngredients;
        private List<Ingredients> sideDishesIngredients;

        private IngredientsMap availableIngredients;
        private BeverageType[] availableBeverages;
        private int allowedBeverages;
        private Merchandise[] merch;
        private CustomerType[] customerTypes;

        private CustomerQueue customerQueue;

        // Kelihatan User
        private Customers[] chairs;
        private Customers nextCustomer; // Diinisialisasi setelah CustomerQueue digenerate
        private int dailyRevenue; // Diinisialisasi saat saat service dibuat. Saat game berakhir, tambahkan pada totalRevenue milik player, kemudian reset menjadi 0.
        private Time openDuration; // ============================== BELOM DIINSTANSIASI ==============================
        // Buat satu class untuk menghitung interval antar customer sesuai aturan yang berlaku

        private Items chosenItem; // Item yang dipilih untuk diberikan kepada pelanggan. 
        private Foods foodBeingPrepared; // Makanan yang sedang disiapkan di meja penyajian.
        private Beverages beveragesBeingPrepared; // Minuman yang sedang disiapkan pada dispenser minuman.

        public GameService(PlayerRepo repo)
        {
            this.repo = repo;

            // ============================== JANGAN LUPA ISI PICTURE! ==============================
            riceIngredients = new List<Ingredients>
            {
                new Ingredients("Regular Rice", 5_000, IngredientCategory.RICE, null),
                new Ingredients("Brown Rice", 10_000, IngredientCategory.RICE, null),
                new Ingredients("Corn Rice", 7_000, IngredientCategory.RICE, null)
            };
            proteinIngredients = new List<Ingredients>
            {
                new Ingredients("Tonkatsu", 30_000, IngredientCategory.PROTEIN, null),
                new Ingredients("Karage", 20_000, IngredientCategory.PROTEIN, null),
                new Ingredients("Ebi Furai", 25_000, IngredientCategory.PROTEIN, null)
            };
            vegetableIngredients = new List<Ingredients>
            {
                new Ingredients("Pickled Radish", 5_000, IngredientCategory.VEGETABLES, null),
                new Ingredients("Edamame", 5_000, IngredientCategory.VEGETABLES, null),
                new Ingredients("Hibiki Salad", 5_000, IngredientCategory.VEGETABLES, null)
            };
            sideDishesIngredients = new List<Ingredients>
            {
                new Ingredients("Sunomono", 7_000, IngredientCategory.SIDE_DISHES, null),
                new Ingredients("Nimono", 8_000, IngredientCategory.SIDE_DISHES, null),
                new Ingredients("Korokke", 10_000, IngredientCategory.SIDE_DISHES, null)
            };

            availableIngredients = new IngredientsMap();
            availableBeverages = new BeverageType[] { BeverageType.WATER, BeverageType.OCHA, BeverageType.SAKE };
            merch = new Merchandise[]
            {
                new Merchandise("Keychain", 70_000, 2, null),
                new Merchandise("T-Shirt", 90_000, 3, null),
                new Merchandise("Action Figure", 120_000, 1, null)
            };
            customerTypes = new CustomerType[] {CustomerType.MALE, CustomerType.FEMALE, CustomerType.CHILD};

            chairs = new Customers[3];

        }

        public void StartGame(int level)
        {
            // Parameter ketiga itu batasan jenis yang tersedia pada level tertentu dihitung sesuai level!!
            // Kalau sudah level 100 keatas buat = count.
            int allowedRice = 1;
            int allowedProtein = 1;
            int allowedVegetable = 1;
            int allowedSideDishes = 1;
            allowedBeverages = 1;

            // Pengecekan untuk batasan bahan
            if (level >= 100) {
                allowedRice = riceIngredients.Count;
                allowedProtein = proteinIngredients.Count;
                allowedVegetable = vegetableIngredients.Count;
                allowedSideDishes = sideDishesIngredients.Count;
                allowedBeverages = availableBeverages.Count();
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
            allowedBeverages = level / 50 + 1;

            availableIngredients.Add(IngredientCategory.RICE, riceIngredients, allowedRice);
            availableIngredients.Add(IngredientCategory.PROTEIN, proteinIngredients, allowedProtein);
            availableIngredients.Add(IngredientCategory.VEGETABLES, vegetableIngredients, allowedVegetable);
            availableIngredients.Add(IngredientCategory.SIDE_DISHES, sideDishesIngredients, allowedSideDishes);

            customerQueue = GenerateQueue(level);

            // Membuka semua bahan" yang diperlukan: Ini ditaroh di view

            // Nyalakan timer, update tampilan 
            
            // Mulai tempatkan pengunjung pada kursi yang tersedia, update tampilan 

        }

        public CustomerQueue GenerateQueue(int level)
        {
            // Menentukan peran apa saja yang diizinkan muncul pada level tertentu
            List<int> availableRole = new List<int>();
            if (level >= 1)
            {
                availableRole.Add(0);

                if (level >= 5)
                {
                    availableRole.Add(1);

                    if (level >= 10)
                    {
                        availableRole.Add(2);

                        if (level >= 20)
                        {
                            availableRole.Add(3);

                            if (level >= 30)
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
            if (level >= 5)
            {
                maxProduct++;

                if (level >= 20)
                {
                    maxProduct++;

                    if (level >= 50)
                    {
                        minProduct++;
                        if (level >= 90)
                        {
                            minProduct++;
                        }
                    }
                }
            }

            // Menghitung jumlah customer berdasarkan level
            int customerAmount;
            if (level <= 100) customerAmount = 10 + level / 5;
            else customerAmount = 30;

            // Menentukan 80% customer yang akan mengikuti rasio level, dan 20% customer yang akan diacak
            int randomizedRoleCustomer = (int)(customerAmount * 0.2);
            int fixedRoleCustomer = customerAmount - randomizedRoleCustomer;

            // Menentukan rasio dari 80% customer
            List<int> customerRoleRatio = new List<int>();
            if (level > 30)
            {
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.35));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.1));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.05));

                if (customerRoleRatio.Sum() < fixedRoleCustomer) customerRoleRatio[0]++;
            }
            else if (level > 20)
            {
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.4));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.1));
            }
            else if (level > 10)
            {
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.5));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
            }
            else if (level > 5)
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
                            availableRole[randomIndex],
                            availableIngredients,
                            merch
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
                    availableRole[Randomizer.Generate(availableRole.Count)],
                    availableIngredients,
                    merch
                    ));
            }

            return customerQueue;

            // Membuat customer sesuai dengan spesifikasi yang diberikan
            Customers GenerateRandomCustomer(int itemCount, CustomerType customerType, int chosenRole, IngredientsMap availableIngredients, Merchandise[] merch)
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

                        food.AddIngredient(availableIngredients.GetRandomIngredient(IngredientCategory.RICE));
                        food.AddIngredient(availableIngredients.GetRandomIngredient(IngredientCategory.PROTEIN));
                        food.AddIngredient(availableIngredients.GetRandomIngredient(IngredientCategory.VEGETABLES));
                        food.AddIngredient(availableIngredients.GetRandomIngredient(IngredientCategory.SIDE_DISHES));
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

                        int beverageOption = Randomizer.Generate(allowedBeverages);
                        BeverageType beverageType = BeverageType.WATER;
                        if (beverageOption == 1) beverageType = BeverageType.OCHA;
                        else if (beverageOption == 2) beverageType = BeverageType.SAKE;

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

                return customer;
            }

        }

    }
}
