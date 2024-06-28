using FoodWars.Values;
using System.Drawing;

namespace FoodWars.Entity.CustomerSubtype
{
    public class Samurai: Customers
    {
        public Samurai(CustomerType customerType, Image picture) : base(customerType, picture)
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

            total += (int)(total * 0.2);

            return total;
        }

        public override void GenerateName()
        {
            if (base.Type.Equals(CustomerType.MALE)) base.Name = "Samurai";
            else if (base.Type.Equals(CustomerType.FEMALE)) base.Name = "Onna-Bugeisha";
            else base.Name = "Young Samurai";
        }

        public override void SetTimer()
        {
            int totalSec = 50;

            totalSec -= (3 - base.Orders.Count) * 10;

            int sec = totalSec % 60;

            base.Timer = new Time(0, 0, sec);
        }
    }
}
