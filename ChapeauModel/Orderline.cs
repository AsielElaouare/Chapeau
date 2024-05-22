using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Orderline
    {
        public int OrderlineNr { get; private set; }
        public int OrderID { get; private set; }
        public int Aantal { get; private set; }
        public string Opmerking { get; private set; }
        public int ArtikelID { get; private set; }
        public Orderline(int orderlineNr, int orderID, int aantal, string opmerking, int artikelID)
        {
            OrderlineNr = orderlineNr;
            OrderID = orderID;
            Aantal = aantal;
            Opmerking = opmerking;
            ArtikelID = artikelID;
        }
    }
}
