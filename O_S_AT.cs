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
    public partial class O_S_AT : Form

    {
        AirTransport air = new AirTransport();
        private string table1 = "transport";
        private string col1_name = "svoystva_name";
        private string col1_value = "svoystva_value";
        private string table2 = "airtransport";
        private string col2_name = "name_property";
        private string col2_value = "value_property";
        public O_S_AT()
        {
            InitializeComponent();
            MergeTables();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }
        private void MergeTables()
        {
            DataTable dt1 = air.GetAllProperties("transport", "svoystva_name", "svoystva_value");
            DataTable dt2 = air.GetAllProperties("airtransport", "name_property", "value_property");

            // Добавляем префиксы, чтобы не было конфликтов
            dt1.Columns["id"].ColumnName = "id1";
            dt1.Columns["svoystva_name"].ColumnName = "name1";
            dt1.Columns["svoystva_value"].ColumnName = "value1";

            dt2.Columns["id"].ColumnName = "id2";
            dt2.Columns["name_property"].ColumnName = "name2";
            dt2.Columns["value_property"].ColumnName = "value2";

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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                air.AddProperty(table1, col1_name, col1_value, textBox1.Text, textBox2.Text);
            }
            else if (radioButton2.Checked)
            {
                air.AddProperty(table2, col2_name, col2_value, textBox1.Text, textBox2.Text);
            }

            textBox1.Clear();
            textBox2.Clear();
            MergeTables();
        }

        private void button_Delete_Click(object sender, EventArgs e)
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
                        air.DeletePropertyById(table1, idToDelete);
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
                        air.DeletePropertyById(table2, idToDelete);
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
                    air.UpdatePropertyById(table1, id, dbColumn, newValue);
                }
            }
            else if (columnName == "name2" || columnName == "value2")
            {
                if (row.Cells["id2"].Value != DBNull.Value)
                {
                    int id = Convert.ToInt32(row.Cells["id2"].Value);
                    string dbColumn = columnName == "name2" ? col2_name : col2_value;
                    air.UpdatePropertyById(table2, id, dbColumn, newValue);
                }
            }

            // Optional: обновим отображение
            MergeTables();
        }

        private void O_S_AT_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
