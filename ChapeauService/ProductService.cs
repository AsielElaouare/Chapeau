using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class ProductService
    {
        private ProductDao productdb;
        public ProductService()
        {
            productdb = new ProductDao();
        }
        public List<Product> GetProducts()
        {
            return productdb.GetAllProducts();
        }
    }
}
