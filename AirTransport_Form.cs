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
    public partial class AirTransport_Form : Form
    {
        AirTransport air = new AirTransport();
        public AirTransport_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            O_S_AT o_S_AT = new O_S_AT();
            o_S_AT.ShowDialog();
            
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            Inherited_transport inherited_Transport = new Inherited_transport();
            inherited_Transport.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AT_pereop_metod aT_Pereop_Metod = new AT_pereop_metod();
            aT_Pereop_Metod.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cpbstv_met_AT cpbstv_Met_AT = new Cpbstv_met_AT();  
            cpbstv_Met_AT.ShowDialog();
        }

        private void AirTransport_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
