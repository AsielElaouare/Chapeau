using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Table
    {
        public int TafelNummer { get; private set; }
        public int ZitPlaatsen { get; private set; }
    

        public TableStatusEnum Status { get; set; }

        public Table(int tafelNummer, int zitPlaatsen)
        {
            TafelNummer = tafelNummer;
            ZitPlaatsen = zitPlaatsen;
        }

        public Table(int tafelNummer, int zitPlaatsen, string status) : this(tafelNummer, zitPlaatsen)
        {
            Status = SetStatus(status);
        }

        public TableStatusEnum SetStatus(string status)
        {
            switch (status)
            {
                case "Vrij": return TableStatusEnum.Free;
                case "Bezet": return TableStatusEnum.Occupied;
                case "Besteld": return TableStatusEnum.Ordered;
                default: return TableStatusEnum.Free;
            }
        }

        
    }
}
