using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA2
{
    public partial class Speed_up_AT : Form
    {
        AirTransport air = new AirTransport();
        public Speed_up_AT()
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
            if (comboBox1.SelectedItem != null)
            {
                string selectedaerodynamics = comboBox1.SelectedItem.ToString();
                air.Aerodynamics = selectedaerodynamics;
                air.Speed_up();
                label1.Text = $"{air.Comment_Speed} Итоговая скорость: {air.GetFinal_speed} км/ч";
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите форму крыльев.");
            }
        }

        private void Speed_up_AT_Load(object sender, EventArgs e)
        {
            LoadAerodynamicsData();
        }

        private void LoadAerodynamicsData()
        {
            string conString = "Server = localhost; port = 5432;database=Transport; user id = postgres; Password = 613930;";
            string query = "SELECT \"Aerodynamics_name\" FROM \"aerodynamics\"";
            using (var conn = new NpgsqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader.GetString(0)); // Добавляем каждый элемент в ComboBox
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
                }
            }
        }



        
    }
}
