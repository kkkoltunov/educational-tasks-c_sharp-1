using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SellersAndBuyers
{
    public partial class LoginAndRegistrationForm : Form
    {
        /// <summary>
        /// Список клиентов.
        /// </summary>
        List<Client> clients = new List<Client>();

        /// <summary>
        /// Индекс закрытия формы.
        /// </summary>
        public int CloseIndex { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public LoginAndRegistrationForm()
        {
            InitializeComponent();

            textBox4.PasswordChar = '*';
            textBox4.MaxLength = 25;
            textBox5.PasswordChar = '*';
            textBox5.MaxLength = 25;
            textBox6.PasswordChar = '*';
            textBox6.MaxLength = 25;

            Deserialize();
        }

        /// <summary>
        /// Кнопка входа.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    // Проверка почты.
                    if (clients[i].EMail == textBox7.Text)
                    {
                        // Проверка пароля.
                        if (clients[i].Password == textBox6.Text)
                        {
                            // Установка значений для открытия формы.
                            BuyersForm.SelfRef.LoginUser(clients[i]);
                            BuyersForm.IndexUser = i + 1;
                            BuyersForm.CloseIndex = 0;
                            BuyersForm.SelfRef.Autorization();
                            CloseIndex = 1;

                            Close();
                            return;
                        }
                        else
                        {
                            textBox6.Text = "";
                            MessageBox.Show($"Пароль введен неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                textBox7.Text = "";
                MessageBox.Show($"Данный покупатель не зарегистрирован в приложении!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Регистрация нового клиента.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!FirstCheckData())
                return;

            if (!SecondCheckData())
                return;

            if (textBox4.Text.Length < 8 || textBox4.Text.Length > 25)
            {
                textBox4.Text = "";
                MessageBox.Show($"Длина пароля должна быть от 8 до 25 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox5.Text != textBox4.Text)
            {
                textBox4.Text = "";
                textBox5.Text = "";
                MessageBox.Show($"Повторный ввод пароля осуществлен неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Добавления клиента.
            clients.Add(new Client(clients.Count + 1, textBox1.Text, textBox2.Text, textBox9.Text, textBox8.Text, textBox10.Text, textBox3.Text, textBox4.Text));

            // Создание новой директории для хранения данных о клиенте.
            Directory.CreateDirectory($"..{Path.DirectorySeparatorChar}data_buyers{Path.DirectorySeparatorChar}user{clients.Count}");
           
            // Добавление новых данных о клиенте.
            File.AppendAllText($"usersAllInformation.txt",
                $"{textBox1.Text};{textBox2.Text};{textBox9.Text};{textBox8.Text};{textBox10.Text};{textBox3.Text};{textBox4.Text}\n");

            CloseIndex = 1;
            BuyersForm.SelfRef.LoginUser(clients[clients.Count - 1]);
            BuyersForm.IndexUser = clients.Count;
            Close();
        }

        /// <summary>
        /// Проверка введенных пользователем данных.
        /// </summary>
        /// <returns>True, если проверка пройдена, False - иначе.</returns>
        bool FirstCheckData()
        {
            if (textBox1.Text.Length < 2 || textBox1.Text.Length > 30)
            {
                textBox1.Text = "";
                MessageBox.Show($"Длина имени должна быть от 2 до 30 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox2.Text.Length < 2 || textBox2.Text.Length > 30)
            {
                textBox2.Text = "";
                MessageBox.Show($"Длина фамилии должна быть от 2 до 30 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox9.Text.Length < 2 || textBox9.Text.Length > 30)
            {
                textBox9.Text = "";
                MessageBox.Show($"Длина отчества должна быть от 2 до 30 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox8.Text.Length != 12 || !textBox8.Text.Contains('+'))
            {
                textBox8.Text = "";
                MessageBox.Show($"Номер телефона должен состоять из 11 цифр и содержать знак '+'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (var el in textBox8.Text)
                if ((el < '0' || el > '9') && el != '+')
                {
                    MessageBox.Show($"Номер телефона должен состоять из 9 цифр и содержать знак '+'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            return true;
        }

        /// <summary>
        /// Проверка введенных пользователем данных.
        /// </summary>
        /// <returns>True, если проверка пройдена, False - иначе.</returns>
        bool SecondCheckData()
        {
            if (textBox10.Text.Length < 8 || textBox10.Text.Length > 150)
            {
                textBox10.Text = "";
                MessageBox.Show($"Длина адреса должна быть от 8 до 150 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!textBox3.Text.Contains('@') || !textBox3.Text.Contains('.'))
            {
                textBox3.Text = "";
                MessageBox.Show($"E-mail должен содержать хотя бы один символ \'@\' и \'.\'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            for (int i = 0; i < textBox3.Text.Length; i++)
            {
                if ((textBox3.Text[i] >= 'A' && textBox3.Text[i] <= 'Z') || (textBox3.Text[i] >= 'a' && textBox3.Text[i] <= 'z') || (textBox3.Text[i] >= '0' && textBox3.Text[i] <= '9') || textBox3.Text[i] == '@' || textBox3.Text[i] == '.') { }
                else
                {
                    textBox3.Text = "";
                    MessageBox.Show($"Использются запрещенные символы в поле с вводом e-mail!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (textBox3.Text.Length < 5 || textBox3.Text.Length > 40)
            {
                textBox3.Text = "";
                MessageBox.Show($"Длина почты должна быть от 5 до 40 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].EMail == textBox3.Text)
                {
                    textBox3.Text = "";
                    MessageBox.Show($"Пользователь с данным электронным адресом уже зарегистрирован в системе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void LoginAndRegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Serialize();

            if (CloseIndex == 0)
            {
                BuyersForm.CloseIndex = -1;
                BuyersForm.SelfRef.CloseMe();
            }
        }

        /// <summary>
        /// Сериализация данных о клиентах.
        /// </summary>
        void Serialize()
        {
            try
            {
                using (Stream file = File.Open("usersLoginAndPassword.txt", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, clients);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Десериализация данных о клиентах.
        /// </summary>
        void Deserialize()
        {
            try
            {
                using (Stream file = File.Open("usersLoginAndPassword.txt", FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    clients = (List<Client>)bf.Deserialize(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
