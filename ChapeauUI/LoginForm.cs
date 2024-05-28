using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;
using ChapeauService;

namespace ChapeauUI
{
    public partial class LoginForm : Form
    {
        public string enteredPassword;
        string enteredNumber;
        private int enteredNumbers;
        private int maxAttempts = 3;
        string youtubeUrl = "https://youtu.be/dQw4w9WgXcQ?si=EMcOrmZ8Kj8C7oY2";

        /// <summary>
        /// revove employee test
        /// </summary>
        Employee employeeTest = new Employee(50, "George", "test", "Server");

        private LoginService loginService;
        public LoginForm()
        {
            InitializeComponent();
            loginService = new LoginService();
        }

        private void UpdateVisualNumbers()
        {
            switch (enteredPassword.Length)
            {
                case 0: { EnteredNumberDesignsDefault(); return; }
                case 1: { EnteredNumberDesign1.BackColor = Color.Black; return; }
                case 2: { EnteredNumberDesign2.BackColor = Color.Black; return; }
                case 3: { EnteredNumberDesign3.BackColor = Color.Black; return; }
                case 4: { EnteredNumberDesign4.BackColor = Color.Black; return; }
                case 5: { EnteredNumberDesign5.BackColor = Color.Black; return; }
                default: { EnteredNumberDesignsDefault(); ClearPassword(); return; }
            }
        }

        private void ClearPassword()
        {
            enteredPassword = "";
            enteredNumbers = 0;
        }

        private void ReturnVisualNumbers()
        {
            switch (enteredPassword.Length)
            {
                case 0: { EnteredNumberDesign1.BackColor = ColorTranslator.FromHtml("#D9D9D9"); return; }
                case 1: { EnteredNumberDesign2.BackColor = ColorTranslator.FromHtml("#D9D9D9"); return; }
                case 2: { EnteredNumberDesign3.BackColor = ColorTranslator.FromHtml("#D9D9D9"); return; }
                case 3: { EnteredNumberDesign4.BackColor = ColorTranslator.FromHtml("#D9D9D9"); return; }
                case 4: { EnteredNumberDesign5.BackColor = ColorTranslator.FromHtml("#D9D9D9"); return; }
                default: { EnteredNumberDesignsDefault(); return; }
            }
        }

        private void EnteredNumberDesignsDefault()
        {
            EnteredNumberDesign1.BackColor = ColorTranslator.FromHtml("#D9D9D9");
            EnteredNumberDesign2.BackColor = ColorTranslator.FromHtml("#D9D9D9");
            EnteredNumberDesign3.BackColor = ColorTranslator.FromHtml("#D9D9D9");
            EnteredNumberDesign4.BackColor = ColorTranslator.FromHtml("#D9D9D9");
            EnteredNumberDesign5.BackColor = ColorTranslator.FromHtml("#D9D9D9");
        }

        private void CheckPassword()
        {
            if (enteredPassword.Length == 5) // make const
            {
                try
                {
                    Employee employee = loginService.VerifyEnteredPassword(enteredPassword);
                    MessageBox.Show($"Successvol ingelogt {employee.name}");
                    OpenRelevantForm(employee);
                }
                catch (Exception ex) { adjustAttempts(); MessageBox.Show($"Error: verkeerd wachtwood." + "\n" + $"{maxAttempts} pogingen over."); EnteredNumberDesignsDefault(); ClearPassword(); }
            }
        }


        private void adjustAttempts()
        {
            maxAttempts--;
            if (maxAttempts <= 0)
            {
                Process.Start(new ProcessStartInfo
                {

                    FileName = youtubeUrl,
                    UseShellExecute = true
                }); ;
            }
        }

        private void OpenRelevantForm(Employee employee)
        {
            if (employee.role == "Chef")
            { //KitchenForm kitchenform = new KitchenForm(); kitchenform.Show(); this.Close();
            }
            else if (employee.role == "Bartender") { }
            else if (employee.role == "Server") { TableOverview tableOverview = new TableOverview(employee); tableOverview.Show(); this.Close(); }
            else if (employee.role == "Manager") { TableOverview tableOverview = new TableOverview(employee); tableOverview.Show(); this.Close(); }
        }
        private void roundButton1_Click(object sender, EventArgs e)
        {
            enteredNumber = "1";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButtonReturn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(enteredPassword))
            {
                enteredPassword = enteredPassword.Remove(enteredPassword.Length - 1);
                ReturnVisualNumbers();
            }
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            enteredNumber = "2";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            enteredNumber = "3";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            enteredNumber = "4";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButton5_Click(object sender, EventArgs e)
        {
            enteredNumber = "5";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButton6_Click(object sender, EventArgs e)
        {
            enteredNumber = "6";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButton7_Click(object sender, EventArgs e)
        {
            enteredNumber = "7";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButton8_Click(object sender, EventArgs e)
        {
            enteredNumber = "8";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButton9_Click(object sender, EventArgs e)
        {
            enteredNumber = "9";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
        }

        private void roundButton0_Click(object sender, EventArgs e)
        {
            enteredNumber = "0";
            enteredPassword += enteredNumber;
            UpdateVisualNumbers();
            if (enteredPassword.Length == 5) { CheckPassword(); }
            else { TableOverview tableOverview = new TableOverview(employeeTest); tableOverview.Show(); this.Close(); }
        }

        private void CloseApplicationBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
