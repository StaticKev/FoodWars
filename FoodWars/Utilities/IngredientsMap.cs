using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWars.Utilities
{
    public class IngredientsMap
    {
        #region Data Members
        private List<IngredientCategory> category;
        private List<List<Ingredients>> allIngredients;
        private List<int> allowedAmount;
        #endregion

        #region Constructors
        public IngredientsMap()
        {
            category = new List<IngredientCategory>();
            allIngredients = new List<List<Ingredients>>();
            allowedAmount = new List<int>();
        }
        #endregion

        #region Methods
        public void Add(IngredientCategory category, List<Ingredients> listOfIngredients, int allowedAmount)
        {
            bool categoryIsPresent = false;
            foreach (IngredientCategory c in this.category)
            {
                if (category == c)
                {
                    categoryIsPresent = true;
                    break;
                }
            }

            if (categoryIsPresent)
            {
                throw new ArgumentException("Category already exist!");
            }
            else
            {
                if (allowedAmount > listOfIngredients.Count)
                {
                    throw new ArgumentException("\'allowedAmount\' can\'t be higher than the amount of ingredients within the list!");
                }
                else
                {
                    this.category.Add(category);
                    this.allowedAmount.Add(allowedAmount);
                    this.allIngredients.Add(listOfIngredients);
                }
            }
        }

        public Ingredients GetRandomIngredient(IngredientCategory category)
        {
            Ingredients randomizedIngredient = null;
            for (int i = 0; i < this.category.Count; i++)
            {
                if (this.category[i] == category)
                {
                    int chosenIngredient = Randomizer.Generate(allowedAmount[i]);
                    return allIngredients[i][chosenIngredient];
                }
            }
            return randomizedIngredient;
        }

        public void ResetAllowedAmount()
        {
            for (int i = 0; i < allIngredients.Count; i++)
            {
                allowedAmount[i] = 1;
            }
        }
        #endregion
    }
}
