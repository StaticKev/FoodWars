using FoodWars.Values;
using System.Drawing;

namespace FoodWars.Entity.CustomerSubtype
{
    public class Nobleman: Customers
    {
        public Nobleman(CustomerType customerType, Image picture) : base(customerType, picture)
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

            total += (int)(total * 0.3);

            return total;
        }

        public override void GenerateName()
        {
            if (base.Type.Equals(CustomerType.MALE)) base.Name = "Daimyo";
            else if (base.Type.Equals(CustomerType.FEMALE)) base.Name = "Seishitsu";
            else base.Name = "Koukeisha";
        }

        public override void SetTimer()
        {
            int totalSec = 15;

            totalSec += base.Orders.Count * 10;

            base.WaitingDuration = new Time(0, 0, totalSec);
        }
    }
}
