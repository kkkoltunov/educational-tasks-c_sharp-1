using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ExcelMini
{
    public partial class ChartBuilder : Form
    {
        /// <summary>
        /// Параметры культуры.
        /// </summary>
        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");

        /// <summary>
        /// Количество столбцов в таблице.
        /// </summary>
        public int CountColums { get; set; }

        /// <summary>
        /// Массив с данными столбца.
        /// </summary>
        public double[] DataOfColumnDouble { get; set; }

        /// <summary>
        /// Параметр типа столбца.
        /// </summary>
        public bool IsDouble { get; set; }

        /// <summary>
        /// Индекс выбранного столбца.
        /// </summary>
        public int IndexOfTheColumn { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public ChartBuilder()
        {
            InitializeComponent();

            // Установка параметров культуры.
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            label5.Visible = false;
            comboBox2.Visible = false;
            label6.Visible = false;
            comboBox3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            IsDouble = false;
            chart1.Series[0].IsValueShownAsLabel = true;

            SetExampleOfDonut();
        }

        /// <summary>
        /// Установка примера круговой диаграммы.
        /// </summary>
        private void SetExampleOfDonut()
        {
            comboBox2.SelectedItem = null;

            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddY(250);
            chart1.Series[0].Points[0].LegendText = "Незачет";
            chart1.Series[0].Points.AddY(30);
            chart1.Series[0].Points[1].LegendText = "Удовлетворительно";
            chart1.Series[0].Points.AddY(10);
            chart1.Series[0].Points[2].LegendText = "Хорошо";
            chart1.Series[0].Points.AddY(5);
            chart1.Series[0].Points[3].LegendText = "Отлично";

            labelTitleOfTheDiagram.Text = "Круговая диаграмма по столбцу. \"Информация об оценках студентов за коллоквиум по линейной алгебре.\"";

            label1.Text = "Среднее значение по столбцу:";
            label2.Text = "Медиана столбца:";
            label3.Text = "Среднеквадратичное отклонение:";
            label4.Text = "Дисперсия:";
        }

        /// <summary>
        /// Установка умалчиваемых значений для panel1.
        /// </summary>
        private void SetDefaultSettings()
        {
            label1.Text = "Среднее значение по столбцу:";
            label2.Text = "Медиана столбца:";
            label3.Text = "Среднеквадратичное отклонение:";
            label4.Text = "Дисперсия:";
        }

        /// <summary>
        /// Установка примера графика.
        /// </summary>
        private void SetExampleOfChart()
        {
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Name = "Функция";
            chart1.ChartAreas[0].AxisX.Title = $"Ось X";
            chart1.ChartAreas[0].AxisY.Title = $"Ось Y";
            chart1.Series[0].BorderWidth = 3;

            chart1.Series[0].Points.AddXY(1, 100);
            chart1.Series[0].Points.AddXY(2, 70);
            chart1.Series[0].Points.AddXY(3, 50);
            chart1.Series[0].Points.AddXY(4, 30);
            chart1.Series[0].Points.AddXY(5, 5);

            chart1.Series[0].IsValueShownAsLabel = true;

            labelTitleOfTheDiagram.Text = "График по столбцам. \"Уровень виживаемости первокурсников ПИ по годам.\"";

            foreach (var el in chart1.Series[0].Points)
            {
                el.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                el.MarkerBorderColor = Color.Black;
                el.BackSecondaryColor = Color.Red;
                el.MarkerColor = Color.Red;
                el.MarkerSize = 10;
            }
        }

        /// <summary>
        /// Установка примера столбчатой диаграммы.
        /// </summary>
        private void SetExampleOfColumn()
        {
            comboBox2.SelectedItem = null;

            chart1.Series[0].Points.Clear();

            chart1.Series[0].Name = "";
            chart1.ChartAreas[0].AxisX.Title = $"";
            chart1.ChartAreas[0].AxisY.Title = $"";

            chart1.Series[0].Points.Add(50);
            chart1.Series[0].Points.Add(340);
            chart1.Series[0].Points.Add(228);
            chart1.Series[0].Points.Add(20);
            chart1.Series[0].Points.Add(100);

            chart1.Series[0].IsValueShownAsLabel = true;

            labelTitleOfTheDiagram.Text = "Диаграмма по столбцу. \"Какой-то пример из интернетов.\"";
        }

        /// <summary>
        /// Установка умалчиваемых значений для компонентов.
        /// </summary>
        private void SetDefaultParametrs()
        {
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            comboBox4.Items.Clear();
            label5.Visible = false;
            comboBox2.Visible = false;
            label6.Visible = false;
            comboBox3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            IsDouble = false;
            chart1.Series.Clear();
            chart1.Series.Add("Series1");
            chart1.Series[0].IsValueShownAsLabel = false;
        }

        /// <summary>
        /// Смена элемента в comboBox1
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.SelfRef.CountRows <= 2)
            {
                MessageBox.Show($"Недостаточно строк для выполнения анализа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Установка умалчиваемых значений.
            SetDefaultParametrs();

            try
            {
                string[] columnsInfo = new string[CountColums];
                for (int i = 0; i < CountColums; i++)
                {
                    columnsInfo[i] = $"{i + 1} столбец";
                }

                // Вызов нужных методов.
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        CallFirstMethod(columnsInfo);
                        break;
                    case 1:
                        CallSecondMethod();
                        break;
                    case 2:
                        CallThirdMethod();
                        break;
                }

                if (comboBox2.Items.Count == 0)
                    comboBox2.Items.AddRange(columnsInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отображение нужных контролов для графика.
        /// </summary>
        /// <param name="columnsInfo">Масив со столбцами.</param>
        private void CallFirstMethod(string[] columnsInfo)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            SetExampleOfChart();
            label5.Visible = true;
            comboBox2.Visible = true;
            label6.Visible = true;
            comboBox3.Visible = true;
            if (comboBox3.Items.Count == 0)
                comboBox3.Items.AddRange(columnsInfo);
        }

        /// <summary>
        /// Отображение нужных контролов для столбчатой диаграммы.
        /// </summary>
        private void CallSecondMethod()
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            SetExampleOfColumn();
            label5.Visible = true;
            comboBox2.Visible = true;
        }

        /// <summary>
        /// Отображение нужных контролов для круговой диаграммы.
        /// </summary>
        private void CallThirdMethod()
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            SetExampleOfDonut();
            label5.Visible = true;
            comboBox2.Visible = true;
            panel1.Visible = true;
        }

        /// <summary>
        /// Анализ числового столбца по параметрам.
        /// </summary>
        /// <param name="numberOfTheColumn"></param>
        private void AnalyzeNumericColumn(int numberOfTheColumn)
        {
            // Получение всех данных из столбца.
            string[] info = MainForm.SelfRef.GetInfoAboutColumn(numberOfTheColumn);
            double[] infoDouble = new double[info.Length];
            double avarageOfColumn = 0;

            for (int i = 0; i < infoDouble.Length; i++)
            {
                if (info[i] == "NaN" || !double.TryParse(info[i], out infoDouble[i]))
                {
                    SetExampleOfDonut();
                    MessageBox.Show($"Невозможно провести данный анализ по выбранному столбцу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                avarageOfColumn += infoDouble[i];

                // Добавление точки на график и аннотации к ней.
                chart1.Series[0].Points.AddY(infoDouble[i]);
                chart1.Series[0].Points[i].LegendText = $"Точка {i + 1}";
            }

            // Отображение значения на элементах на графике.
            if (infoDouble.Length <= 20)
            {
                chart1.Series[0].IsValueShownAsLabel = true;
            }

            // Подсчет среднего арифмитического.
            avarageOfColumn /= infoDouble.Length;

            Array.Sort(infoDouble);

            // Подсчет среднего значения, медианы, среднеквадратичного отклонения и дисперсии.
            label1.Text = label1.Text + $" {avarageOfColumn:f10}";
            label2.Text = label2.Text + $" {(infoDouble[(infoDouble.Length + 1) / 2]):f10}";
            label3.Text = label3.Text + $" {StandardDeviation(infoDouble, avarageOfColumn):f10}";
            label4.Text = label4.Text + $" {Variance((double[])infoDouble.Clone(), avarageOfColumn):f10}";

            // Подпись графика.
            labelTitleOfTheDiagram.Text = $"Круговая диаграмма по столбцу. \"{MainForm.SelfRef.NameOfTheColumn(numberOfTheColumn)}\"";
        }

        /// <summary>
        /// Подсчет среднеквардратичного отклонения.
        /// </summary>
        /// <param name="infoDouble">Массив с данными столбца.</param>
        /// <param name="avarageOfColumn">Среднее арифметическое по данному столбцу.</param>
        /// <returns>Значение отколнения.</returns>
        private double StandardDeviation(double[] infoDouble, double avarageOfColumn)
        {
            double result = 0;

            for (int i = 0; i < infoDouble.Length; i++)
            {
                result += Math.Pow((infoDouble[i] - avarageOfColumn), 2);
            }

            result /= infoDouble.Length;

            return result;
        }

        /// <summary>
        /// Подсчет дисперсии.
        /// </summary>
        /// <param name="infoDouble">Массив с данными столбца.</param>
        /// <param name="avarageOfColumn">Среднее арифметическое по данному столбцу.</param>
        /// <returns>Значение дисперсии.</returns>
        private double Variance(double[] infoDouble, double avarageOfColumn)
        {
            double result = 0;

            for (int i = 0; i < infoDouble.Length; i++)
            {
                infoDouble[i] -= avarageOfColumn;
                result += Math.Pow(infoDouble[i], 2);
            }

            return result;
        }

        /// <summary>
        /// Анализ любого столбца по числу встречаемости элементов или интервалам.
        /// </summary>
        /// <param name="numberOfTheColumn">Номер выбранного столбца.</param>
        private void AnalyzeSelectColumn(int numberOfTheColumn)
        {
            // Словарь с данными, встречающимися в столбце.
            Dictionary<string, double> data = new Dictionary<string, double>();
            bool flagNotDouble = false;
            IndexOfTheColumn = numberOfTheColumn;
            string[] info = MainForm.SelfRef.GetInfoAboutColumn(numberOfTheColumn);
            double[] infoDouble = new double[info.Length];

            try
            {
                for (int i = 0; i < info.Length; i++)
                {
                    if (!double.TryParse(info[i], out infoDouble[i]))
                    {
                        flagNotDouble = true;
                    }
                    if (!data.ContainsKey(info[i]))
                    {
                        data.Add(info[i], 1);
                    }
                    else
                    {
                        data[info[i]]++;
                    }
                }

                DataOfColumnDouble = infoDouble;
                panel2.Visible = true;
                labelTitleOfTheDiagram.Text = $"Диаграмма по столбцу. \"{MainForm.SelfRef.NameOfTheColumn(numberOfTheColumn)}\"";

                // Проведение аналитики в зависимости от типа параметров столбца.
                if (flagNotDouble)
                {
                    AddDataToColumn(data);
                }
                else
                {
                    IsDouble = true;
                    ChangeInterval(infoDouble);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление информации о числе повторений строковых данных в столбце.
        /// </summary>
        /// <param name="data">Словарь с данными.</param>
        private void AddDataToColumn(Dictionary<string, double> data)
        {
            IsDouble = false;
            bool flagAnnotationColumn = false;

            // Анотация столбцов при их количестве меньше 20.
            if (data.Count <= 20) flagAnnotationColumn = true;

            // Максимальное значение переключателя.
            numericUpDown1.Maximum = 1;

            // Информация о столбцах для изменения цвета.
            string[] columnsInfo = new string[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                columnsInfo[i] = $"{i + 1} столбец";
            }

            // Очистка и добавление элементов.
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(columnsInfo);

            chart1.Series.Clear();

            int j = 0;
            foreach (KeyValuePair<string, double> keyValue in data)
            {
                chart1.Series.Add(keyValue.Key);
                if (flagAnnotationColumn)
                {
                    chart1.Series[j].IsValueShownAsLabel = true;
                }
                chart1.Series[j++].Points.Add(keyValue.Value);
            }
        }

        /// <summary>
        /// Добавление точек по частоте встречаемости данных.
        /// </summary>
        /// <param name="numberOfTheFirstColumn">Номер первого столбца для анализа.</param>
        /// <param name="numberOfTheSecondColumn">Номер второго столбца для анализа.</param>
        private void BuildChart(int numberOfTheFirstColumn, int numberOfTheSecondColumn)
        {
            // Получение данных о столбцах.
            string[] infoFirstColumn = MainForm.SelfRef.GetInfoAboutColumn(numberOfTheFirstColumn);
            string[] infoSecondColumn = MainForm.SelfRef.GetInfoAboutColumn(numberOfTheSecondColumn);
            double[] infoDoubleFirstColumn = new double[infoFirstColumn.Length];
            double[] infoDoubleSecondColumn = new double[infoSecondColumn.Length];

            chart1.Series[0].Points.Clear();
            chart1.Series[0].BorderWidth = 3;

            // Парсинг данных столбца.
            for (int i = 0; i < infoFirstColumn.Length; i++)
            {
                if (infoFirstColumn[i] == "NaN" || infoSecondColumn[i] == "NaN" || !double.TryParse(infoFirstColumn[i], out infoDoubleFirstColumn[i]) || !double.TryParse(infoSecondColumn[i], out infoDoubleSecondColumn[i]))
                {
                    SetExampleOfChart();
                    MessageBox.Show($"Невозможно провести данный анализ по выбранному столбцу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Анотация столбцов при их количестве меньше 20.
            if (infoFirstColumn.Length <= 20) chart1.Series[0].IsVisibleInLegend = true;

            // Добавление точек на график.
            for (int i = 0; i < infoFirstColumn.Length; i++)
            {
                chart1.Series[0].Points.AddXY(infoDoubleFirstColumn[i], infoDoubleSecondColumn[i]);
            }

            // Добавление подписей на график.
            chart1.Series[0].Name = "Функция";
            chart1.ChartAreas[0].AxisX.Title = $"{MainForm.SelfRef.NameOfTheColumn(numberOfTheFirstColumn)}";
            chart1.ChartAreas[0].AxisY.Title = $"{MainForm.SelfRef.NameOfTheColumn(numberOfTheSecondColumn)}";
            labelTitleOfTheDiagram.Text = $"График по столбцам. \"{MainForm.SelfRef.NameOfTheColumn(numberOfTheFirstColumn)}\". \"{MainForm.SelfRef.NameOfTheColumn(numberOfTheSecondColumn)}\"";

            // Изменение цвета для точек.
            foreach (var el in chart1.Series[0].Points)
            {
                el.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                el.MarkerBorderColor = Color.Black;
                el.BackSecondaryColor = Color.Red;
                el.MarkerColor = Color.Red;
                el.MarkerSize = 10;
            }
        }
        
        /// <summary>
        /// Изменение элемента в comboBox2.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверка количества строк в настоящей таблице.
            if (MainForm.SelfRef.CountRows <= 2)
            {
                MessageBox.Show($"Недостаточно строк для выполнения анализа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            IsDouble = false;

            // Очистка всех существующих точек.
            chart1.Series[0].Points.Clear();

            // Отключение подписей к данным на графике.
            chart1.Series[0].IsValueShownAsLabel = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (comboBox3.SelectedItem == null || comboBox2.SelectedItem == null)
                        return;
                    BuildChart(comboBox2.SelectedIndex, comboBox3.SelectedIndex);
                    break;
                case 1:
                    if (comboBox2.SelectedItem == null)
                        return;
                    comboBox4.Items.Clear();
                    AnalyzeSelectColumn(comboBox2.SelectedIndex);
                    break;
                case 2:
                    SetDefaultSettings();
                    if (comboBox2.SelectedItem == null)
                        return;
                    AnalyzeNumericColumn(comboBox2.SelectedIndex);
                    break;
            }
        }

        /// <summary>
        /// Изменение элемента в comboBox3.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверка количества строк в настоящей таблице.
            if (MainForm.SelfRef.CountRows <= 2)
            {
                MessageBox.Show($"Недостаточно строк для выполнения анализа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (comboBox3.SelectedItem == null || comboBox2.SelectedItem == null)
                return;

            IsDouble = false;
            chart1.Series[0].IsValueShownAsLabel = false;

            BuildChart(comboBox2.SelectedIndex, comboBox3.SelectedIndex);
        }

        /// <summary>
        /// Сохранение графика.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonSaveChart_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Сохранить изображение как ...";
                    saveFileDialog.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = "ChartImage";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1: chart1.SaveImage(saveFileDialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp); break;
                            case 2: chart1.SaveImage(saveFileDialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); break;
                            case 3: chart1.SaveImage(saveFileDialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); break;
                        }

                        MessageBox.Show("Изображение графика успешно сохранено!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Изменение элемента в comboBox4.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.SelectedItem != null)
                {
                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < comboBox4.Items.Count; i++)
                        {
                            if (chart1.Series[i].Color == colorDialog1.Color)
                            {
                                MessageBox.Show($"Данный цвет уже применен в столбце.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        chart1.Series[comboBox4.SelectedIndex].Color = colorDialog1.Color;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Изменение интервала.
        /// </summary>
        /// <param name="infoDouble">Массив с данными столбца.</param>
        /// <param name="numberOfTheColumn">Номер столбца.</param>
        private void ChangeInterval(double[] infoDouble)
        {
            double min = double.MaxValue;
            double max = double.MinValue;

            // Поиск максимального и минимального значения.
            for (int i = 0; i < infoDouble.Length; i++)
            {
                if (infoDouble[i] > max)
                    max = infoDouble[i];
                if (infoDouble[i] < min)
                    min = infoDouble[i];
            }

            // Установка макисмального значения для numericUpDown1.
            if (max - min >= 1)
            {
                numericUpDown1.Maximum = (decimal)(max - min);
            }
            else
            {
                MessageBox.Show("Недостаточно данных для анализа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int countColumns = (int)numericUpDown1.Value;
            int[] coords = new int[countColumns];

            for (int i = 0; i < infoDouble.Length; i++)
                for (int j = 0; j < countColumns; j++)
                    if (infoDouble[i] > min + (((max - min + 1) / countColumns) * j) && infoDouble[i] < min + (((max - min + 1) / countColumns) * (j + 1)))
                        coords[j]++;

            if (countColumns == 1 || countColumns == 2)
                for (int j = 0; j < countColumns; j++)
                    coords[j]++;

            AddInfoAboutColumns(coords, min, max, countColumns);
        }

        /// <summary>
        /// Добавление информации на график.
        /// </summary>
        /// <param name="coords">Массив с данными в интервалах.</param>
        /// <param name="min">Минимальное значение во всем столбце.</param>
        /// <param name="max">Максимальное значение во всем столбце.</param>
        /// <param name="countColumns">Количество столбцов.</param>
        public void AddInfoAboutColumns(int[] coords, double min, double max, int countColumns)
        {
            bool flagAnnotationColumn = false;

            if (coords.Length <= 20) flagAnnotationColumn = true;

            // Добавление столбцов по интервалам.
            chart1.Series.Clear();
            for (int i = 0; i < coords.Length; i++)
            {
                chart1.Series.Add($"[{(int)(((max - min + 1) / countColumns * i) + min)}, {(int)(((max - min + 1) / countColumns * (i + 1)) + min)})");
                if (flagAnnotationColumn)
                {
                    chart1.Series[i].IsValueShownAsLabel = true;
                }
                chart1.Series[i].Points.Add(coords[i]);
            }

            // Добавления списка столбцов для изменения цвета.
            string[] columnsInfo = new string[coords.Length];
            for (int i = 0; i < coords.Length; i++)
            {
                columnsInfo[i] = $"{i + 1} столбец";
            }

            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(columnsInfo);
        }

        /// <summary>
        /// Клик элемента в контроле numericUpDown1.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsDouble)
                {
                    ChangeInterval(DataOfColumnDouble);
                }
                else
                {
                    MessageBox.Show("Данное действие предусмотрено только для числовых данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Клик по контролу numericUpDown1.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            if (!IsDouble)
            {
                MessageBox.Show("Данное действие предусмотрено только для числовых данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
