using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class OrderlineService
    {
        private OrderlineDao orderlinedb;
        private ProductDao productdb;

        public OrderlineService()
        {
            orderlinedb = new OrderlineDao();
            productdb = new ProductDao();
        }

        public void StoreOrder(List<Orderline> orders)
        {
            foreach(Orderline order in orders)
            {
                orderlinedb.StoreOrderline(order);
            }
            
        }
    }
}
