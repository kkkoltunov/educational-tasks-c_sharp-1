using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SellersAndBuyers
{
    public partial class OpenForm : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public OpenForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Открытие формы покупателя.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BuyersForm buyersForm = new BuyersForm();
                buyersForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Открытие формы продавца.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SellersForm sellersForm = new SellersForm();
                sellersForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
