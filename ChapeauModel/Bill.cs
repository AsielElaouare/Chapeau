using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Bill
    {
     
        public int billNumber { get; set; }
        public int tablenr { get;  set; }
        public int employeenr { get; set; }
        public string review { get; set; }
        public decimal totalPrice { get; set; }
        public List <Order> orders { get; set; }

        public Bill(int billNumber, int table, int employee)
        {
            this.billNumber = billNumber;
            this.tablenr = table;
            this.employeenr = employee;
           
            orders =new List<Order>();
            totalPrice = 0;
        }
    }
}
