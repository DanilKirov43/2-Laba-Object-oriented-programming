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
    public partial class Choice : Form
    {
       
        public Choice()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Vabor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GroundTransport_Formcs groundTransport_Formcs = new GroundTransport_Formcs();  
            groundTransport_Formcs.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AirTransport_Form airTransport_Form = new AirTransport_Form();
            airTransport_Form.ShowDialog();
        }
    }
}
