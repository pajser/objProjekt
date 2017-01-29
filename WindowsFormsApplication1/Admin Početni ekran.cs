using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Admin_Početni_ekran : Form
    {
        private KorisnickiRacunPredlozak Korisnik;
        private string pamti = "nista";
       
        public Admin_Početni_ekran(KorisnickiRacunPredlozak idKor, string zapamcen)
        {
            this.pamti = zapamcen;
            Korisnik = idKor;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Novi_korisnik korisnik = new Novi_korisnik();
            korisnik.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pregled_timova timovi = new Pregled_timova();
            timovi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.pamti != "nista") { Form1 login = new Form1(this.pamti);
                login.Show();
            }
            else { Form1 login = new Form1();
                login.Show();
            }        
        }
    
        private void Admin_Početni_ekran_Load(object sender, EventArgs e)
        {
        }
    }
}
