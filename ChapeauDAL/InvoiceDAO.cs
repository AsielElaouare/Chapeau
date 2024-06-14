using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    public class InvoiceDAO : BaseDao
    {
        public void CreateInvoice(Bill bill)
        {
           /* string query = "INSERT INTO [rekening](tafelnr, serveerderid) " +
                "VALUES (@tableNumber, @EmployeeId)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@tableNumber", table.TafelNummer);
            sqlParameters[1] = new SqlParameter("@EmployeeId", employee.employeeId);
            ExecuteEditQuery(query, sqlParameters);
           */

            string query = "INSERT INTO [rekening](tafelnr, serveerderid) " +
                "OUTPUT INSERTED.rekeningnr " +
                "VALUES (@tableNumber, @EmployeeId)";

            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@tableNumber", bill.table.TafelNummer);
            command.Parameters.AddWithValue("@EmployeeId", bill.employee.employeeId);
            
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
               bill.billNumber = (int)reader["rekeningnr"];
            }
            reader.Close();
        }

        public Bill GetBillNumber(Bill bill)
        {
            string query =
                $"SELECT MAX(rekeningnr) as rekeningnr FROM [rekening] where tafelnr=@tafelnr;";
            
            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@tafelnr", bill.table.TafelNummer);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                bill.billNumber = Convert.ToInt32((int)reader["rekeningnr"]);
            }
            reader.Close();
            CloseConnection();

         

            return bill;
        

    }
           
        
        public void FinishInvoice(Bill bill)
        {
            if (bill.review == null) { bill.review = ""; }
            
            //if (bill.totalPrice == null) { bill.totalPrice = 0; }
            string query = 
               /* $"UPDATE [orderline] SET isbetaald = 1 from orderline " + 
                $"join [order] on [orderline].orderid=[order].orderid " +
                $"WHERE isbetaald=0 and rekeningnr=@rekeningnr " + */
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
        public Bill GetOrdersForBill(Bill bill)
        {
            string query = "select rekening.rekeningnr, [dbo].[order].orderid, tafelnr, opmerking, onbetaald, review, " +
                "[order].[status], serveerderid, orderlinenr, aantal, naam, prijs, artikel.artikelid, categorie " +
                "from [dbo].[order] " +
                "join rekening on rekening.rekeningnr = [dbo].[order].rekeningnr " +
                "join orderline on orderline.orderid = [dbo].[order].orderid " +
                "join artikel on artikel.artikelid = orderline.artikelid " +
                "where rekening.rekeningnr=@rekeningnr"; ;


            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@rekeningnr", bill.billNumber);

            SqlDataReader reader = command.ExecuteReader();
            List<Orderline> orderlines = new List<Orderline>();

            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("onbetaald")))
                { bill.unpaid = (decimal)reader["onbetaald"]; }

                bill.review = reader["review"] as string;
               
                do
                {
                    Orderline orderline = ReadOrdersBill(reader);

                    orderlines.Add(orderline);
                }

                while (reader.NextResult());
            }
            reader.Close();
            CloseConnection();

           
            bill.orderlines = orderlines;

            return bill;
        }
        public Orderline ReadOrdersBill(SqlDataReader reader)
        {



            Product product = new Product
                 (reader["naam"] as string,
                 reader["categorie"] as string,
                 (decimal)reader["prijs"]
                 );


            Orderline orderline = new Orderline(
                 (int)reader["rekeningnr"], (int)reader["aantal"], product);
                 //(bool)reader["isbetaald"]

            

           // order.orderlines.Add(orderline);


            return orderline;
        }
    }
}
