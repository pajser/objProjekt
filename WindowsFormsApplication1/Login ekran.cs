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
        string zapamcen="nista";
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string pamti)
        {
            this.zapamcen = pamti;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.zapamcen!="nista")
            {
                //this.radioButton1.PerformClick();
                this.textBox1.Text = this.zapamcen;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KorisnickiRacunPredlozak Kor = KorisnickiRacunTablica.UlogirajKorisnika(this.textBox1.Text, this.textBox2.Text);

            if (Kor.idKorisnickiRacun == 1)//admin
            {
                if (this.radioButton1.Checked)
                    zapamcen = this.textBox1.Text;
                else this.zapamcen = "nista";
                Admin_Početni_ekran adminPočetni = new Admin_Početni_ekran(Kor, zapamcen);
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
                    if (this.radioButton1.Checked)
                        zapamcen = this.textBox1.Text;
                    else this.zapamcen = "nista";
                    Početni početni = new Početni(Kor,zapamcen);
                    početni.Show();
                    this.Hide();
                }
            }
            
        }
    }
}
