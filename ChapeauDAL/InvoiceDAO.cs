using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    public class InvoiceDAO : BaseDao
    {
        //hier maak ik een nieuwe invoice aan in de database
        public void CreateInvoice(Table table, Employee employee)
        {
           
            //hij autoincrement de invoicenummer met 1 op het moment dat er nieuwe gegevens in de database komen
            //dus we voegen alleen tafelnr en serveerderid in de database
            string query = "INSERT INTO [rekening](tafelnr, serveerderid) " +
               
                "VALUES (@tableNumber, @EmployeeId)";

            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@tableNumber", table.TafelNummer);
            command.Parameters.AddWithValue("@EmployeeId", employee.employeeId);
            command.ExecuteNonQuery();
           
        }

        // op het moment van betaling wordt met deze methode de bill in de database geupdate
        public void FinishInvoice(Bill bill)
        { 
            try
            {
                string query =

                    $"update rekening set review= @review, totaalprijs = @totaalprijs, fooi=@fooi, onbetaald=@onbetaald where rekeningnr=@rekeningnr;";
                SqlParameter[] parameters =
                {
                new SqlParameter("@review", bill.review),
                 new SqlParameter("@totaalprijs", bill.totalPrice),
                new SqlParameter("@rekeningnr", bill.billNumber ),
                new SqlParameter("@fooi", bill.tip ),
                new SqlParameter("@onbetaald", bill.unpaid )
            };
                ExecuteEditQuery(query, parameters);
            } 
            //op het moment dat er een exception vallt wordt het hier opgevangen en verduidelijkt wat er fout is gegaan
            catch (Exception ex ){ throw new Exception("er ging iets fout bij het schrijven naar de database", ex);  }
            



        }
        // deze methode neemt een bill object als argument, vult hem op, en returnt hem
        public Bill GetOrdersForBill(Bill bill)
        { // de query haalt alle gegevens op die ik nodig heb om een bill object te vullen door de order tabel te combineren met rekening, orderline en artikel
            string query = "select rekening.rekeningnr, onbetaald, review, fooi, " +
                "serveerderid, orderlinenr, aantal, artikel.naam, prijs, artikel.artikelid, categorie " +
                "from [dbo].[order] " +
                "join rekening on rekening.rekeningnr = [dbo].[order].rekeningnr " +
                "join orderline on orderline.orderid = [dbo].[order].orderid " +
                "join artikel on artikel.artikelid = orderline.artikelid " +
                "where rekening.rekeningnr in (SELECT MAX(rekeningnr) as rekeningnr FROM [rekening] where tafelnr=@tafelnr)"; 


            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@tafelnr", bill.table.TafelNummer);

            SqlDataReader reader = command.ExecuteReader();

            List<Orderline> orderlines = new List<Orderline>();

            if (reader.Read())
            {
                //er wordt gecheckt of het in de database als nul is opgeslagen
                if (!reader.IsDBNull(reader.GetOrdinal("onbetaald")))
                { bill.unpaid = (decimal?)reader["onbetaald"]; }

                if (!reader.IsDBNull(reader.GetOrdinal("fooi")))
                { bill.tip = (decimal)reader["fooi"]; }
                else { bill.tip = 0; }

                    // ik lees alleen de eerste lijn om de bill object te vullen
                    bill.review = reader["review"] as string;
                bill.billNumber = (int)reader["rekeningnr"];
             
              
                //vervolgens vul ik een orderline object per regel en stel ik de lijst van orderlines uiteindelijk gelijk aan die van mijn bill
                do

                {
                    Orderline orderline = ReadOrdersBill(reader);
                    orderlines.Add(orderline);
                }

                while (reader.Read());
            }
            reader.Close();
            CloseConnection();

           
            bill.orderlines = orderlines;

            return bill;
        }
        // hier vul ik eerst een product object die ik aan orderline meegeef waarna ik een lijst van orderlines weer aan bill meegeef
        public Orderline ReadOrdersBill(SqlDataReader reader)
        {
            Product product = new Product
                 (reader["naam"] as string,
                 reader["categorie"] as string,
                 (decimal)reader["prijs"]
                 );


            Orderline orderline = new Orderline(
                 (int)reader["rekeningnr"], (int)reader["aantal"], product);
            return orderline;
        }
    }
}
