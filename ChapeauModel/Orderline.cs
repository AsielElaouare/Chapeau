using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Orderline
    {
      
        public int OrderID { get; private set; }
        public int Aantal { get;  set; }
        public string Opmerking { get; private set; }
        public int ArtikelID { get; private set; }
        public Orderline(int orderID, int aantal, string opmerking, int artikelID)
        {
            OrderID = orderID;
            Aantal = aantal;
            Opmerking = opmerking;
            ArtikelID = artikelID;
        }
        public void IncreaseQuantity()
        {
            Aantal ++;
        }

        public void DecreaseQuantity()
        {
            Aantal --;
        }
        public void SetOrderID(int orderID)
        {
            OrderID = orderID;
        }
        public void AddComment(string comment)
        {
            Opmerking = comment;
        }
    }
}
