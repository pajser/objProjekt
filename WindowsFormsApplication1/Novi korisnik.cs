using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Novi_korisnik : Form
    {
        public Novi_korisnik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            bool uspjesnost = dodajKorisnika(this.textBox1.Text,this.textBox2.Text, this.textBox3.Text, this.textBox4.Text);
                this.Close();
        }

        //private static string connStr = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;
        private static string connStr =  System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;

        public bool dodajKorisnika(string user, string pass, string imePrezime, string jmbag)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO KorisnickiRacun Values ('" + user + "', '" + pass + "', '" + imePrezime + "', '" + jmbag + "')";

            try
            {
                conn.Open();
                int test = command.ExecuteNonQuery();
                if (test > 0)
                {
                    return true;
                }
            }

            catch (Exception e)
            {
                return false;
            }

            return false;

        }
        private void Novi_korisnik_Load(object sender, EventArgs e)
        {

        }
    }
}
