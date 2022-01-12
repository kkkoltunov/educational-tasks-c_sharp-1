using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SellersAndBuyers
{
    public partial class BuyersForm : Form
    {
        /// <summary>
        /// Список продуктов в корзине.
        /// </summary>
        List<Product> products = new List<Product>();

        /// <summary>
        /// Список заказов клиента.
        /// </summary>
        List<Order> orders = new List<Order>();

        /// <summary>
        /// Авторизовавшийся клиент.
        /// </summary>
        public Client client;

        /// <summary>
        /// Словарь в котором, ключ - продукт, а значение - количество в корзине.
        /// </summary>
        Dictionary<Product, uint> basket = new Dictionary<Product, uint>();

        /// <summary>
        /// Свойство со ссылкой на данную форму.
        /// </summary>
        public static BuyersForm SelfRef { get; set; }

        /// <summary>
        /// Индекс закрытия формы.
        /// </summary>
        public static int CloseIndex { get; set; }

        /// <summary>
        /// Идентификатор клиента, который совершает покупки.
        /// </summary>
        public static int IndexUser { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public BuyersForm()
        {
            InitializeComponent();

            SetDataInTable();

            SelfRef = this;

            timer1.Start();
        }

        /// <summary>
        /// Добавление данных в таблицу.
        /// </summary>
        void SetDataInTable()
        {
            string[] data = File.ReadAllLines("dataParse.txt");

            DataTable dataTable = new DataTable();
            string[] nameColumns = data[0].Split(';');

            for (int i = 0; i < nameColumns.Length; i++)
                dataTable.Columns.Add(nameColumns[i]);

            try
            {
                for (int i = 1; i < data.Length; i++)
                {
                    string[] dataRow = data[i].Split(";", StringSplitOptions.RemoveEmptyEntries);
                    uint.TryParse(dataRow[3], out uint count);
                    decimal.TryParse(dataRow[4], out decimal price);

                    products.Add(new Product(dataRow[0], dataRow[1], dataRow[2], count, price));

                    dataTable.Rows.Add();
                    dataTable.Rows[i - 1][0] = products[i - 1].CarBrand;
                    dataTable.Rows[i - 1][1] = products[i - 1].FuelType;
                    dataTable.Rows[i - 1][2] = products[i - 1].BodyType;
                    dataTable.Rows[i - 1][3] = products[i - 1].Count;
                    dataTable.Rows[i - 1][4] = products[i - 1].Price;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;

            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        /// <summary>
        /// Добавление товара в корзину.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells != null)
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        if (basket.ContainsKey(products[dataGridView1.SelectedCells[0].RowIndex]))
                        {
                            products[dataGridView1.SelectedCells[0].RowIndex].Count += basket[products[dataGridView1.SelectedCells[0].RowIndex]];
                            dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value = products[dataGridView1.SelectedCells[0].RowIndex].Count.ToString();
                            basket.Remove(products[dataGridView1.SelectedCells[0].RowIndex]);

                            MessageBox.Show($"Товар уже был в вашей корзине, поэтому был удален! Введите нужное количество заново!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        SelectProductForm selectProductForm = new SelectProductForm();
                        selectProductForm.SetTextLabel1(products[dataGridView1.SelectedCells[0].RowIndex].CarBrand);
                        selectProductForm.SetTextLabel2(products[dataGridView1.SelectedCells[0].RowIndex].BodyType);
                        selectProductForm.SetTextLabel3(products[dataGridView1.SelectedCells[0].RowIndex].FuelType);
                        selectProductForm.SetTextLabel4(products[dataGridView1.SelectedCells[0].RowIndex].Count.ToString());
                        selectProductForm.SetTextLabel5(products[dataGridView1.SelectedCells[0].RowIndex].Price.ToString());
                        selectProductForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show($"Необходимо выбрать товар в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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

            try
            {
                LoginAndRegistrationForm loginAndRegistrationForm = new LoginAndRegistrationForm();
                loginAndRegistrationForm.ShowDialog();

                if (CloseIndex == 0)
                {
                    MessageBox.Show($"Авторизация выполнена успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Deserialize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Установка клиента, осуществляющего заказы.
        /// </summary>
        /// <param name="client"></param>
        public void LoginUser(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// Добавление товара, который уже был в корзине.
        /// </summary>
        /// <param name="countOrdered"></param>
        public void AddProductToBasket(uint countOrdered)
        {
            try
            {
                basket.Add(products[dataGridView1.SelectedCells[0].RowIndex], countOrdered);
                products[dataGridView1.SelectedCells[0].RowIndex].Count -= countOrdered;
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value = products[dataGridView1.SelectedCells[0].RowIndex].Count;
                MessageBox.Show($"Товар успешно добавлен в корзину!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление нового заказа.
        /// </summary>
        /// <param name="productsOrdered"></param>
        public void AddNewOrder(Dictionary<Product, uint> productsOrdered)
        {
            Random random = new Random();
            Dictionary<Product, uint> newProductsOrdered = new Dictionary<Product, uint>();

            try
            {
                foreach (KeyValuePair<Product, uint> product in productsOrdered)
                {
                    Product newProduct = product.Key;
                    uint count = product.Value;
                    newProductsOrdered.Add(newProduct, count);
                }

                orders.Add(new Order(newProductsOrdered, DateTime.Now, client, (uint)random.Next(1000, 1000000000)));

                MessageBox.Show($"Заказ успешно создан!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                basket.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        /// Авторизация клиента.
        /// </summary>
        public void Autorization()
        {
            if (CloseIndex == 0)
            {
                MessageBox.Show($"Авторизация выполнена успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Deserialize();
            }
        }

        /// <summary>
        /// Кнопка просмотра корзины.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void basketButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (basket.Count > 0)
                {
                    BasketForm basketForm = new BasketForm();
                    basketForm.Products = basket;
                    basketForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Вы не добавили ни одного товара в корзину!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка просмотра всех заказов.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Соыбтие.</param>
        private void allOrdersButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (orders.Count > 0)
                {
                    OrdersForm ordersForm = new OrdersForm();
                    ordersForm.Orders = orders;
                    ordersForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Вы не сделали ни одного заказа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка изменения клиента.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void changeUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                Serialize();

                LoginAndRegistrationForm loginAndRegistrationForm = new LoginAndRegistrationForm();
                loginAndRegistrationForm.ShowDialog();

                timer2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void BuyersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (IndexUser != 0)
                    Serialize();

                DataTable data = (DataTable)dataGridView1.DataSource;

                string nameColumns = $"Марка автомобиля;Тип топлива;Тип кузова;Остаток на складе;Стоимость ($)";

                List<string> dataColumns = new List<string>();

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    dataColumns.Add($"{data.Rows[i][0]};{data.Rows[i][1]};{data.Rows[i][2]};{data.Rows[i][3]};{data.Rows[i][4]}");
                }

                using (StreamWriter writer = File.CreateText(@"dataParse.txt"))
                {
                    writer.WriteLine(nameColumns);

                    foreach (var el in dataColumns)
                        writer.WriteLine(el);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сериализация.
        /// </summary>
        void Serialize()
        {
            try
            {
                using (Stream file = File.Open($"..{Path.DirectorySeparatorChar}data_buyers{Path.DirectorySeparatorChar}user{IndexUser}{Path.DirectorySeparatorChar}orders.txt", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, orders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Десериализация.
        /// </summary>
        void Deserialize()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($"..{Path.DirectorySeparatorChar}data_buyers{Path.DirectorySeparatorChar}user{IndexUser}");
            if (directoryInfo.GetFiles().Length > 0)
            {

                try
                {
                    using (Stream file = File.Open($"..{Path.DirectorySeparatorChar}data_buyers{Path.DirectorySeparatorChar}user{IndexUser}{Path.DirectorySeparatorChar}orders.txt", FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        orders = (List<Order>)bf.Deserialize(file);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            if (CloseIndex == 0)
            {
                MessageBox.Show($"Авторизация выполнена успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Deserialize();
            }
        }
    }
}
