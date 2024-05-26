using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ChapeauDAL;
using ChapeauModel;
using System.Globalization;

namespace ChapeauService
{
    public class LoginService
    {
        LoginDao loginDao;
        Employee employee;

        public LoginService()
        {
            loginDao = new LoginDao();
        }
        private string EncryptPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public bool CheckIfEmployeeIdExists(string employeeId)
        {
            return loginDao.GetByEmployeeId(employeeId);
        }

        public Employee checkLogin(string username,string password) 
        {
            try
            {
                loginDao.GetPassWordbyID(username);
                string encryptedPassword = EncryptPassword(password);
                Employee employee = loginDao.GetPassWordbyID(username);
                if (employee.password == encryptedPassword)
                {
                    return employee;
                }
                else
                {
                    throw new Exception("Verkeerde gebruikersnaam of wachtwoord");
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        
        

        


    }
}
