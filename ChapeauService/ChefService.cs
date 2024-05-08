using ChapeauDAL;
using ChapeauModel;
using System.Collections.Generic;

namespace ChapeauService
{
    public class ChefService
    {
        private ChefDao chefdb;

        public ChefService()
        {
            chefdb = new ChefDao();
        }

        public List<Chef> GetChefs()
        {
            List<Chef> chefs = chefdb.GetAllChefs();
            return chefs;
        }
    }
}