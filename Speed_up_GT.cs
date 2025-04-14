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
    public partial class Speed_up_GT : Form
    {
        GroundTransport ground = new GroundTransport();

        public Speed_up_GT()
        {
            InitializeComponent();
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
            if (int.TryParse(textBox1.Text, out int speed))
            {
                // Проверка, что число больше нуля
                if (speed > 0)
                {
                    // Сброс текущей скорости на начальную, чтобы не накапливалась
                    ground.Speed_0_GT = speed;  // Устанавливаем начальную скорость

                    ground.Speed_up();  // Вызываем метод для увеличения скорости
                    label1.Text = "Новая скорость: " + ground.GetSpeed_GT();  // Отображаем новую скорость
                }
                else
                {
                    MessageBox.Show("Скорость должна быть положительным числом!");
                }
            }
            else
            {
                MessageBox.Show("Введи норм скорость!!!!");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
