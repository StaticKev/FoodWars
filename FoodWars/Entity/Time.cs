using System;

namespace FoodWars
{
    [Serializable]
    public class Time
    {
        #region Data Members 
        private int hour;
        private int minute;
        private int second;
        #endregion

        #region Constructors
        public Time(int hour, int minute, int second)
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }
        #endregion
        
        #region Properties
        private int Hour
        {
            get => hour;
            set
            {
                if (value < 0 && value > 23) throw new ArgumentException("Hour must be 0-23 in range!");
                else this.hour = value;
            }
        }
        private int Minute
        {
            get => minute;
            set
            {
                if (value < 0 && value > 59) throw new ArgumentException("Minute must be 0-59 in range!");
                else this.minute = value;
            }
        }
        private int Second
        {
            get => second;
            set
            {
                if (value < 0 && value > 59) throw new ArgumentException("Second must be 0-59 in range!");
                else this.second = value;
            }
        }
        #endregion 

        #region Methods
        public void Add(int addSec)
        {
            int sec = this.Hour * 3600 + this.Minute * 60 + this.Second;
            if (!(sec + addSec < 0))
            {
                sec += addSec;
            }
            this.Hour = sec / 3600;
            this.Minute = sec % 3600 / 60;
            this.Second = sec % 60;
        }

        public int GetDurationInSecond()
        {
            return this.Hour * 3600 + this.Minute * 60 + this.Second;
        }

        public bool IsLonger(Time time)
        {
            if (this.GetDurationInSecond() > time.GetDurationInSecond()) return true;
            else return false;
        }

        public string DurationToString()
        {
            string data = this.Minute.ToString().PadLeft(2, '0') + " : " +
                this.Second.ToString().PadLeft(2, '0');

            return data;
        }
        #endregion 
    }
}