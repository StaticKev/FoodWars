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
            base.BaseWaitingDuration = 45;
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
    }
}
