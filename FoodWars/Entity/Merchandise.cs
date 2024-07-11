using System;
using System.Drawing;

namespace FoodWars
{
    public class Merchandise : Items
    {
        // Add create data member and parameter on constructor: Image!

        #region Data Members
        private int stock;
        #endregion

        #region Constructors
        public Merchandise(string name, int price, int stock, Image picture) : base(name, price, picture)
        {
            this.Stock = stock;
        }
        #endregion

        #region Properties
        public int Stock
        {
            get => stock;
            set
            {
                if (value < 0) throw new ArgumentException("Stock must be greater or equals 0!");
                else this.stock = value;
            }
        }
        #endregion

        #region Methods
        public override bool ContentEquals(Items item)
        {
            if (item.Name.Equals(this.Name)) return true;
            else return false;
        }
        #endregion
    }
}