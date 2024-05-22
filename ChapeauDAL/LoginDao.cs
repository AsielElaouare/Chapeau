using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class LoginDao : BaseDao
    {
        public Employee GetByPassWord(string hashedPassword)
        {
            string query = "SELECT personeelnummer, naam , wachtwoord FROM [Docent] WHERE wachtwoord = @password";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@password", hashedPassword);
            return ReadSingleRow(ExecuteSelectQuery(query, sqlParameters));
        }

        private Employee ReadSingleRow(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                int Id = (int)dr["personelnummer"];
                string Name = dr["naam"].ToString();
                string password = dr["wachtwoord"].ToString();
                string role = dr["functie"].ToString();
                Employee employee = new Employee(Id, Name, password, role);
                return employee;
            }
            else { throw new Exception("The DataTable is empty"); }
        }
    }
}
