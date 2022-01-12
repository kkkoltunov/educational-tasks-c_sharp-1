using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProductsWarehouse
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Ссылка на объект данной формы.
        /// </summary>
        public static MainForm SelfRef { get; set; }

        /// <summary>
        /// Таблица с пустыми строками информации о товаре.
        /// </summary>
        DataTable dataTableDefault = new DataTable();

        /// <summary>
        /// Таблица с пустыми строками инормации о товаре для загрузки отчёта.
        /// </summary>
        DataTable dataTableCSV = new DataTable();

        /// <summary>
        /// Объект класса Random для генерации чисел.
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Установка ссылки на форму.
            SelfRef = this;

            // Установка умалчиваемых значений для объектов.
            SetDefaultSettings();

            timer1.Start();
        }

        /// <summary>
        /// Установка предварительных параметров объектов для работы программы.
        /// </summary>
        private void SetDefaultSettings()
        {
            // Загрузка изображения для TreeView.
            try
            {
                ImageList myImageList = new ImageList();
                myImageList.Images.Add(Image.FromFile("folder_image.png"));
                treeView1.ImageList = myImageList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataTableDefault.Columns.Add("Наименование товара");
            dataTableDefault.Columns.Add("Артикул товара");
            dataTableDefault.Columns.Add("Цена товара");
            dataTableDefault.Columns.Add("Остаток на складе");

            dataTableCSV.Columns.Add("путь классификатора");
            dataTableCSV.Columns.Add("артикул");
            dataTableCSV.Columns.Add("название товара");
            dataTableCSV.Columns.Add("количество на складе");

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
        }

        /// <summary>
        /// Создание раздела TreeView.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.Nodes.Count == 0)
                    MessageBox.Show($"Необходимо добавить хотя бы один корневой раздел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (treeView1.SelectedNode == null)
                    MessageBox.Show($"Необходимо выбрать раздел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    SetNameForm setNameForm = new SetNameForm();
                    setNameForm.Indexer = 2;
                    setNameForm.ShowDialog();
                    treeView1.SelectedNode = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление раздела TreeView.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.SelectedNode.Nodes.Count != 0 || dataGridView1.Rows.Count != 0)
                    {
                        MessageBox.Show($"Невозможно удалить данный раздел, так как он содержит какую-то информацию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    treeView1.Nodes.Remove(treeView1.SelectedNode);
                    treeView1.SelectedNode = null;
                    MessageBox.Show($"Раздел успешно удален!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (treeView1.Nodes.Count == 0)
                    MessageBox.Show($"Необходимо добавить хотя бы один корневой раздел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Необходимо выбрать раздел, который вы хотите удалить!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление корневого раздела TreeView.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SetNameForm setNameForm = new SetNameForm();
                setNameForm.Indexer = 1;
                setNameForm.ShowDialog();
                treeView1.SelectedNode = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение названия нового раздела TreeView.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    SetNameForm setNameForm = new SetNameForm();
                    setNameForm.Indexer = 0;
                    setNameForm.ShowDialog();
                    treeView1.SelectedNode = null;
                }
                else if (treeView1.Nodes.Count == 0)
                    MessageBox.Show($"Необходимо добавить хотя бы один корневой раздел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Необходимо выбрать раздел, название которого вы хотите изменить!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Изменение названия раздела TreeView.
        /// </summary>
        /// <param name="newName">Новое названеи раздела.</param>
        public void ChangeNameSection(string newName)
        {
            try
            {
                if (CheckNameParentNode(newName))
                {
                    treeView1.SelectedNode.Text = newName;
                    MessageBox.Show($"Название раздела успешно изменено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверка названия для узла TreeView.
        /// </summary>
        /// <param name="newName">Новое название раздела.</param>
        /// <returns>True, если название свободно, иначе False.</returns>
        public bool CheckNameParentNode(string newName)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                    if (treeView1.SelectedNode.Parent != null)
                        for (int i = 0; i < treeView1.SelectedNode.Parent.Nodes.Count; i++)
                        {
                            if (treeView1.SelectedNode.Parent.Nodes[i].Text == newName)
                            {
                                MessageBox.Show($"Данное название уже используется!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    else
                        for (int i = 0; i < treeView1.Nodes.Count; i++)
                        {
                            if (treeView1.Nodes[i].Text == newName)
                            {
                                MessageBox.Show($"Данное название уже используется!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Создание узла TreeView.
        /// </summary>
        /// <param name="newName">Новое название раздела.</param>
        public void AddNode(string newName)
        {
            try
            {
                if (CheckNameNode(newName))
                {
                    treeView1.SelectedNode.Nodes.Add(newName);
                    treeView1.SelectedNode.Expand();
                    treeView1.SelectedNode = null;
                    MessageBox.Show($"Раздел успешно создан!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверка названия узла TreeView.
        /// </summary>
        /// <param name="newName">Новое название раздела.</param>
        /// <returns></returns>
        public bool CheckNameNode(string newName)
        {
            try
            {
                for (int i = 0; i < treeView1.SelectedNode.Nodes.Count; i++)
                {
                    if (treeView1.SelectedNode.Nodes[i].Text == newName)
                    {
                        MessageBox.Show($"Данное название уже используется!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Создание корневого узла TreeView.
        /// </summary>
        /// <param name="newName">Новое название узла.</param>
        public void AddRootNode(string newName)
        {
            try
            {

                if (CheckNameRootNode(newName))
                {
                    treeView1.Nodes.Add(newName);
                    MessageBox.Show($"Корневой раздел успешно создан!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверка названия корневого узла TreeView.
        /// </summary>
        /// <param name="newName">Новое название узла.</param>
        /// <returns></returns>
        public bool CheckNameRootNode(string newName)
        {
            try
            {
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    if (treeView1.Nodes[i].Text == newName)
                    {
                        MessageBox.Show($"Данное название уже используется!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Тики таймера.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null)
                    FirstGroupButtonsNotEnabled();
                else
                    FirstGroupButtonsEnabled();

                if (dataGridView1.Rows.Count == 0)
                    SecondGroupButtonsEnabled();
                else
                    SecondGroupButtonsNotEnabled();

                if (dataGridView1.SelectedCells != null)
                    if (dataGridView1.SelectedCells.Count > 0)
                        ThirdGroupButtonsEnabled();
                    else
                        ThirdGroupButtonsNotEnabled();

                if (Directory.GetFiles($"..{Path.DirectorySeparatorChar}data serialize").Length > 0)
                    FourthGroupButtonsEnabled();
                else
                    FourthGroupButtonsNotEnabled();

                if (treeView1.Nodes.Count == 0)
                    FifthGroupButtonsNotEnabled();
                else
                    FifthGroupButtonsEnabled();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Активация кнопок взаимодействия с приложением.
        /// </summary>
        private void FirstGroupButtonsEnabled()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        /// <summary>
        /// Деактивация кнопок взаимодействия с приложением.
        /// </summary>
        private void FirstGroupButtonsNotEnabled()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        /// <summary>
        /// Активация кнопок взаимодействия с приложением.
        /// </summary>
        private void SecondGroupButtonsEnabled()
        {
            dataGridView1.DataSource = new DataTable();
            dataGridView1.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            label3.Visible = true;
        }

        /// <summary>
        /// Деактивация кнопок взаимодействия с приложением.
        /// </summary>
        private void SecondGroupButtonsNotEnabled()
        {
            NumberingRows();

            dataGridView1.Enabled = true;
            button5.Enabled = true;

            label3.Visible = false;
        }

        /// <summary>
        /// Активация кнопок взаимодействия с приложением.
        /// </summary>
        private void ThirdGroupButtonsEnabled()
        {
            button5.Enabled = true;
            button6.Enabled = true;
        }

        /// <summary>
        /// Деактивация кнопок взаимодействия с приложением.
        /// </summary>
        private void ThirdGroupButtonsNotEnabled()
        {
            button5.Enabled = false;
            button6.Enabled = false;
        }

        /// <summary>
        /// Активация кнопок взаимодействия с приложением.
        /// </summary>
        private void FourthGroupButtonsEnabled()
        {
            button9.Enabled = true;
            button10.Enabled = true;
        }

        /// <summary>
        /// Деактивация кнопок взаимодействия с приложением.
        /// </summary>
        private void FourthGroupButtonsNotEnabled()
        {
            button9.Enabled = false;
            button10.Enabled = false;
        }

        /// <summary>
        /// Активация кнопок взаимодействия с приложением.
        /// </summary>
        private void FifthGroupButtonsEnabled()
        {
            button8.Enabled = true;
            button11.Enabled = true;
        }

        /// <summary>
        /// Деактивация кнопок взаимодействия с приложением.
        /// </summary>
        private void FifthGroupButtonsNotEnabled()
        {
            button8.Enabled = false;
            button11.Enabled = false;
        }

        /// <summary>
        /// Изменение нумерации строк.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NumberingRows();
        }

        /// <summary>
        /// Добавление товара в таблицу.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ProductForm productForm = new ProductForm();

                if (treeView1.SelectedNode.Tag == null)
                {
                    productForm.Indexer = 0;
                }
                else
                {
                    productForm.Indexer = 1;
                }

                productForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Создание таблицы и добавление в нее первого товара.
        /// </summary>
        /// <param name="newRow"></param>
        public void AddNewDataTable(string[] newRow)
        {
            try
            {
                DataTable dataTable = dataTableDefault.Clone();
                dataTable.Rows.Add(newRow);

                dataGridView1.DataSource = dataTable;

                // Установка ширины столбцов.
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 180;

                NumberingRows();

                treeView1.SelectedNode.Tag = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление строк в таблицу.
        /// </summary>
        /// <param name="newRow">Массив с данными о строке.</param>
        public void CompleteDataTable(string[] newRow)
        {
            try
            {
                DataTable dataTable = (DataTable)treeView1.SelectedNode.Tag;
                dataTable.Rows.Add(newRow);

                dataGridView1.DataSource = dataTable;

                // Установка ширины столбцов.
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 180;

                NumberingRows();

                treeView1.SelectedNode.Tag = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Передача характеристики товара.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ProductForm productForm = new ProductForm();
                productForm.Indexer = 2;
                productForm.SetTextBox1(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                productForm.SetTextBox2(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
                productForm.SetTextBox3(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString());
                productForm.SetTextBox4(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value.ToString());
                productForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Изменение характеристики товара. 
        /// </summary>
        /// <param name="nameProduct">Название товара.</param>
        /// <param name="articleProduct">Артикул товара.</param>
        /// <param name="costProduct">Цена товара.</param>
        /// <param name="countProduct">Количество товара на складе.</param>
        public void EditDataCell(string nameProduct, string articleProduct, string costProduct, string countProduct)
        {
            try
            {
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value = nameProduct;
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value = articleProduct;
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value = costProduct;
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value = countProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление выбранного товара.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);

                if (treeView1.SelectedNode != null && dataGridView1.Rows.Count == 0)
                    treeView1.SelectedNode.Tag = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отображение таблицы, прикрепленной к связке.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    // Очистка таблицы.
                    dataGridView1.DataSource = new DataTable();

                    if (treeView1.SelectedNode.Tag != null)
                    {
                        // Загрузка новой таблицы и установка ширины столбцов.
                        dataGridView1.DataSource = treeView1.SelectedNode.Tag;
                        dataGridView1.Columns[0].Width = 200;
                        dataGridView1.Columns[1].Width = 150;
                        dataGridView1.Columns[2].Width = 150;
                        dataGridView1.Columns[3].Width = 180;

                        NumberingRows();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Нумерация строк таблицы.
        /// </summary>
        private void NumberingRows()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
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
        /// <param name="path">Путь до файла для серилзации.</param>
        public void Serialize(string path)
        {
            try
            {
                using (Stream file = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, treeView1.Nodes.Cast<TreeNode>().ToList());
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
        /// <param name="path">Путь до файла для десерилзации.</param>
        public void Deserialize(string path)
        {
            try
            {
                // Очистка таблицы и дерева узлов.
                dataGridView1.DataSource = new DataTable();
                treeView1.Nodes.Clear();

                using (Stream file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(file);
                    TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
                    treeView1.Nodes.AddRange(nodeList);
                }

                // Раскрытие всех узлов после десериализации.
                treeView1.ExpandAll();

                MessageBox.Show($"Данные успешно загружены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сохранение данных о складе.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.Nodes.Count > 0)
                {
                    string filePath = $"..{Path.DirectorySeparatorChar}data serialize" +
                        $"{Path.DirectorySeparatorChar}" +
                        $"data{Directory.GetFiles($"..{Path.DirectorySeparatorChar}data serialize").Length + 1}.txt";

                    Serialize(filePath);

                    MessageBox.Show($"Данные успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Отсутсвуют данные для сохранения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузка данных склада.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.GetFiles($"..{Path.DirectorySeparatorChar}data serialize").Length > 0)
                {
                    DeserializeForm deserializeForm = new DeserializeForm();
                    deserializeForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Сохраненные данные отсутствуют!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Очистка сохранённых данных.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = Directory.GetFiles($"..{Path.DirectorySeparatorChar}data serialize");
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение данных для формирования отчета о недостающих товаров.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                ReportForm reportForm = new ReportForm();
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Формирования отчета о недостающих товаров.
        /// </summary>
        /// <param name="minCountWarehouse">Минимальное количество товаров.</param>
        public void CreateReport(long minCountWarehouse)
        {
            try
            {
                DataTable dataRows = CreateDataTableForReport(minCountWarehouse);

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Сохранить файл как ...";
                    saveFileDialog.Filter = "*.csv|*.csv";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = "";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var streamWriter = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                        {
                            // Запись названия столбцов.
                            var columns = dataRows.Columns.Cast<DataColumn>();
                            streamWriter.WriteLine(string.Join(";", columns));

                            // Запись всех строк.
                            foreach (DataRow row in dataRows.Rows)
                            {
                                streamWriter.WriteLine(string.Join(";", row.ItemArray));
                            }
                        }

                        MessageBox.Show($"Отчет успешно сохранён!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Создание таблицы для отчете о недостающих товарах.
        /// </summary>
        /// <param name="minCountWarehouse">Минимальное количество товаров.</param>
        /// <returns>Таблица с данными.</returns>
        private DataTable CreateDataTableForReport(long minCountWarehouse)
        {
            // Установка шаблона таблицы.
            DataTable dataRows = dataTableCSV.Clone();

            try
            {
                // Получение всех связок в TreeView.
                List<TreeNode> treeNodes = EnumerateAllTreeNodes<TreeNode>();

                for (int i = 0; i < treeNodes.Count; i++)
                {
                    if (treeNodes[i].Tag != null)
                    {
                        // Получение таблицы связки.
                        DataTable dataTable = (DataTable)treeNodes[i].Tag;

                        for (int j = 0; j < dataTable.Rows.Count; j++)
                        {
                            // Парсинг количества товаров на складе.
                            long.TryParse(dataTable.Rows[j].ItemArray[3].ToString(), out long countWarehouse);

                            // Проверка условия количества товара.
                            if (countWarehouse <= minCountWarehouse)
                            {
                                dataRows.Rows.Add(new string[] { $"{treeNodes[i].FullPath}", $"{dataTable.Rows[j].ItemArray[1]}", $"{dataTable.Rows[j].ItemArray[0]}", $"{countWarehouse}" });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataRows;
        }

        /// <summary>
        /// Обобщенный список для всех связок дерева.
        /// Код частично взят с ресурса в интернете (пруфы есть).
        /// </summary>
        /// <typeparam name="T">Обобщенный тип.</typeparam>
        /// <param name="parentNode">Родительская связка.</param>
        /// <returns>Список всех связок в дереве.</returns>
        List<T> EnumerateAllTreeNodes<T>(T parentNode = null) where T : TreeNode
        {
            // Создание результирующего списка связок.
            List<T> result = new List<T>();

            try
            {
                // Возвращение пустого списка, если родительская связка отсутсвует.
                if (parentNode != null && parentNode.Nodes.Count == 0)
                    return new List<T>() { };

                // Получение коллекции связок.
                TreeNodeCollection nodes = parentNode != null ? parentNode.Nodes : treeView1.Nodes;
                List<T> childList = nodes.Cast<T>().ToList();
                result.AddRange(childList);

                // Добавление каждой связки в список.
                childList.ForEach(node => result.AddRange(EnumerateAllTreeNodes(node)));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        /// <summary>
        /// Получение данных для генерации классификатора.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateClassifierForm generateClassifier = new GenerateClassifierForm();
                generateClassifier.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Гнерация классификатора.
        /// </summary>
        /// <param name="countNodes">Количество связок.</param>
        /// <param name="countProducts">Количество продуктов.</param>
        public void GenerateClassifier(int countNodes, int countProducts)
        {
            treeView1.Nodes.Clear();

            try
            {
                // Создание корневых разделов TreeView.
                for (int i = 0; i < countNodes; i++)
                {
                    treeView1.Nodes.Add($"Раздел #{treeView1.Nodes.Count + 1}");
                }

                // Создание таблицы с товарами для каждого раздела TreeView.
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    treeView1.Nodes[i].Tag = GenerateDataProducts(countProducts);
                }

                MessageBox.Show($"Классфикатор успешно сгенерирован!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Создание таблицы с товарами при генерациии классификатора.
        /// </summary>
        /// <param name="countProducts">Количество товаров в таблице.</param>
        /// <returns>Таблица с данными.</returns>
        private DataTable GenerateDataProducts(int countProducts)
        {
            DataTable dataTable = dataTableDefault.Clone();

            try
            {
                int randomCountProducts = random.Next(1, countProducts + 1);

                for (int i = 0; i < randomCountProducts; i++)
                {
                    dataTable.Rows.Add(new string[] { $"товар #{i + 1}",
                    $"{(char)random.Next('A', 'Z')}" +
                    $"{(char)random.Next('A', 'Z')}" +
                    $"-{random.Next(10000, 100000)}" +
                    $"{random.Next(10000, 100000)}",
                    $"{random.Next(0, 10000) + random.NextDouble()}",
                    $"{random.Next(0, 10000)}" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка!" +
                    $"\n\nИнформация об ошибке: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
    }
}
