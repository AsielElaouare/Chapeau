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
    }
}
