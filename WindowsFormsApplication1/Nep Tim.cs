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
    public partial class Nep_Tim : Form
    {
        private List<TimPredlozak> timovi;
        private KorisnickiRacunPredlozak korisnikk;
        public Nep_Tim(KorisnickiRacunPredlozak korisnik)
        {
            this.korisnikk = korisnik;
            InitializeComponent();
        }

        private void Nep_Tim_Load(object sender, EventArgs e)
        {
            this.timovi = TimTablica.DohvatiZahtjeveZaKorisnika(korisnikk.idKorisnickiRacun);
            this.listBox1.DataSource = timovi;
            listBox1.DisplayMember = "ImeTima";
            listBox1.ValueMember = "IdTima";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idTima = Int32.Parse(listBox1.SelectedValue.ToString());
                bool x = ClanTimaTablica.DodajClanTima(this.korisnikk.idKorisnickiRacun, idTima, false);
                bool y = ZahtjevTablica.IzbrisiZahtjev(this.korisnikk.idKorisnickiRacun, -1);
                if (x && y) { System.Windows.MessageBox.Show("Uspješno si ušao u tim!"); }

            }
            catch (Exception ž) {

            }
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
