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
        private TimPredlozak pripadniTim;
        public Moj_tim(int id)
        {
            pripadniTim = TimTablica.DohvatiTimPoIdu(id);
            pripadniTim.idTima = id;
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
            this.listBox3.DataSource = soloKorisnici;
            listBox3.DisplayMember = "imeP";
            listBox3.ValueMember = "idKR";


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int idPozvanog = this.listBox3.SelectedItem;          
            //String curItem = (listBox3.SelectedValue as ListBoxItem).Content.ToString();
            int idPozvanog = Int32.Parse(listBox3.SelectedValue.ToString());
            ZahtjevTablica.DodajZahtjev(idPozvanog, this.pripadniTim.idTima, false, null);
            this.listBox3.Update();
            MessageBox.Show(idPozvanog.ToString());
         }
    }
}
