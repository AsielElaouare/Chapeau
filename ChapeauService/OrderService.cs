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
        private OrderDao orderdb;

        public OrderService()
        {
            orderdb = new OrderDao();
        }
        public void StoreOrder(DateTime timeOfOrder, int selectedtable,List<Orderline> orders)
        {
             orderdb.StoreNewOrder(timeOfOrder, selectedtable, orders);
        }
        public List<Order> GetAllPendingOrdersForBar()
        {
            List<Order> orders;
            return orders = orderdb.GetOrdersForBar();
        }

        public List<Order> GetPendingOrdersForKitchen()
        {
            List<Order> orders;
            return orders = orderdb.GetOrdersForKitchen();
        }

        public void UpdateToReadyOrders(int orederID, OrderStatus orderStatus)
        {
            orderdb.CompleteOrder(orederID, orderStatus);
        }
        public void UpdateToPreparingOrders(int orederID, OrderStatus orderStatus)
        {
            orderdb.StartOrder(orederID, orderStatus);
        }

        public void UpdateToRemakingOrder(int orederID, OrderStatus orderStatus)
        {
            orderdb.StartOrder(orederID, orderStatus);
        }

      
        public List<Order> GetReadyOrdersForKitchen(DateOnly dateToday)
        {
            List<Order> orders;
            return orders = orderdb.GetPreviousOrdersForKitchen(dateToday);
        }
        public List<Order> GetOrdersByTable(Tafel table)
        {
            List<Order> orders;
            return orders = orderdb.GetOrdersForTable(table);
        }

        public void SetOrderDelivered(Order order)
        {
            orderdb.SetDelivered(order);
        }
    }
}
