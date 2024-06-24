using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace FoodWars
{
    public class Customers
    {

        private string name;
        private CustomerType type;
        private Role role;
        private List<Items> orders;
        private Image picture;
        private Time timer;

        public Customers(CustomerType customerType, Role role, Image picture)
        {
            this.Type = customerType;
            this.Role = role;
            this.Orders = new List<Items>();
            this.Picture = picture;
        }

        public string Name { get => name; set => name = value; }
        public CustomerType Type { get => type; private set => type = value; }
        public Role Role { get => role; private set => role = value; }
        public List<Items> Orders
        {
            get => orders;
            set
            {
                if (value == null || (value.Count == 0 && this.orders != null))
                {
                    throw new ArgumentException("No orders specified!");
                }
                else
                {
                    if (value == null || value.Count == 0) throw new ArgumentException("Attempted to assign an empty list of \'Items\'!");
                    else orders = value;
                }
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
        private Time Timer
        {
            get => timer;
            set
            {
                if (timer == null) throw new NullReferenceException();
                else this.timer = value;
            }
        }

        public void AddOrder(Items item)
        {
            if (Orders.Count < 3) Orders.Add(item);
            else throw new ArgumentException("Maximum number of orders reached!");
        }

        public void SetTimer()
        {
            int totalSec = 0;

            if (this.Role == Role.FOLK) totalSec = 60;
            else if (this.Role == Role.BUSINESS_MAN) totalSec = 55;
            else if (this.Role == Role.SAMURAI) totalSec = 50;
            else if (this.Role == Role.NOBLE) totalSec = 45;
            else totalSec = 40;

            totalSec -= (3 - orders.Count) * 10;

            int sec = totalSec % 60;
            int min = totalSec / 60;

            this.Timer = new Time(0, min, sec);
        }

        public void UpdateTimer()
        {
            this.Timer.Add(-1);
        }

        public int CountTotalPrice()
        {
            int total = 0;
            foreach (Items item in this.Orders)
            {
                total += item.Price;
            }
            
            if (this.Role == Role.BUSINESS_MAN) total += (int) (total * 0.1);
            else if (this.Role == Role.SAMURAI) total += (int)(total * 0.2);
            else if (this.Role == Role.NOBLE) total += (int)(total * 0.3);
            else if(this.Role == Role.ROYAL_FAMILY) total += (int)(total * 0.5);

            return total;
        }
    }
}