﻿using System;
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
        public TableOverview(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
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
                tableButton.ForeColor = Color.White;
                if (table.Status == TableStatusEnum.Free) { tableButton.Font = new Font(tableButton.Font.FontFamily, 40); }
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
            bottomRowIndex++;
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
                case TableStatusEnum.Ordered: return Color.FromArgb(201, 126, 13);
                default: return Color.DarkGray;
            }
        }

        public void ReOpenForm()
        {
            this.Hide();
            TableOverview tableOverview = new TableOverview(employee);
            tableOverview.Show();
            this.Close();
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
                case TableStatusEnum.Ordered:   /*Write a statement to check if order is ready to open ordered form else open -->>*/ OpenPopUpOccupiedTable(table); break;
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
