﻿using ChapeauDAL;
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

        public void StoreOrder(DateTime timeOfOrder, int selectedtable,List<Orderline> orders, Bill bill)
        {
             orderdb.StoreNewOrder(timeOfOrder, selectedtable, orders, bill);
        }

        public List<Order> GetOrdersForBar(OrderStatus status, DateOnly todayDate)
        {
            string[] barCategories = { "bier", "KoffieThee", "Gedistilleerd", "Frisdrank", "wijn" };
            List<Order> orders;
            return orders = orderdb.GetOrders(status, barCategories, todayDate);
        }
        public List<Order> GetOrdersForKitchen(OrderStatus status, DateOnly dateToday)
        {
            string[] kitchenCategories = { "Hoofdgerechten", "Nagerechten", "Tussengerechten", "Voorgerechten" };
            List<Order> orders;
            return orders = orderdb.GetOrders(status, kitchenCategories, dateToday);
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
