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
        public Employee GetPassWordbyID(string personeelNummer)
        {
            string query = "SELECT [personeelnummer], [naam] , [wachtwoord], [functie] FROM [personeel] WHERE [personeelnummer] = @personeelnummer";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@personeelnummer", personeelNummer);
            return ReadSingleRow(ExecuteSelectQuery(query, sqlParameters));
        }

        public bool GetByEmployeeId(string employeeId)
        {
            string query = "SELECT [personeelnummer], [naam] FROM [personeel] WHERE [personeelnummer] = @EmployeeId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@EmployeeId", employeeId);
            return ReadIfEmployeeIdExists(ExecuteSelectQuery(query, sqlParameters));
        }
        private bool ReadIfEmployeeIdExists(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }

        private Employee ReadSingleRow(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                int employeeId = (int)dr["personeelnummer"];
                string Name = dr["naam"].ToString();
                string password = dr["wachtwoord"].ToString();
                string role = dr["functie"].ToString();
                Employee employee = new Employee(employeeId, Name, password, role);
                return employee;
            }
            else { throw new Exception("Verkeerde gebruikersnaam of wachtwoord"); }
        }

        




    }
}
