using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

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
            if (stock <= 0) throw new ArgumentException("Initial stock must be greater than 0!");
            else this.Stock = stock;
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
    }
}