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
        public void CreateInvoice(Tafel table, Employee employee)
        {
            string query = "INSERT INTO [rekening](tafelnr, serveerderid) VALUES (@tableNumber, @EmployeeId)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@tableNumber", table.TafelNummer);
            sqlParameters[1] = new SqlParameter("@EmployeeId", employee.employeeId);
            ExecuteEditQuery(query, sqlParameters);
        }

        public List<Orderline> GetOrdersForBill(Bill bill)
        {
            string query = "select rekening.rekeningnr, [dbo].[order].orderid, tafelnr, opmerking, " +
                "[order].[status], serveerderid, orderlinenr, aantal, naam, prijs, artikel.artikelid, categorie " +
                "from [dbo].[order] " +
                "join rekening on rekening.rekeningnr = [dbo].[order].rekeningnr " +
                "join orderline on orderline.orderid = [dbo].[order].orderid " +
                "join artikel on artikel.artikelid = orderline.artikelid " +
                "where rekening.tafelnr=@tafelnr and status != 'paid'"; ;


            SqlCommand command = new SqlCommand(query, OpenConnection());
            command.Parameters.AddWithValue("@tafelnr", bill.table.TafelNummer);

            SqlDataReader reader = command.ExecuteReader();
            List<Orderline> orderlines = new List<Orderline>();
            
         

            while (reader.Read())
            {
                Orderline orderline = ReadOrdersBill(reader);
                orderlines.Add(orderline);
            }
            reader.Close();
            CloseConnection();
            

            return orderlines;
        }
        public Orderline ReadOrdersBill(SqlDataReader reader)
        {



            Order order = new Order
                 (
                    (int)reader["rekeningnr"],
                (int)reader["orderid"],
                     (int)reader["tafelnr"],
                   (OrderStatus)Enum.Parse(typeof(OrderStatus), (string)reader["status"])


                 );


            Product product = new Product
                 (reader["naam"] as string,
                 reader["categorie"] as string,
                 (decimal)reader["prijs"]
                 );


            Orderline orderline = new Orderline(
                order, (int)reader["aantal"], product);



            order.orderlines.Add(orderline);


            return orderline;
        }
    }
}
