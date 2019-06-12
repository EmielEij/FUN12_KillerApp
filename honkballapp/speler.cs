using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace honkballapp
{
    public class speler
    {
        public int bondID { get; private set; }
        public int lineupNM { get; private set; }
        public int rugNummer { get; private set; }
        public int positie { get; private set; }
        public string naam { get; private set; }

        public speler(int bondID, int lineupNM, int rugNummer, int positie,string naam)
        {
            this.bondID = bondID;
            this.lineupNM = lineupNM;
            this.rugNummer = rugNummer;
            this.positie = positie;
            this.naam = naam;
        }
        public override string ToString()
        {
            return @"Naam Speler= "+naam+" positie= "+positie+" linupNummer= "+lineupNM+" rugnummer= "+rugNummer+" bondID= "+bondID;
        }

    }
}
