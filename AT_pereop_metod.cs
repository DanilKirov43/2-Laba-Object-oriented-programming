using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA2
{
    public partial class AT_pereop_metod : Form
    {
        public AT_pereop_metod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Speed_up_AT speed_Up_AT = new Speed_up_AT();
            speed_Up_AT.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Movment_data_AT movment_Data_AT = new Movment_data_AT();
            movment_Data_AT.ShowDialog();
        }

        private void AT_pereop_metod_Load(object sender, EventArgs e)
        {

        }
    }
}
