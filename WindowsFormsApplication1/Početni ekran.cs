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
    public partial class Početni : Form
    {
        public Početni()
        {
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
            Tim tim = new Tim();
            tim.Show();
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Početni_Load(object sender, EventArgs e)
        {

        }
    }
}
