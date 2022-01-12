using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Diagnostics;

namespace NotePad__
{
    public partial class OpenDocForm : Form
    {
        // Путь к открытому файлу.
        string filePath;

        // Метка изменения текста в RichTextBox1.
        bool flagTextChanged;

        // Метка изменения темы формы.
        bool flagColorForm;

        // Свойство изменения темы формы.
        public bool FlagColorForm
        {
            get
            {
                return flagColorForm;
            }
            set
            {
                flagColorForm = value;
                Customize();
            }
        }

        public OpenDocForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            // Элементы контекстного меню.
            ToolStripMenuItem selectAll = new ToolStripMenuItem("Выбрать все");
            ToolStripMenuItem selectCut = new ToolStripMenuItem("Вырезать");
            ToolStripMenuItem selectPast = new ToolStripMenuItem("Вставить");
            ToolStripMenuItem selectCopy = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem selectFormat = new ToolStripMenuItem("Формат");

            // Контекстное меню (правая кнопка мыши).
            rightButtomMenuStrip.Items.AddRange(new[] { selectCopy, selectPast, selectAll, selectCut, selectFormat });

            // Значение, указывающее, будет ли форма получать ключевые события до того, как событие будет передано элементу управления.
            KeyPreview = true;

            // Обработка события при щелчке по ПКМ.
            richTextBox1.MouseUp += RichTextBox1_MouseUp;

            // Обработка событий при выборе временного интервала сохранения открытых файлов.
            intervalStripMenuItem1.Click += IntervalStripMenuItem1_Click;
            intervalStripMenuItem2.Click += IntervalStripMenuItem2_Click;
            intervalStripMenuItem3.Click += IntervalStripMenuItem3_Click;
            intervalStripMenuItem4.Click += IntervalStripMenuItem4_Click;
            intervalStripMenuItem5.Click += IntervalStripMenuItem5_Click;
            intervalStripMenuItem6.Click += IntervalStripMenuItem6_Click;
            intervalStripMenuItem7.Click += IntervalStripMenuItem7_Click;
            intervalStripMenuItem8.Click += IntervalStripMenuItem8_Click;
            intervalStripMenuItem9.Click += IntervalStripMenuItem9_Click;

            // Обработка событий при выборе элементов в menuStrip и rightButtomMenuStrip.
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;

            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;

            selectAll.Click += SelectAll_Click;
            selectAllToolStripMenuItem.Click += SelectAll_Click;

            selectCut.Click += SelectCut_Click;
            cutToolStripMenuItem.Click += SelectCut_Click;

            selectPast.Click += SelectPast_Click;
            pasteToolStripMenuItem.Click += SelectPast_Click;

            selectCopy.Click += SelectCopy_Click;
            copyToolStripMenuItem.Click += SelectCopy_Click;

            selectFormat.Click += FontsStripMenuItem_Click;
            fontsStripMenuItem.Click += SelectFormat_Click;

            undoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;

            redoToolStripMenuItem.Click += RedoToolStripMenuItem_Click;

            // Установка форматов для открытия и сохранения файлов с указанным расширением.
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|Rich Text Format File(*.rtf)|*.rtf";

            // Запуск таймера для автоматического сохранения файлов (по умолчанию 10 секунд).
            timer1.Start();
        }

        // Отмена действия.
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Redo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Повторение предыдущих действий.
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Undo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при щелчке по ПКМ.
        private void RichTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightButtomMenuStrip.Show((Control)sender, e.Location);
            }
        }

        // Сохранение открытого файла по таймеру.
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (filePath != "" && filePath != null)
                {
                    if (filePath.EndsWith(".txt"))
                    {
                        File.WriteAllText(filePath, richTextBox1.Text);
                    }
                    if (filePath.EndsWith(".rtf"))
                    {
                        richTextBox1.SaveFile(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show($"Произошла ошибка при сохранении файла:" +
                    $"\n{ex}" +
                    $"\nТаймер сохранения остановлен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Формат".
        private void SelectFormat_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectAll();
                    richTextBox1.SelectionFont = fontDialog1.Font;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Выбрать всё".
        private void SelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Text.Length > 0)
                {
                    richTextBox1.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Вырезать".
        private void SelectCut_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Text.Length > 0)
                {
                    richTextBox1.Cut();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Вставить".
        private void SelectPast_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Paste();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Копировать".
        private void SelectCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Text.Length > 0)
                {
                    richTextBox1.Copy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Формат" и "Шрифт".
        private void FontsStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog1.Font;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Сохранить как".
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                if (saveFileDialog1.FileName.EndsWith(".txt"))
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                }
                if (saveFileDialog1.FileName.EndsWith(".rtf"))
                {
                    richTextBox1.ForeColor = Color.Black;
                    richTextBox1.BackColor = Color.White;
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                }

                filePath = saveFileDialog1.FileName;

                MessageBox.Show("Файл успешно сохранен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно сохранить данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Сохранить".
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (filePath != null && filePath != "")
                {
                    if (File.Exists(filePath))
                    {
                        if (filePath.EndsWith(".txt"))
                        {
                            File.WriteAllText(filePath, richTextBox1.Text);
                        }
                        if (filePath.EndsWith(".rtf"))
                        {
                            richTextBox1.BackColor = Color.White;
                            richTextBox1.ForeColor = Color.Black;
                            richTextBox1.SaveFile(filePath);
                        }

                        MessageBox.Show("Файл успешно сохранен!");
                    }
                    else
                    {
                        MessageBox.Show($"Невозможно сохранить файл!" +
                            $"\n\nИспользуйте функцию \"Сохранить как\"!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Используйте функцию \"Сохранить как\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Используйте функцию \"Сохранить как\".\nНевозможно сохранить данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события перед закрытием формы.
        private void OpenDocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason != CloseReason.UserClosing)
                {
                    return;
                }

                if (flagTextChanged)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы хотите сохранить файлы перед закрытием приложения?", "Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (filePath != "" && filePath != null)
                        {
                            SaveFileWithPath();
                        }
                        else
                        {
                            SaveFileWithoutPath();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно сохранить данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранения файла по указанному пути.
        private void SaveFileWithPath()
        {
            if (filePath.EndsWith(".txt"))
            {
                File.WriteAllText(filePath, richTextBox1.Text);
            }
            if (filePath.EndsWith(".rtf"))
            {
                richTextBox1.SaveFile(filePath);
            }
        }

        // Сохранения файла по пути, выбранном пользователем.
        private void SaveFileWithoutPath()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            if (saveFileDialog1.FileName.EndsWith(".txt"))
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
            if (saveFileDialog1.FileName.EndsWith(".rtf"))
            {
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.BackColor = Color.White;
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        // Обработка события при изменении текста в RichTextBox.
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            flagTextChanged = true;
        }

        // Установка черного цвета слов в кнопках в menusStrip (для светлой темы).
        private void ResetColor(ToolStripMenuItem toolStripMenuItem)
        {
            toolStripMenuItem.ForeColor = Color.Black;

            foreach (ToolStripMenuItem dropDowntoolStripMenuItem in toolStripMenuItem.DropDownItems)
            {
                if (dropDowntoolStripMenuItem is ToolStripMenuItem)
                {
                    ResetColor(dropDowntoolStripMenuItem);
                }
            }
        }

        // Установка оранжевого цвета слов в кнопках в menusStrip (для темной темы).
        private void SetOrangeColor(ToolStripMenuItem toolStripMenuItem)
        {
            toolStripMenuItem.ForeColor = Color.OrangeRed;

            foreach (ToolStripMenuItem dropDowntoolStripMenuItem in toolStripMenuItem.DropDownItems)
            {
                if (dropDowntoolStripMenuItem is ToolStripMenuItem)
                {
                    SetOrangeColor(dropDowntoolStripMenuItem);
                }
            }
        }

        // Изменение темы при вызове соответветствующего события на основной форме.
        public void Customize()
        {
            if (flagColorForm)
            {
                CustomizeWhiteTheme();
            }
            else
            {
                CustomizeDarkTheme();
            }
        }

        // Установка светлой темы.
        private void CustomizeWhiteTheme()
        {
            // Цвет формы.
            BackColor = Color.Black;

            // Цвет menuStrip.
            menuStrip1.BackColor = Color.Black;

            // Изменение цвета для каждого элемента в menuStrip.
            foreach (ToolStripMenuItem toolStripMenuItem in MainMenuStrip.Items)
            {
                SetOrangeColor(toolStripMenuItem);
            }

            // Создание объекта класса для изменения цвета menuStrip.
            MainMenuStrip.Renderer = new ToolStripProfessionalRenderer(new ColorsDarkTheme());

            if (filePath != null)
            {
                if (!filePath.EndsWith(".rtf"))
                {
                    richTextBox1.BackColor = Color.DimGray;
                    richTextBox1.ForeColor = Color.White;
                }
            }
            else
            {
                richTextBox1.BackColor = Color.DimGray;
                richTextBox1.ForeColor = Color.White;
            }
        }

        // Установка темной темы.
        private void CustomizeDarkTheme()
        {
            BackColor = Color.White;
            menuStrip1.BackColor = Color.Silver;
            menuStrip1.ForeColor = Color.Black;

            foreach (ToolStripMenuItem m in MainMenuStrip.Items)
            {
                ResetColor(m);
            }

            MainMenuStrip.Renderer = new ToolStripProfessionalRenderer(new ColorsWhiteTheme());

            if (filePath != null)
            {
                if (!filePath.EndsWith(".rtf"))
                {
                    richTextBox1.BackColor = Color.White;
                    richTextBox1.ForeColor = Color.Black;
                }
            }
            else
            {
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
            }
        }

        // Интервал сохранения открытых файлов - 1 час.
        private void IntervalStripMenuItem9_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 10000000;
            timer1.Start();
        }

        // Интервал сохранения открытых файлов - 30 минут.
        private void IntervalStripMenuItem8_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 3000000;
            timer1.Start();
        }

        // Интервал сохранения открытых файлов - 15 минут.
        private void IntervalStripMenuItem7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 1500000;
            timer1.Start();
        }

        // Интервал сохранения открытых файлов - 5 минут.
        private void IntervalStripMenuItem6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 500000;
            timer1.Start();
        }

        // Интервал сохранения открытых файлов - 2 минуты.
        private void IntervalStripMenuItem5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 200000;
            timer1.Start();
        }

        // Интервал сохранения открытых файлов - 1 минута.
        private void IntervalStripMenuItem4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 100000;
            timer1.Start();
        }

        // Интервал сохранения открытых файлов - 30 секунд.
        private void IntervalStripMenuItem3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 30000;
            timer1.Start();
        }

        // Интервал сохранения открытых файлов - 15 секунд.
        private void IntervalStripMenuItem2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 15000;
            timer1.Start();
        }

        // Интервал сохранения открытых файлов - 5 секунд.
        private void IntervalStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 5000;
            timer1.Start();
        }
    }
}
