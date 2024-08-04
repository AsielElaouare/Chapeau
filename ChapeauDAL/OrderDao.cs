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

        public void StoreNewOrder(Order order)
        {
            try
            {  
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
                command.Parameters.AddWithValue("@timeOfOrder", order.OrderTime.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@selectedTable", $"{order.Table.TafelNummer}");
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                 order.SetOrderID( Convert.ToInt32((int)reader["newOrderID"]));
                    
                }
                reader.Close();
                foreach (Orderline line in order.orderlines)
                {
                    StoreOrderline(line, order.OrderID);
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
            command.Parameters.AddWithValue("@artikelid", orderline.product.Artikelid);
            command.Parameters.AddWithValue("@aantal", orderline.Quantity);
            command.ExecuteNonQuery();
        }
        private void StoreOrderline(Orderline orderline, int orderid)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [orderline] (orderid, aantal, opmerking, artikelid) VALUES (@orderId, @aantal, @opmerking, @artikelid)", OpenConnection());
            command.Parameters.AddWithValue("@orderId", orderid);
            command.Parameters.AddWithValue("@aantal", orderline.Quantity);
            command.Parameters.AddWithValue("@opmerking", string.IsNullOrEmpty(orderline.Commentary) ? (object)DBNull.Value : orderline.Commentary);
            command.Parameters.AddWithValue("@artikelid", orderline.product.Artikelid);
            command.ExecuteNonQuery();
        }
        public List<Order> GetOrders(OrderStatus status, ProductCategorie[] productCategories, DateOnly dateToday)
        {
            string query = @"
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
            WHERE [status] = @status AND (ak.categorie = @category1 OR ak.categorie = @category2 OR ak.categorie =  @category3  OR ak.categorie = @category4 OR ak.categorie = @category5) AND CAST([order].ordertime AS DATE) = @dateToday
            GROUP BY 
                rk.tafelnr, [order].orderid, [order].[status], [order].orderTime
            ORDER BY 
                [order].orderid, rk.tafelnr";
            try
            {
                List<Order> orders = new List<Order>();
                SqlCommand command = new SqlCommand(query, OpenConnection());
                command.Parameters.AddWithValue("@status", status.ToString());
                command.Parameters.AddWithValue("@category1", productCategories[0].ToString());
                command.Parameters.AddWithValue("@category2", productCategories[1].ToString());
                command.Parameters.AddWithValue("@category3", productCategories[2].ToString());
                command.Parameters.AddWithValue("@category4", productCategories[3].ToString());
                command.Parameters.AddWithValue("@category5", productCategories[4].ToString());
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
            //public Order(int OrderID, int TafelNR, string Status, Orderline OrderLine, DateTime orderTime)

            Order currentOrder = null;
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
                    new Table((int)reader["tafelnr"]),
                    (string)reader["status"],
                    (DateTime)reader["orderTime"]
            );

            int index = 0;
            foreach (string productName in productsArray)
            {
                currentOrderLine = new Orderline(currentOrder, int.Parse(quantityPerProduct[index]), new Product(productName, categories[index]), productComment[index]);
                currentOrder.orderlines.Add(currentOrderLine);
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

        public List<Order> GetOrdersForTable(Table table)
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
                        new Table((int)reader["tafelnr"]),
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
    }
}
