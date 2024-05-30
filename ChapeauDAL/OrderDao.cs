using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderDao : BaseDao
    {
        public void StoreNewOrder(DateTime timeOfOrder, int selectedtable,List<Orderline> orderlines)
        {
            //add order status to database!!!!!!
            int orderId = 0;
            string query = @"
                DECLARE @currentrekeningnummer INT;
                SELECT TOP 1 @currentrekeningnummer = [rekeningnr] 
                FROM [dbo].[rekening] 
                WHERE [tafelnr] = @selectedTable 
                ORDER BY [rekeningnr] DESC;

                INSERT INTO [dbo].[order] (rekeningnr, ordertime) 
                VALUES (@currentrekeningnummer, @timeOfOrder); 

                SELECT CAST(SCOPE_IDENTITY() AS INT) AS newOrderID;";

            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@timeOfOrder", timeOfOrder.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@selectedTable", $"{selectedtable}");
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                orderId = Convert.ToInt32((int)reader["newOrderID"]);
            }
            reader.Close();
             foreach (Orderline line in orderlines)
            {
                StoreOrderline(line, orderId);
            }
            CloseConnection();
            

        }
        public void StoreOrderline(Orderline orderline, int orderid)
        {
            if (orderline.Opmerking != null)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [orderline] (orderid, aantal, opmerking, artikelid) VALUES (@orderId, @aantal, @opmerking, @artikelid)");
                command.Parameters.AddWithValue("@orderId", orderid);
                command.Parameters.AddWithValue("@aantal", orderline.Aantal);
                command.Parameters.AddWithValue("@opmerking", orderline.Opmerking);
                command.Parameters.AddWithValue("@artikelid", orderline.ArtikelID);
                command.ExecuteNonQuery();
            }
            else
            {
                SqlCommand command = new SqlCommand("INSERT INTO [orderline] (orderid, aantal, artikelid) VALUES (@orderId, @aantal, @artikelid)");
                command.Parameters.AddWithValue("@orderId", orderid);
                command.Parameters.AddWithValue("@aantal", orderline.Aantal);
                command.Parameters.AddWithValue("@artikelid", orderline.ArtikelID);
                command.ExecuteNonQuery();
            }
            
        }
        public List<Order> GetOrdersForBar()
        {
            string query = @"
            SELECT 
                rk.tafelnr,
                [order].orderid,
                SUM(ol.aantal) AS aantal,
                STRING_AGG([ol].opmerking, '; ') AS opmerking,
                [order].[status],
                STRING_AGG(ak.naam, '; ') AS Article, 
                STRING_AGG(ak.categorie, ', ') AS categorie 
            FROM 
                [order]
            JOIN 
                orderline AS OL ON [order].[orderid] = OL.orderid
            JOIN 
                rekening AS rk ON [order].rekeningnr = rk.rekeningnr
            JOIN 
                artikel AS ak ON ol.artikelid = ak.artikelid
            where [status] = 'Pending' AND (ak.categorie = 'bier' or ak.categorie = 'KoffieThee' or ak.categorie = 'Gedistilleerd' or ak.categorie = 'Frisdrank' or ak.categorie = 'wijn')
            GROUP BY 
                rk.tafelnr, [order].orderid, [order].[status]
            ORDER BY 
                rk.tafelnr, [order].orderid";
            SqlCommand command = new SqlCommand(query, OpenConnection());

            SqlDataReader reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();

            while (reader.Read())
            {

                Order order = ReadOrders(reader);
                orders.Add(order);
            }
            reader.Close();
            CloseConnection();
            return orders;
        }
        public List<Order> GetOrdersForKitchen()
        {
            string query = @"
            SELECT 
                rk.tafelnr,
                [order].orderid,
                SUM(ol.aantal) AS aantal,
                STRING_AGG([ol].opmerking, '; ') AS opmerking,
                [order].[status],
                STRING_AGG(ak.naam, '; ') AS Article, 
                STRING_AGG(ak.categorie, ', ') AS categorie 
            FROM 
                [order]
            JOIN 
                orderline AS OL ON [order].[orderid] = OL.orderid
            JOIN 
                rekening AS rk ON [order].rekeningnr = rk.rekeningnr
            JOIN 
                artikel AS ak ON ol.artikelid = ak.artikelid
            where [status] = 'Pending' AND (ak.categorie = 'Hoofdgerechten' or ak.categorie = 'Nagerechten' or ak.categorie = 'Tussengerechten' or ak.categorie = 'Voorgerechten')
            GROUP BY 
                rk.tafelnr, [order].orderid, [order].[status]
            ORDER BY 
                rk.tafelnr, [order].orderid";
            SqlCommand command = new SqlCommand(query, OpenConnection());

            SqlDataReader reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();

            while (reader.Read())
            {

                Order order = ReadOrders(reader);
                orders.Add(order);
            }
            reader.Close();
            CloseConnection();
            return orders;
        }
        public Order ReadOrders(SqlDataReader reader)
        {
            Order currentOrder = null;
            Product currentProduct = null;

            currentOrder = new Order
                (
                    (int)reader["orderid"],
                    (int)reader["tafelnr"],
                    (string)reader["status"],
                    new Orderline((int)reader["orderId"], (int)reader["aantal"], reader["opmerking"] as string ?? null)
                );

            string products = (string)reader["Article"];
            string[] productsArray = products.Split(';');

            foreach (string product in productsArray)
            {
                currentProduct = new Product(product, (string)reader["categorie"]);
                currentOrder.ProductList.Add(currentProduct);

            }
            return currentOrder;
        }
        public void CompleteOrder(int orderId, OrderStatus orderStatus)
        {
            string query = $"UPDATE [order] SET [status] = @orderStatus WHERE [orderId] = @OrderId";
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderId", orderId),
                new SqlParameter("@orderStatus", orderStatus.ToString())
            };
            ExecuteEditQuery(query, parameters);

        }
        public void StartOrder(int orderId, OrderStatus orderStatus)
        {
            string query = $"UPDATE [order] SET [status] = @orderStatus WHERE [orderId] = @OrderId";
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderId", orderId),
                new SqlParameter("@orderStatus", orderStatus.ToString())
            };
            ExecuteEditQuery(query, parameters);
        }
    }
}
