using System;
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
        public int Quantity { get; set; }
        public string Commentary { get; private set; }
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
        public Orderline(int aantal, string opmerking, Product product)
        {
            Quantity = aantal;
            Commentary = opmerking;
            this.product = product;
        }

        public Orderline( int aantal, Product product)
        {
           
            this.Quantity = aantal;
            this.product = product;
         
        }

        public void IncreaseQuantity()
        {
            Quantity++;
        }

        public void DecreaseQuantity()
        {
            Quantity--;
        }
       
        public void AddComment(string comment)
        {
            Commentary = comment;
        }
    }
}
