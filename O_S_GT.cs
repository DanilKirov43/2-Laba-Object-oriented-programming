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
    public partial class O_S_GT : Form
    {
        GroundTransport ground = new GroundTransport();
        private string table1 = "transport";
        private string col1_name = "svoystva_name";
        private string col1_value = "svoystva_value";

        private string table2 = "groundtransport";
        private string col2_name = "type_of_road_name";
        private string col2_value = "type_of_road_value";
        public O_S_GT()
        {
            InitializeComponent();
            MergeTables();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void MergeTables()
        {
            DataTable dt1 = ground.GetAllProperties("transport", "svoystva_name", "svoystva_value");
            DataTable dt2 = ground.GetAllProperties("groundtransport", "type_of_road_name", "type_of_road_value");

            // Добавляем префиксы, чтобы не было конфликтов
            dt1.Columns["id"].ColumnName = "id1";
            dt1.Columns["svoystva_name"].ColumnName = "name1";
            dt1.Columns["svoystva_value"].ColumnName = "value1";

            dt2.Columns["id"].ColumnName = "id2";
            dt2.Columns["type_of_road_name"].ColumnName = "name2";
            dt2.Columns["type_of_road_value"].ColumnName = "value2";

            int maxRows = Math.Max(dt1.Rows.Count, dt2.Rows.Count);
            DataTable merged = new DataTable();
            merged.Columns.Add("id1", typeof(int));
            merged.Columns.Add("name1", typeof(string));
            merged.Columns.Add("value1", typeof(string));
            merged.Columns.Add("id2", typeof(int));
            merged.Columns.Add("name2", typeof(string));
            merged.Columns.Add("value2", typeof(string));

            for (int i = 0; i < maxRows; i++)
            {
                DataRow newRow = merged.NewRow();
                if (i < dt1.Rows.Count)
                {
                    newRow["id1"] = dt1.Rows[i]["id1"];
                    newRow["name1"] = dt1.Rows[i]["name1"];
                    newRow["value1"] = dt1.Rows[i]["value1"];
                }
                if (i < dt2.Rows.Count)
                {
                    newRow["id2"] = dt2.Rows[i]["id2"];
                    newRow["name2"] = dt2.Rows[i]["name2"];
                    newRow["value2"] = dt2.Rows[i]["value2"];
                }
                merged.Rows.Add(newRow);
            }

            dataGridView1.DataSource = merged;
            SetupDataGridViewHeaders();
            SetupDataGridViewColumns();
            //dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
        }
        private void SetupDataGridViewColumns()
        {
            // Общие настройки
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Задание одинаковой ширины каждому столбцу
            int columnWidth = 110; // например, 150 пикселей
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = columnWidth;
            }
        }
        private void SetupDataGridViewHeaders()
        {
            // Скрываем ID столбцы
            if (dataGridView1.Columns.Contains("id1"))
                dataGridView1.Columns["id1"].Visible = false;

            if (dataGridView1.Columns.Contains("id2"))
                dataGridView1.Columns["id2"].Visible = false;

            // Устанавливаем заголовки
            if (dataGridView1.Columns.Contains("name1"))
                dataGridView1.Columns["name1"].HeaderText = "Общие свойства";

            if (dataGridView1.Columns.Contains("value1"))
                dataGridView1.Columns["value1"].HeaderText = "Значение";

            if (dataGridView1.Columns.Contains("name2"))
                dataGridView1.Columns["name2"].HeaderText = "Собственные свойства";

            if (dataGridView1.Columns.Contains("value2"))
                dataGridView1.Columns["value2"].HeaderText = "Значение";
        }


        /*private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            // Проверка на null, чтобы не было исключений
            object id1 = row.Cells["id1"].Value;
            object id2 = row.Cells["id2"].Value;

            // Цвет для транспорт (id1 не null)
            if (id1 != DBNull.Value && id1 != null)
            {
                row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            // Цвет для groundtransport (id2 не null)
            else if (id2 != DBNull.Value && id2 != null)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else
            {
                // На случай если строка вообще пустая
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }*/



        private void label1_Click(object sender, EventArgs e)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        
        //удаление
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dataGridView1.SelectedRows[0];

                if (radioButton1.Checked)
                {
                    // Удаление из первой таблицы (transport)
                    if (selected.Cells["id1"].Value != DBNull.Value)
                    {
                        int idToDelete = Convert.ToInt32(selected.Cells["id1"].Value);
                        ground.DeletePropertyById(table1, idToDelete);
                    }
                    else
                    {
                        MessageBox.Show("В выбранной строке нет записи из первой таблицы.");
                    }
                }
                else if (radioButton2.Checked)
                {
                    // Удаление из второй таблицы (groundtransport)
                    if (selected.Cells["id2"].Value != DBNull.Value)
                    {
                        int idToDelete = Convert.ToInt32(selected.Cells["id2"].Value);
                        ground.DeletePropertyById(table2, idToDelete);
                    }
                    else
                    {
                        MessageBox.Show("В выбранной строке нет записи из второй таблицы.");
                    }
                }

                MergeTables();
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ground.AddProperty(table1, col1_name, col1_value, textBox1.Text, textBox2.Text);
            }
            else if (radioButton2.Checked)
            {
                ground.AddProperty(table2, col2_name, col2_value, textBox1.Text, textBox2.Text);
            }

            textBox1.Clear();
            textBox2.Clear();
            MergeTables();
        }

        private void O_S_GT_Load(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var newValue = row.Cells[e.ColumnIndex].Value?.ToString();

            if (string.IsNullOrWhiteSpace(newValue))
                return;

            if (columnName == "name1" || columnName == "value1")
            {
                if (row.Cells["id1"].Value != DBNull.Value)
                {
                    int id = Convert.ToInt32(row.Cells["id1"].Value);
                    string dbColumn = columnName == "name1" ? col1_name : col1_value;
                    ground.UpdatePropertyById(table1, id, dbColumn, newValue);
                }
            }
            else if (columnName == "name2" || columnName == "value2")
            {
                if (row.Cells["id2"].Value != DBNull.Value)
                {
                    int id = Convert.ToInt32(row.Cells["id2"].Value);
                    string dbColumn = columnName == "name2" ? col2_name : col2_value;
                    ground.UpdatePropertyById(table2, id, dbColumn, newValue);
                }
            }

            // Optional: обновим отображение
            MergeTables();
        }
    }
}
