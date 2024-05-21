using System.Collections.Generic;

namespace ChapeauModel
{
    public class Order
    {
        public List<Article> articles;
        public int orderId { get; set; }
        public OrderStatus status { get; set; }
        public int numberOfArticles { get; set; }
        public string comment { get; set; }
        public int tableNr { get; set; }
        public Order()
        {
            articles = new List<Article>();
        }
    }
}