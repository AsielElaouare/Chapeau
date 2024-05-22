﻿using ChapeauDAL;
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
        public List<Tafel> GetTafel()
        {
            return tafeldb.GetAllTafels();
        }
    }
}