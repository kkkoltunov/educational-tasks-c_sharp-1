using System;
using System.Windows.Forms;

namespace ProductsWarehouse
{
    public partial class SetNameForm : Form
    {
        /// <summary>
        /// Индексатор для вызова нужного метода в основной программе.
        /// </summary>
        public int Indexer { get; set; }

        /// <summary>
        /// Констркутор формы.
        /// </summary>
        public SetNameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Подтверждение введенного названия.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength >= 1 && textBox1.TextLength <= 50)
            {
                try
                {
                    // Выбор нужного метода.
                    if (Indexer == 0)
                        MainForm.SelfRef.ChangeNameSection(textBox1.Text);
                    else if (Indexer == 1)
                        MainForm.SelfRef.AddRootNode(textBox1.Text);
                    else if (Indexer == 2)
                        MainForm.SelfRef.AddNode(textBox1.Text);

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла неизвестная ошибка!" +
                        $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show($"Длина названия должна быть от 1 до 50 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
