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
        public Tafel table { get;  set; }
        public Employee employee { get; set; }
        public string review { get; set; }
        public decimal tip {  get; set; }
        public decimal? unpaid { get; set; }
        public decimal totalPrice 
        {
            get
            {
                decimal total = 0;
                foreach (Orderline line in orderlines)
                {
                    total += (line.product.Prijs * line.Quantity);
                }
                return total;
            }
        }
        public List <Orderline> orderlines { get; set; }

        public Bill( Tafel table, Employee employee)
        {
            this.billNumber = billNumber;
            this.table = table;
            this.employee = employee;
           
            
            this.orderlines =new List<Orderline>();
         

        }
    }
}
