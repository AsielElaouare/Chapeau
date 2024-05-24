using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Employee
    {
        public Employee(int employeeId, string name, string password, string role)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.password = password;
            this.role = role;
        }

        private int employeeId { get; }
        public string name { get; }
        private string password { get; }
        public string role { get; }

        //private EmployeeRoleEnum assignRole(string role)
        //{

        //}
    }
}
