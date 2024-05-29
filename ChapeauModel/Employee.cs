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
            this.role=assignRole(role);
        }

        private int employeeId { get; }
        public string name { get; }
        public string password { get; }
        public EmployeeRoleEnum role { get; }

        private EmployeeRoleEnum assignRole(string role)
        {
            switch (role)
            {
                case "chef":
                    return EmployeeRoleEnum.Chef;
                case "Owner/Manager":
                    return EmployeeRoleEnum.Manager;
                case "Waitress":
                    return EmployeeRoleEnum.Waiter;
                case "Barmen/Barista":
                    return EmployeeRoleEnum.Barista;
                default: throw new Exception("Role doesn't exist. Please inform manager!");
            }
        }
    }
}
