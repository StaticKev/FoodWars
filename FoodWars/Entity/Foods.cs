using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FoodWars
{
    public class Foods : Items
    {
        // Add parameter on constructor: Image!

        #region Data Members
        private List<Ingredients> ingredients;
        #endregion

        #region Constructors
        public Foods(string name, Image picture) : base(name, picture)
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
        public override bool ContentEquals(Items item)
        {
            if (item.Name.Equals(this.Name)) return true;
            else return false;
        }

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
            else
            {
                // Ini di catch ketika nambahkan ingredient, trus panggil method SwitchIngredient
                throw new ArgumentException("Ingredient already present in the menu!");
            }
        }

        // Method yang dipanggil di meja chef, mengganti ingredient dari food yang sedang disiapkan
        public void SwitchIngredient(Ingredients ingredient) 
        {
            // Cek dulu apakah ingredient bertipe tersebut ada, jika ada gantikan, jika tidak tambahkan
            bool categoryIsNotPresent = true;
            foreach (Ingredients ing in this.Ingredients)
            {
                if (ingredient.Category == ing.Category)
                {
                    this.Ingredients.Remove(ing);
                    this.Ingredients.Add(ingredient);
                    GenerateName();
                    categoryIsNotPresent = false;
                    break;
                }
            }

            if (Ingredients.Count < 4 && categoryIsNotPresent)
            {
                Ingredients.Add(ingredient);
                GenerateName();
            }
        }

        private void GenerateName()
        {
            string name = "";

            string rice = "";
            string protein = "";
            string veggie = "";
            string sideDish = "";

            foreach (Ingredients ingredient in Ingredients)
            {
                if (ingredient.Category == IngredientCategory.RICE) rice = ingredient.Name;
                else if (ingredient.Category == IngredientCategory.PROTEIN) protein = ingredient.Name;
                else if (ingredient.Category == IngredientCategory.VEGETABLES) veggie = ingredient.Name;
                else sideDish = ingredient.Name;
            } 

            base.Name = rice + protein + veggie + sideDish;
        }
        #endregion
    }
}