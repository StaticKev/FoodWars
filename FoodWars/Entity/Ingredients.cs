using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoodWars
{
    public class Ingredients
    {
        // Add data member & parameter in constructor: Image!

        #region Data Members
        private string name;
        private int price;
        private IngredientCategory category;
        private Image picture;
        #endregion

        #region Constructors

        public Ingredients(string name, int price, IngredientCategory category, Image picture)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.Picture = picture;
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
            private set => this.category = value;
        }
        public Image Picture 
        {
            get => picture;
            set
            {
                this.picture = value; // TEST_PURPOSE
                /*                if (value == null) throw new ArgumentException("No image specified!");
                                else this.picture = value;*/
            }
        }
        #endregion

    }
}