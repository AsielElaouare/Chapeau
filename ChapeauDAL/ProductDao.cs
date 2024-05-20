using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class ProductDao :BaseDao
    {
        public List<Product> GetAll()
        {
            SqlCommand command = new SqlCommand("SELECT artikelid, naam, voorraad, prijs, categorie, kaart FROM [artikel]", OpenConnection());

            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = ReadProduct(reader);
                products.Add(product);
            }
            reader.Close();
            CloseConnection();

            return products;
        }
        private Product ReadProduct(SqlDataReader reader)
        {
            Product product = new Product(
                (int)reader["artikelid"],
                (string)reader["naam"],
                (int)reader["voorraad"],
                (decimal)reader["prijs"],
                (string)reader["categorie"],
                (string)reader["kaart"] );
            return product;
        }
    }
}
