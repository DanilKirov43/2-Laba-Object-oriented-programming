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
    public partial class GroundTransport_Formcs : Form
    {
        GroundTransport ground = new GroundTransport();

        public GroundTransport_Formcs()
        {
            InitializeComponent();
        }

        private void GroundTransport_Formcs_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            O_S_GT o_S_GT = new O_S_GT();
            o_S_GT.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inherited_transport inherited_Transport = new Inherited_transport();
            inherited_Transport.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GT_pereop_met gT_Pereop_Met = new GT_pereop_met();
            gT_Pereop_Met.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cobstv_met_GT cobstv_Met_GT = new Cobstv_met_GT();
            cobstv_Met_GT.ShowDialog();
        }
    }
}
