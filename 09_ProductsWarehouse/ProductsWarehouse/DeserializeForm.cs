using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ProductsWarehouse
{
    public partial class DeserializeForm : Form
    {
        /// <summary>
        /// Таблица с пустыми строками информации о сохранениях.
        /// </summary>
        DataTable dataTableDefault = new DataTable();

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public DeserializeForm()
        {
            InitializeComponent();

            // Установка предварительных параметров объектов для работы программы.
            SetDefaultSettings();

            // Получение информации обо всех сохраненных состояниях склада.
            GetDataFromDirectory();

            timer1.Start();
        }

        /// <summary>
        /// Установка предварительных параметров объектов для работы программы.
        /// </summary>
        private void SetDefaultSettings()
        {
            dataTableDefault.Columns.Add("Сохранение");
            dataTableDefault.Columns.Add("Дата сохранения");
            dataTableDefault.Columns.Add("Объем файла (КБ)");

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
        }

        /// <summary>
        /// Получение информации обо всех сохраненных состояниях склада.
        /// </summary>
        private void GetDataFromDirectory()
        {
            try
            {
                DataTable dataTable = dataTableDefault.Clone();

                for (int i = 0; i < Directory.GetFiles($"..{Path.DirectorySeparatorChar}data serialize").Length; i++)
                {
                    // Получение объема файла в байтах.
                    long length = new FileInfo($"..{Path.DirectorySeparatorChar}data serialize{Path.DirectorySeparatorChar}data{i + 1}.txt").Length;

                    // Формирование строки о сохранении.
                    string[] infoAboutFile = new string[] { $"Сохранение #{i + 1}",
                    $"{File.GetCreationTime($"..{Path.DirectorySeparatorChar}data serialize{Path.DirectorySeparatorChar}data{i + 1}.txt")}",
                    $"{length / 1024.0}"};

                    dataTable.Rows.Add(infoAboutFile);
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 180;
                dataGridView1.Columns[2].Width = 180;
            }
            catch (Exception ex) { MessageBox.Show($"Произошла неизвестная ошибка!" +
                $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); };
        }

        /// <summary>
        /// Тики таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells != null)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        /// <summary>
        /// Подтверждение загрузки сохраненной информации.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.SelfRef.Deserialize($"..{Path.DirectorySeparatorChar}data serialize" +
                    $"{Path.DirectorySeparatorChar}data{dataGridView1.SelectedCells[0].RowIndex + 1}.txt");

                Close();
            }
            catch (Exception ex) { MessageBox.Show($"Произошла неизвестная ошибка!" +
                $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); };
        }
    }
}
