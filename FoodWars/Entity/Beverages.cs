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
        private BeverageType type;
        private GlassSize size;
        #endregion

        #region Constructors
        public Beverages(string name, bool isCold, BeverageType beverageType, GlassSize size, Image picture) : base(name, picture)
        {
            this.IsCold = isCold;
            this.Size = size;
            this.BeverageType = beverageType;
            GenerateName();

            int price = 0;

            if (this.BeverageType == BeverageType.WATER) price += 5000;
            else if (this.BeverageType == BeverageType.OCHA) price += 7000;
            else price += 10000;

            if (this.IsCold) price += 1000;

            if (size.Equals(GlassSize.SMALL)) price += (int)(price * 0.3);
            else if (size.Equals(GlassSize.MEDIUM)) price += (int)(price * 0.6);
            else price += (int)(price * 0.8);
            base.Price = price;
        }
        #endregion

        #region Properties
        public bool IsCold
        {
            get => isCold;
            private set => isCold = value;
        }
        public BeverageType BeverageType
        {
            get => type;
            private set => type = value;
        }
        public GlassSize Size
        {
            get => size;
            private set => size = value;
        }
        #endregion

        #region Methods
        public override bool ContentEquals(Items item)
        {
            if (item.Name.Equals(this.Name)) return true;
            else return false;
        }

        // POTENTIALLY_BEING_MODIFIED_LATER
        private void GenerateName()
        {
            string name = "";

            if (this.IsCold) name += this.Size + " cold ";
            else name += this.Size + " hot ";

            name += this.BeverageType;

            base.Name = name;
        }
        #endregion
    }
}