using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

//neka linija
namespace WindowsFormsApplication1
{
    public partial class Moj_tim : Form
    {

        private List<KorisnickiRacunPredlozak> soloKorisnici;
        private List<KorisnickiRacunPredlozak> timskiKorisnici;
        private List<KorisnikZahtjevPredlozak> zeljniKorisnici;
        private TimPredlozak pripadniTim;
        private int idOsobe;
        public Moj_tim(int id,int idO)
        {
            try
            {
                pripadniTim = TimTablica.DohvatiTimPoIdu(id);
                pripadniTim.idTima = id;
                idOsobe = idO;
                InitializeComponent();
                bool voda = ClanTimaTablica.DohvatiVodstvo(idO);
                if (voda)
                {
                    button5.Hide();
                }
                else
                {
                    button1.Hide();
                    button2.Hide();
                    button3.Hide();
                    button4.Hide();
                    button6.Hide();
                    button7.Hide();
                }
                if(pripadniTim.idStatusa>1)
                {
                    button1.Hide();
                    button3.Hide();
                    button4.Hide();
                    button5.Hide();
                    button6.Hide();
                    button7.Hide();
                    this.button2.BackgroundImage = null;
                    button2.BackColor = Color.Gray;
                    button2.Text = "Zaključan projekt";
                }
            }
            catch(Exception žnj)
            {
                this.Hide();
                System.Windows.MessageBox.Show("Nisi u timu");
            }
        }

        private void Moj_tim_Load(object sender, EventArgs e)
        {
            this.label3.Text = "Ime Tima: "+ pripadniTim.imeTima;
            this.label6.Text = "Naslov aplikacije: " + pripadniTim.naslovAplikacije;
            this.textBox1.Text = pripadniTim.opisAplikacije;



            this.timskiKorisnici = KorisnickiRacunTablica.DohvatiSveClanoveTima(pripadniTim.idTima);
            listBox1.DataSource = timskiKorisnici;
            listBox1.DisplayMember = "imeP";
            listBox1.ValueMember = "idKR";


            this.soloKorisnici = KorisnickiRacunTablica.DohvatiSveSlobodneKorisnike();
            listBox3.DataSource = soloKorisnici;
            listBox3.DisplayMember = "imeP";
            listBox3.ValueMember = "idKR";


            
            this.zeljniKorisnici = ZahtjevTablica.DohvatiZahtjeveZaTim(pripadniTim.idTima);
            listBox2.DataSource = zeljniKorisnici;
            listBox2.DisplayMember = "imeP";
            listBox2.ValueMember = "idKR";


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClanTimaTablica.IzbrisiClanoveTima(this.pripadniTim.idTima);
            ZahtjevTablica.IzbrisiZahtjev(-1, this.pripadniTim.idTima);
            TimTablica.IzbrisiTim(this.pripadniTim.idTima);
            System.Windows.MessageBox.Show("Članovi tima izbačeni i projekt uspješno izbrisan!");
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idPozvanog = Int32.Parse(listBox3.SelectedValue.ToString());
            if(ZahtjevTablica.DodajZahtjev(idPozvanog, this.pripadniTim.idTima, false, null))
            {
                System.Windows.MessageBox.Show("Uspješno pozvan u tim!");
                this.soloKorisnici = KorisnickiRacunTablica.DohvatiSveSlobodneKorisnike();
                listBox3.DataSource = soloKorisnici;
                listBox3.DisplayMember = "";
                listBox3.DisplayMember = "imeP";
            }
            this.listBox3.Update();
         }


        private void button1_Click(object sender, EventArgs e)
        {
           int idBrisanog = Int32.Parse(listBox1.SelectedValue.ToString());
           if(ClanTimaTablica.IzbrisiClanaTima(idBrisanog,this.pripadniTim.idTima))
            {
                System.Windows.MessageBox.Show("Član izbačen iz tima!");
            }
            this.timskiKorisnici = KorisnickiRacunTablica.DohvatiSveClanoveTima(pripadniTim.idTima);
            listBox1.DataSource = timskiKorisnici;
            this.soloKorisnici = KorisnickiRacunTablica.DohvatiSveSlobodneKorisnike();
            listBox3.DataSource = soloKorisnici;
            listBox1.DisplayMember = "";
            listBox1.DisplayMember = "imeP";
            listBox3.DisplayMember = "";
            listBox3.DisplayMember = "imeP";
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            KorisnikZahtjevPredlozak odabraniKorZahtjev = this.listBox2.SelectedItem as KorisnikZahtjevPredlozak;
            this.textBox2.Text = odabraniKorZahtjev.Por;
        }

        //pozovi u tim
        private void button6_Click(object sender, EventArgs e)
        {
            KorisnikZahtjevPredlozak odabraniKorZahtjev = this.listBox2.SelectedItem as KorisnikZahtjevPredlozak;
            if (ClanTimaTablica.DodajClanTima(odabraniKorZahtjev.idKR, pripadniTim.idTima, false))
            {
                System.Windows.MessageBox.Show(odabraniKorZahtjev.imeP + " je dodan u tim!");
            }
            ZahtjevTablica.IzbrisiZahtjev(odabraniKorZahtjev.idKR, -1);
            this.zeljniKorisnici = ZahtjevTablica.DohvatiZahtjeveZaTim(pripadniTim.idTima);
            listBox2.DataSource = zeljniKorisnici;
            listBox2.DisplayMember = "imeP";
            listBox2.ValueMember = "idKR";

            this.timskiKorisnici = KorisnickiRacunTablica.DohvatiSveClanoveTima(pripadniTim.idTima);
            listBox1.DataSource = timskiKorisnici;
            listBox1.DisplayMember = "imeP";
            listBox1.ValueMember = "idKR";

            this.soloKorisnici = KorisnickiRacunTablica.DohvatiSveSlobodneKorisnike();
            listBox3.DataSource = soloKorisnici;
            listBox3.DisplayMember = "imeP";
            listBox3.ValueMember = "idKR";
        }






        //odbij zahtjev
        private void button7_Click(object sender, EventArgs e)
        {
            KorisnikZahtjevPredlozak odabraniKorZahtjev = this.listBox2.SelectedItem as KorisnikZahtjevPredlozak;
            if (ZahtjevTablica.IzbrisiZahtjev(odabraniKorZahtjev.idKR, pripadniTim.idTima))
            {
                this.zeljniKorisnici = ZahtjevTablica.DohvatiZahtjeveZaTim(pripadniTim.idTima);
                listBox2.DataSource = zeljniKorisnici;
                listBox2.DisplayMember = "imeP";
                listBox2.ValueMember = "idKR";

                if (zeljniKorisnici.Count() < 1)
                {
                    this.textBox2.Text = "";
                }
                else
                {
                    odabraniKorZahtjev = this.listBox2.SelectedItem as KorisnikZahtjevPredlozak;
                    this.textBox2.Text = odabraniKorZahtjev.Por;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int idBrisanog = idOsobe;
            if (ClanTimaTablica.IzbrisiClanaTima(idBrisanog, this.pripadniTim.idTima))
            {
                System.Windows.MessageBox.Show("Izašao si iz tima!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimTablica.ZakljucajTim(this.pripadniTim.IdTima);
            ZahtjevTablica.IzbrisiZahtjev(-1, pripadniTim.idTima);
            button1.Hide();
            button3.Hide();
            button4.Hide();
            button6.Hide();
            button7.Hide();
            this.textBox2.Text = "";
            this.button2.BackgroundImage = null;
            button2.BackColor = Color.Gray;
            button2.Text = "Zaključan projekt";
        }
    }
}
