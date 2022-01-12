using System;
using System.Windows.Forms;

namespace ProductsWarehouse
{
    public partial class ReportForm : Form
    {
        /// <summary>
        /// Констркутор формы.
        /// </summary>
        public ReportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Подтверждение ввода данных о формировании отчёта.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 1 || textBox1.TextLength > 15 || !long.TryParse(textBox1.Text, out long count) || count < 0)
            {
                textBox1.Text = "";
                MessageBox.Show($"Нужно ввести неотрицательное целое число!" +
                    $"\n\nПримечание: в данную ячейку можно ввести от 1 до 15 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();

            try
            {
                // Вызов метода основной формы для создания отчета.
                MainForm.SelfRef.CreateReport(count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
