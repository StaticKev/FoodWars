using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodWars
{
    public abstract class Items
    {
        // Add data member & parameter in constructor: Image!

        #region Data Members
        private string name;
        private int price;
        #endregion

        #region Constructors
        public Items(string name)
        {
            this.name = name;
        }
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set
            {
                if (this.Name != "") throw new ArgumentException("Name already assigned!");
                else
                {
                    if (value == "") throw new ArgumentException("Name can't be empty!");
                    else this.name = value;
                }
            }
        }
        public int Price
        {
            get => price;
            set
            {
                if (this.price != 0) throw new ArgumentException("Price already assigned!");
                else
                {
                    if (value <= 0) throw new ArgumentException("Price must be greater than 0!");
                    else this.price = value;
                }
            }
        }
        #endregion
    }
}