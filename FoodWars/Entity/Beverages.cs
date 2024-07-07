using FoodWars.Values;
using System.Drawing;

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

            if (this.BeverageType == BeverageType.WATER) price += 50;
            else if (this.BeverageType == BeverageType.OCHA) price += 70;
            else price += 100;

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

        public void SwitchVariety(bool isCold)
        {
            if (IsCold != isCold)
            {
                IsCold = !IsCold;
                SwitchImage();
            }
        }

        public void SwitchVariety(GlassSize glassSize)
        {
            if (Size != glassSize)
            {
                Size = glassSize;
                SwitchImage();
            }
        }

        public void SwitchVariety(BeverageType beverageType)
        {
            if (BeverageType != beverageType)
            {
                BeverageType = beverageType;
                SwitchImage();
            }
        }

        private void SwitchImage()
        {
            // Mengganti image sesuai dengan kombinasi menu
        }

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