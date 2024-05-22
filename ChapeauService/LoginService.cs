using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ChapeauDAL;
using ChapeauModel;


namespace ChapeauService
{
    public class LoginService
    {
        LoginDao loginDao;
        Employee employee;
        private string EncryptPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }


        public Employee VerifyEnteredPassword(string password)
        {
            EncryptPassword(password);
            loginDao = new LoginDao();
            employee = loginDao.GetByPassWord(password);
            return employee;
            
        }
        private void OpenRelevantForm()
        {
            if (employee.role == "Chef"){ }
            else if(employee.role == "Bartender"){ }
            else if (employee.role == "Server") { }
            else if (employee.role == "Manager") { }
        }

        


    }
}
