﻿using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChapeauUI
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //LoginForm loginForm = new LoginForm();
            //loginForm.Show();
            OrderForm form = new OrderForm();
            form.Show();
            KitchenForm kitchenForm = new KitchenForm(form);
            kitchenForm.Show();
            Application.Run(new BarForm(form));



        }
    }
}
