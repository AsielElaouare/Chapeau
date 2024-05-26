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
        private string enteredUsername;
        private string enteredPassword;
        private const int maxAttempts = 3;
        private int Attempts = 0;
        string youtubeUrl = "https://youtu.be/dQw4w9WgXcQ?si=EMcOrmZ8Kj8C7oY2";

        
        private LoginService loginService;
        public LoginForm()
        {
            InitializeComponent();
            loginService = new LoginService();
        }

       

        private void ClearPassword()
        {
            PasswordTextBox.Text = string.Empty;
        }


        private void CheckLogin()
        {
            if(loginService.CheckIfEmployeeIdExists(enteredUsername))
            {
                Employee employee = loginService.checkLogin(enteredUsername, enteredPassword);
                if (employee != null){ try { OpenRelevantForm(employee); } catch (Exception ex) { adjustAttempts(ex.Message); ClearPassword(); } }
            }
            else{adjustAttempts("Verkeerde gebruikersnaam"); ClearPassword();}     
        }


        private void adjustAttempts(string message)
        {
            Attempts++;
            MessageBox.Show(message);
            if (Attempts >= maxAttempts)
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
            if (employee.role == EmployeeRoleEnum.Chef) { KitchenForm kitchenform = new KitchenForm(); kitchenform.Show(); this.Close(); }
            else if (employee.role == EmployeeRoleEnum.Barista) { BarForm barform = new BarForm(); barform.Show(); this.Close(); }
            else if (employee.role == EmployeeRoleEnum.Waiter) { TableOverview tableOverview = new TableOverview(employee); tableOverview.Show(); this.Close(); }
            else if (employee.role == EmployeeRoleEnum.Manager) { TableOverview tableOverview = new TableOverview(employee); tableOverview.Show(); this.Close(); }
        }

        private void CloseApplicationBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            enteredUsername = UsernameTextBox.Text.ToString();
            enteredPassword = PasswordTextBox.Text.ToString();
            CheckLogin();
        }
    }
}
