using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///voor de connectie
using System.Data.SqlClient;
using System.Windows.Forms;


namespace honkballapp
{
    public class Team
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Honkbalcompetitie.mdf;Integrated Security=True";
        private SqlConnection conn = new SqlConnection(connectionString);
        public int TeamID { get; private set; }

        public string NaamTeam { get; private set; }

        public List<speler> spelers { get; private set; }

        public Team(int teamID, string naamTeam)
        {
            TeamID = teamID;
            this.NaamTeam = naamTeam;
            spelers = new List<speler>();
            Laadspelers();
        }
        public void Laadspelers()
        {
            spelers.Clear();
            conn.Open();
            string Query = "Select * from Spelers where TeamID ="+TeamID;
            SqlCommand cmd = new SqlCommand(Query, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //id titel file location file size date lastplayed
                    int BondID = reader.GetInt32(0);
                    string naamSpeler = reader.GetString(1);
                    int rugNummer= reader.GetInt32(2);
                    int positie= reader.GetInt32(3);
                    int linupNummer= reader.GetInt32(4);

                    speler speler = new speler(BondID,linupNummer,rugNummer,positie,naamSpeler);
                    spelers.Add(speler);
                }

            }
            conn.Close();

        }
        public override string ToString()
        {
            return @"ID=" + TeamID + " Naam Team= " + NaamTeam;
        }
        public string Naam()
        {
            return NaamTeam;
        }
    }
}
