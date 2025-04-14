using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace LABA2
{
    public abstract class Transportabstract
    {
        //подключение к БД
        private string connectionString = "Server = localhost; port = 5432;database=Transport; user id = postgres; Password = 613930;";
        //функция для получения всех свойств из таблицы
        public DataTable GetAllProperties(string tableName, string column1, string column2)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT id, \"{column1}\", \"{column2}\" FROM \"{tableName}\" ORDER BY id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        // Добавление записи
        public void AddProperty(string tableName, string column1, string column2, string value1, string value2)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = $"INSERT INTO \"{tableName}\" (\"{column1}\", \"{column2}\") VALUES (@val1, @val2);";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@val1", value1);
                    cmd.Parameters.AddWithValue("@val2", value2);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Удаление 
        public void DeletePropertyById(string tableName, int id)
        {
            var confirmResult = MessageBox.Show("Вы действительно хотите удалить эту запись?",
                                                "Подтверждение удаления",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"DELETE FROM \"{tableName}\" WHERE id = @id;";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        // Вирутальный метод для увеличения скорости
        public virtual void Speed_up()
        {
            
        }

        // Вирутальный метод для вычисления движения
        public virtual void Movement_data()
        { 

        }
        //наследуемые методы
        public async void Engine_start(Label label)
        {
            await Task.Delay(50);
            label.Text = "Запуск двигателя!\n";
            label.Refresh();
            label.ForeColor = Color.Green;
            for (int i = 0; i<=10; i++)
            {
                label.Text = label.Text + "*";
                await Task.Delay(50);
                label.Refresh();
            }
            label.Text = label.Text + " Запущен 100%";
           
        }
        public async void Engine_stop(Label label)
        {
            await Task.Delay(50);
            label.Text = "Остановка двигателя!\n";
            label.Refresh();
            label.ForeColor = Color.Red;
            for (int i = 0; i <= 10; i++)
            {
                label.Text = label.Text + "*";
                await Task.Delay(50);
                label.Refresh();
            }
            label.Text = label.Text + " Остановка 0%";
        }

        //обновление БД
        public  void UpdatePropertyById(string tableName, int id, string columnName, string newValue)
        {
            using (var conn = new Npgsql.NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = $"UPDATE {tableName} SET {columnName} = @value WHERE id = @id";
                using (var cmd = new Npgsql.NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@value", newValue);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
