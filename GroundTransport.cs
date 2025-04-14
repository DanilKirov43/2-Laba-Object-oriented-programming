using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection.Emit;
using Label = System.Windows.Forms.Label;


namespace LABA2
{
    public class GroundTransport : Transportabstract
    {
        private string type_of_road_value;
        public GroundTransport() 
        {
            type_of_road_value = GetValueFromDatabase<string>("groundtransport", "type_of_road_value", 2);
        }
        private int speed_0;
        protected string finel_speed1, text2;
        public override void Speed_up()
        {
            text2 = type_of_road_value;
            if (text2 == "Асфальт")
            {
                
                speed_0 = speed_0 + 100;
                MessageBox.Show($"У вас асфальт, ваша скорость становиться: {speed_0}");

                finel_speed1 = speed_0.ToString();
                
            }
            else if (text2 == "Грунтовка") 
            {
                speed_0 = speed_0 + 1;
                MessageBox.Show($"У вас грунтовка, ваша скорость становиться: {speed_0}");
                finel_speed1 = speed_0.ToString();
                
            }
            else
            {
                speed_0 = speed_0 + 999;
                MessageBox.Show($"У вас даже не знаю что,летите тогда, ваша стала: {speed_0}");

                finel_speed1 = speed_0.ToString();
                
            }
        }
        public string GetSpeed_GT()
        {
            return finel_speed1;
        }
        public int Speed_0_GT
        {
            set { speed_0 = value; }
        } 
        public string Type_Of_Road_Value
        {
            get { return type_of_road_value; }
            private set { type_of_road_value = value; }
        }
        private int mileage_GT;
        protected int movement_data_GT;
        protected string movement_data_name_GT;
        public override void Movement_data()
        {
            movement_data_GT = ((mileage_GT+100) / 60)+30;
            if (movement_data_GT < 100)
            {
                movement_data_name_GT = "Мы прибавили 30 мин. пробки\nВ итоге вы все ровно быстрые";
            }
            else
            {
                movement_data_name_GT = "Вместе с пробками и такой скоростью, вам ещё долго ехать! :(";
            }
        }
        public int GetMovement_data_GT()
        {
            return movement_data_GT;
        }
        public string GetMovement_data_name_GT()
        {
            return movement_data_name_GT;
        }
        public int Mileage_GT
        {
            set { mileage_GT = value; }
        }
        //Проверить состояние дороги
        public async void Road_condition(Label label)
        {
            label.ForeColor = Color.Brown;
            await Task.Delay(150);
            label.Text = "Начать проверку\n";
            label.Refresh();
            for (int i = 0; i <= 20; i++)
            {
                label.Text = label.Text + "*";
                await Task.Delay(150);
                label.Refresh();
            }
            label.Text = label.Text + " проверено  5%\n";
            await Task.Delay(300);
            label.Text = label.Text + "Проверим количество скользких участков\n";
            label.Refresh();
            for (int i = 0; i <= 20; i++)
            {
                label.Text = label.Text + "*";
                await Task.Delay(150);
                label.Refresh();
            }
            label.Text = label.Text + " проверено  50%\n";
            await Task.Delay(300);
            label.Text = label.Text + "Проверим ещё и дорожные ситуации\n";
            label.Refresh();
            for (int i = 0; i <= 20; i++)
            {
                label.Text = label.Text + "*";
                await Task.Delay(150);
                label.Refresh();
            }
            label.Text = label.Text + " проверено  100%\n";
            await Task.Delay(300);
            label.Text = label.Text + "Итог:\n";
            await Task.Delay(400);
            label.Text = label.Text + "Скольских участков: много\n";
            await Task.Delay(400);
            label.Text = label.Text + "Дорожные ситуаций: мало\n";
            await Task.Delay(400);
            label.Text = label.Text + "Счастливово Пути!\n";
        }

        private int col_cars;
        private string traff;
        //Оценить трафик на дороге
        public void Traffic_roads()
        {
            if (col_cars == 0)
            {
                traff = "Свобода. Дорога ваша!";
            }
            else if (col_cars > 0 && col_cars < 10)
            {
                traff = "Трафик малый. Малая загруженность";
            }
            else if (col_cars >= 10 && col_cars < 30) 
            {
                traff = "Трафик умеренный. Средняя загруженность";
            }
            else if (col_cars >= 30 && col_cars < 50)
            {
                traff = "Трафик высокий. Высокая загруженность";
            }
            else if (col_cars >= 50 && col_cars < 100)
            {
                traff = "Мега тяжелая ситуация с пробками!";
            }
            else
            {
                traff = "Иди пешком. Завтра заберешь свою машину!";
            }
        }

        public string Traff
        {
            get { return traff; } 
            private set { traff = value; } 
        }

        public int Col_Cars
        {
            get { return col_cars; }
            set { col_cars = value; }
        }

        private string connectionString = "Server = localhost; port = 5432;database=Transport; user id = postgres; Password = 613930;";
        private T GetValueFromDatabase<T>(string tableName, string columnName, int offset)
        {
            T value = default(T);  // Инициализируем значение по умолчанию для типа T
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT \"{columnName}\" FROM \"{tableName}\" WHERE \"id\" = {offset};";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        value = (T)Convert.ChangeType(result, typeof(T));  // Преобразуем результат в нужный тип
                    }
                }
            }
            return value;
        }
    }
}
