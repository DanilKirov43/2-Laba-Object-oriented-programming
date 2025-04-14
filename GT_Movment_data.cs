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
    public partial class GT_Movment_data : Form
    {
        GroundTransport ground = new GroundTransport();
        public GT_Movment_data()
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int movment))
            {
                if (movment > 0)
                {
                    ground.Mileage_GT = movment;
                    ground.Movement_data();
                    label_final.Text = "Ваше время в пути: " + ground.GetMovement_data_GT() + " минут.\n"+ground.GetMovement_data_name_GT();
                    MessageBox.Show("Ну как то так вы и поедите и полетите!");
                }
                else
                {
                    MessageBox.Show("Время то уж точно не бывает отрицательным, а жаль(");
                }
            }
            else
            {
                MessageBox.Show("Мне надо только числовые значения!");
            }
        }

        private void GT_Movment_data_Load(object sender, EventArgs e)
        {

        }
    }
}
