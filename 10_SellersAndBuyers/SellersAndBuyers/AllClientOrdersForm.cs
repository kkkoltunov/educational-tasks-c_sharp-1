using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace SellersAndBuyers
{
    public partial class AllClientOrdersForm : Form
    {
        /// <summary>
        /// Список заказов клиентов.
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public AllClientOrdersForm()
        {
            InitializeComponent();

            timer1.Start();
        }

        /// <summary>
        /// Добавление заказов в таблицу.
        /// </summary>
        void AddOrdersToTable()
        {
            DataTable dataTable = new DataTable();

            int allPrice = 0;
            string[] nameColumns = new string[] { "Номер заказа", "Статус", "Дата заказа", "Информация о заказанных товарах", "Стоимость ($)" };

            try
            {
                for (int i = 0; i < nameColumns.Length; i++)
                    dataTable.Columns.Add(nameColumns[i]);

                for (int i = 0; i < Orders.Count; i++)
                {
                    string[] data = Orders[i].ToString().Split(';');
                    dataTable.Rows.Add();
                    dataTable.Rows[i][0] = data[0];
                    dataTable.Rows[i][1] = data[1];
                    dataTable.Rows[i][2] = data[2];
                    dataTable.Rows[i][3] = data[3];
                    dataTable.Rows[i][4] = data[4];

                    int.TryParse(data[4], out int sum);
                    allPrice += sum;
                }

                label2.Text = allPrice.ToString();

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 200;

                dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
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

            AddOrdersToTable();
        }
    }
}
