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
        public Table table { get; set; }
        public Employee employee { get; set; }
        public string review { get; set; }
        public decimal tip { get; set; }
        public decimal unpaid { get { return (totalPrice - paid); } }
        public decimal paid { get; set; }
        public decimal VAT
        {
            get
            {
                return DetermineBtw();
                
            }
        }
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
        public List<Orderline> orderlines { get; set; }

        public Bill(Table table, Employee employee)
        {
            
            this.table = table;
            this.employee = employee;


            this.orderlines = new List<Orderline>();




        }

        private decimal DetermineBtw()
        {
            decimal totalbtw = 0;

            foreach (Orderline orderline in orderlines)
            {
                switch (orderline.product.Category)
                {
                    case ProductCategorie.Bier: totalbtw += orderline.product.Prijs * 0.21m * orderline.Quantity; break;
                    case ProductCategorie.Frisdrank: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Gedistilleerd: totalbtw += orderline.product.Prijs * 0.21m * orderline.Quantity; break;
                    case ProductCategorie.Hoofdgerechten: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.KoffieThee: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Nagerechten: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Tussengerechten: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Voorgerechten: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Wijn: totalbtw += orderline.product.Prijs * 0.21m * orderline.Quantity; break;
                    default: break;
                }
            }

            return totalbtw;
        }
    }
}
