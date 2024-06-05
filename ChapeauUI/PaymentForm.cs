using ChapeauModel;
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

namespace ChapeauUI
{
    public partial class PaymentForm : Form
    {
        private List<Order> orders;
        private OrderService orderService;
        public PaymentForm()
        {
            InitializeComponent();
            ShowOrder(GetBillOrders());

        }
        private List<Order> GetBillOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetNotPAidOrdersForBill(4);
            return orders;
        }


        public void ShowOrder(List<Order> orders)
        {
            listview_Bestelling.Items.Clear();
            foreach (Order ord in orders)
            {
                ListViewItem order = new ListViewItem(ord.ProductList[0].Naam);
                order.SubItems.Add(ord.orders[0].Aantal.ToString());
                order.SubItems.Add(ord.ProductList[0].Prijs.ToString());
                //order.SubItems.Add(ord.OrderID.ToString());



                order.Tag = ord;
                listview_Bestelling.Items.Add(order);

            }

            listview_Bestelling.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void lbl_ReceiptNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
