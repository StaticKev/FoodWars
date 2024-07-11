using System;
using System.Drawing;

namespace FoodWars
{
    public abstract class Items
    {
        // Add data member & parameter in constructor: Image!

        #region Data Members
        private string name;
        private int price;
        private Image picture;
        #endregion

        #region Constructors
        public Items(string name, Image picture)
        {
            this.Name = name;
            this.Picture = picture;
        }
        public Items(string name, int price, Image picture)
        {
            this.Name = name;
            this.Price = price;
            this.Picture = picture;
        }
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set
            {
                this.name = value;
            }
        }
        public int Price
        {
            get => price;
            set
            {
                if (value <= 0) throw new ArgumentException("Price must be greater than 0!");
                else this.price = value;
            }
        }
        public Image Picture
        {
            get => picture;
            set => picture = value;
        }
        #endregion

        #region Methods
        public abstract bool ContentEquals(Items item);
        #endregion
    }
}