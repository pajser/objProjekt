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
        private int idKorisnika;
        public Pregled_timova()
        {
            InitializeComponent();
        }
        public Pregled_timova(int ID)
        {
            this.idKorisnika = ID;
            InitializeComponent();
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

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimPredlozak gledaniTim = this.listBox1.SelectedItem as TimPredlozak;
            this.label3.Text = "Ime tima: " + gledaniTim.imeTima;
            this.label6.Text = "Ime aplikacije: " + gledaniTim.naslovAplikacije;
            this.textBox1.Text = gledaniTim.OpisAplikacije;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idOdabranog = Int32.Parse(listBox1.SelectedValue.ToString());
            string tekstPoruke = this.textBox2.Text.ToString();
            if(ZahtjevTablica.DodajZahtjev(this.idKorisnika, idOdabranog, true, tekstPoruke))
                System.Windows.MessageBox.Show("Zahtjev uspješno poslan!");
        }
        
    }
}
