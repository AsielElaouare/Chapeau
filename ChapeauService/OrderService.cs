using ChapeauDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class OrderService
    {
        private OrderDao orderdb;
        
        public OrderService()
        {
            orderdb = new OrderDao();
        }
        public int GetNewOrderID(DateTime timeOfOrder,int selectedtable)
        {
            return orderdb.MakeNewOrder(timeOfOrder, selectedtable);
        }
    }
}
    