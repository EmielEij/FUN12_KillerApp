using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace honkballapp
{
    public partial class Form1 : Form
    {
        Competitie MLB = new Competitie("MLB", 2019, "MLB");
        public Form1()
        {
            InitializeComponent();
            int Index = MLB.teams.Count();
            for (int i = 0; i < Index; i++)
            {
                comboBox1.Items.Add(MLB.teams[i].Naam());
            }
            for (int i = 0; i < Index; i++)
            { 
            comboBox2.Items.Add(MLB.teams[i].Naam());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Index = MLB.teams.Count();
            for (int i = 0; i < Index; i++)
            {
                listBox1.Items.Add(MLB.teams[i].Naam());
            }
            MLB.UpdateWedstrijden();
            Index = MLB.GespeeldeWedstrijden.Count();
            for (int i = 0; i < Index; i++)
            {
                listBox3.Items.Add(MLB.GespeeldeWedstrijden[i].uitslag());
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            listBox2.DataSource = MLB.teams[index].spelers;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int thuisTeamID = comboBox1.SelectedIndex;
            int uitTeamID = comboBox2.SelectedIndex;
            int uitslagThuisTeam = Convert.ToInt32(textBox1.Text);
            int uitslagUitTeam = Convert.ToInt32(textBox2.Text);

            MLB.VoegWedstrijdToe(thuisTeamID, uitTeamID, uitslagThuisTeam, uitslagUitTeam);
            listBox3.Items.Clear();
            int index = MLB.GespeeldeWedstrijden.Count;
            for (int i = 0; i < index; i++)
            {
                listBox3.Items.Add(MLB.GespeeldeWedstrijden[i].uitslag());
            }
        }
    }
}
