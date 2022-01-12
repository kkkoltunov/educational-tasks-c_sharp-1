using System;
using System.Windows.Forms;

namespace SellersAndBuyers
{
    public partial class SelectProductForm : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public SelectProductForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Установка текста.
        /// </summary>
        /// <param name="text">Текст.</param>
        public void SetTextLabel1(string text)
        {
            typeCarLabel.Text = text;
        }

        /// <summary>
        /// Установка текста.
        /// </summary>
        /// <param name="text">Текст.</param>
        public void SetTextLabel2(string text)
        {
            typeFuelLabel.Text = text;
        }

        /// <summary>
        /// Установка текста.
        /// </summary>
        /// <param name="text">Текст.</param>
        public void SetTextLabel3(string text)
        {
            typeBodyLabel.Text = text;
        }

        /// <summary>
        /// Установка текста.
        /// </summary>
        /// <param name="text">Текст.</param>
        public void SetTextLabel4(string text)
        {
            countLabel.Text = text;
        }

        /// <summary>
        /// Установка текста.
        /// </summary>
        /// <param name="text">Текст.</param>
        public void SetTextLabel5(string text)
        {
            priceLabel.Text = text;
        }

        /// <summary>
        /// Подтверждение заказа выбранного товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!uint.TryParse(textBox4.Text, out uint count) || count <= 0)
            {
                textBox4.Text = "";
                MessageBox.Show($"Количество должно быть целым неотрицательным числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            uint.TryParse(countLabel.Text, out uint countOnWarehouse);

            if (count > countOnWarehouse)
            {
                textBox4.Text = "";
                MessageBox.Show($"Количество товара не должно превышать его количество на складе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BuyersForm.SelfRef.AddProductToBasket(count);
            Close();
        }
    }
}
