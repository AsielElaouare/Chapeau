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

namespace ChapeauUI
{
    public partial class TableOverview : Form
    {
        Employee employee;
        List<Tafel> tables;
        const int startX = 108;
        const int topRowY = 150;
        const int bottomRowY = topRowY + 266;
        const int spacingX = 189;
        const int columns = 5;
        
        public TableOverview(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            this.tables = GetTables();

            InitializeTables();
        }

        private void CheckLayOut()
        {

        }
        private List<Tafel> GetTables()
        {
            TafelService tafelService = new TafelService();
            return tafelService.GetTafel();
        }


        private void InitializeTables()
        {
            int topRowIndex = 0;
            int bottomRowIndex = 0;
            foreach (Tafel table in tables)
            {
                Button tableButton = new Button();
                if (table.Status == TableStatusEnum.Free || table.Status == TableStatusEnum.Reserved) { tableButton.Font = new Font(tableButton.Font.FontFamily, 40); }
                tableButton.Text = $"{table.TafelNummer}";
                tableButton.Tag = table;
                tableButton.FlatStyle = FlatStyle.Flat;
                tableButton.FlatAppearance.BorderSize = 0;
                int column;
                int xPosition;
                int yPosition;
                // make this method smaller
                //the if is for the even tables to be placed correctly (on the top) and the else is for the odd numbered tables to be placed correctly (on the bottom) :)
                // Add it so that when the tables are above 10 that another row is created below the already existing row.
                if ((table.TafelNummer + 1) % 2 != 0)
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
                CreateTables(tableButton, xPosition, yPosition, table);
            }
        }
        private void CreateEvenTables(int column, int xPosition, int yPosition)
        {


        }

        private void CreateOddTables()
        {

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
                case TableStatusEnum.Free:return Color.Green;
                case TableStatusEnum.Reserved: return Color.Blue;
                case TableStatusEnum.Occupied:return Color.Red;
                case TableStatusEnum.ordered: return Color.Yellow;
                default: return Color.DarkGray;
            }
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
                case TableStatusEnum.Free:
                    OpenPopUpFreeTable(table); break;
                case TableStatusEnum.Reserved:
                    OpenPopUpFreeTable(table); break;
                case TableStatusEnum.Occupied:
                    OpenPopUpOccupiedTable(table); break;
                case TableStatusEnum.ordered:
                    OpenPopUpOccupiedTable(table); break;
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
            /// add if else for when an order is ready to be delivered
            PopUpOccupiedTable popUpFreeTable = new PopUpOccupiedTable(employee, table, this);
            popUpFreeTable.Show();
        }
    }
}
