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
    public partial class Inherited_transport : Form
    {
        GroundTransport ground = new GroundTransport();
        //Transport transp = new Transport();
        public Inherited_transport()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            ground.Engine_start(label1);
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            ground.Engine_stop(label1);
        }

        private void Inherited_transport_Load(object sender, EventArgs e)
        {

        }
    }
}
