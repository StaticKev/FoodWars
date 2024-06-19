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

        List<Ingredients> riceIngredients = new List<Ingredients>
        {
            new Ingredients("Regular Rice", 5_000, IngredientCategory.RICE),
            new Ingredients("Brown Rice", 10_000, IngredientCategory.RICE),
        };
        List<Ingredients> proteinIngredients = new List<Ingredients>
        {
            new Ingredients("Tonkatsu", 30_000, IngredientCategory.PROTEIN),
            new Ingredients("Chicken Katsu", 15_000, IngredientCategory.PROTEIN),
            new Ingredients("Ebi Furai", 20_000, IngredientCategory.PROTEIN)
        };
        List<Ingredients> vegetableIngredients = new List<Ingredients>
        {
            new Ingredients("Pickled Radish", 5_000, IngredientCategory.VEGETABLES),
            new Ingredients("Pickled Cucumber", 5_000, IngredientCategory.VEGETABLES)
        };
        List<Ingredients> sideDishesIngredients = new List<Ingredients>
        {
            new Ingredients("Sunomono", 7_000, IngredientCategory.SIDE_DISHES),
            new Ingredients("Nimono", 8_000, IngredientCategory.SIDE_DISHES),
            new Ingredients("Korokke", 10_000, IngredientCategory.SIDE_DISHES)
        };

        IngredientsMap availableIngredients = new IngredientsMap();
        availableIngredients.Add(IngredientCategory.RICE, riceIngredients, riceIngredients.Count);
        availableIngredients.Add(IngredientCategory.PROTEIN, proteinIngredients, proteinIngredients.Count);
        availableIngredients.Add(IngredientCategory.VEGETABLES, vegetableIngredients, vegetableIngredients.Count);
        availableIngredients.Add(IngredientCategory.SIDE_DISHES, sideDishesIngredients, sideDishesIngredients.Count);

        public GameService(PlayerRepo repo)
        {
            this.repo = repo;
        }

        public void StartGame(int level)
        {
            
        }



    }
}
