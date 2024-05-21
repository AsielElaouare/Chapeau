using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Text;
using System.Xml.Linq;
using System.Collections;

namespace ChapeauDAL
{
    public class ArticleDao : BaseDao
    {
        public List<Article> GetAllArticles()
        {

            string query = "SELECT * FROM [Artikel]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Article> GetAllArticles(int orderId)
        {

            string query = "SELECT * FROM [Artikel] WHERE orderId = @orderId";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@orderId", orderId)
            };
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Article> ReadTables(DataTable dataTable)
        {
            List<Article> articles = new List<Article>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Article article = new Article()
                {
                    articleId = (int)dr["artikelid"],
                    name = (string)dr["name"],
                    category = (string)dr["categorie"],
                    stock = (int)dr["voorraad"]
                };
                articles.Add(article);
            }
            return articles;
        }

    }
}
