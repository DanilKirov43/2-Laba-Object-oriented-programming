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
    public partial class Movment_data_AT : Form
    {
        AirTransport air = new AirTransport();
        public Movment_data_AT()
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
            if (int.TryParse(textBox1.Text, out int speed_at))
            {
                if (speed_at > 0)
                {
                    air.Speed_Flight_0 = speed_at;
                    air.Movement_data();
                    label2.Text = "Длительность полета с учетом начальной скорости = "+air.Movement_Data_AT;
                    
                }
                else
                {
                    MessageBox.Show("Начальная скорость не может быть отрицательной");
                }
            }
            else
            {
                MessageBox.Show("Мне надо только числовые значения!");
            }
        }

        private void Movment_data_AT_Load(object sender, EventArgs e)
        {

        }
    }
}
