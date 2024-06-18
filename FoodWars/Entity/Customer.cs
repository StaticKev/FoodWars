using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FoodWars
{
    public class Customers
    {
        // Add data member & parameter in constructor: Timer!

        private string name;
        private CustomerType type;
        private Role role;
        private List<Items> orders;
        private Image picture;

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
                    if (Role != Role.KING && orders != null) throw new ArgumentException("Only \'King\' allowed to change his orders!");
                    else if (value == null) throw new ArgumentException("Attempted to assign an empty list of \'Items\'!");
                    else orders = value;
                }
            }
        }
        public Image Picture
        {
            get => picture;
            set
            {
                if (value == null) throw new ArgumentException("No image specified!");
                else this.picture = value;
            }
        }

        public void AddOrder(Items item)
        {
            if (Orders.Count < 3) Orders.Add(item);
            else throw new ArgumentException("Maximum number of orders reached!");
        }

        public int CountTotalPrice()
        {
            int total = 0;
            foreach (Items item in this.Orders)
            {
                total += item.Price;
            }
            return total;
        }
    }
}