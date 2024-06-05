using ChapeauModel;
using ChapeauService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class PopUpOrderedTable : Form
    {
        Employee employee;
        Tafel table;
        OrderForm orderForm;
        TableOverview tableOverview;
        Order order;
        OrderService orderService;
        TafelService tafelService = new TafelService();
        private string bezetStatus = "Bezet";
        private int cornerRadius = 30;
        public PopUpOrderedTable(Employee employee, Tafel table, TableOverview tableOverview, Order order)
        {
            InitializeComponent();
            SetRoundedRegion();
            this.table = table;
            this.employee = employee;
            tableLbl.Text = $"Tafel {table.TafelNummer.ToString()}";
            this.tableOverview = tableOverview;
            this.order = order;
            SetButtons();
        }
        private void SetRoundedRegion()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(this.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(this.Width - cornerRadius, this.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, this.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
            this.Invalidate();
        }

        private void PopUpOrderedTable_Deactivate(object sender, EventArgs e)
        {
            this.Close();
            tableOverview.ReOpenForm();
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            orderForm = new OrderForm(table, employee);
            orderForm.Show();
            tableOverview.Close();
            this.Close();
        }

        private void exitPopUpBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            tableOverview.ReOpenForm();
        }

        private void BarBtn_Click(object sender, EventArgs e)
        {
            orderService = new OrderService();
            order.barStatus = OrderStatus.Delivered;
            orderService.SetOrderDelivered(order);
            if (order.barStatus == OrderStatus.Delivered && order.kitchenStatus == OrderStatus.Delivered) { tafelService.UpdateTableStatus(table, bezetStatus); }
            this.Close();
        }

        private void KitchenBtn_Click(object sender, EventArgs e)
        {
            orderService = new OrderService();
            order.kitchenStatus = OrderStatus.Delivered;
            orderService.SetOrderDelivered(order);
            if (order.barStatus == OrderStatus.Delivered && order.kitchenStatus == OrderStatus.Delivered) { tafelService.UpdateTableStatus(table, bezetStatus); }
            this.Close();
        }

        private void BillBtn_Click(object sender, EventArgs e)
        {
            //////Open reciept form
            this.Close();
            tableOverview.Close();
        }

        private void SetButtons()
        {
            if (order.barStatus != OrderStatus.Ready && order.kitchenStatus != OrderStatus.Ready)
            {
                if (order.barStatus == OrderStatus.Ready) { KitchenBtn.Enabled = false; KitchenBtn.BackColor = Color.FromArgb(224, 224, 224); }
                else if (order.kitchenStatus == OrderStatus.Ready) { BarBtn.Enabled = false; BarBtn.BackColor = Color.FromArgb(224, 224, 224); }
            }
        }
    }
}
