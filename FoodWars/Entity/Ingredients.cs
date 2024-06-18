using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodWars
{
    public class Ingredients
    {
        // Add data member & parameter in constructor: Image!

        #region Data Members
        private string name;
        private int price;
        private IngredientCategory category;
        #endregion

        #region Constructors
        public Ingredients(string name, int price, IngredientCategory category)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            private set
            {
                if (value == "") throw new ArgumentException("Name can't be empty!");
                else this.name = value;
            }
        }
        public int Price
        {
            get => price;
            private set
            {
                if (value <= 0) throw new ArgumentException("Price must be greater than 0!");
                else this.price = value;
            }
        }
        public IngredientCategory Category
        {
            get => category;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Category can't be null!");
                }
                else
                {
                    this.category = value;
                }
            }
        }
        #endregion

    }
}