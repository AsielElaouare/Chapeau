using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderDao :BaseDao
    {
        public int MakeNewOrder(DateTime timeOfOrder, int selectedtable)
        {
            int orderId=0;
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
            command.Parameters.AddWithValue("@timeOfOrder", timeOfOrder.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@selectedTable", $"{selectedtable}");
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                orderId = Convert.ToInt32((int)reader["newOrderID"]);
            }
            reader.Close();
            CloseConnection();
            return orderId;
        }

    }
}
