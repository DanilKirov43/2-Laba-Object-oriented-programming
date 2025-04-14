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
    public partial class Traffic_roads : Form
    {
        GroundTransport ground = new GroundTransport();
        public Traffic_roads()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int cars))
            {
                if (cars >= 0)
                {
                    ground.Col_Cars = cars;
                    ground.Traffic_roads();
                    label1.Text = "Вердикт: " +  ground.Traff;
                    
                }
                else
                {
                    MessageBox.Show("Неверно, у вас машины в минус ушли");
                }
            }
            else
            {
                MessageBox.Show("Мне надо только числовые значения!");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
