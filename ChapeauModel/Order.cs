using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderID { get; private set; }
        public int RekeningNR { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime OrderTime { get; private set; }
        public Orderline OrderLine { get; private set; }
        public int TafelNR { get; private set; }
        public OrderStatus barStatus { get; set; }
        public OrderStatus kitchenStatus { get; set; }

        public List<Orderline> orderlines { get; private set; }
        public List<Product> ProductList { get; set; }


        //for get orders constructor 

        public Order(int OrderID, int TafelNR, string Status, DateTime orderTime)
        {
            this.OrderID = OrderID;
            this.TafelNR = TafelNR;
            this.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Status);
            this.OrderLine = OrderLine;
            this.OrderTime = orderTime;
            this.orderlines = new List<Orderline>();
        }
        public Order(int OrderID, int TafelNR, string Status, Orderline orderline, DateTime orderTime)
        {
            this.OrderID = OrderID;
            this.TafelNR = TafelNR;
            this.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Status);
            this.OrderLine = OrderLine;
            this.OrderTime = orderTime;
            this.OrderLine = orderline;
            this.ProductList = new List<Product>();
        }

        public Order(int rekeningNR, int orderID, int tafelNR, OrderStatus status)
        {
            this.RekeningNR = rekeningNR;
            this.OrderID = orderID;
            this.TafelNR = tafelNR;
            this.Status = status;

            this.orderlines = new List<Orderline>();
        }

        public void setBarStatus(byte barStatus)
        {
            if (barStatus == 1) { this.barStatus = OrderStatus.Ready; }
            else if (barStatus == 2 || !CheckBarOrder()) { this.barStatus = OrderStatus.Delivered; }
            else { this.barStatus = OrderStatus.Pending; }
        }
        public void setKitchenStatus(byte kitchenStatus)
        {
            if (kitchenStatus == 1) { this.kitchenStatus = OrderStatus.Ready; }
            else if (kitchenStatus == 2 || !CheckKitchenOrder()) { this.kitchenStatus = OrderStatus.Delivered; }
            else { this.kitchenStatus = OrderStatus.Pending; }
        }

        private bool CheckKitchenOrder()
        {
            bool hasOrdered = false;
            foreach (Product product in ProductList)
            {
                if (product.Category == ProductCategorie.Voorgerechten || product.Category == ProductCategorie.Hoofdgerechten || product.Category == ProductCategorie.Tussengerechten || product.Category == ProductCategorie.Nagerechten) { hasOrdered = true; break; }
            }
            return hasOrdered;
        }
        private bool CheckBarOrder()
        {
            bool hasOrdered = false;
            foreach (Product product in ProductList)
            {
                if (product.Category == ProductCategorie.Bier || product.Category == ProductCategorie.Wijn || product.Category == ProductCategorie.Gedistilleerd || product.Category == ProductCategorie.KoffieThee || product.Category == ProductCategorie.Frisdrank) { hasOrdered = true; break; }
            }
            return hasOrdered;
        }
    }
}
