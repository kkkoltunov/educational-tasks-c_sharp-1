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
    public partial class OrdersForm : Form
    {
        /// <summary>
        /// Список заказов.
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public OrdersForm()
        {
            InitializeComponent();

            timer1.Start();
        }

        /// <summary>
        /// Добавление данных в таблицу.
        /// </summary>
        void AddOrdersToTable()
        {
            DataTable dataTable = new DataTable();

            string[] nameColumns = new string[] { "Номер заказа", "Статус", "Дата заказа", "Информация о заказанных товарах", "Стоимость ($)" };

            for (int i = 0; i < nameColumns.Length; i++)
                dataTable.Columns.Add(nameColumns[i]);

            try
            {
                for (int i = 0; i < Orders.Count; i++)
                {
                    string[] data = Orders[i].ToString().Split(';');
                    dataTable.Rows.Add();
                    dataTable.Rows[i][0] = data[0];
                    dataTable.Rows[i][1] = data[1];
                    dataTable.Rows[i][2] = data[2];
                    dataTable.Rows[i][3] = data[3];
                    dataTable.Rows[i][4] = data[4];
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
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 200;

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

            AddOrdersToTable();
        }

        /// <summary>
        /// Оплата заказа.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells != null)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (Orders[dataGridView1.SelectedCells[0].RowIndex].Status != Status.New && Orders[dataGridView1.SelectedCells[0].RowIndex].Paid != true)
                    {
                        Orders[dataGridView1.SelectedCells[0].RowIndex].Paid = true;

                        MessageBox.Show($"Заказ успешно оплачен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"Данный заказ оплачен или имеет статус \"НОВЫЙ\". Для оплаты нужен статус \"ОБРАБОТАН\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Необходимо выбрать товар в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
