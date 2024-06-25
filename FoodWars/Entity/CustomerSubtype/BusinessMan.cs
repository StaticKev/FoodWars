using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace FoodWars.Entity.CustomerSubtype
{
    public class BusinessMan: Customers
    {
        public BusinessMan(CustomerType customerType, Image picture) : base(customerType, picture)
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

            total += (int)(total * 0.1);

            return total;
        }

        public override void GenerateName()
        {
            if (base.Type.Equals(CustomerType.MALE)) base.Name = "Business Man";
            else if (base.Type.Equals(CustomerType.FEMALE)) base.Name = "Business Woman";
            else base.Name = "Young Entrepreneur";
        }

        public override void SetTimer()
        {
            int totalSec = 55;

            totalSec -= (3 - base.Orders.Count) * 10;

            int sec = totalSec % 60;

            base.Timer = new Time(0, 0, sec);
        }
    }
}
