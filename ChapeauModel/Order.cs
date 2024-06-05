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
        public Orderline OrderLineComment { get; private set; }
        public int TafelNR { get; private set; }
        public OrderStatus barStatus { get; set; }
        public OrderStatus kitchenStatus { get; set; }

        public List<Product> ProductList { get; set; }
        public Order(int OrderID, int TafelNR, string Status, Orderline OrderLineComment)
        {
            this.OrderID = OrderID;
            this.TafelNR = TafelNR;
            this.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Status); ;
            this.OrderLineComment = OrderLineComment;
            this.ProductList = new List<Product>();
        }

        public Order(int OrderID, int TafelNR, string Status, Orderline OrderLineComment, DateTime orderTime, byte barStatus, byte kitchenStatus):this(OrderID, TafelNR, Status, OrderLineComment) 
        { 
            this.OrderTime = orderTime;
            setBarStatus(barStatus);
            setKitchenStatus(kitchenStatus);
        }

        public void setBarStatus(byte barStatus)
        {
            if (barStatus == 1) { this.barStatus = OrderStatus.Ready; }
            else { this.barStatus = OrderStatus.Pending;}
        }
        public void setKitchenStatus(byte kitchenStatus)
        {
            if (kitchenStatus == 1) { this.kitchenStatus = OrderStatus.Ready; }
            else { this.kitchenStatus = OrderStatus.Pending; }
        }


    }
}
