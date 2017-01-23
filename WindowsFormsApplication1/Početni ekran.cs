﻿using System;
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
    public partial class Početni : Form
    {
        private KorisnickiRacunPredlozak Korisnik;
        public Početni(KorisnickiRacunPredlozak idKor)
        {
            Korisnik = idKor;
            InitializeComponent();
        }

        private void mojtim_Click(object sender, EventArgs e)
        {
            Moj_tim moj_tim = new Moj_tim();
            moj_tim.Show();
        }
        private void pregledtim_Click(object sender, EventArgs e)
        {
            Pregled_timova timovi = new Pregled_timova();
            timovi.Show();
        }
        private void kreirajtim_Click(object sender, EventArgs e)
        {
            Tim tim = new Tim(this.Korisnik);
            tim.Show();
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Početni_Load(object sender, EventArgs e)
        {
            label1.Text = "Dobrodošao, " + Korisnik.imePrezime + "!";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login=new Form1();
            login.Show();

        }
    }
}
