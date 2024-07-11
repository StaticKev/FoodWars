using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        public Ingredients GetIngredientsOfCategory(IngredientCategory category, int index)
        {
            List<Ingredients> listOfCategory = null;
            for (int i = 0; i < this.category.Count; i++)
            {
                if (this.category[i] == category)
                {
                    listOfCategory = allIngredients[i];
                    break;
                }
            }
            return listOfCategory[index];
        }

        public int GetAvailableIngredientOfCategory(IngredientCategory category)
        {
            int amount = 0;
            for (int i = 0; i < this.category.Count; i++)
            {
                if (this.category[i] == category)
                {
                    amount = allowedAmount[i];
                    break;
                }
            }
            return amount;
        }
        #endregion
    }
}
