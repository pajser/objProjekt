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
    public partial class Moj_tim : Form
    {
        private List<KorisnickiRacunPredlozak> soloKorisnici;
        private TimPredlozak pripadniTim;
        public Moj_tim(int id)
        {
            pripadniTim = TimTablica.DohvatiTimPoIdu(id);
            InitializeComponent();
        }

        private void Moj_tim_Load(object sender, EventArgs e)
        {
            this.label3.Text = pripadniTim.imeTima;
            this.label6.Text = pripadniTim.naslovAplikacije;
            this.textBox1.Text = pripadniTim.opisAplikacije;
            List<ClanTimaPredlozak> clanoviTima = ClanTimaTablica.DohvatiClanoveTima(pripadniTim.idTima);
            this.listBox1.Items.Add(clanoviTima);
            this.soloKorisnici = KorisnickiRacunTablica.DohvatiSveSlobodneKorisnike();
            this.listBox3.Items.Add(soloKorisnici);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
