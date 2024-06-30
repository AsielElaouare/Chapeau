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

        public void StoreOrder(Order order)
        {
            orderdb.StoreNewOrder(order);
        }

        public List<Order> GetOrdersForBar(OrderStatus status, DateOnly todayDate)
        {
            ProductCategorie[] productCategories = new ProductCategorie[] { ProductCategorie.Bier, ProductCategorie.Wijn, ProductCategorie.KoffieThee, ProductCategorie.Gedistilleerd, ProductCategorie.Frisdrank };
            List<Order> orders;
            return orders = orderdb.GetOrders(status, productCategories, todayDate);
        }
        public List<Order> GetOrdersForKitchen(OrderStatus status, DateOnly dateToday)
        {
            ProductCategorie[] productCategories = new ProductCategorie[] { ProductCategorie.Hoofdgerechten, ProductCategorie.Tussengerechten, ProductCategorie.Voorgerechten, ProductCategorie.Nagerechten, ProductCategorie.NULL };
            List<Order> orders;
            return orders = orderdb.GetOrders(status, productCategories, dateToday);
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
