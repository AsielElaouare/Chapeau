using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ChapeauModel;

namespace ChapeauDAL
{
    public class ChefDao : BaseDao
    {
        public List<Chef> GetAllChefs()
        {
            string query = "SELECT StudentId, Name FROM [TABLE]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Chef> ReadTables(DataTable dataTable)
        {
            List<Chef> chefs = new List<Chef>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Chef chef = new Chef()
                {
                    Id = (int)dr["StudentId"],
                    Name = dr["Name"].ToString()
                };
                chefs.Add(chef);
            }
            return chefs;
        }
    }
}