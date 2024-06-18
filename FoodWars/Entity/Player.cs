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
        private int totalIncome;
        private Image picture;
        private Timer timer;
        #endregion

        #region Constructors
        public Players(string name, Image picture)
        {
            this.Name = name;
            this.TotalIncome = 0;
            this.Picture = picture;
            this.Timer = new Timer();
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
        public int TotalIncome
        {
            get => totalIncome;
            set
            {
                if (value < 0) throw new ArgumentException("Total income can't be negative!");
                else this.totalIncome = value;
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
        public Timer Timer
        {
            get => timer;
            private set => timer = value;
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