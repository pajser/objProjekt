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
    public partial class Pregled_timova : Form
    {
        List<TimPredlozak> timovi;
        private List<KorisnickiRacunPredlozak> ljudiPrikazanogTima;
        private int idKorisnika=-1;
        private bool uTimu;
        public Pregled_timova()
        {
            InitializeComponent();
            label1.Hide();
            textBox2.Hide();
            button2.Hide();
            this.uTimu = true;
        }
        public Pregled_timova(int ID)
        {
            this.idKorisnika = ID;
            InitializeComponent();
            this.button1.Hide();
            int idtima = ClanTimaTablica.DohvatiIdTima(this.idKorisnika);
            if (idtima != 0) this.uTimu = true;
            else this.uTimu = false;
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void Pregled_timova_Load(object sender, EventArgs e)
        {
            this.timovi = TimTablica.DohvatiSveTimove();
            listBox1.DataSource = timovi;
            listBox1.DisplayMember = "ImeTima";
            listBox1.ValueMember = "IdTima";              
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimPredlozak gledaniTim = this.listBox1.SelectedItem as TimPredlozak;
            TimTablica.OdobriProjekt(gledaniTim.idTima);
            this.label4.Text="Status tima: Zaključan i odobren projekt";
            this.button1.Hide();
            this.button3.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimPredlozak gledaniTim = this.listBox1.SelectedItem as TimPredlozak;
            this.label3.Text = "Ime tima: " + gledaniTim.imeTima;
            this.label6.Text = "Ime aplikacije: " + gledaniTim.naslovAplikacije;
            this.textBox1.Text = gledaniTim.OpisAplikacije;
            switch (gledaniTim.idStatusa)
            {
                case 1:
                    this.label4.Text = "Status tima: Otvoren projekt";
                break;
                case 2:
                    this.label4.Text = "Status tima: Zaključan projekt";
                break;
                case 3:
                    this.label4.Text = "Status tima: Zaključan i odobren projekt";
                break;
            }
            this.button1.Hide();
            this.button3.Hide();
            if (this.uTimu || gledaniTim.idStatusa>1)
            {
                this.button2.Hide();
                this.label1.Hide();
                this.textBox2.Hide();
            }
            else
            {
                this.button2.Show();
                this.label1.Show();
                this.textBox2.Show();
            }
            if (gledaniTim.idStatusa == 2 && this.idKorisnika == -1)
            {
                this.button1.Show();
                this.button3.Show();
            }


            this.ljudiPrikazanogTima = KorisnickiRacunTablica.DohvatiSveClanoveTima(gledaniTim.idTima);
            listBox2.DataSource = ljudiPrikazanogTima;
            listBox2.DisplayMember = "imeP";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idOdabranog = Int32.Parse(listBox1.SelectedValue.ToString());
            string tekstPoruke = this.textBox2.Text.ToString();
            if(ZahtjevTablica.DodajZahtjev(this.idKorisnika, idOdabranog, true, tekstPoruke))
                System.Windows.MessageBox.Show("Zahtjev uspješno poslan!");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimPredlozak gledaniTim = this.listBox1.SelectedItem as TimPredlozak;
            TimTablica.OtkljucajProjekt(gledaniTim.idTima);
            this.label4.Text = "Status tima: Otvoren projekt";
            this.button1.Hide();
            this.button3.Hide();
        }
    }
}
