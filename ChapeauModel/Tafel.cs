using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Tafel
    {
        public int TafelNummer { get; private set; }
        public int ZitPlaatsen { get; private set; }

        public TableStatusEnum Status { get; set; }

        public Tafel(int tafelNummer, int zitPlaatsen)
        {
            TafelNummer = tafelNummer;
            ZitPlaatsen = zitPlaatsen;
            Status = TableStatusEnum.Free;
        }
    }
}
