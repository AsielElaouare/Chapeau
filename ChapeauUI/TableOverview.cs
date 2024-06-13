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
using ChapeauService;
using System.Timers;

namespace ChapeauUI
{
    public partial class TableOverview : Form
    {
        Employee employee;
        List<Tafel> tables;
        OrderService orderService;
        TafelService tableService;

        const int startX = 108;
        int topRowY = 150;
        int bottomRowY = 416;
        int thirdRowY = 416;
        const int spacingX = 189;
        const int columns = 5;

        // for table creation
        int column;
        int xPosition;
        int yPosition;
        int topRowIndex = 0;
        int bottomRowIndex = 0;
        int thirdRowIndex = 0;
        int amountOfTablesCreated = 0;
        const int regularAmountOfTables = 10;

        //refresh the form
        private System.Windows.Forms.Timer refreshTimer;
        public TableOverview(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            this.tables = GetTables();
            CheckLayOut();
            InitializeTimer();
            DisableReserveButton();
        }

        private void DisableReserveButton()
        {
            ReservationBtn.Enabled = false;
            ReservationBtn.Visible = false;
        }

        //again this is to refresh the form every 30 seconds
        private void InitializeTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 30000; 
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshTableButtons();
        }

        public void RefreshTableButtons()
        {
            var tableButtons = this.Controls.OfType<Button>().Where(button => button.Tag is Tafel).ToList();
            foreach (var tableButton in tableButtons)
            {
                this.Controls.Remove(tableButton);
            }
            this.tables = GetTables();
            CheckLayOut();
        }
        private void CheckLayOut()
        {
            if (tables.Count <= regularAmountOfTables)
            {
                InitializeTables();
            }
            else
            {
                UpdateRows();
                InitializeTables();
            }
        }

        private void UpdateRows()
        {
            topRowY = 100;
            bottomRowY = 314;
        }

        private List<Tafel> GetTables()
        {
            TafelService tafelService = new TafelService();
            return tafelService.GetTablesAndStatus();
        }


        private void InitializeTables()
        {
            foreach (Tafel table in tables)
            {
                Button tableButton = new Button();
                tableButton.Font = new Font(tableButton.Font.FontFamily, 16);
                if (table.Status == TableStatusEnum.Ordered) { tableButton.ForeColor = Color.Black; } else { tableButton.ForeColor = Color.White; }
                if (table.Status == TableStatusEnum.Free) { tableButton.Font = new Font(tableButton.Font.FontFamily, 40); }
                if (table.Status == TableStatusEnum.Ordered) { if (CheckOrderReady(table)) { tableButton.Paint += TableButton_PaintReady; } else { tableButton.Paint += TableButton_PaintNotReady; } }
                tableButton.Text = $"{table.TafelNummer}";
                tableButton.Tag = table;
                tableButton.FlatStyle = FlatStyle.Flat;
                tableButton.FlatAppearance.BorderSize = 0;
                if ((table.TafelNummer + 1) % 2 != 0) { CreateEvenTables(); }
                else if (amountOfTablesCreated <= 10) { CreateOddTables(); }
                else { CreateExtraTables(); }
                CreateTables(tableButton, xPosition, yPosition, table);
            }
        }


        private void TableButton_PaintNotReady(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag is Tafel table && table.Status == TableStatusEnum.Ordered)
            {
                Image icon = Properties.Resources.time24x24b;
                int iconSize = 24;
                int iconX = 5;
                int iconY = button.Height - iconSize - 5;
                e.Graphics.DrawImage(icon, iconX, iconY, iconSize, iconSize);
                string text = GetOrderTime(table) + " Minuten";
                Font font = new Font(button.Font.FontFamily, 12);
                Brush brush = Brushes.Black;
                int textX = iconX + iconSize + 5;
                int textY = iconY + (iconSize / 2) - (font.Height / 2);
                e.Graphics.DrawString(text, font, brush, textX, textY);
            }
        }

        private void TableButton_PaintReady(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag is Tafel table && table.Status == TableStatusEnum.Ordered)
            {
                Image icon = Properties.Resources.time24x24y;
                int iconSize = 24;
                int rightIconSize = 50;
                int iconX = 5;
                int iconY = button.Height - iconSize - 5;
                e.Graphics.DrawImage(icon, iconX, iconY, iconSize, iconSize);
                string text = GetOrderTime(table) + " Minuten";
                Font font = new Font(button.Font.FontFamily, 12);
                Brush brush = new SolidBrush(ColorTranslator.FromHtml("#FFFF00"));
                button.ForeColor = Color.White;
                int textX = iconX + iconSize + 5;
                int textY = iconY + (iconSize / 2) - (font.Height / 2);
                e.Graphics.DrawString(text, font, brush, textX, textY);
                Image rightIcon = SelectRightIcon(table);
                int rightIconX = button.Width - rightIconSize - 5;
                int rightIconY = 5;
                e.Graphics.DrawImage(rightIcon, rightIconX, rightIconY, rightIconSize, rightIconSize);
            }
        }

        private Image SelectRightIcon(Tafel table)
        {
            orderService = new OrderService();
            List<Order> orders = orderService.GetOrdersByTable(table);
            if (orders.Count == 0) { tableService = new TafelService(); table.Status = TableStatusEnum.Occupied; tableService.UpdateTableStatus(table); }
            Order mostRecentOrder = orders.OrderByDescending(order => order.OrderTime).FirstOrDefault();
            if (mostRecentOrder.barStatus == OrderStatus.Ready && mostRecentOrder.kitchenStatus == OrderStatus.Ready) { return Properties.Resources.check50x50y; }
            else if (mostRecentOrder.barStatus == OrderStatus.Ready) { return Properties.Resources.drink50x50y; }
            else if (mostRecentOrder.kitchenStatus == OrderStatus.Ready) { return Properties.Resources.food50x50y; }
            return Properties.Resources.rick_astley50x50TheBestOne;
        }

        private string GetOrderTime(Tafel table)
        {
            orderService = new OrderService();
            List<Order> orders = orderService.GetOrdersByTable(table);
            if (orders.Count == 0)
            {
                tableService = new TafelService(); table.Status = TableStatusEnum.Occupied; tableService.UpdateTableStatus(table);
                RefreshTableButtons();
            }
            Order mostRecentOrder = orders.OrderByDescending(order => order.OrderTime).FirstOrDefault();
            TimeSpan timeDifference = DateTime.Now - mostRecentOrder.OrderTime;
            int minutes = (int)timeDifference.TotalMinutes;
            return minutes.ToString();
        }

        private Order getOrderForTable(Tafel table)
        {
            orderService = new OrderService();
            List<Order> orders = orderService.GetOrdersByTable(table);
            if (orders.Count == 0)
            {
                tableService = new TafelService(); table.Status = TableStatusEnum.Occupied; tableService.UpdateTableStatus(table);
                RefreshTableButtons();
            }
            return orders.OrderByDescending(o => o.OrderTime).FirstOrDefault();
        }

        private void CreateEvenTables()
        {
            column = topRowIndex % columns;
            xPosition = startX + column * spacingX;
            yPosition = topRowY;
            topRowIndex++;
        }

        private void CreateOddTables()
        {
            column = bottomRowIndex % columns;
            xPosition = startX + column * spacingX;
            yPosition = bottomRowY;
            bottomRowIndex++;
        }

        private void CreateExtraTables()
        {
            column = thirdRowIndex % columns;
            xPosition = startX + column * spacingX;
            yPosition = thirdRowY;
            thirdRowIndex++;
        }
        private void CreateTables(Button tableButton, int xPosition, int yPosition, Tafel table)
        {
            tableButton.Location = new Point(xPosition, yPosition);
            tableButton.Size = new Size(161, 100);
            tableButton.Click += TableButton_Click;
            tableButton.BackColor = tableStatus(table);
            this.Controls.Add(tableButton);
        }

        private Color tableStatus(Tafel table)
        {
            switch (table.Status)
            {
                case TableStatusEnum.Free: return Color.FromArgb(5, 123, 31);
                case TableStatusEnum.Reserved: return Color.FromArgb(12, 18, 150);
                case TableStatusEnum.Occupied: return Color.FromArgb(153, 0, 17);
                case TableStatusEnum.Ordered: if (CheckOrderReady(table)) { return Color.Black; } else { return Color.FromArgb(255, 79, 0); }
                default: return Color.DarkGray;
            }
        }

        private bool CheckOrderReady(Tafel table)
        {
            orderService = new OrderService();
            List<Order> orders = orderService.GetOrdersByTable(table);
            if (orders.Count == 0) { tableService = new TafelService(); table.Status = TableStatusEnum.Occupied; tableService.UpdateTableStatus(table); return false; }
            Order mostRecentOrder = orders.OrderByDescending(order => order.OrderTime).FirstOrDefault();
            if (mostRecentOrder.barStatus == OrderStatus.Ready || mostRecentOrder.kitchenStatus == OrderStatus.Ready) { return true; }
            else { return false; }
        }

        


        private void TableButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Tafel clickedTable = clickedButton.Tag as Tafel;
            OpenCorrectForm(clickedTable);
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            employee = null;
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void OpenCorrectForm(Tafel table)
        {
            switch (table.Status)
            {
                case TableStatusEnum.Free: OpenPopUpFreeTable(table); break;
                case TableStatusEnum.Reserved: OpenPopUpFreeTable(table); break;
                case TableStatusEnum.Occupied: OpenPopUpOccupiedTable(table); break;
                case TableStatusEnum.Ordered: OpenPopUpOrderedTable(table); break;
                default: OpenPopUpFreeTable(table); break;
            }
        }

        private void OpenPopUpFreeTable(Tafel table)
        {
            PopUpFreeTable popUpFreeTable = new PopUpFreeTable(employee, table, this);
            popUpFreeTable.Show();
        }
        private void OpenPopUpOccupiedTable(Tafel table)
        {
            PopUpOccupiedTable popUpOccupiedTable = new PopUpOccupiedTable(employee, table, this);
            popUpOccupiedTable.Show();
        }

        private void OpenPopUpOrderedTable(Tafel table)
        {
            if (CheckOrderReady(table)) { PopUpOrderedTable popUpOrderedTable = new PopUpOrderedTable(employee, table, this, getOrderForTable(table)); popUpOrderedTable.Show(); }
            else { OpenPopUpOccupiedTable(table); }
        }
        private void OpenLegendBtn_Click(object sender, EventArgs e)
        {
            Legend legend = new Legend();
            legend.Show();
        }

        private void ReservationBtn_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm();
            reservationForm.Show();
        }
    }
}
