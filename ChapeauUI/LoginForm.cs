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
            DisableConfirmButton();
        }

        private void DisableConfirmButton()
        {
            ConfirmBtn.Enabled = false;
            ConfirmBtn.BackgroundImage = Properties.Resources.cannot_loggin_50x50;
        }

        private void EnableConfirmButton()
        {
            ConfirmBtn.Enabled = true;
            ConfirmBtn.BackgroundImage = Properties.Resources.sign_in_50x50;
        }

        private void ClearPassword()
        {
            PasswordTextBox.Text = string.Empty;
        }


        private void CheckLogin()
        {
            try
            {
                if (loginService.CheckIfEmployeeIdExists(enteredUsername))
                {
                    Employee employee = loginService.checkLogin(enteredUsername, enteredPassword);
                    if (employee != null) { try { OpenRelevantForm(employee); } catch (Exception ex) { adjustAttempts(ex.Message); ClearPassword(); } }

                }
                else { adjustAttempts("Verkeerde gebruikersnaam"); ClearPassword(); }
            }
            catch (Exception ex) { adjustAttempts(ex.Message); }
        }

        private void adjustAttempts(string message)
        {
            Attempts++;
            ShowAttempts(message);
            if (Attempts >= maxAttempts)
            {
                LockDownSystem();
                Process.Start(new ProcessStartInfo
                {
                    FileName = youtubeUrl,
                    UseShellExecute = true
                });
            }
        }

        private void ShowAttempts(string message)
        {
            if (Attempts >= maxAttempts)
            {
                MessageBox.Show(message + "\n Systeem staat op slot. \n Start het systeem opnieuw op om weer te proberen.");
            }
            else
            {
                MessageBox.Show(message + $"\n {maxAttempts - Attempts} pogingen over");
            }
        }

        private void LockDownSystem()
        {
            UsernameTextBox.Enabled = false;
            PasswordTextBox.Enabled = false;
            DisableConfirmButton();
        }

        private void OpenRelevantForm(Employee employee)
        {
            if (employee.role == EmployeeRoleEnum.Chef) { KitchenAndBarForm kitchenform = new KitchenAndBarForm(employee); kitchenform.Show(); this.Close(); }
            else if (employee.role == EmployeeRoleEnum.Barista) { KitchenAndBarForm kitchenform = new KitchenAndBarForm(employee); kitchenform.Show(); this.Close(); }
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

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableConfirmButton();
        }
    }
}
