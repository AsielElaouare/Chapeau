using ChapeauService;
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


namespace ChapeauUI
{
    public partial class KitchenForm : Form
    {
        private List<Order> orders;
        public KitchenForm()
        {
            InitializeComponent();
            DisplayOrders();
        }

        private void KitchenForm_Load(object sender, EventArgs e)
        {

        }

        private List<Order> GetKitchenOrders()
        {
            OrderService order = new OrderService();
            return this.orders = order.GetKitchenOrders();
        }
        private void DisplayOrders()
        {
            flowLayoutKitchenPnl.Controls.Clear();
            Label timeLabel = new Label();
            Label orderInfLabel = new Label();
            Label mainDishesLabel = new Label();
            Label sideDishesLabel = new Label();
            Label dessertsLabel = new Label();
            //
            //Main orderPanel
            //
            FlowLayoutPanel orderPanel = new FlowLayoutPanel();
            orderPanel.Width = 200;
            orderPanel.Height = 450;
            orderPanel.FlowDirection = FlowDirection.TopDown;
            orderPanel.BackColor = Color.FromArgb(128, 128, 128);
            //
            //Timer Label
            //
            timeLabel.BackColor = Color.FromArgb(173, 173, 173);
            timeLabel.TextAlign = ContentAlignment.MiddleRight;
            timeLabel.Width = 200;
            timeLabel.Margin = new Padding(0);
            //
            //Order header info
            //
            orderInfLabel.Text = "Order NR                               Tafel NR";
            orderInfLabel.Margin = new Padding(0, 5, 0, 0);
            orderInfLabel.Width = 200;
            //
            //Main dishes label
            //
            mainDishesLabel.Text = "Hoofdgerechten";
            mainDishesLabel.Width = 200;
            mainDishesLabel.Height = 16;
            mainDishesLabel.BackColor = Color.FromArgb(255, 143, 143);
            mainDishesLabel.Margin = new Padding(0, 10, 0, 0);
            //
            //Side dishes label
            //
            sideDishesLabel.Text = "Voorgerechten";
            sideDishesLabel.Width = 200;
            sideDishesLabel.Height = 16;
            sideDishesLabel.BackColor = Color.FromArgb(119, 234, 109);
            sideDishesLabel.Margin = new Padding(0, 60, 0, 0);
            //
            //dessert dishes label
            //
            dessertsLabel.Text = "Toetjes";
            dessertsLabel.Width = 200;
            dessertsLabel.Height = 16;
            dessertsLabel.BackColor = Color.FromArgb(234, 199, 109);
            dessertsLabel.Margin = new Padding(0, 60, 0, 0);
            //
            //Controls FlowLayoutPanel
            //
            orderPanel.Controls.Add(timeLabel);
            orderPanel.Controls.Add(orderInfLabel);
            orderPanel.Controls.Add(mainDishesLabel);
            orderPanel.Controls.Add(sideDishesLabel);
            orderPanel.Controls.Add(dessertsLabel);

            flowLayoutKitchenPnl.Controls.Add(orderPanel);

        }
    }
}
