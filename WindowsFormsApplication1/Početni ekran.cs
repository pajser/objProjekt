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
    public partial class Početni : Form
    {
        private KorisnickiRacunPredlozak Korisnik;
        private string pamti="nista";
        public Početni(KorisnickiRacunPredlozak idKor, string zapamcen)
        {
            this.pamti = zapamcen;
            Korisnik = idKor;
            InitializeComponent();
        }

        private void mojtim_Click(object sender, EventArgs e)
        {
            int idtima = ClanTimaTablica.DohvatiIdTima(this.Korisnik.idKorisnickiRacun);
            if (idtima != 0)
            {
                Moj_tim moj_tim = new Moj_tim(idtima,Korisnik.idKorisnickiRacun);
                moj_tim.Show();
            }
            else System.Windows.MessageBox.Show("Nisi u timu");
        }
        private void pregledtim_Click(object sender, EventArgs e)
        {
            Pregled_timova timovi = new Pregled_timova(Korisnik.idKorisnickiRacun);
            timovi.Show();
        }
        private void kreirajtim_Click(object sender, EventArgs e)
        {
            int idtima = ClanTimaTablica.DohvatiIdTima(this.Korisnik.idKorisnickiRacun);
            if (idtima != 0) System.Windows.MessageBox.Show("Ne možeš kreirat tim dok si već u timu!");
            else {
                Tim tim = new Tim(this.Korisnik);
                tim.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Početni_Load(object sender, EventArgs e)
        {
            label1.Text = "Dobrodošao, " + Korisnik.imePrezime + "!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.pamti != "nista")
            {
                Form1 login = new Form1(this.pamti);
                login.Show();
            }
            else
            {
                Form1 login = new Form1();
                login.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int idtima = ClanTimaTablica.DohvatiIdTima(this.Korisnik.idKorisnickiRacun);
            if (idtima != 0) System.Windows.MessageBox.Show("Nemaš zahtjeva, već si u timu!");
            else
            {
                Nep_Tim tim = new Nep_Tim(this.Korisnik);
                tim.Show();
            }
        }
      
    }
    
    }
