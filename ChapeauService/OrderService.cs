using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class OrderService
    {

        private OrderDao orderDb;
        private List<Order> orders;

        public OrderService()
        {
            this.orders = new List<Order>();
            this.orderDb = new OrderDao();
        }
        public List<Order> GetKitchenOrders()
        {
            orders = orderDb.GetAllOrders();
            return orders;
        }
    }
}
