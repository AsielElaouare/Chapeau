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

        public void StoreOrder(DateTime timeOfOrder, int selectedtable, List<Orderline> orders)
        {
            orderdb.StoreNewOrder(timeOfOrder, selectedtable, orders);
        }

        public List<Order> GetOrdersForBar(OrderStatus status, DateOnly todayDate)
        {

            List<Order> orders;
            return orders = orderdb.GetOrders(status, OrderType.Bar, todayDate);
        }
        public List<Order> GetOrdersForKitchen(OrderStatus status, DateOnly dateToday)
        {

            List<Order> orders;
            return orders = orderdb.GetOrders(status, OrderType.Kitchen, dateToday);
        }


        public void UpdateToCompleteOrders(int orederID, OrderStatus orderStatus)
        {
            orderdb.CompleteDeliveredOrder(orederID, orderStatus);

        }

        public void UpdateToReadyOrders(int orederID, OrderStatus orderStatus, OrderType orderType)
        {
            orderdb.CompleteOrder(orederID, orderStatus, orderType);

        }
        public void UpdateToPreparingOrders(int orederID, OrderStatus orderStatus, OrderType orderType)
        {
            orderdb.StartOrder(orederID, orderStatus, orderType);
        }

        public void UpdateToRemakingOrder(int orederID, OrderStatus orderStatus, OrderType orderType)
        {
            orderdb.StartOrder(orederID, orderStatus, orderType);
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
