using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SellersAndBuyers
{
    public partial class AllOrdersForm : Form
    {
        /// <summary>
        /// Список заказов клиентов.
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public AllOrdersForm()
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

            string[] nameColumns = new string[] { "Номер заказа", "Статус", "Дата заказа", "Информация о заказанных товарах", "Стоимость ($)", "Заказчик" };

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
                    dataTable.Rows[i][5] = data[5];
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

            AddOrdersToTable();
        }

        /// <summary>
        /// Обновление данных таблицы.
        /// </summary>
        void RefreshDataTable()
        {
            dataGridView1.DataSource = new DataTable();

            AddOrdersToTable();
        }

        /// <summary>
        /// Установка статуса "Обработан".
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells != null)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (Orders[dataGridView1.SelectedCells[0].RowIndex].Status != Status.Processed && Orders[dataGridView1.SelectedCells[0].RowIndex].Status != Status.Completed && Orders[dataGridView1.SelectedCells[0].RowIndex].Status != Status.Shipped)
                    {
                        Orders[dataGridView1.SelectedCells[0].RowIndex].Status = Status.Processed;

                        MessageBox.Show($"Статус \"ОБРАБОТАН\" успешно установлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshDataTable();
                    }
                    else
                    {
                        MessageBox.Show($"Данный cтатус уже установлен или заказ имеет статус \"ИСПОЛНЕН\", \"ОТГРУЖЕН\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Необходимо выбрать нужный заказ в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Установка статуса "Отгружен".
        /// </summary>
        /// <param name="sender">Объект./param>
        /// <param name="e">Событие.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells != null)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (Orders[dataGridView1.SelectedCells[0].RowIndex].Status != Status.Shipped && Orders[dataGridView1.SelectedCells[0].RowIndex].Status != Status.Completed && Orders[dataGridView1.SelectedCells[0].RowIndex].Status != Status.New)
                    {
                        Orders[dataGridView1.SelectedCells[0].RowIndex].Status = Status.Shipped;

                        MessageBox.Show($"Статус \"ОТГРУЖЕН\" успешно установлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshDataTable();
                    }
                    else
                    {
                        MessageBox.Show($"Данный cтатус уже установлен или заказ имеет статус \"НОВЫЙ\" или \"ИСПОЛНЕН\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Необходимо выбрать нужный заказ в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Установка статуса "Исполнен".
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells != null)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (Orders[dataGridView1.SelectedCells[0].RowIndex].Status != Status.Completed && Orders[dataGridView1.SelectedCells[0].RowIndex].Paid == true)
                    {
                        Orders[dataGridView1.SelectedCells[0].RowIndex].Status = Status.Completed;

                        MessageBox.Show($"Статус \"ИСПОЛНЕН\" успешно установлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshDataTable();
                    }
                    else
                    {
                        MessageBox.Show($"Данный cтатус уже установлен или не оплачен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Необходимо выбрать нужный заказ в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
