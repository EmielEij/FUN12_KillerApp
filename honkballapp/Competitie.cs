using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///voor de connectie
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace honkballapp
{
    public class Competitie
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Honkbalcompetitie.mdf;Integrated Security=True";
        private SqlConnection conn = new SqlConnection(connectionString);
        public string Naam { get; private set; }
        public int Jaar { get; private set; }
        public string Klasse { get; private set; }

        public List<Team> teams { get; private set; }

        public List<wedstrijd> GespeeldeWedstrijden { get; private set; }

        public Competitie(string naam, int jaar, string klasse)
        {
            this.Naam = naam;
            this.Jaar = jaar;
            this.Klasse = klasse;
            teams = new List<Team>();
            GespeeldeWedstrijden = new List<wedstrijd>();
            Laadteams();
        }
        public void Laadteams()
        {
            teams.Clear();
            conn.Open(); 
            string Query = "select * from Teams";
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int TeamID = reader.GetInt32(0);
                    string naamTeam = reader.GetString(1);                
                    Team team = new Team(TeamID,naamTeam);
                    teams.Add(team);         
                }
            }
            conn.Close();
        }
        public void VoegWedstrijdToe(int thuisTeamID,int uitTeamID ,int puntenThuisTeam, int puntenUitteam )
        {
            GespeeldeWedstrijden.Clear();
            UpdateWedstrijden();
            conn.Open();
            int wedstrijdID = GespeeldeWedstrijden.Count()+1;
            wedstrijd wedstrijd = new wedstrijd(wedstrijdID, uitTeamID+1, thuisTeamID+1, puntenThuisTeam, puntenUitteam);
            GespeeldeWedstrijden.Add(wedstrijd);
            //string Query = "insert into Resultaat (wedstrijdID, puntenThuisTeam, puntenUitTeam) values ("+wedstrijdID+","+puntenThuisTeam+","+puntenUitteam+ ") insert into Wedstrijd (ResultaatWedstrijd,ThuisTeamID,UitTeamID) values("+wedstrijdID+","+ thuisTeamID + ","+ uitTeamID+")";
            string Query= "insert into Resultaat(wedstrijdID, puntenThuisTeam, puntenUitTeam) values(@wedstrijdID, @puntenThuisteam, @puntenUitteam) insert into Wedstrijd (ResultaatWedstrijdID,ThuisTeamID,UitTeamID) values(@wedastijdID, @thuisTeamID, @uiteamID)";
            
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.Add("@wedstrijdID", SqlDbType.Int).Value = wedstrijdID;
            cmd.Parameters.Add("@puntenThuisteam", SqlDbType.Int).Value = puntenThuisTeam;
            cmd.Parameters.Add("@puntenUitteam", SqlDbType.Int).Value = puntenUitteam;
            cmd.Parameters.Add("@wedastijdID", SqlDbType.Int).Value = wedstrijdID;
            cmd.Parameters.Add("@thuisTeamID", SqlDbType.Int).Value = thuisTeamID+1;
            cmd.Parameters.Add("@uiteamID", SqlDbType.Int).Value = uitTeamID+1;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateWedstrijden()
        {
            GespeeldeWedstrijden.Clear();
            conn.Open();
            string Query = "select wedstrijdID,puntenThuisTeam,puntenUitTeam,ThuisTeamID,UitTeamID from Resultaat inner join Wedstrijd on Resultaat.wedstrijdID = Wedstrijd.ResultaatWedstrijdID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int wedstrijdID= reader.GetInt32(0);
                    int puntenthuisteam = reader.GetInt32(1);
                    int puntenuitteeam = reader.GetInt32(2);
                    int thuisteamID = reader.GetInt32(3);
                    int uitteamID = reader.GetInt32(4);
                    wedstrijd wedstrijd = new wedstrijd(wedstrijdID, uitteamID, thuisteamID, puntenthuisteam, puntenuitteeam);
                    GespeeldeWedstrijden.Add(wedstrijd);
                }
            }
            conn.Close();
        }
        
        

    }
}
