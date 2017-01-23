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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KorisnickiRacunPredlozak Kor = KorisnickiRacunTablica.UlogirajKorisnika(this.textBox1.Text, this.textBox2.Text);

            if (Kor.idKorisnickiRacun == 1)//admin
            {
                Admin_Početni_ekran adminPočetni = new Admin_Početni_ekran();
                adminPočetni.Show();
                this.Hide();

            }
            else
            {
                if (Kor == null)
                {
                    //pokazi gresku da korisnik ne postoji
                }
                else
                {
                    Početni početni = new Početni(Kor);
                    početni.Show();
                    this.Hide();
                }
            }
            
        }
    }
}
