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
        private Tafel ReadTafel(SqlDataReader reader)
        {
            Tafel tafel = new Tafel(
                (int)reader["tafelnr"],
                (int)reader["zitplaats"]);
            return tafel;
        }
    }
}
