using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodWars
{
    public class Foods : Items
    {
        // Add parameter on constructor: Image!

        #region Data Members
        private List<Ingredients> ingredients;
        #endregion

        #region Constructors
        public Foods(string name) : base(name)
        {
            this.Ingredients = new List<Ingredients>();
        }
        #endregion

        #region Properties
        public List<Ingredients> Ingredients
        {
            get => ingredients;
            private set
            {
                if (value == null) throw new ArgumentException("No ingredients found!");
                else this.ingredients = value;
            }
        }
        #endregion

        #region Methods
        public void AddIngredient(Ingredients ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentException("Invalid argument for \'ingredient\'!");
            }

            // Cek apakah sudah ada bahan dengan tipe tersebut pada list, jika belum ada tambahkan.
            bool isPresent = false;
            foreach (Ingredients ingredientPresent in this.Ingredients)
            {
                if (ingredient.Category == ingredientPresent.Category)
                {
                    isPresent = true;
                }
            }

            if (!isPresent)
            {
                this.Ingredients.Add(ingredient);
                if (this.Ingredients.Count == 4)
                {
                    GenerateName();
                    int price = 0;
                    foreach (Ingredients i in this.Ingredients)
                    {
                        price += i.Price;
                    }
                    base.Price = price;
                }
            }
        }

        // POTENTIALLY_BEING_MODIFIED_LATER
        private void GenerateName()
        {
            string name = "";

            name += this.Ingredients[0].Name + " " + this.Ingredients[1].Name + " Bento with " + this.Ingredients[2].Name + " & " + this.Ingredients[3].Name;

            base.Name = name;
        }
        #endregion
    }
}