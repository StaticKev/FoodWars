using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FoodWars
{
    public class Players
    {
        #region Data Members
        private string name;
        private int bestIncome;
        private long totalIncome;
        private int bestLevel;
        private Image picture;
        #endregion

        #region Constructors
        public Players(string name, Image picture)
        {
            this.Name = name;
            this.TotalIncome = 0;
            this.Picture = picture;
        }
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            private set
            {
                if (value == "") throw new ArgumentException("Name can't be empty!");
                else this.name = value;
            }
        }
        public int BestIncome
        {
            get => bestIncome;
            set
            {
                if (value <= 0) throw new ArgumentException("Best income must be greater than 0!");
                else this.bestIncome = value;
            }
        }
        public long TotalIncome
        {
            get => totalIncome;
            set
            {
                if (value < 0) throw new ArgumentException("Total income can't be negative!");
                else this.totalIncome = value;
            }
        }
        public int BestLevel
        {
            get => bestLevel;
            set
            {
                if (value <= 0) throw new ArgumentException("Best level must be greater than 0!");
                else this.bestLevel = value;
            }
        }
        public Image Picture
        {
            get => picture;
            private set
            {
                if (value == null) throw new ArgumentException("No image specified!");
                else this.picture = value;
            }
        }
        #endregion

        #region Methods
        public void AddIncome(int income)
        {
            if (income < 0) throw new ArgumentException("Income can't be negative!");
            else this.TotalIncome += income;
        }
        #endregion
    }
}