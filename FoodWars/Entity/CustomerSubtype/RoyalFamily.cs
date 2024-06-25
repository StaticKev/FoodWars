using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FoodWars.Entity.CustomerSubtype
{
    public class RoyalFamily: Customers
    {
        public RoyalFamily(CustomerType customerType, Image picture) : base(customerType, picture)
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

            total += (int)(total * 0.5);

            return total;
        }

        public override void GenerateName()
        {
            if (base.Type.Equals(CustomerType.MALE)) base.Name = "Tenno";
            else if (base.Type.Equals(CustomerType.FEMALE)) base.Name = "Kogo";
            else base.Name = "Kotaishi";
        }

        public override void SetTimer()
        {
            int totalSec = 40;

            totalSec -= (3 - base.Orders.Count) * 10;

            int sec = totalSec % 60;

            base.Timer = new Time(0, 0, sec);
        }
    }
}
