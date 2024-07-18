using FoodWars.Values;
using System.Drawing;

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

            foreach (Items item in base.CompletedOrders)
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
            int totalSec = 45;

            totalSec += base.Orders.Count * 10;

            base.WaitingDuration = new Time(totalSec);
        }
    }
}
