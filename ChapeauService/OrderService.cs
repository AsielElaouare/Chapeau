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

        OrderDao orderDb = new OrderDao();
        List<Order> orders = new List<Order>();
        public void GetKitchenOrders()
        {
            orders = orderDb.GetAllOrders();
        }
    }
}
