using System;
using System.Windows.Forms;

namespace SellersAndBuyers
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Индекс закрытия формы.
        /// </summary>
        public int CloseIndex { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();

            passwordTextBox.PasswordChar = '*';

            emailTextBox.Text = "topseller.edu.hse.ru";
            passwordTextBox.Text = "KsyW{zCG0a";
        }

        /// <summary>
        /// Кнопка входа.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void AutorizationButton_Click(object sender, EventArgs e)
        {
            if (emailTextBox.Text != "topseller.edu.hse.ru")
            {
                MessageBox.Show($"Данный пользователь не зарегистрирован!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (passwordTextBox.Text != "KsyW{zCG0a")
            {
                MessageBox.Show($"Пароль введён неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CloseIndex = 1;
            Close();
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseIndex == 0)
            {
                SellersForm.CloseIndex = -1;
                SellersForm.SelfRef.CloseMe();
            }
        }
    }
}
