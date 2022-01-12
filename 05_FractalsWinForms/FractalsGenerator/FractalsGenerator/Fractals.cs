using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace FractalsGenerator
{
    public partial class Fractals : Form
    {
        // Создание объекта фрактала.
        Fractal fractal = new Fractal();

        // Очистка окна для рисований.
        private bool clearPicture = false;

        // Объект точки для мыши.
        private Point mouse;


        // Конструктор формы и обработчики событий в форме.
        public Fractals()
        {
            InitializeComponent();
            fractalComboBox.DataSource = new string[] { "Фрактальное дерево", "Кривая Коха", "Ковёр Серпинского", "Треугольник Серпинского", "Множество Кантора" };
            fractalPictureBox.MouseWheel += pictureBox1_MouseWheel;
        }

        // Обновление окна рисовании при форматировании окна программы.
        private void Form1_Resize(object sender, EventArgs e)
        {
            fractalPictureBox.Refresh();
        }

        // Метод для отрисовки фракталов 
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Очистка окна рисования
            if (clearPicture)
            {
                e.Graphics.Clear(Color.White);
                clearPicture = false;
            }

            // Отрисовка фрактала.
            else
            {
                fractal.gr = e.Graphics;
                try
                {
                    fractal.DrawFractal(fractalPictureBox);
                    if (fractal.limit) depthUpDown.Maximum = fractal.depthLimit;
                }
                catch (StackOverflowException)
                {
                    fractal.depthLimit -= 1;
                    depthUpDown.Maximum -= 1;
                    fractal.depth -= 1;
                }
            }
        }

        // Выбор фрактала из выпадающего списка и передача значений для него.
        private void fractalComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (fractalComboBox.SelectedIndex)
            {
                case 0:
                    // Очистка окна рисования.
                    clearPicture = true;

                    // Обновление окна рисования.
                    fractalPictureBox.Refresh();

                    // Панель с событиями фрактального дерева видна.
                    fractalTreePanel.Visible = true;

                    // Панели не относящиеся к данному фракталу скрываются.
                    fractalKochCurvePanel.Visible = false;
                    fractalCantorPanel.Visible = false;

                    // Создание объекта фрактала.
                    fractal = new FractalTree();

                    // Установка значения длины отрезка.
                    fractal.lengthFactor = 0.1f;

                    // Установка значения лейбла масштаба.
                    fractalScaleLabel.Text = $"МАСШТАБ: {Math.Round((fractal.lengthFactor / 0.1f) * 100)}%";

                    // Установка масштаба фрактала.
                    fractal.branchLengthScale = (double)treeLengthBar.Value / 100;

                    // Установка глубины рекурсии.
                    fractal.depth = 10;
                    depthUpDown.Value = 10;
                    depthUpDown.Maximum = 18;

                    // Установка значения углов.
                    fractal.fractalTreeAngle1 = Math.PI / 4;
                    fractal.fractalTreeAngle2 = Math.PI / 4;

                    // Уставнока значения длины ветвей.
                    treeLengthBar.Value = 75;

                    // Установка координат для начала отрисовки.
                    fractal._mousePt.X = fractalPictureBox.Size.Width / 2;
                    fractal._mousePt.Y = fractalPictureBox.Size.Height;
                    break;
                case 1:
                    // Очистка окна рисования.
                    clearPicture = true;

                    // Обновление окна рисования.
                    fractalPictureBox.Refresh();

                    // Панель с событиями кривой Коха видна.
                    fractalKochCurvePanel.Visible = true;

                    // Панели не относящиеся к данному фракталу скрываются.
                    fractalTreePanel.Visible = false;
                    fractalCantorPanel.Visible = false;

                    // Создание объекта фрактала.
                    fractal = new KochsCurve();

                    // Установка значения длины отрезка.
                    fractal.lengthFactor = 0.5f;

                    // Установка значения лейбла масштаба.
                    fractalScaleLabel.Text = $"МАСШТАБ: {Math.Round((fractal.lengthFactor / 0.1f) * 100)}%";

                    // Установка глубины рекурсии.
                    fractal.depth = 4;
                    depthUpDown.Maximum = 50;
                    depthUpDown.Value = 4;

                    // Установка координат для начала отрисовки.
                    fractal._mousePt.X = fractalPictureBox.Size.Width / 2;
                    fractal._mousePt.Y = fractalPictureBox.Size.Height / 2;
                    break;
                case 2:
                    // Очистка окна рисования.
                    clearPicture = true;

                    // Панель с событиями ковра Серпинского видна.
                    fractalKochCurvePanel.Visible = true;

                    // Обновление окна рисования.
                    fractalPictureBox.Refresh();
                    fractalTreePanel.Visible = false;
                    fractalCantorPanel.Visible = false;

                    // Создание объекта фрактала.
                    fractal = new SierpinskisCarpet();

                    // Установка значения длины отрезка.
                    fractal.lengthFactor = 0.08f;

                    // Установка значения лейбла масштаба.
                    fractalScaleLabel.Text = $"МАСШТАБ: {Math.Round((fractal.lengthFactor / 0.1f) * 100)}%";

                    // Установка глубины рекурсии.
                    fractal.depth = 4;
                    depthUpDown.Maximum = 25;
                    depthUpDown.Value = 4;

                    // Установка координат для начала отрисовки.
                    fractal._mousePt.X = fractalPictureBox.Size.Width / 2;
                    fractal._mousePt.Y = fractalPictureBox.Size.Height / 2;
                    break;
                case 3:
                    // Очистка окна рисования.
                    clearPicture = true;

                    // Обновление окна рисования.
                    fractalPictureBox.Refresh();

                    // Панель с событиями треугольника Серпинского видна.
                    fractalKochCurvePanel.Visible = true;

                    // Панели не относящиеся к данному фракталу скрываются.
                    fractalTreePanel.Visible = false;
                    fractalCantorPanel.Visible = false;

                    // Создание объекта фрактала.
                    fractal = new SierpinskisTriangle();

                    // Установка значения длины отрезка.
                    fractal.lengthFactor = 0.35f;

                    // Установка значения лейбла масштаба.
                    fractalScaleLabel.Text = $"МАСШТАБ: {Math.Round((fractal.lengthFactor / 0.1f) * 100)}%";

                    // Установка глубины рекурсии.
                    fractal.depth = 4;
                    depthUpDown.Maximum = 25;
                    depthUpDown.Value = 4;

                    // Установка координат для начала отрисовки.
                    fractal._mousePt.X = fractalPictureBox.Size.Width / 2;
                    fractal._mousePt.Y = fractalPictureBox.Size.Height / 2;
                    break;
                case 4:
                    clearPicture = true;

                    // Обновление окна рисования.
                    fractalPictureBox.Refresh();

                    // Панель с событиями множества Кантора видна.
                    fractalCantorPanel.Visible = true;

                    // Панели не относящиеся к данному фракталу скрываются.
                    fractalTreePanel.Visible = false;
                    fractalKochCurvePanel.Visible = false;

                    // Создание объекта фрактала.
                    fractal = new CantorsSet();

                    // Установка значения длины отрезка.
                    fractal.lengthFactor = 0.4f;

                    // Установка значения лейбла масштаба.
                    fractalScaleLabel.Text = $"МАСШТАБ: {Math.Round((fractal.lengthFactor / 0.4f) * 100)}%";

                    // Установка глубины рекурсии.
                    fractal.depth = 4;
                    depthUpDown.Maximum = 50;
                    depthUpDown.Minimum = 1;
                    depthUpDown.Value = 4;

                    // Установка координат для начала отрисовки.
                    fractal._mousePt.X = fractalPictureBox.Size.Width / 2;
                    fractal._mousePt.Y = fractalPictureBox.Size.Height / 2;
                    fractalPictureBox.Refresh();
                    break;
            }
            fractalPictureBox.Refresh();
        }

        // Метод для приближения/отдаления изображения фрактала колесиком мыши.
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs mouse)
        {
            // Приближение изображения при прокрутке колесиком вперед.
            if (mouse.Delta > 0)
            {
                if (fractal.lengthFactor > 0.01)
                {
                    fractal.lengthFactor += 0.01f;

                    if (fractal is CantorsSet)
                    {
                        fractal.layerDistance += 1;
                    }

                    fractalPictureBox.Refresh();
                }
            }

            // Отдаление изображения при прокрутке колесиком назад.
            else if (mouse.Delta < 0)
            {
                // Уменьшение изображения для множества Кантора.
                if (fractal is CantorsSet)
                {
                    if (fractal.lengthFactor - 0.01f > 0.4)
                    {
                        fractal.lengthFactor -= 0.01f;

                        if (fractal is CantorsSet)
                        {
                            fractal.layerDistance -= 1;
                        }

                        fractalPictureBox.Refresh();
                    }
                }
                // Уменьшение изображения для иных фракталов.
                else
                {
                    if (fractal.lengthFactor - 0.01f > 0.01)
                    {
                        fractal.lengthFactor -= 0.01f;

                        if (fractal is CantorsSet)
                        {
                            fractal.layerDistance -= 1;
                        }

                        fractalPictureBox.Refresh();
                    }
                }
            }

            // Изменение масштаба в соответсвии с текущим значением для множества Кантора.
            if (fractal is CantorsSet)
            {
                fractalScaleLabel.Text = $"МАСШТАБ: {Math.Round((fractal.lengthFactor / 0.4f) * 100)}%";
            }
            // Изменение масштаба в соответсвии с текущим значением для иных фракталов.
            else
            {
                fractalScaleLabel.Text = $"МАСШТАБ: {Math.Round((fractal.lengthFactor / 0.1f) * 100)}%";
            }
        }

        // Метод для выполнения перемещения в точке щелчка.
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = new Point(fractal._mousePt.X - e.Location.X, fractal._mousePt.Y - e.Location.Y);
        }

        // Перемещение изображения.
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                fractal._mousePt.X = e.Location.X + mouse.X;
                fractal._mousePt.Y = e.Location.Y + mouse.Y;
                fractalPictureBox.Refresh();
            }
        }

        // Метод для измененения значения и перерисовки фрактала при увелечении/уменьшении глубины рекурсии.
        private void depthValueControl_ValueChanged(object sender, EventArgs e)
        {
            // Передача глубины рекурсии в класс 
            fractal.depth = (int)depthUpDown.Value;

            // Добавление глубины рекурсии(только для треуголька Серпинского).
            if (fractal is SierpinskisTriangle)
            {
                fractal.depth += 1;
            }

            // Обновление окна рисования и проверка на переполнение стека.
            try
            {
                fractalPictureBox.Refresh();
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("Произошло переполнение стека.");
                fractal.depth = 10;
                depthUpDown.Value = (decimal)10;
                fractalPictureBox.Refresh();
            }
        }

        // Сохранение изображения.
        private void saveImageButton_Click(object sender, EventArgs e)
        {
            // Создание диалога для выбора места для сохранения изображения.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Форматы для сохранения.
            saveFileDialog1.Filter = "BitMap Image|*.bmp";

            // Заголовок окна сохранения.
            saveFileDialog1.Title = "Сохранение";

            // Отображение на экране диалогового окна.
            saveFileDialog1.ShowDialog();

            // Процесс сохранения.
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        Bitmap bmp = new Bitmap(fractalPictureBox.ClientSize.Width, fractalPictureBox.ClientSize.Height);
                        fractalPictureBox.DrawToBitmap(bmp, fractalPictureBox.ClientRectangle);
                        bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
                fs.Close();
            }
        }

        // Изменение значения длины ветвей фрактального дерева.
        private void treeLengthBar_ValueChanged(object sender, EventArgs e)
        {
            fractal.branchLengthScale = (double)treeLengthBar.Value / 100;
            treeLengthLabel.Text = $"{treeLengthBar.Value}%";
            fractalPictureBox.Refresh();
        }

        // Изменение значения 1 угла ветвей фрактального дерева.
        private void treeAngleBar1_ValueChanged(object sender, EventArgs e)
        {
            fractal.fractalTreeAngle1 = (Math.PI / 2) * ((double)treeAngleBar1.Value / 100);
            treeDegreeLabel1.Text = $"{(int)(((double)treeAngleBar1.Value / 100) * 90)}\x00B0";
            fractalPictureBox.Refresh();
        }

        // Изменение значения 2 угла ветвей фрактального дерева.
        private void treeAngleBar2_ValueChanged(object sender, EventArgs e)
        {
            fractal.fractalTreeAngle2 = (Math.PI / 2) * ((double)treeAngleBar2.Value / 100);
            treeDegreeLabel2.Text = $"{(int)(((double)treeAngleBar2.Value / 100) * 90)}\x00B0";
            fractalPictureBox.Refresh();
        }

        // Изменение масштаба фракталов.
        private void nonTreeLengthBar_ValueChanged(object sender, EventArgs e)
        {
            fractal.lengthFactor = 0.1f * fractalsLengthBar.Value / 100;
            nonTreeLengthLabel.Text = $"{fractalsLengthBar.Value}%";
            fractalPictureBox.Refresh();
        }

        // Функция включения/отключения ограничения на количество итераций.
        private void limitButton_Click(object sender, EventArgs e)
        {
            if (fractal.limit)
            {
                fractal.limit = false;
                fractalLimit.Text = "ВКЛЮЧИТЬ ОГРАНИЧЕНИЕ";
                MessageBox.Show("Вы выключили ограничение, которое контролирует использование ресурсов программы, " +
                    "корректность работы программы не гарантируется!");
                depthUpDown.Maximum = 20;
            }
            else
            {
                fractal.limit = true;
                fractalLimit.Text = "ВЫКЛЮЧИТЬ ОГРАНИЧЕНИЕ";
            }
        }

        // Изменение расстояния между отрезками в множестве Кантора.
        private void cantorLayerBar_ValueChanged(object sender, EventArgs e)
        {
            cantorLayerLabel.Text = $"{cantorLayerBar.Value}px";
            fractal.layerDistance = cantorLayerBar.Value;
            fractalPictureBox.Refresh();
        }

        // Отображение текста приветсвия при запуске программы.
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Приветствую в приложении для отрисовки фракталов!" +
                "\n\nВсе ключевые блоки для каждого фрактала будут выведены после его выбора." +
                "\nФункция включения/отключения ограничения контролирует переполнение стека, не рекомендуется ее отключать." +
                "\nСохранение изображения фрактала производится в формате *bmp." +
                "\nФункция приближения/отдаления фрактала реализована с использованием колесика мыши." +
                "\n\nУдачи в использовании!");
        }

        // Обновление окна рисования.
        private void Fractals_Paint(object sender, PaintEventArgs e)
        {
            fractalPictureBox.Refresh();
        }

        private void fractalExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void fractalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
