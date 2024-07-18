using FoodWars.Values;
using System;
using System.Drawing;

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

            foreach (Items item in base.CompletedOrders)
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
            int totalSec = 50;

            totalSec += base.Orders.Count * 10;

            base.WaitingDuration = new Time(totalSec);
        }
    }
}
