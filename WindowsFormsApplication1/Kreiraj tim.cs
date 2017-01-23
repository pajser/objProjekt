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
    public partial class Tim : Form
    {
        private KorisnickiRacunPredlozak kreator;
        public Tim(KorisnickiRacunPredlozak kreatorr)
        {
            this.kreator = kreatorr;
            InitializeComponent();
        }

        private void Tim_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            bool uspjesnost = TimTablica.dodaj(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text,1 ,0);
            int idTima = TimTablica.dohvatiIdTima(this.textBox1.Text);
            bool uspjesnost123 = ClanTimaTablica.dodaj(kreator.idKorisnickiRacun, idTima, true);


            if (uspjesnost123) { this.Close(); }
            
        }
    }
}
