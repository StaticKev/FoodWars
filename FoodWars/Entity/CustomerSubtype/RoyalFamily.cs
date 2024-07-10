using FoodWars.Values;
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

            foreach (Items item in base.CompletedOrders)
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
            int totalSec = 10;

            totalSec += base.Orders.Count * 10;

            base.WaitingDuration = new Time(0, 0, totalSec);
        }
    }
}
