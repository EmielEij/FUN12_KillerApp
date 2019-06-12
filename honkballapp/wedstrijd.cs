using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace honkballapp
{
    public class wedstrijd
    {
        public int wedstrijdID { get; private set; }

        public int uitteamID { get; private set; }

        public int thuisteamID { get; private set; }

        public int puntenthuisTeam { get; private set; }
        public int puntenuitTeam { get; private set; }

        public int winnaarID { get; private set; }

        public wedstrijd(int wedstrijdID, int uitteamID, int thuisteamID, int puntenthuisTeam, int puntenuitTeam)
        {
            this.wedstrijdID = wedstrijdID;
            this.uitteamID = uitteamID;
            this.thuisteamID = thuisteamID;
            this.puntenthuisTeam = puntenthuisTeam;
            this.puntenuitTeam = puntenuitTeam;
            if (puntenthuisTeam==puntenuitTeam)
            {
                winnaarID = -1;
            }
            else if (puntenthuisTeam >= puntenuitTeam)
            {
                winnaarID = thuisteamID;
            }
            else
            {
                winnaarID = uitteamID;
            }
        }
        public string uitslag()
        {
            return "thuisteam=" + thuisteamID + "heeft=" + puntenthuisTeam + " punten en uitteam=" + uitteamID + " heeft " + puntenuitTeam;
        }
    }
}
