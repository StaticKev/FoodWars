using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Timers;

namespace FoodWars
{
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
        public int Hour
        {
            get => hour;
            set
            {
                if (value < 0 && value > 23) throw new ArgumentException("Hour must be 0-23 in range!");
                else this.hour = value;
            }
        }
        public int Minute
        {
            get => minute;
            set
            {
                if (value < 0 && value > 59) throw new ArgumentException("Minute must be 0-59 in range!");
                else this.minute = value;
            }
        }
        public int Second
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
            int sec = this.Hour * 3600 + this.Minute * 60 + this.Second + addSec;
            this.Hour = sec / 3600;
            this.Minute = sec % 3600 / 60;
            this.Second = sec % 60;
        }

        public string Convert()
        {
            string data = this.Minute.ToString().PadLeft(2, '0') + " : " +
                this.Second.ToString().PadLeft(2, '0');

            return data;
        }
        #endregion 
    }
}