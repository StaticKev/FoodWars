﻿using FoodWars.Values;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FoodWars
{
    public abstract class Customers
    {
        #region Data Members
        private string name;
        private CustomerType type;
        private List<Items> orders;
        private List<Items> completedOrders;
        private Image picture;
        private Time waitingDuration;
        #endregion

        #region Constructors
        public Customers(CustomerType customerType, Image picture)
        {
            this.Type = customerType;
            this.Orders = new List<Items>();
            this.CompletedOrders = new List<Items>();
            this.Picture = picture;
            this.WaitingDuration = new Time(0, 0, 0);
        }
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public CustomerType Type { get => type; private set => type = value; }
        public List<Items> Orders
        {
            get => orders;
            private set
            {
                if (value == null || (value.Count == 0 && this.orders != null))
                {
                    throw new ArgumentException("No orders specified!");
                }
                else
                {
                    if (value == null) throw new ArgumentException("Attempted to assign an empty list of \'Items\'!");
                    else orders = value;
                }
            }
        }
        protected List<Items> CompletedOrders
        {
            get => completedOrders;
            set
            {
                if (value == null) throw new ArgumentException("No orders specified!");
                else completedOrders = value;
            }
        }
        public Image Picture
        {
            get => picture;
            private set
            {
                if (value == null) throw new ArgumentException("No image specified!");
                else this.picture = value;
            }
        }
        public Time WaitingDuration
        {
            get => waitingDuration;
            set
            {
                if (value == null) throw new NullReferenceException();
                else this.waitingDuration = value;
            }
        }
        #endregion

        #region Methods
        public abstract void GenerateName();
        public void AddOrder(Items item)
        {
            if (Orders.Count < 3) Orders.Add(item);
            else throw new ArgumentException("Maximum number of orders reached!");
        }
        public abstract void SetTimer();
        public void MarkCompleteOrder(Items order)
        {
            Orders.Remove(order);
            CompletedOrders.Add(order);
        }
        public abstract int CountTotalPrice();
        #endregion
    }
}