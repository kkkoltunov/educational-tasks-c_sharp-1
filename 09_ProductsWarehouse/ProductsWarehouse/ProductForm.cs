using System;
using System.Windows.Forms;

namespace ProductsWarehouse
{
    public partial class ProductForm : Form
    {
        /// <summary>
        /// Индексатор для вызова нужного метода в основной программе.
        /// </summary>
        public int Indexer { get; set; }

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public ProductForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Подтверждение сохранения характеристики товара.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 1 || textBox1.TextLength > 50)
            {
                textBox1.Text = "";
                MessageBox.Show($"Длина названия товара должна быть от 1 до 50 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox2.TextLength < 1 || textBox2.TextLength > 18)
            {
                textBox2.Text = "";
                MessageBox.Show($"Длина артикула товара должна быть от 1 до 18 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3.TextLength < 1 || textBox3.TextLength > 25 || !decimal.TryParse(textBox3.Text, out decimal price) || price < 0)
            {
                textBox3.Text = "";
                MessageBox.Show($"Цена товара должна быть положительным вещественным числом!" +
                    $"\n\nПримечание: в данную ячейку нужно ввести от 1 до 25 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox4.TextLength < 1 || textBox4.TextLength > 15 || !long.TryParse(textBox4.Text, out long count) || count < 0)
            {
                textBox4.Text = "";
                MessageBox.Show($"Количество товара на складе должно быть положительным целым числом!" +
                    $"\n\nПримечание: в данную ячейку нужно ввести от 1 до 15 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] newRow = new string[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text };

            try
            {
                // Выбор нужного метода.
                if (Indexer == 0)
                    MainForm.SelfRef.AddNewDataTable(newRow);
                else if (Indexer == 1)
                    MainForm.SelfRef.CompleteDataTable(newRow);
                else if (Indexer == 2)
                    MainForm.SelfRef.EditDataCell(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Установка названия товара в textBox1.
        public void SetTextBox1(string text) => textBox1.Text = text;

        // Установка артикула товара в textBox2.
        public void SetTextBox2(string text) => textBox2.Text = text;

        // Установка цены товара в textBox3.
        public void SetTextBox3(string text) => textBox3.Text = text;

        // Установка количества товара на складе в textBox4.
        public void SetTextBox4(string text) => textBox4.Text = text;
    }
}
