using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SellersAndBuyers
{
    public partial class SellersForm : Form
    {
        /// <summary>
        /// Ссылка на форму.
        /// </summary>
        public static SellersForm SelfRef { get; set; }

        /// <summary>
        /// Индекс закрытия формы.
        /// </summary>
        public static int CloseIndex { get; set; }

        /// <summary>
        /// Список заказов.
        /// </summary>
        List<Order> orders;

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public SellersForm()
        {
            InitializeComponent();

            SetDataInTable();

            orders = new List<Order>();

            AddOrdersToData();

            SelfRef = this;

            timer1.Start();
        }

        /// <summary>
        /// добавление данных в таблицу.
        /// </summary>
        void SetDataInTable()
        {
            string[] data = File.ReadAllLines("dataParse.txt");

            DataTable dataTable = new DataTable();
            string[] nameColumns = data[0].Split(';');

            for (int i = 0; i < nameColumns.Length; i++)
                dataTable.Columns.Add(nameColumns[i]);

            for (int i = 1; i < data.Length; i++)
            {
                string[] dataRow = data[i].Split(";", StringSplitOptions.RemoveEmptyEntries);
                dataTable.Rows.Add(dataRow);
            }

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
        }

        /// <summary>
        /// Сериализация данных в файлы с заказчиками.
        /// </summary>
        void AddOrdersToData()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($"..{Path.DirectorySeparatorChar}data_buyers");

            orders = new List<Order>();

            if (directoryInfo.GetDirectories().Length > 0)
            {
                try
                {
                    for (int i = 0; i < directoryInfo.GetDirectories().Length; i++)
                    {
                        using (Stream file = File.Open($"..{Path.DirectorySeparatorChar}data_buyers{Path.DirectorySeparatorChar}user{i + 1}{Path.DirectorySeparatorChar}orders.txt", FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            BinaryFormatter bf = new BinaryFormatter();
                            var newOrders = (List<Order>)bf.Deserialize(file);
                            orders.AddRange(newOrders);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла неизвестная ошибка!" +
                        $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Сериализация данных в файлы с заказчиками.
        /// </summary>
        void Serialize()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($"..{Path.DirectorySeparatorChar}data_buyers");

            if (directoryInfo.GetDirectories().Length > 0)
            {
                try
                {
                    for (int i = 0; i < directoryInfo.GetDirectories().Length; i++)
                    {
                        List<Order> newOrders = new List<Order>();
                        
                        for (int j = 0; j < orders.Count; j++)
                        {
                            if (orders[j].Client.ID == i + 1)
                            {
                                newOrders.Add(orders[j]);
                            }
                        }

                        using (Stream file = File.Open($"..{Path.DirectorySeparatorChar}data_buyers{Path.DirectorySeparatorChar}user{i + 1}{Path.DirectorySeparatorChar}orders.txt", FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(file, newOrders);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла неизвестная ошибка!" +
                        $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Тики таймера.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            try
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (CloseIndex == 0)
                MessageBox.Show($"Авторизация выполнена успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Метод для закрытия формы из внешнего кода.
        /// </summary>
        public void CloseMe()
        {
            MessageBox.Show($"Для работы с магазином необходимо авторизоваться!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Close();
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void SellersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable data = (DataTable)dataGridView1.DataSource;

            string nameColumns = $"Марка автомобиля;Тип топлива;Тип кузова;Остаток на складе;Стоимость ($)";

            List<string> dataColumns = new List<string>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                dataColumns.Add($"{data.Rows[i][0]};{data.Rows[i][1]};{data.Rows[i][2]};{data.Rows[i][3]};{data.Rows[i][4]}");
            }

            using (StreamWriter writer = File.CreateText("dataParse.txt"))
            {
                writer.WriteLine(nameColumns);

                foreach (var el in dataColumns)
                    writer.WriteLine(el);
            }

            Serialize();
        }

        /// <summary>
        /// Клиенты, совершившие заказы.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void checkClientsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (orders.Count > 0)
                {
                    AllClientsForm allClientsForm = new AllClientsForm();
                    allClientsForm.Orders = orders;
                    allClientsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Клиенты, совершившие заказы, отсутствуют!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Демонстрация заказов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkOrdersButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (orders.Count > 0)
                {
                    AllOrdersForm allOrdersForm = new AllOrdersForm();
                    allOrdersForm.Orders = orders;
                    allOrdersForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Заказы отсутсвуют!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Просмотр списка активных клиентов.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> activeOrders = new List<Order>();

            try
            {
                for (int i = 0; i < orders.Count; i++)
                    if (orders[i].Status != Status.Completed)
                        activeOrders.Add(orders[i]);

                if (activeOrders.Count > 0)
                {
                    AllActiveOrdersForm allActiveOrdersForm = new AllActiveOrdersForm();
                    allActiveOrdersForm.Orders = activeOrders;
                    allActiveOrdersForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Заказы отсутсвуют!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
