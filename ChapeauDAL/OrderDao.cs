using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ChapeauModel;
using System;
using System.Collections;

namespace ChapeauDAL
{
    public class OrderDao : BaseDao
    {
        public List<Order> GetAllOrders()
        {
            //SQL join needed for Orderline,  Oreder table and article table. Implement query when mockdata is available!
            string query = "SELECT * FROM [order]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order()
                {
                    orderId = (int)dr["orderid"],
                    status = Enum.TryParse((string)dr["status"], out OrderStatus status) ? status : OrderStatus.Pending,
                    numberOfArticles = (int)dr["orderid"],
                    comment = (string)dr["opmerking"],

                };
                orders.Add(order);
            }
            return orders;
        }
        private void GetArticlesForOrder(List<Order> orders)
        {
            ArticleDao articlesForOrder = new ArticleDao();

            foreach (Order order in orders)
            {
                List<Article> articles = articlesForOrder.GetAllArticles(order.orderId);
                order.articles = articles;
            }
        }
    }
}