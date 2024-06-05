using ChapeauModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
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
                AdjustStock(line);
            }
            CloseConnection();
        }
        private void AdjustStock(Orderline orderline)
        {
            SqlCommand command = new SqlCommand("UPDATE [dbo].[artikel] SET [voorraad] = [voorraad] - @aantal WHERE [artikelid] = @artikelid;", OpenConnection());
            command.Parameters.AddWithValue("@artikelid", orderline.ArticleID);
            command.Parameters.AddWithValue("@aantal", orderline.Quantity);
            command.ExecuteNonQuery();
        }
        private void StoreOrderline(Orderline orderline, int orderid)
        {
            if (orderline.Commentary != null)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [orderline] (orderid, aantal, opmerking, artikelid) VALUES (@orderId, @aantal, @opmerking, @artikelid)", OpenConnection());
                command.Parameters.AddWithValue("@orderId", orderid);
                command.Parameters.AddWithValue("@aantal", orderline.Quantity);
                command.Parameters.AddWithValue("@opmerking", orderline.Commentary);
                command.Parameters.AddWithValue("@artikelid", orderline.ArticleID);
                command.ExecuteNonQuery();
            }
            else
            {
                SqlCommand command = new SqlCommand("INSERT INTO [orderline] (orderid, aantal, artikelid) VALUES (@orderId, @aantal, @artikelid)", OpenConnection());
                command.Parameters.AddWithValue("@orderId", orderid);
                command.Parameters.AddWithValue("@aantal", orderline.Quantity);
                command.Parameters.AddWithValue("@artikelid", orderline.ArticleID);
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

        public List<Order> GetOrdersForTable(Tafel table)
        {
            string query = @"
            SELECT 
                  rk.tafelnr,
                  [order].orderid AS OrderID,
                   ol.aantal AS Aantal,
                   ol.opmerking AS Opmerking,
                  [order].[status] AS Status,
                   ak.naam AS Article, 
                   ak.categorie AS Categorie,
                  [order].ordertime AS OrderTime,
                  [order].bar,
                  [order].keuken
            FROM 
                  [order]
            JOIN 
                  orderline AS ol ON [order].[orderid] = ol.orderid
            JOIN 
                  rekening AS rk ON [order].rekeningnr = rk.rekeningnr
            JOIN 
                  artikel AS ak ON ol.artikelid = ak.artikelid
            WHERE 
                  rk.tafelnr = @tableNumber AND [status] IS NOT NULL AND [bar] IS NOT NULL AND [keuken] IS NOT NULL
            ORDER BY 
                  [order].ordertime DESC";
            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@tableNumber", table.TafelNummer);
            SqlDataReader reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();

            while (reader.Read())
            {

                Order order = ReadOrderForTable(reader);
                orders.Add(order);
            }
            reader.Close();
            CloseConnection();
            return orders;
        }

        public Order ReadOrderForTable(SqlDataReader reader)
        {
            Order currentOrder = null;
            Product currentProduct = null;

            currentOrder = new Order
                (
                    (int)reader["orderid"],
                    (int)reader["tafelnr"],
                    (string)reader["status"],
                    new Orderline((int)reader["orderId"], (int)reader["aantal"], reader["opmerking"] as string ?? null),
                    (DateTime)reader["ordertime"],
                    (byte)reader["bar"],
                    (byte)reader["keuken"]
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

        public void SetDelivered(Order order)
        {
            byte bar = SetBarByte(order);
            byte kitchen = SetKitchenByte(order);
            UpdateOrder(order, bar, kitchen);
            
        }
        private byte SetBarByte(Order order)
        {
            if (order.barStatus == OrderStatus.Delivered || order.barStatus != OrderStatus.Ready) { return 0; }
            return 1;
        }
        private byte SetKitchenByte(Order order)
        {
            if (order.kitchenStatus == OrderStatus.Delivered && order.kitchenStatus != OrderStatus.Ready) { return 0; }
            return 1;
        }

        private void UpdateOrder(Order order, byte bar, byte kitchen)
        {
            string query = $"UPDATE [order] SET [status] = @orderStatus, [bar] = @bar, [keuken] = @kitchen WHERE [orderId] = @OrderId";
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderId", order.OrderID),
                new SqlParameter("@orderStatus", order.Status.ToString()),
                new SqlParameter("@bar",bar),
                new SqlParameter("@kitchen", kitchen)
            };
            ExecuteEditQuery(query, parameters);
        }

    }
}
