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
        public int GetNewOrderID(DateTime timeOfOrder, int selectedtable)
        {
            return orderdb.MakeNewOrder(timeOfOrder, selectedtable);
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

        public List <Order> GetNotPAidOrdersForBill(int rekeningnummer)
        {
            List<Order> orders;
            return orders =orderdb.GetOrdersForBill(rekeningnummer);
        }

        public void UpdateToReadyOrders(int orederID, OrderStatus orderStatus)
        {
            orderdb.CompleteOrder(orederID, orderStatus);
        }
        public void UpdateToPreparingOrders(int orederID, OrderStatus orderStatus)
        {
            orderdb.StartOrder(orederID, orderStatus);
        }
    }
}
