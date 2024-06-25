using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWars.Entity.CustomerRole
{
    public class Folk: Customers
    {
        public Folk(CustomerType customerType, Image picture) : base(customerType, picture)
        {
            GenerateName();
        }

        public override int CountTotalPrice()
        {
            int total = 0;

            foreach (Items item in base.Orders)
            {
                total += item.Price;
            }

            return total;
        }

        public override void GenerateName()
        {
            base.Name = base.Type.ToString() + " Folk";
        }

        public override void SetTimer()
        {
            int totalSec = 60;

            totalSec -= (3 - base.Orders.Count) * 10;

            int sec = totalSec % 60;
            int min = totalSec / 60;

            base.Timer = new Time(0, min, sec);
        }
    }
}
