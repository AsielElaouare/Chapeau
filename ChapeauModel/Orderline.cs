﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Orderline
    {

        public int OrderID { get; private set; }
        public Order order { get; private set; }
        public int billnumber { get; set; }
        public int Quantity { get; set; }
        public string Commentary { get; private set; }
        public int ArticleID { get; private set; }
        public Product product { get; private set; }

        public Orderline(Order order, int quantity, Product product, string Commentary)
        {
            this.order = order;
            this.Quantity = quantity;
            this.product = product;
            this.Commentary = Commentary;
        }

        public Orderline(int orderID, int aantal, string opmerking)
        {
            OrderID = orderID;
            Quantity = aantal;
            Commentary = opmerking;
        }
        public Orderline(int aantal, string opmerking, int artikelID)
        {
            Quantity = aantal;
            Commentary = opmerking;
            ArticleID = artikelID;
        }

        public Orderline(int billnumber, int aantal, Product product)
        {
            this.billnumber = billnumber;
            this.Quantity = aantal;
            this.product = product;
            // this.Is_Paid = Is_Paid;
        }

        public void IncreaseQuantity()
        {
            Quantity++;
        }

        public void DecreaseQuantity()
        {
            Quantity--;
        }
        public void SetOrderID(int orderID)
        {
            OrderID = orderID;
        }
        public void AddComment(string comment)
        {
            Commentary = comment;
        }
    }
}
