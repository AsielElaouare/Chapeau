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

        public void CreateInvoice(Bill bill)
        {
            invoiceDAO.CreateInvoice(bill);
        }
        public Bill GetBillNumber(Bill bill)
        { return invoiceDAO.GetBillNumber(bill);}

        public void FinishInvoice(Bill bill)
        {
            invoiceDAO.FinishInvoice(bill); 
        }
        public List<Orderline> GetNotPaidOrderlinesForBill(Bill bill)
        {
            List<Orderline> orderlines;
            return orderlines = invoiceDAO.GetOrdersForBill(bill).orderlines;
        }

    }
}
