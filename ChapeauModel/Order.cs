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
        public OrderStatus Status { get; set; }
        public DateTime OrderTime { get; private set; }
        public Orderline OrderLineComment { get; private set; }
        public List<Orderline> orders { get;  set; }

        public int TafelNR { get; private set; }

        public List<Product> ProductList { get; set; }

        public Order(int OrderID, int TafelNR, string Status, Orderline OrderLineComment)
        {
            this.OrderID = OrderID;
            this.TafelNR = TafelNR;
            this.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Status); ;
            this.OrderLineComment = OrderLineComment;
            this.ProductList = new List<Product>();
            this.orders = new List<Orderline>();
        }
    }
}
