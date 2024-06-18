using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FoodWars
{
    public class Beverages : Items
    {
        // Add parameter on constructor: Image!

        #region Data Members
        private bool isCold;
        private GlassSize size;
        #endregion

        #region Constructors
        public Beverages(string name, bool isCold, GlassSize size, Image picture) : base(name, picture)
        {
            this.IsCold = isCold;
            this.Size = size;
            GenerateName();

            int price = 5000;
            if (this.IsCold) price += 1000;

            if (size.Equals(GlassSize.SMALL)) price += 2000;
            else if (size.Equals(GlassSize.MEDIUM)) price += 3000;
            else price += 4000;
            base.Price = price;
        }
        #endregion

        #region Properties
        public bool IsCold
        {
            get => isCold;
            private set => isCold = value;
        }
        public GlassSize Size
        {
            get => size;
            private set => size = value;
        }
        #endregion

        #region Methods
        // POTENTIALLY_BEING_MODIFIED_LATER
        private void GenerateName()
        {
            string name = "";

            if (this.IsCold) name += this.Size + " cold ocha";
            else name += this.Size + " hot ocha";

            base.Name = name;
        }
        #endregion
    }
}