using System;
using System.Windows.Forms;

namespace ProductsWarehouse
{
    public partial class GenerateClassifierForm : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public GenerateClassifierForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверка корректности введенных данных и вызов метода для генерации отчета.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 1 || textBox1.TextLength > 3 || !int.TryParse(textBox1.Text, out int countNodes) || countNodes < 2)
            {
                textBox1.Text = "";
                MessageBox.Show($"Количество разделов должно быть положительным целочисленным числом больше 2 и меньше 1000." +
                    $"\n\nПримечание: в данную ячейку нужно ввести от 1 до 3 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox2.TextLength < 1 || textBox2.TextLength > 3 || !int.TryParse(textBox2.Text, out int countProducts) || countProducts < 2)
            {
                textBox2.Text = "";
                MessageBox.Show($"Количество товаров должно быть положительным целочисленным числом больше 2 и меньше 1000." +
                    $"\n\nПримечание: в данную ячейку нужно ввести от 1 до 3 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Вызов метода для генерации классификатора.
                MainForm.SelfRef.GenerateClassifier(countNodes, countProducts);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
