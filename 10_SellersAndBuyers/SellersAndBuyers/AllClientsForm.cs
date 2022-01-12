using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SellersAndBuyers
{
    public partial class AllClientsForm : Form
    {
        /// <summary>
        /// Список заказов клиентов.
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Список всех клиентов.
        /// </summary>
        List<Client> clients;

        /// <summary>
        /// Словарь в котором ключом является ID клиента, а значением - количество заказов.
        /// </summary>
        Dictionary<int, int> ordersCount;

        /// <summary>
        /// Объект клиента, с которым происходит взаимодействие.
        /// </summary>
        Client client;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public AllClientsForm()
        {
            InitializeComponent();

            ordersCount = new Dictionary<int, int>();
            clients = new List<Client>();

            timer1.Start();
        }

        /// <summary>
        /// Получение подробной информации о заказах выбранного клиента.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells != null)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    List<Order> ordersSelectClient = new List<Order>();

                    foreach (var el in Orders)
                        if (el.Client.ID == dataGridView1.SelectedCells[0].RowIndex + 1)
                            ordersSelectClient.Add(el);

                    AllClientOrdersForm allClientOrdersForm = new AllClientOrdersForm();
                    allClientOrdersForm.Orders = ordersSelectClient;
                    allClientOrdersForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Добавление информации о клиентах в таблицу.
        /// </summary>
        void AddOrdersToTable()
        {
            DataTable dataTable = new DataTable();
            string[] nameColumns = new string[] { "ID", "Фамилия", "Имя", "Отчество", "Номер телефона", "Домашний адрес", "E-mail", "Пароль", "Количество заказов" };

            for (int i = 0; i < nameColumns.Length; i++)
                dataTable.Columns.Add(nameColumns[i]);

            try
            {
                for (int i = 0; i < Orders.Count; i++)
                    if (ordersCount.ContainsKey(Orders[i].Client.ID))
                        ordersCount[Orders[i].Client.ID]++;
                    else
                        ordersCount.Add(Orders[i].Client.ID, 1);

                int j = 0;
                foreach (KeyValuePair<int, int> order in ordersCount)
                {
                    client = clients[order.Key - 1];
                    dataTable.Rows.Add();
                    dataTable.Rows[j][0] = client.ID;
                    dataTable.Rows[j][1] = client.Surname;
                    dataTable.Rows[j][2] = client.Name;
                    dataTable.Rows[j][3] = client.Patronymic;
                    dataTable.Rows[j][4] = client.PhoneNumber;
                    dataTable.Rows[j][5] = client.HomeAddress;
                    dataTable.Rows[j][6] = client.EMail;
                    dataTable.Rows[j][7] = client.Password;
                    dataTable.Rows[j][8] = order.Value;
                    j++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.DataSource = dataTable;

            SetDefaultSettings();
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        /// <summary>
        /// Установка ширины столбцов таблицы.
        /// </summary>
        void SetDefaultSettings()
        {
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 200;
            dataGridView1.Columns[8].Width = 200;
        }

        /// <summary>
        /// Десериализация списка клиентов.
        /// </summary>
        void Deserialize()
        {
            try
            {
                using (Stream file = File.Open("usersLoginAndPassword.txt", FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    clients = (List<Client>)bf.Deserialize(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Deserialize();

            AddOrdersToTable();
        }
    }
}
