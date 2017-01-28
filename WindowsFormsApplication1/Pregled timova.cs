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
        public Pregled_timova()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Pregled_timova_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaOBJDataSet1.Tim' table. You can move, or remove it, as needed.
            this.timTableAdapter.Fill(this.bazaOBJDataSet1.Tim);
       
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
