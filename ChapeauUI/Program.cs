using ChapeauModel;
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
            //TableOverview tableOverview = new TableOverview(new ChapeauModel.Employee(1,"Henk","test","Waitress"));
            //tableOverview.Show();

            KitchenForm form = new KitchenForm();
            BarForm barForm = new BarForm();
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
            form.Show();
            barForm.Show();


            Application.Run();

        }
    }
}
