using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderlineDao : BaseDao
    {
        public void StoreOrderline(Orderline orderline)
        {
            if (orderline.Opmerking != null)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [orderline] (orderid, aantal, opmerking, artikelid) VALUES (@orderId, @aantal, @opmerking, @artikelid)", OpenConnection());
                command.Parameters.AddWithValue("@orderId", orderline.OrderID);
                command.Parameters.AddWithValue("@aantal", orderline.Aantal);
                command.Parameters.AddWithValue("@opmerking", orderline.Opmerking);
                command.Parameters.AddWithValue("@artikelid", orderline.ArtikelID);
                command.ExecuteNonQuery();
            }
            else 
            {
                SqlCommand command = new SqlCommand("INSERT INTO [orderline] (orderid, aantal, artikelid) VALUES (@orderId, @aantal, @artikelid)", OpenConnection());
                command.Parameters.AddWithValue("@orderId", orderline.OrderID);
                command.Parameters.AddWithValue("@aantal", orderline.Aantal);
                command.Parameters.AddWithValue("@artikelid", orderline.ArtikelID);
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
    }
}
