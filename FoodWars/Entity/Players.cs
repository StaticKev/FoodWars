using System;
using System.Drawing;
using System.Drawing.Text;

namespace FoodWars
{
    [Serializable]
    public class Players
    {
        #region Data Members
        private string name;
        private int bestIncome;
        private long totalIncome;
        private int level;
        private Time bestTime;
        private Image picture;
        #endregion

        #region Constructors
        public Players(string name, Image picture)
        {
            // DEV MODE 
            /*            if (name.Substring(0, 3).Equals("DEV")) this.CurrentLevel = int.Parse(name.Substring(3));
                        else this.currentLevel = 1;*/

            this.Level = 1;
            this.Name = name;
            this.TotalIncome = 0;
            this.BestTime = new Time(0, 0, 0);
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
                else if (value != 0 && value < this.bestIncome) throw new ArgumentException("New best income must be greater than the previous one!");
                else this.bestIncome = value;
            }
        }
        public long TotalIncome
        {
            get => totalIncome;
            set
            {
                if (value < 0) throw new ArgumentException("Total income must be greater than 0!");
                else if (value != 0 && value < this.totalIncome) throw new ArgumentException("New total income must be greater than the previous one!");
                else this.totalIncome = value;
            }
        }
        public int Level
        {
            get => level;
            set
            {
                if (value <= 0) throw new ArgumentException("Current level must be greater than 0!");
                else if (value != 0 && value < this.level) throw new ArgumentException("Level can only be incremented!");
                else this.level = value;
            }
        }
        public Time BestTime
        {
            get => bestTime;
            set
            {
                if (value == null) throw new ArgumentException("No time specified!");
                else if (bestTime != null)
                {
                    if (value.IsLonger(this.bestTime))
                    {
                        throw new ArgumentException("New best time can't be longer than the previous one!");
                    }
                }
                else this.bestTime = value;
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