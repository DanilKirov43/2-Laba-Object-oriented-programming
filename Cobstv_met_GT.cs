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
    public partial class Cobstv_met_GT : Form
    {
        public Cobstv_met_GT()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Road_Condition road_Condition = new Road_Condition();   
            road_Condition.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Traffic_roads traffic_Roads = new Traffic_roads();
            traffic_Roads.ShowDialog();
        }
    }
}
