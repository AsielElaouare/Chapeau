using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class InvoiceService
    {
        private InvoiceDAO invoiceDAO;
        public InvoiceService() 
        {
            invoiceDAO = new InvoiceDAO();
        }

        public void CreateInvoice(Table table, Employee employee)
        {
            invoiceDAO.CreateInvoice(table, employee);
        }
       

        public void FinishInvoice(Bill bill)
        {
            invoiceDAO.FinishInvoice(bill); 
        }
        public List<Orderline> GetOrderlinesForBill(Bill bill)
        {
           
            return  invoiceDAO.GetOrdersForBill(bill).orderlines;
        }

    }
}
