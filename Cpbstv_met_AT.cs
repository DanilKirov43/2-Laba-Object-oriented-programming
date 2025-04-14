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
    public partial class Cpbstv_met_AT : Form
    {
        AirTransport air = new AirTransport();
        public Cpbstv_met_AT()
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
            air.Weather_conditions(richTextBox1, pictureBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            air.To_plant(richTextBox1, pictureBox1);
        }

        private void Cpbstv_met_AT_Load(object sender, EventArgs e)
        {

        }
    }
}
