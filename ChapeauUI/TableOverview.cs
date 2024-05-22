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
    public partial class TableOverview : Form
    {
        Employee employee;
        public TableOverview(Employee employee)
        {
            InitializeComponent();
            InitializeTables();
            this.employee = employee;
        }

        // adjust this so it gets the tables out of the database!!!!!
        private int tableCount = 10;
        // ^^^^^^^^^^^^^^^^^^^^


        private void InitializeTables()
        {
            int startX = 108;
            int topRowY = 150;
            int bottomRowY = topRowY + 266;
            int spacingX = 189;
            int columns = 5;

            int topRowIndex = 0;
            int bottomRowIndex = 0;

            for (int i = 0; i < tableCount; i++)
            {
                Button tableButton = new Button();
                tableButton.Text = $"Table {i + 1}";

                int column;
                int xPosition;
                int yPosition;

                //the if is for the even tables to be placed correctly (on the top) and the else is for the odd numbered tables to be placed correctly (on the bottom) :)
                if ((i + 1) % 2 != 0)
                {
                    column = topRowIndex % columns;
                    xPosition = startX + column * spacingX;
                    yPosition = topRowY;
                    topRowIndex++;
                }
                else
                {
                    column = bottomRowIndex % columns;
                    xPosition = startX + column * spacingX;
                    yPosition = bottomRowY;
                    bottomRowIndex++;
                }
                tableButton.Location = new Point(xPosition, yPosition);
                tableButton.Size = new Size(161, 100);
                tableButton.Click += TableButton_Click;
                this.Controls.Add(tableButton);
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            MessageBox.Show($"{clickedButton.Text} clicked");
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            employee = null;
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
