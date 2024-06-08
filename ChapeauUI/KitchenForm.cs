﻿using ChapeauService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;
using System.Media;


namespace ChapeauUI
{
    public partial class KitchenForm : Form
    {
        private Timer timer;
        private List<Order> orders;
        private OrderService orderService;

        public KitchenForm()
        {
            InitTimer();
            InitializeComponent();
            DisplayOrders();
            openOrdersLabel.Text = $"Open: {flowLayoutKitchenPnl.Controls.Count}";
            this.orderService = new OrderService();
        }

        public void Update()
        {
            List<Order> latestOrders = orderService.GetPendingOrdersForKitchen();

            foreach (Order order in latestOrders)
            {
                if (!orders.Any(o => o.OrderID == order.OrderID))
                {
                    orders.Add(order);
                    KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order, openOrdersLabel);
                    flowLayoutKitchenPnl.Controls.Add(kitchenDisplayOrder);

                    playNotificationSound();
                }
            }
        }
        private List<Order> GetKitchenOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetPendingOrdersForKitchen(); ;
            return orders;
        }

        private void DisplayOrders()
        {
            orders = GetKitchenOrders();
            foreach (Order order in orders)
            {
                KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order, openOrdersLabel);
                flowLayoutKitchenPnl.Controls.Add(kitchenDisplayOrder);

            }
        }

        //private void historyOrders_Click(object sender, EventArgs e)
        //{
        //    previousOrdersForm.Show();
        //    this.Hide();
        //}

        private void playNotificationSound()
        {
            SoundPlayer sound = new SoundPlayer("NewOrder.wav");
            sound.Play();
        }

        private void UpdateOpenOrderLabel()
        {
            flowLayoutKitchenPnl.Refresh();
            openOrdersLabel.Text = $"Open: {flowLayoutKitchenPnl.Controls.Count}";
        }

        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 5000;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Update();
        }

        private void historyOrders_Click(object sender, EventArgs e)
        {
            PreviousOrders previousOrders = new PreviousOrders(this);
            this.Hide();
            previousOrders.Show();
        }
    }
}
