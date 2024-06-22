using ChapeauModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderDao : BaseDao
    {

        public void StoreNewOrder(DateTime timeOfOrder, int selectedtable, List<Orderline> orderlines)
        {
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
            try
            {

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
            catch (Exception ex)
            {
                throw new Exception("Error occurred while executing database operations.", ex);
            }

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
        public List<Order> GetOrders(OrderStatus status, OrderType orderType, DateOnly dateToday)
        {
            string query;
            if (orderType == OrderType.Kitchen)
            {
                query = GetKitchenQuery();
            }
            else
            {
                query = GetBarQuery();
            }
            try
            {
                List<Order> orders = new List<Order>();
                SqlCommand command = new SqlCommand(query, OpenConnection());
                command.Parameters.AddWithValue("@status", status.ToString());
                command.Parameters.AddWithValue("@dateToday", dateToday.ToString("yyyy-MM-dd"));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Order order = ReadOrders(reader);
                    orders.Add(order);
                }
                reader.Close();
                CloseConnection();
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while executing database operations.", ex);
            }

        }

        public Order ReadOrders(SqlDataReader reader)
        {
            Order currentOrder = null;
            Product currentProduct;
            Orderline currentOrderLine;

            string quantity = (string)reader["concatenated_quantity"];
            string[] quantityPerProduct = quantity.Split(',');

            string products = (string)reader["Article"];
            string[] productsArray = products.Split(';');

            string comments = (string)reader["opmerking"];
            string[] productComment = comments.Split(';');

            string category = (string)reader["categorie"];
            string[] categories = category.Split(',');

            currentOrder = new Order
            (
                    (int)reader["orderid"],
                    (int)reader["tafelnr"],
                    (string)reader["status"],
                    new Orderline((int)reader["orderId"], (int)reader["aantal"], reader["opmerking"] as string ?? null),
                    (DateTime)reader["orderTime"]
            );


            int index = 0;
            foreach (string productName in productsArray)
            {
                currentProduct = new Product(productName, categories[index], int.Parse(quantityPerProduct[index]), productComment[index]);
                currentOrder.ProductList.Add(currentProduct);
                index++;
            }
            return currentOrder;
        }


        public void CompleteDeliveredOrder(int orderId, OrderStatus orderStatus)
        {
            string query = $"UPDATE [order] SET [status] = @orderStatus, [bar] = 1 WHERE [orderId] = @OrderId";
            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderId", orderId),
                new SqlParameter("@orderStatus", orderStatus.ToString())
            };
            ExecuteEditQuery(query, parameters);

        }
        public void CompleteOrder(int orderId, OrderStatus orderStatus, OrderType barOrKitchen)
        {
            string query;
            if (barOrKitchen == OrderType.Bar)
                query = $"UPDATE [order] SET [status] = @orderStatus, [bar] = 1 WHERE [orderId] = @OrderId";
            else
                query = $"UPDATE [order] SET [status] = @orderStatus, [keuken] = 1 WHERE [orderId] = @OrderId";

            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderId", orderId),
                new SqlParameter("@orderStatus", orderStatus.ToString())
            };
            ExecuteEditQuery(query, parameters);

        }
        public void StartOrder(int orderId, OrderStatus orderStatus, OrderType barOrKitchen)
        {
            string query;
            if (barOrKitchen == OrderType.Bar)
                query = $"UPDATE [order] SET [status] = @orderStatus, [bar] = 0 WHERE [orderId] = @OrderId";
            else
                query = $"UPDATE [order] SET [status] = @orderStatus, [keuken] = 0 WHERE [orderId] = @OrderId";

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
                    rk.tafelnr = @tableNumber AND [status] IS NOT NULL AND [status] <> @deliveredStatus AND [bar] IS NOT NULL AND [keuken] IS NOT NULL 
             ORDER BY 
                   [order].ordertime DESC";

            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@tableNumber", table.TafelNummer);
            command.Parameters.AddWithValue("@deliveredStatus", "Delivered");
            SqlDataReader reader = command.ExecuteReader();

            List<Order> orders = new List<Order>();
            Dictionary<int, Order> orderDict = new Dictionary<int, Order>();

            while (reader.Read())
            {
                int orderId = (int)reader["OrderID"];
                if (!orderDict.ContainsKey(orderId))
                {
                    Order order = new Order
                    (
                        (int)reader["OrderID"],
                        (int)reader["tafelnr"],
                        (string)reader["status"],
                        new Orderline((int)reader["OrderID"], (int)reader["Aantal"], reader["Opmerking"] as string ?? null),
                        (DateTime)reader["OrderTime"]
                    );
                    orderDict[orderId] = order;
                }

                Product product = new Product((string)reader["Article"], (string)reader["Categorie"]);
                orderDict[orderId].ProductList.Add(product);


                orderDict[orderId].setBarStatus((byte)reader["bar"]);
                orderDict[orderId].setKitchenStatus((byte)reader["keuken"]);
            }

            reader.Close();
            CloseConnection();

            orders = orderDict.Values.ToList();
            return orders;
        }

        public void SetDelivered(Order order)
        {
            byte bar = SetBarByte(order);
            byte kitchen = SetKitchenByte(order);
            UpdateOrder(order, bar, kitchen);

        }
        private byte SetBarByte(Order order)
        {
            if (order.barStatus == OrderStatus.Delivered) { return 2; }
            else if (order.barStatus == OrderStatus.Ready) { return 1; }
            else if (order.barStatus == OrderStatus.Pending) { return 0; }
            return 0;
        }
        private byte SetKitchenByte(Order order)
        {
            if (order.kitchenStatus == OrderStatus.Delivered) { return 2; }
            else if (order.kitchenStatus == OrderStatus.Ready) { return 1; }
            else if (order.barStatus == OrderStatus.Pending) { return 0; }
            return 0;
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


        private string GetBarQuery()
        {
            string query = $@"
            SELECT 
                rk.tafelnr,
                [order].orderid,
                SUM(ol.aantal) AS aantal,
                STRING_AGG(COALESCE(ol.opmerking, ''), '; ') AS opmerking,
                STRING_AGG(OL.aantal, ',') AS concatenated_quantity,
                [order].[status],
                STRING_AGG(ak.naam, '; ') AS Article, 
                STRING_AGG(ak.categorie, ', ') AS categorie,
	            [order].ordertime AS [orderTime] 
            FROM 
                [order]
            JOIN 
                orderline AS OL ON [order].[orderid] = OL.orderid
            JOIN 
                rekening AS rk ON [order].rekeningnr = rk.rekeningnr
            JOIN 
                artikel AS ak ON ol.artikelid = ak.artikelid
            WHERE [status] = @status AND (ak.categorie = 'bier' OR ak.categorie = 'KoffieThee' OR ak.categorie =  'Gedistilleerd'  OR ak.categorie =  'Frisdrank' OR ak.categorie =  'wijn') AND CAST([order].ordertime AS DATE) = @dateToday
            GROUP BY 
                rk.tafelnr, [order].orderid, [order].[status], [order].orderTime
            ORDER BY 
                rk.tafelnr, [order].orderid";
            return query;
        }

        private string GetKitchenQuery()
        {
            string query = $@"
            SELECT 
                rk.tafelnr,
                [order].orderid,
                SUM(ol.aantal) AS aantal,
                STRING_AGG(COALESCE(ol.opmerking, ''), '; ') AS opmerking,
                STRING_AGG(OL.aantal, ',') AS concatenated_quantity,
                [order].[status],
                STRING_AGG(ak.naam, '; ') AS Article, 
                STRING_AGG(ak.categorie, ', ') AS categorie,
	            [order].ordertime AS [orderTime] 
            FROM 
                [order]
            JOIN 
                orderline AS OL ON [order].[orderid] = OL.orderid
            JOIN 
                rekening AS rk ON [order].rekeningnr = rk.rekeningnr
            JOIN 
                artikel AS ak ON ol.artikelid = ak.artikelid
            WHERE [status] = @status AND (ak.categorie = 'Hoofdgerechten' OR ak.categorie = 'Nagerechten' OR ak.categorie = 'Tussengerechten' OR ak.categorie = 'Voorgerechten') AND CAST([order].ordertime AS DATE) = @dateToday
            GROUP BY 
                rk.tafelnr, [order].orderid, [order].[status], [order].orderTime
            ORDER BY 
                rk.tafelnr, [order].orderid";
            return query;
        }
    }
}
