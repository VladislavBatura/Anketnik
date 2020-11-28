using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ankets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fr = this;
        }

        Form1 fr;
        Button[] applicationButtons;
        string[] dataFromBD = new string[13];
        string[] rowsFromTable;
        List<string> info = new List<string>();
        int id;
        string initializeBD = "SELECT `id`, `nickname`, `discord-nickname`, `solution` FROM `applicants`";
        string getEverythingFromBD = "SELECT `id`, `name`, `nickname`, `discord-nickname`, `age`, `about`, `book`, `future`, `why`, `rules`, `date`, `ip` FROM `applicants` WHERE `id`=@nm";

        private void Form1_Load(object sender, EventArgs e)
        {
            BD bd = new BD(); //объект БД
            DataTable table = new DataTable(); // Таблица нужна для начальной инициализации кнопок
            MySqlDataAdapter adapter = new MySqlDataAdapter(); //Эта строчка для чтения данных из БД
            MySqlCommand command = new MySqlCommand(initializeBD, bd.getConnection()); //Команда к БД

            bd.openBD(); //Открываем БД

            adapter.SelectCommand = command; //Запускаем команду
            adapter.Fill(table); //Заполняем таблицу для инициализации
            MySqlDataReader reader = command.ExecuteReader(); //Обозначем ридер
            rowsFromTable = new string[table.Rows.Count]; //Массив имён для кнопок
            string[] idS = new string[table.Rows.Count];
            int j = 0; //простой счётчик
            string[] solution = new string[table.Rows.Count];

            while (reader.Read()) //Пока читает, заносит имена в массив
            {
                rowsFromTable[j] = reader.GetString("nickname");
                info.Add(reader.GetString("discord-nickname"));
                
                idS[j] = reader.GetString("id");
                if(reader.IsDBNull(reader.GetOrdinal("solution")))
                {
                    solution[j] = "NaN";
                }
                else
                {
                    solution[j] = reader.GetString("solution");
                }
                j++;
            }

            bd.closeBD(); //Закрываем БД

            int ran = table.Rows.Count; //Количество кнопок равно количеству строк имён из БД
            applicationButtons = new Button[ran]; //Массив кнопок
            int posX, posY; //позиции Х и У
            posX = 10; //Начальная позиция
            posY = 50;
            List<Button> sort = new List<Button>();
            
            for(int i = 0; i < 2; i++)
            {
                sort.Add(new Button());
                sort[i].ForeColor = Color.Black;
                sort[i].Size = new Size(115, 25);
                sort[i].Location = new Point(posX, 20);
                switch(i)
                {
                    case 0:
                        sort[i].Text = "Никнейм в игре"; //Текст на кнопке как имя из БД
                        sort[i].Name = $"buttonSort{i}";
                        sort[i].Click += new EventHandler(Sort); //Подписываемся на событие по клику
                        break;

                    case 1:
                        sort[i].Text = "Никнейм в дискорде"; //Текст на кнопке как имя из БД
                        sort[i].Name = $"buttonSort{i}";
                        sort[i].Click += new EventHandler(Sort); //Подписываемся на событие по клику
                        break;
                }

                posX += 125;
                this.Controls.Add(sort[i]);
            }

            posX = 10;

            for(int i = 0; i < ran; i++) //Цикл создания кнопок
            {
                applicationButtons[i] = new Button(); 
                if(solution[i] == "Принят")
                {
                    applicationButtons[i].BackColor = Color.LightGreen;
                }
                else if(solution[i] == "Собес")
                {
                    applicationButtons[i].BackColor = Color.LightBlue;
                }
                else if(solution[i] == "Отказано")
                {
                    applicationButtons[i].BackColor = Color.Red;
                }
                else
                {
                    applicationButtons[i].BackColor = Color.LightGray;
                }
                applicationButtons[i].ForeColor = Color.Black;
                applicationButtons[i].Size = new Size(110, 25);
                applicationButtons[i].Location = new Point(posX, posY);
                applicationButtons[i].Text = rowsFromTable[i]; //Текст на кнопке как имя из БД
                applicationButtons[i].Name = $"buttonApp{i}";
                applicationButtons[i].Tag = idS[i];
                applicationButtons[i].Click += new EventHandler(loadApplication); //Подписываемся на событие по клику
                this.Controls.Add(applicationButtons[i]);
                posX += 115;
                if(applicationButtons[i].Location.X > (this.Size.Width - 200))
                {
                    posY += 30;
                    posX = 10;
                }
            }


            ButtonApproved.Click += new EventHandler(LoadApplications);
            ButtonMeeting.Click += new EventHandler(LoadApplications);
            ButtonNotApproved.Click += new EventHandler(LoadApplications);
            ButtonReturn.Click += new EventHandler(LoadApplications);
            ButtonDelete.Click += new EventHandler(LoadApplications);
        }

        private void loadApplication(object sender, EventArgs e)
        {
            Button a = (Button)sender;

            BD bd = new BD();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(getEverythingFromBD, bd.getConnection());
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = a.Tag;

            bd.openBD();

            MySqlDataReader reader = command.ExecuteReader();
            
            id = Convert.ToInt32(a.Tag);

            while (reader.Read())
            {
                
                dataFromBD[0] = Convert.ToString(reader.GetInt32(0));
                dataFromBD[1] = Convert.ToString(reader.GetString(1));
                dataFromBD[2] = Convert.ToString(reader.GetString(2));
                dataFromBD[3] = Convert.ToString(reader.GetString(3));
                dataFromBD[4] = Convert.ToString(reader.GetString(4));
                dataFromBD[5] = Convert.ToString(reader.GetString(5));
                dataFromBD[6] = Convert.ToString(reader.GetString(6));
                dataFromBD[7] = Convert.ToString(reader.GetString(7));
                dataFromBD[8] = Convert.ToString(reader.GetString(8));
                dataFromBD[9] = Convert.ToString(reader.GetString(9));
                dataFromBD[10] = Convert.ToString(reader.GetDateTime(10));
                dataFromBD[11] = Convert.ToString(reader.GetString(11));
            }

            reader.Close();
            bd.closeBD();

            foreach (Button i in applicationButtons)
            {
                i.Hide();
            }

            ButtonApproved.Show();
            ButtonMeeting.Show();
            ButtonNotApproved.Show();
            ButtonReturn.Show();
            ButtonDelete.Show();

            //Тут тоже костыль, можно вместо потехи с 6 строками, сделать цикл, пробегающийся по двумерному массиву -
            // - 1 строка это имена столбцов, а 2 - сами данные. Пока что только так
            ApplicationTextBox.Visible = true;
            ApplicationTextBox.Text += $"Номер анкеты: {dataFromBD[0]}\n\n";
            ApplicationTextBox.Text += $"Имя: {dataFromBD[1]}\n\n";
            ApplicationTextBox.Text += $"Ник в игре: {dataFromBD[2]}\n\n";
            ApplicationTextBox.Text += $"Ник в дискорде: {dataFromBD[3]}\n\n";
            ApplicationTextBox.Text += $"Возраст: {dataFromBD[4]}\n\n";
            ApplicationTextBox.Text += $"О себе: {dataFromBD[5]}\n\n";
            ApplicationTextBox.Text += $"Любимая книга: {dataFromBD[6]}\n\n";
            ApplicationTextBox.Text += $"Кем себя видит: {dataFromBD[7]}\n\n";
            ApplicationTextBox.Text += $"Причина: {dataFromBD[8]}\n\n";
            ApplicationTextBox.Text += $"Правила: {dataFromBD[9]}\n\n";
            ApplicationTextBox.Text += $"Дата поступления анкеты: {dataFromBD[10]}\n\n";
            ApplicationTextBox.Text += $"IP: {dataFromBD[11]}\n\n";


            try
            {
                if (int.Parse(dataFromBD[4]) < 16)
                {
                    int positionInText = ApplicationTextBox.Find("Возраст");
                    string lengthInText = $"Возраст: {dataFromBD[4]}\n\n";
                    ApplicationTextBox.SelectionStart = positionInText;
                    ApplicationTextBox.SelectionLength = lengthInText.Length;
                    ApplicationTextBox.SelectionColor = Color.Red;
                }
            }
            catch(Exception exce)
            {

            }
            finally
            {
                
            }
            
        }

        private void ButtonApproved_Click(object sender, EventArgs e)
        {
            UpdateApproved("Принят");
        }

        private void LoadApplications(object sender, EventArgs e)
        {
            foreach (Button i in applicationButtons)
            {
                i.Show();
                //if (i.Tag.ToString() == id.ToString())
                //{
                //    i.Dispose();
                //}
            }

            ApplicationTextBox.Clear();
            ApplicationTextBox.Hide();
            ButtonApproved.Hide();
            ButtonMeeting.Hide();
            ButtonNotApproved.Hide();
            ButtonReturn.Hide();
            ButtonDelete.Hide();
        }

        private void ButtonMeeting_Click(object sender, EventArgs e)
        {
            UpdateApproved("Собес");
        }

        private void ButtonNotApproved_Click(object sender, EventArgs e)
        {
            UpdateApproved("Отказано");
        }

        private void UpdateApproved(string com)
        {
            BD bd = new BD();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"UPDATE `applicants` SET `solution` = '{com}' WHERE `id` = @nm", bd.getConnection());
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = id;

            bd.openBD();

            command.ExecuteNonQuery();

            bd.closeBD();

            UpdateButton(id, com);
        }

        void UpdateButton(int id, string sol)
        {
            int j = 0;
            foreach(Button i in applicationButtons)
            {
                if(id == Convert.ToInt32(i.Tag))
                {
                    switch (sol)
                    {
                        case "Принят":
                            {
                                applicationButtons[j].BackColor = Color.LightGreen;
                            }
                            break;
                        case "Собес":
                            {
                                applicationButtons[j].BackColor = Color.LightBlue;
                            }
                            break;
                        case "Отказано":
                            {
                                applicationButtons[j].BackColor = Color.Red;
                            }
                            break;
                    }
                }
                j++;
            }

        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            string deleteCommand = "DELETE FROM `applicants` WHERE `id` = @nm LIMIT 1";

            BD bd = new BD();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(deleteCommand, bd.getConnection());
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = id;

            try
            {
                bd.openBD();

                command.ExecuteNonQuery();

                bd.closeBD();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int j = 0;
            foreach (Button i in applicationButtons)
            {
                if (id == Convert.ToInt32(i.Tag))
                {
                    fr.Controls.RemoveByKey(applicationButtons[j].Name);
                }
                j++;
            }
        }

        void Sort(object sender, EventArgs e)
        {
            Button a = (Button)sender;

            if(a.Name == "buttonSort0")
            {
                for(int i = 0; i < applicationButtons.Length; i++)
                {
                    applicationButtons[i].Text = rowsFromTable[i];
                }
            }
            else if(a.Name == "buttonSort1")
            {
                for (int i = 0; i < applicationButtons.Length; i++)
                {
                    applicationButtons[i].Text = info[i];
                }
            }
            else
            {
                
            }
        }
    }
}
