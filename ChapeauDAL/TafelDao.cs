using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class TafelDao : BaseDao
    {
        public List<Tafel> GetAllTafels()
        {
            SqlCommand command = new SqlCommand("SELECT [tafelnr],[zitplaats] FROM [tafel]", OpenConnection());

            SqlDataReader reader = command.ExecuteReader();
            List<Tafel> tafels = new List<Tafel>();

            while (reader.Read())
            {
                Tafel tafel = ReadTafel(reader);
                tafels.Add(tafel);
            }
            reader.Close();
            CloseConnection();

            return tafels;
        }
        public List<Tafel> GetAllTablesAndStatus()
        {
            SqlCommand command = new SqlCommand("SELECT [tafelnr],[zitplaats],[status] FROM [tafel]", OpenConnection());

            SqlDataReader reader = command.ExecuteReader();
            List<Tafel> tafels = new List<Tafel>();

            while (reader.Read())
            {
                Tafel tafel = ReadTableAndStatus(reader);
                tafels.Add(tafel);
            }
            reader.Close();
            CloseConnection();

            return tafels;
        }

        private Tafel ReadTafel(SqlDataReader reader)
        {
            Tafel tafel = new Tafel(
                (int)reader["tafelnr"],
                (int)reader["zitplaats"]);
            return tafel;
        }
        private Tafel ReadTableAndStatus(SqlDataReader reader)
        {
            Tafel tafel = new Tafel(
                (int)reader["tafelnr"],
                (int)reader["zitplaats"],
                (string)reader["status"]);
            return tafel;
        }

        public void UpdateTableStatus(Tafel table, string status)
        {
            string query = "UPDATE [tafel] SET [status] = @status WHERE tafelnr = @tableNumber";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@status", status);
            sqlParameters[1] = new SqlParameter("@tableNumber", table.TafelNummer);
            ExecuteEditQuery(query, sqlParameters);
            
        }
    }
}
