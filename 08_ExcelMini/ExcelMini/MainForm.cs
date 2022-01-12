using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace ExcelMini
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Свойство ссылки на данную форму.
        /// </summary>
        public static MainForm SelfRef { get; set; }

        /// <summary>
        /// Изменение русской локали на американскую.
        /// </summary>
        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");

        /// <summary>
        /// Свойство для получения актуального количества строк.
        /// </summary>
        public int CountRows
        {
            get => dataGridView1.Rows.Count;
        }

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Установка параметров культуры.
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            // Установка ссылки на объект.
            SelfRef = this;
        }

        /// <summary>
        /// Окно для октрытия таблицы с данными.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonOpenCSV_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка количества открытых форм.
                foreach (Form forms in Application.OpenForms)
                {
                    if (forms.Name == "OpenFileForm")
                    {
                        MessageBox.Show($"Данное окно уже открыто!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (forms.Name == "ChartBuilder")
                    {
                        MessageBox.Show($"Для открытия новой таблицы закройте все окна с аналитикой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Создание нового окна с установкой параметров открываемого файла.
                Form form = new OpenFileForm();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Окно для аналитики данных.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonAnalyzeData_Click(object sender, EventArgs e)
        {
            int counterOpenAnalyzeForms = 0;

            try
            {
                // Проверка корректности данных перед открытием.
                if (dataGridView1.Columns.Count == 0)
                {
                    MessageBox.Show($"Таблица не загружена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridView1.Rows.Count <= 2)
                {
                    MessageBox.Show($"Недостаточно строк для выполнения анализа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Подсчет количества открытых окон (максимум 5).
                foreach (Form forms in Application.OpenForms)
                {
                    if (forms.Name == "ChartBuilder")
                    {
                        counterOpenAnalyzeForms++;
                    }
                }
                if (counterOpenAnalyzeForms == 5)
                {
                    MessageBox.Show($"Открыто максимальное количество окон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Создание нового окна для аналитики данных.
                ChartBuilder form = new ChartBuilder();
                form.CountColums = dataGridView1.ColumnCount;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Парсинг загружаемого файла.
        /// </summary>
        /// <param name="fileName">Путь к файлу.</param>
        /// <param name="delimiters">Разделитель.</param>
        /// <param name="firstRowContainsFieldNames">Параметры первой строки.</param>
        public void NewDataTable(string fileName, string delimiters, bool firstRowContainsFieldNames)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // Использование библиотеки для парсинга.
                using (Microsoft.VisualBasic.FileIO.TextFieldParser textFieldParser = new Microsoft.VisualBasic.FileIO.TextFieldParser(fileName))
                {
                    // Установка разделителей.
                    textFieldParser.SetDelimiters(delimiters);

                    if (!textFieldParser.EndOfData)
                    {
                        string[] fields = textFieldParser.ReadFields();

                        // Установка названий столбцов.
                        for (int i = 0; i < fields.Count(); i++)
                        {
                            if (firstRowContainsFieldNames)
                                dataTable.Columns.Add(fields[i]);
                            else
                                dataTable.Columns.Add($"Сolumn{i + 1}");
                        }
                        if (!firstRowContainsFieldNames)
                            dataTable.Rows.Add(fields);
                    }

                    // Считывание строк до конца файла.
                    while (!textFieldParser.EndOfData)
                    {
                        string[] fields = textFieldParser.ReadFields();

                        for (int i = 0; i < fields.Length; i++)
                            if (fields[i] == null || fields[i] == "")
                                fields[i] = "NaN";

                        dataTable.Rows.Add(fields);
                    }
                }

                // Загрузка данных в DataGrid.
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение строк выбранного столбца.
        /// </summary>
        /// <param name="indexOfTheColumn">Номер столбца.</param>
        /// <returns>Массив данных.</returns>
        public string[] GetInfoAboutColumn(int indexOfTheColumn)
        {
            try
            {
                string[] info = new string[dataGridView1.RowCount - 1];

                for (int i = 0; i < info.Length; i++)
                {
                    info[i] = dataGridView1[indexOfTheColumn, i].Value.ToString();
                }

                return info;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return new string[]{ "default1", "default2", "default3" };
        }

        /// <summary>
        /// Получение названия выбранного столбца.
        /// </summary>
        /// <param name="numberOfTheColumn">Номер столбца.</param>
        /// <returns>Строка с данными.</returns>
        public string NameOfTheColumn(int numberOfTheColumn)
        {
            try
            {
                return dataGridView1.Columns[numberOfTheColumn].Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "DefaultNameOfTheColumn";
        }
    }
}
