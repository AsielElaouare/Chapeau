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

        public void CreateInvoice(Tafel table, Employee employee)
        {
            invoiceDAO.CreateInvoice(table, employee);
        }
        public List<Orderline> GetNotPaidOrderlinesForBill(Bill bill)
        {
            List<Orderline> orderlines;
            return orderlines = invoiceDAO.GetOrdersForBill(bill);
        }
    }
}
