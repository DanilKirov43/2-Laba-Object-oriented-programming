using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection.Emit;
using Label = System.Windows.Forms.Label;

namespace LABA2
{
    public class AirTransport : Transportabstract
    {
        public AirTransport() 
        {
            //flight_altitude_name = GetValueFromDatabase<string>("airtransport", "name_property", 1);
            //flight_altitude_value = GetValueFromDatabase<int>("airtransport", "value_property", 1);
            //wingspan_name = GetValueFromDatabase<string>("airtransport", "name_property", 2);
            //wingspan_value = GetValueFromDatabase<int>("airtransport", "value_property", 2);
        }

        private string aerodynamics, comment_speed;
        private int speed_null;
        private int finel_speed1;
        public override void Speed_up()
        {
            speed_null = 400;
            if (aerodynamics == "Эллипсовидные")
            {
                speed_null = speed_null + 10000;
                MessageBox.Show($"Это лучшая форма крыльев, ваша новая скорость:{speed_null} ");
                comment_speed = "Это лучшая форма крыльев!";
                finel_speed1 = speed_null;
            }
            else if (aerodynamics == "Прямоугольные")
            {
                speed_null = speed_null + 5000;
                MessageBox.Show($"Это менее выгодная форма крыльев, ваша новая скорость:{speed_null} ");
                comment_speed = "Это менее выгодная форма крыльев!";
                finel_speed1 = speed_null;
            }
            else if (aerodynamics == "Трапециевидные")
            {
                speed_null = speed_null + 8000;
                MessageBox.Show($"По аэродинамическим характеристикам лучше прямоугольного, ваша новая скорость:{speed_null} ");
                comment_speed = "По аэродинамическим характеристикам лучше прямоугольного!";
                finel_speed1 = speed_null;
            }
            else if (aerodynamics == "Стреловидные")
            {
                speed_null = speed_null + 15000;
                MessageBox.Show($"Это мега улучшенная форма, ваша новая скорость:{speed_null} ");
                comment_speed = "Это мега улучшенная форма!";
                finel_speed1 = speed_null;
            }
            else
            {
                speed_null = speed_null + 20000;
                MessageBox.Show($"Такая форма для сверхзвуковых, поэтому ваша новая скорость: {speed_null} ");
                comment_speed = "Такая форма для сверхзвуковых!";
                finel_speed1 = speed_null;
            }
        }
        public string Aerodynamics
        {
            get { return aerodynamics; }
            set {  aerodynamics = value; }
        }
        public string Comment_Speed
        {
            get { return comment_speed; }
            private set { comment_speed = value; }
        }
        public int GetFinal_speed
        {
            get { return finel_speed1; }
            private set { finel_speed1 = value;}
        }
        private double a = 45;
        private double movement_data_AT;
        private double I;
        private double speed_flight_0;
        private double g = 10;
        public override void Movement_data()
        {

            I = ((speed_flight_0)*2 * Math.Sin(a ))/g;
            movement_data_AT = I;


        }
        public double Speed_Flight_0
        {
            get { return  speed_flight_0; }
            set {  speed_flight_0 = value; }
        }
        public double Movement_Data_AT
        {
            get { return movement_data_AT; }
            private set {  movement_data_AT = value; }
        }
        //Проверить метеоусловия
        public async void Weather_conditions(RichTextBox richTextBox, PictureBox pictureBox)
        {
            pictureBox.Image = null;
            richTextBox.Clear();
            richTextBox.SelectionColor = Color.Black;
            await Task.Delay(500);
            richTextBox.AppendText(" Проверим метеусловия!\n");
            richTextBox.Refresh();

            for (int i = 0; i <= 15; i++)
            {
                richTextBox.AppendText(">");
                await Task.Delay(150);
                richTextBox.Refresh();
            }

            
            richTextBox.SelectionColor = Color.Blue; // Меняем цвет на синий
            richTextBox.AppendText(" Погода пасмурная...\n");
            richTextBox.SelectionColor = Color.Black; // Возвращаем цвет обратно

            await Task.Delay(500);

            for (int i = 0; i <= 15; i++)
            {
                richTextBox.AppendText(">");
                await Task.Delay(150);
                richTextBox.Refresh();
            }
           
            richTextBox.SelectionColor = Color.Blue;
            richTextBox.AppendText(" Иногда дождик...\n");
            richTextBox.SelectionColor = Color.Black;

            await Task.Delay(500);

            for (int i = 0; i <= 15; i++)
            {
                richTextBox.AppendText(">");
                await Task.Delay(150);
                richTextBox.Refresh();
            }
            
            richTextBox.SelectionColor = Color.Blue;
            richTextBox.AppendText(" Высокая влажность...\n");
            richTextBox.SelectionColor = Color.Black;

            await Task.Delay(1000);


            pictureBox.Image = Image.FromFile("D:\\w4.png");
            richTextBox.SelectionColor = Color.Red; // Меняем цвет на красный
            richTextBox.AppendText("Погода нелетная! Лучше поездом!\n");
            richTextBox.SelectionColor = Color.Black; // Возвращаем цвет обратно







        }
        //Выполнить посадку
        public async void To_plant(RichTextBox richTextBox, PictureBox pictureBox)
        {
            pictureBox.Image = null;
            richTextBox.Clear();
            richTextBox.SelectionColor = Color.Blue;
            await Task.Delay(500);
            richTextBox.AppendText("Процесс посадки:\n");

            richTextBox.Refresh();
            richTextBox.SelectionColor = Color.Black;
            for (int i = 0; i <= 15; i++)
            {
                richTextBox.AppendText(">");
                await Task.Delay(150);
                richTextBox.Refresh();
            }


            richTextBox.SelectionColor = Color.Green; // Меняем цвет на синий
            richTextBox.AppendText(" Штурвал взяли\n");
            richTextBox.SelectionColor = Color.Black; // Возвращаем цвет обратно

            await Task.Delay(500);

            for (int i = 0; i <= 15; i++)
            {
                richTextBox.AppendText(">");
                await Task.Delay(150);
                richTextBox.Refresh();
            }

            richTextBox.SelectionColor = Color.Green;
            richTextBox.AppendText(" Координаты посчитали\n");
            richTextBox.SelectionColor = Color.Black;

            await Task.Delay(500);

            for (int i = 0; i <= 15; i++)
            {
                richTextBox.AppendText(">");
                await Task.Delay(150);
                richTextBox.Refresh();
            }

            richTextBox.SelectionColor = Color.Green;
            richTextBox.AppendText(" Снижаемся\n");
            richTextBox.SelectionColor = Color.Black;
            await Task.Delay(500);

            for (int i = 0; i <= 15; i++)
            {
                richTextBox.AppendText(">");
                await Task.Delay(150);
                richTextBox.Refresh();
            }

            richTextBox.SelectionColor = Color.Green;
            richTextBox.AppendText(" Выдвигаем шасси\n");
            richTextBox.SelectionColor = Color.Black;
            await Task.Delay(500);

            for (int i = 0; i <= 15; i++)
            {
                richTextBox.AppendText(">");
                await Task.Delay(150);
                richTextBox.Refresh();
            }

            richTextBox.SelectionColor = Color.Green;
            richTextBox.AppendText(" Присаживаемся в Победилово :)\n");
            richTextBox.SelectionColor = Color.Black;

            await Task.Delay(1000);


            pictureBox.Image = Image.FromFile("D:\\w3.png");
            richTextBox.SelectionColor = Color.Green; // Меняем цвет на красный
            richTextBox.AppendText("Мы молодцы! Мы сели, да ещё и целые!\n");
            richTextBox.SelectionColor = Color.Black; // Возвращаем цвет обратно
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