using System;
using System.Windows.Forms;

namespace ExcelMini
{
    public partial class OpenFileForm : Form
    {
        /// <summary>
        /// Путь к открываемому файлу.
        /// </summary>
        string filePath = null;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public OpenFileForm()
        {
            InitializeComponent();

            labelFileSelect.Visible = false;
        }

        /// <summary>
        /// Получение пути к файлу.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            labelFileNotSelect.Visible = true;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                    labelFileNotSelect.Visible = false;
                    labelFileSelect.Visible = true;
                }
                else
                {
                    filePath = null;
                    labelFileNotSelect.Visible = true;
                    labelFileSelect.Visible = false;
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при открытии файла: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Подтверждение установки всех параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            string separator;
            bool rowsNames = false; 

            // Выбор разделителя.
            if (checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
                separator = ",";
            else if (!checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
                separator = ";";
            else if (!checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked && !checkBox4.Checked)
                separator = ":";
            else if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && checkBox4.Checked)
                separator = ".";
            else
            {
                MessageBox.Show($"Необходимо выбрать один разделитель!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Выбор формата первой строки.
            if (comboBoxAnswer.SelectedItem != null)
            {
                if (comboBoxAnswer.SelectedIndex == 0)
                    rowsNames = true;
            }
            else
            {
                MessageBox.Show($"Необходимо указать информацию о первой строке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Выбор пути к файлу.
            if (filePath == null || filePath == "")
            {
                MessageBox.Show($"Необходимо выбрать нужный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Заполнение данных в таблице.
            MainForm.SelfRef.NewDataTable(filePath, separator, rowsNames);

            Close();
        }
    }
}
