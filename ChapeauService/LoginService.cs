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

        public Employee VerifyEnteredPassword(string password)
        {
            string hashedPassword = EncryptPassword(password);
            employee = loginDao.GetByPassWord(hashedPassword);
            return employee;
            
        }
        

        


    }
}
