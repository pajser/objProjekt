﻿using System;
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
        private TimPredlozak pripadniTim;
        public Moj_tim(int id)
        {
            try
            {
                pripadniTim = TimTablica.DohvatiTimPoIdu(id);
                pripadniTim.idTima = id;
                InitializeComponent();
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
        
    }
}
