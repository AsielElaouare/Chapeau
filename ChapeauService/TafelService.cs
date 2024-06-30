using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class TafelService
    {
        private TafelDao tafeldb;
        public TafelService()
        {
            tafeldb = new TafelDao();
        }
        public List<Table> GetTafel()
        {
            return tafeldb.GetAllTafels();
        }

        public List<Table> GetTablesAndStatus()
        {
            return tafeldb.GetAllTablesAndStatus();
        }

        public void UpdateTableStatus(Table table)
        {
            tafeldb.UpdateTableStatus(table, ConvertTableStatus(table));
        }

        private string ConvertTableStatus(Table table)
        {
            switch(table.Status)
            {
                case TableStatusEnum.Free: return "Vrij";
                case TableStatusEnum.Reserved: return "Gereserveerd";
                case TableStatusEnum.Occupied: return "Bezet";
                case TableStatusEnum.Ordered: return "Besteld";
                default: return "Vrij";
            }
        }
    }
}
