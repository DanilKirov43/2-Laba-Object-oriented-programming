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
    public partial class GT_pereop_met : Form
    {
        public GT_pereop_met()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Speed_up_GT speed_Up_GT = new Speed_up_GT();
            speed_Up_GT.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GT_Movment_data gT_Movment_Data = new GT_Movment_data();
            gT_Movment_Data.ShowDialog();
        }
    }
}
