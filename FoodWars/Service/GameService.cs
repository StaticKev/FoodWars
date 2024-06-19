using FoodWars.Repository;
using FoodWars.Utilities;
using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FoodWars.Service
{
    internal class GameService
    {

        private PlayerRepo repo;

        List<Ingredients> riceIngredients;
        List<Ingredients> proteinIngredients;
        List<Ingredients> vegetableIngredients;
        List<Ingredients> sideDishesIngredients;

        IngredientsMap availableIngredients;
        Merchandise[] merch;
        CustomerType[] customerTypes;

        CustomerQueue customerQueue;
        Customers[] chairs;
        Time openDuration; // ============================== BELOM DIINSTANSIASI ==============================
        // Buat satu class untuk menghitung interval antar customer sesuai aturan yang berlaku

        public GameService(PlayerRepo repo)
        {
            this.repo = repo;

            // JANGAN LUPA ISI PICTURE!
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
                new Ingredients("Ebi Furai", 25_000, IngredientCategory.PROTEIN, null),
                new Ingredients("Tofu", 15_000, IngredientCategory.PROTEIN, null)
            };
            vegetableIngredients = new List<Ingredients>
            {
                new Ingredients("Pickled Radish", 5_000, IngredientCategory.VEGETABLES, null),
                new Ingredients("Pickled Cucumber", 5_000, IngredientCategory.VEGETABLES, null),
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

            merch = new Merchandise[]
            {
                new Merchandise("Keychain", 70_000, 2, null),
                new Merchandise("T-Shirt", 90_000, 3, null),
                new Merchandise("Action Figure", 120_000, 1, null)
            };
            customerTypes = new CustomerType[] {CustomerType.MALE, CustomerType.FEMALE, CustomerType.CHILD};

            chairs = new Customers[4];
        }

        public void StartGame(int level)
        {
            // Parameter ketiga itu batasan jenis yang tersedia pada level tertentu dihitung sesuai level!!
            // Kalau sudah level 100 keatas buat = count.
            int allowedRice = 1;
            int allowedProtein = 1;
            int allowedVegetable = 1;
            int allowedSideDishes = 1;

            // Pengecekan untuk batasan bahan
            

            availableIngredients.Add(IngredientCategory.RICE, riceIngredients, allowedRice);
            availableIngredients.Add(IngredientCategory.PROTEIN, proteinIngredients, allowedProtein);
            availableIngredients.Add(IngredientCategory.VEGETABLES, vegetableIngredients, allowedVegetable);
            availableIngredients.Add(IngredientCategory.SIDE_DISHES, sideDishesIngredients, allowedSideDishes);

            customerQueue = GenerateQueue(level);

            // Nyalakan timer
            
            // Mulai tempatkan pengunjung pada kursi yang tersedia

        }

        public CustomerQueue GenerateQueue(int level)
        {
            // Menentukan peran apa saja yang diizinkan muncul pada level tertentu
            List<Role> availableRole = new List<Role>();
            if (level >= 1)
            {
                availableRole.Add(Role.FOLK);

                if (level >= 5)
                {
                    availableRole.Add(Role.BUSINESS_MAN);

                    if (level >= 10)
                    {
                        availableRole.Add(Role.SAMURAI);

                        if (level >= 20)
                        {
                            availableRole.Add(Role.NOBLEMAN);

                            if (level >= 30)
                            {
                                availableRole.Add(Role.ROYAL_FAMILY);

                                if (level >= 40)
                                {
                                    availableRole.Add(Role.KING);
                                }
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

            // Queue yang akan dikembalikan
            CustomerQueue customerQueue = new CustomerQueue(customerAmount);

            // Menentukan rasio dari 80% customer
            List<int> customerRoleRatio = new List<int>();
            if (level > 40)
            {
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.15));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.1));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.05));

                if (customerRoleRatio.Sum() < fixedRoleCustomer) customerRoleRatio[0]++;
            }
            else if (level > 30)
            {
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.35));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.3));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.2));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.1));
                customerRoleRatio.Add((int)Math.Round(fixedRoleCustomer * 0.05));
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

            // Mengisi queue sesuai dengan aturan
            for (int i = fixedRoleCustomer; i > 0; i--)
            {
                while (true)
                {
                    int randomIndex = Randomizer.Generate(customerRoleRatio.Count);
                    if (customerRoleRatio[randomIndex] > 0)
                    {
                        customerQueue.EnQueue(GenerateRandomizedCustomer(
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
                customerQueue.EnQueue(GenerateRandomizedCustomer(
                    Randomizer.Generate(minProduct, maxProduct),
                    customerTypes[Randomizer.Generate(customerTypes.Length)],
                    availableRole[Randomizer.Generate(availableRole.Count)],
                    availableIngredients,
                    merch
                    ));
            }

            return customerQueue;

            // Membuat customer sesuai dengan spesifikasi yang diberikan
            Customers GenerateRandomizedCustomer(int itemCount, CustomerType type, Role role, IngredientsMap availableIngredients, Merchandise[] merch)
            {
                // JANGAN LUPA ISI PICTURE! (Yang ini pake pengecekan, bergantung pada type, dan role)
                Customers customer = new Customers(type, role, null);

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
                        bool isCold = false;
                        if (1 == Randomizer.Generate(1)) isCold = true;

                        int glassOption = Randomizer.Generate(3);
                        GlassSize glassSize = GlassSize.SMALL;
                        if (glassOption == 1) glassSize = GlassSize.MEDIUM;
                        else if (glassOption == 2) glassSize = GlassSize.LARGE;

                        // JANGAN LUPA ISI PICTURE! (Yang ini pake pengecekan, bergantung pada type, dan role)
                        Beverages beverage = new Beverages("", isCold, glassSize, null);

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
                            bool isAvailableToSell = false;
                            // Cek apakah ada merch yang dapat dijual (semua stok merch != 0), kalau tidak ada, availableItems--, i--, kembali ke awal.
                            foreach (Merchandise m in merch)
                            {
                                if (m.Stock > 0) isAvailableToSell = true;
                                totalMerchStock += m.Stock;
                            }

                            if (isAvailableToSell)
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
