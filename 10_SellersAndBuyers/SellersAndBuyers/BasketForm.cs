using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SellersAndBuyers
{
    public partial class BasketForm : Form
    {
        /// <summary>
        /// Словарь, в котором ключ - продукт, а значение - количество в заказе.
        /// </summary>
        public Dictionary<Product, uint> Products { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public BasketForm()
        {
            InitializeComponent();

            timer1.Start();
        }

        /// <summary>
        /// Добавление данных в таблицу.
        /// </summary>
        void SetDataInTable()
        {
            DataTable dataTable = new DataTable();
            string[] nameColumns = new string[] { "Марка автомобиля", "Тип топлива", "Тип кузова", "Остаток на складе", "Стоимость ($)", "Количество в заказе" };

            for (int i = 0; i < nameColumns.Length; i++)
                dataTable.Columns.Add(nameColumns[i]);

            try
            {
                int j = 0;
                foreach (KeyValuePair<Product, uint> product in Products)
                {
                    dataTable.Rows.Add();
                    dataTable.Rows[j][0] = product.Key.CarBrand;
                    dataTable.Rows[j][1] = product.Key.FuelType;
                    dataTable.Rows[j][2] = product.Key.BodyType;
                    dataTable.Rows[j][3] = product.Key.Count;
                    dataTable.Rows[j][4] = product.Key.Price;
                    dataTable.Rows[j][5] = product.Value;
                    j++;
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
            dataGridView1.Columns[5].Width = 200;

            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        /// <summary>
        /// Тики таймера.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            SetDataInTable();
        }

        /// <summary>
        /// Добавление нового заказа.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            BuyersForm.SelfRef.AddNewOrder(Products);

            Close();
        }
    }
}
