using FoodWars.Properties;
using FoodWars.Values;
using System.Drawing;

namespace FoodWars
{
    public class Beverages : Items
    {

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

            base.Price = CountPrice();
        }

        // Yang ini namanya dikosongi, picturenya diganti gelas
        public Beverages(string name, Image picture, GlassSize size) : base(name, picture) 
        {
            this.isCold = false;
            this.Size = size;
            this.BeverageType = BeverageType.UNASSIGNED;
            SwitchVariety(size);
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

        // SwitchVariety dipanggil ketika player menekan salah satu komponen Beverage
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
            // Menghitung kembali harga
            base.Price = CountPrice();

            // Mengganti image sesuai dengan kombinasi menu
            if (BeverageType == BeverageType.UNASSIGNED)
            {
                if (Size == GlassSize.SMALL) base.Picture = Resources.glass_S; // Tugaskan gambar gelas kecil kosong
                else if (Size == GlassSize.MEDIUM) base.Picture = Resources.glass_M; // Tugaskan gambar gelas sedang kosong
                else base.Picture = Resources.glass_L; // Tugaskan gamber gelas besar kosong
            }
            else if (BeverageType == BeverageType.WATER)
            {
                if (isCold)
                {
                    if (Size == GlassSize.SMALL) base.Picture = Resources.Bev_water_S_Cold; // Air kecil dingin
                    else if (Size == GlassSize.MEDIUM) base.Picture = Resources.Bev_water_M_Cold; // Air sedang dingin
                    else base.Picture = Resources.Bev_water_L_Cold; // Air besar dingin
                }
                else
                {
                    if (Size == GlassSize.SMALL) base.Picture = Resources.Bev_water_S; // Air kecil
                    else if (Size == GlassSize.MEDIUM) base.Picture = Resources.Bev_water_M; // Air sedang
                    else base.Picture = Resources.Bev_water_L; // Air besar
                }
            }
            else if (BeverageType == BeverageType.OCHA)
            {
                if (isCold)
                {
                    if (Size == GlassSize.SMALL) base.Picture = Resources.Bev_ocha_S_Cold; // Ocha kecil dingin
                    else if (Size == GlassSize.MEDIUM) base.Picture = Resources.Bev_ocha_M_Cold; // Ocha sedang dingin
                    else base.Picture = Resources.Bev_ocha_L_Cold; // Ocha besar dingin
                }
                else
                {
                    if (Size == GlassSize.SMALL) base.Picture = Resources.Bev_ocha_S; // Ocha kecil
                    else if (Size == GlassSize.MEDIUM) base.Picture = Resources.Bev_ocha_M; // Ocha sedang
                    else base.Picture = Resources.Bev_ocha_L; // Ocha besar
                }
            }
            else 
            {
                if (isCold)
                {
                    if (Size == GlassSize.SMALL) base.Picture = Resources.Bev_sake_S_Cold; // Sake kecil dingin
                    else if (Size == GlassSize.MEDIUM) base.Picture = Resources.Bev_sake_M_Cold; // Sake sedang dingin
                    else base.Picture = Resources.Bev_sake_L_Cold; // Sake besar dingin
                }
                else
                {
                    if (Size == GlassSize.SMALL) base.Picture = Resources.Bev_sake_S; // Sake kecil
                    else if (Size == GlassSize.MEDIUM) base.Picture = Resources.Bev_sake_M; // Sake sedang
                    else base.Picture = Resources.Bev_sake_L; // Sake besar
                }
            }
        }

        private void GenerateName()
        {
            string name = "";

            if (this.IsCold) name += this.Size + " cold ";
            else name += this.Size + " hot ";

            name += this.BeverageType;

            base.Name = name;
        }

        private int CountPrice()
        {
            int price = 0;

            if (this.BeverageType == BeverageType.WATER) price += 50;
            else if (this.BeverageType == BeverageType.OCHA) price += 70;
            else price += 100;

            if (this.IsCold) price += 10;

            if (size.Equals(GlassSize.SMALL)) price += (int)(price * 0.3);
            else if (size.Equals(GlassSize.MEDIUM)) price += (int)(price * 0.6);
            else price += (int)(price * 0.8);
            base.Price = price;

            return price;
        }
        #endregion
    }
}