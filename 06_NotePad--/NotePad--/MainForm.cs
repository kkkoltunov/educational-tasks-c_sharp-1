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
    public partial class NotePad : Form
    {
        // Счетчик новых вкладок (созданных в приложении).
        static int counterNewTabs = 0;

        // Список всех RichTextBoxes.
        List<RichTextBox> allTextBoxes = new List<RichTextBox>();

        // Словарь, в котором содержатся все RichTextBoxes, в которых были произведены изменения текста.
        Dictionary<RichTextBox, bool> textBoxsChanged = new Dictionary<RichTextBox, bool>();

        // Метка, хранящая содержание о цвете формы.
        bool flagFormColor = false;

        // Объект формы для открытия документа в новом окне.
        OpenDocForm formOpenDoc;

        // Объект формы для разработчиков.
        DevelopersForm formDevelopers;

        public NotePad()
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

            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;

            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;

            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;

            saveAllToolStripMenuItem.Click += SaveAllToolStripMenuItem_Click;

            createToolStripMenuItem.Click += CreateToolStripMenuItem_Click;

            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;

            customizeToolStripMenuItem.Click += CustomizeToolStripMenuItem_Click;

            openNewFormStripMenuItem.Click += OpenNewFormStripMenuItem_Click;

            developersStripMenuItem.Click += DevelopersStripMenuItem_Click;

            undoStripMenuItem.Click += UndoStripMenuItem_Click;

            redoStripMenuItem.Click += RedoStripMenuItem_Click;

            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;

            // Установка форматов для открытия и сохранения файлов с указанным расширением.
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|Rich Text Format File(*.rtf)|*.rtf";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|Rich Text Format File(*.rtf)|*.rtf";

            // Очистка всех открытых вкладок tabPanel.
            tabPanel.TabPages.Clear();

            // Отключение видимости tabPanel.
            tabPanel.Visible = false;

            // Восстановление настроек до закрытия формы.
            OpenFileAndChangeSettings();

            // Запуск таймера для автоматического сохранения файлов (по умолчанию 10 секунд). 
            timer1.Start();
        }

        // Обработка события при нажатии на кнопку "О программе".
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа предназначена для открытия, создания, редактирования текстовых файлов " +
                "формата *.rtf и *.txt. Отдельно в программе присутствует \"Режим разработчика\" для работы с кодом на языке C#." +
                "\n\nПри выборе в пункте меню вкладки \"Шрифт\" учитывайте, что форматирование применяется для всего текста, " +
                "чтобы отформатировать выделенный фрагмент, воспользуйтесь контекстным меню!" +
                "\n\nГорячие клавиши для закрытия приложения \"Alt + F4\"." +
                "\n\nПриятного использования!");
        }

        // Отмена действия.
        private void RedoStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                allTextBoxes[tabPanel.SelectedIndex].Redo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Повторение предыдущих действий.
        private void UndoStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                allTextBoxes[tabPanel.SelectedIndex].Undo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Создание формы для разработчика.
        private void DevelopersStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form forms in Application.OpenForms)
                {
                    if (forms.Name == "DevelopersForm" || forms.Name == "OpenDocForm")
                    {
                        MessageBox.Show("Закройте одну из форм для открытия новой!");
                        return;
                    }
                }
                formDevelopers = new DevelopersForm();
                formDevelopers.FlagColorForm = flagFormColor;
                formDevelopers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Создание формы для отдельного документа.
        private void OpenNewFormStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form forms in Application.OpenForms)
                {
                    if (forms.Name == "DevelopersForm" || forms.Name == "OpenDocForm")
                    {
                        MessageBox.Show("Закройте одну из форм для открытия новой!");
                        return;
                    }
                }
                formOpenDoc = new OpenDocForm();
                formOpenDoc.FlagColorForm = flagFormColor;
                formOpenDoc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Установка черного цвета слов в кнопках в menusStrip (для светлой темы).
        private void ResetColor(ToolStripMenuItem toolStripMenuItem)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Установка оранжевого цвета слов в кнопках в menusStrip (для темной темы).
        private void SetOrangeColor(ToolStripMenuItem toolStripMenuItem)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Изменить тему".
        private void CustomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (flagFormColor)
                {
                    CustomizeWhiteTheme();
                    flagFormColor = false;
                }
                else
                {
                    CustomizeDarkTheme();
                    flagFormColor = true;
                }

                // Изменение темы на открытых формах.
                foreach (Form forms in Application.OpenForms)
                {
                    if (forms.Name == "OpenDocForm")
                    {
                        formOpenDoc.FlagColorForm = flagFormColor;
                        formOpenDoc.Customize();
                    }
                    if (forms.Name == "DevelopersForm")
                    {
                        formDevelopers.FlagColorForm = flagFormColor;
                        formDevelopers.Customize();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Изменение темы при создании новых вкладок и открытии документов.
        private void Customize()
        {
            try
            {
                if (flagFormColor)
                {
                    CustomizeWhiteTheme();
                    flagFormColor = false;
                }
                else
                {
                    CustomizeDarkTheme();
                    flagFormColor = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Установка темной темы.
        private void CustomizeDarkTheme()
        {
            try
            {
                // Цвет формы.
                BackColor = Color.Black;

                // Цвет menuStrip.
                menuStrip.BackColor = Color.Black;

                // Изменение цвета для каждого элемента в menuStrip.
                foreach (ToolStripMenuItem toolStripMenuItem in MainMenuStrip.Items)
                {
                    SetOrangeColor(toolStripMenuItem);
                }

                // Создание объекта класса для изменения цвета menuStrip.
                MainMenuStrip.Renderer = new ToolStripProfessionalRenderer(new ColorsDarkTheme());

                // Применение цвета ко всем RichTextBoxes на открытых вкладках.
                for (int i = 0; i < tabPanel.TabPages.Count; i++)
                {
                    if (!tabPanel.TabPages[i].Name.EndsWith(".rtf"))
                    {
                        tabPanel.TabPages[i].BackColor = Color.Black;
                        allTextBoxes[i].BackColor = Color.DimGray;
                        allTextBoxes[i].ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Установка светлой темы.
        private void CustomizeWhiteTheme()
        {
            try
            {
                // Цвет формы.
                BackColor = Color.White;

                // Цвет menuStrip.
                menuStrip.BackColor = Color.Silver;

                // Изменение цвета для каждого элемента в menuStrip.
                foreach (ToolStripMenuItem toolStripMenuItem in MainMenuStrip.Items)
                {
                    ResetColor(toolStripMenuItem);
                }

                // Создание объекта класса для изменения цвета menuStrip.
                MainMenuStrip.Renderer = new ToolStripProfessionalRenderer(new ColorsWhiteTheme());

                // Применение цвета ко всем RichTextBoxes на открытых вкладках.
                for (int i = 0; i < tabPanel.TabPages.Count; i++)
                {
                    if (!tabPanel.TabPages[i].Name.EndsWith(".rtf"))
                    {
                        tabPanel.TabPages[i].BackColor = Color.White;
                        allTextBoxes[i].BackColor = Color.White;
                        allTextBoxes[i].ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранение всех открытых документов по таймеру.
        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение коллекции открытых вкладок.
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                if (tabPanel.TabPages.Count != 0)
                {
                    for (int i = 0; i < tabPanel.TabPages.Count; i++)
                    {
                        if (tabPageCollection[i].Name != "" && tabPageCollection[i].Name != null)
                        {
                            // Сохранение файлов в зависимости от расширения.
                            if (tabPageCollection[i].Name.EndsWith(".txt"))
                            {
                                File.WriteAllText(tabPageCollection[i].Name, allTextBoxes[i].Text);
                            }
                            if (tabPageCollection[i].Name.EndsWith(".rtf"))
                            {
                                allTextBoxes[i].SaveFile(tabPageCollection[i].Name);
                            }

                            // Удаление RichTextBox из словаря изменений.
                            textBoxsChanged.Remove(allTextBoxes[i]);
                        }
                    }

                    MessageBox.Show("Все открытые файлы успешно сохранены!");
                }
                else
                {
                    MessageBox.Show($"Отсутствуют открытые вкладки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении файла:" +
                    $"\n{ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Формат".
        private void SelectFormat_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabPanel.SelectedTab != null)
                {
                    if (fontDialog1.ShowDialog() == DialogResult.OK)
                    {
                        allTextBoxes[tabPanel.SelectedIndex].SelectAll();
                        allTextBoxes[tabPanel.SelectedIndex].SelectionFont = fontDialog1.Font;
                    }
                }
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (tabPanel.SelectedTab != null)
                {
                    if (allTextBoxes[tabPanel.SelectedIndex].Text.Length > 0)
                    {
                        allTextBoxes[tabPanel.SelectedIndex].SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (tabPanel.SelectedTab != null)
                {
                    if (allTextBoxes[tabPanel.SelectedIndex].Text.Length > 0)
                    {
                        allTextBoxes[tabPanel.SelectedIndex].Cut();
                    }
                }
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (tabPanel.SelectedTab != null)
                {
                    allTextBoxes[tabPanel.SelectedIndex].Paste();
                }
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (tabPanel.SelectedTab != null)
                {
                    if (allTextBoxes[tabPanel.SelectedIndex].Text.Length > 0)
                    {
                        allTextBoxes[tabPanel.SelectedIndex].Copy();
                    }
                }
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Открыть".
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flagFileAlreadyOpen = false;
            int selectedTab = 0;

            tabPanel.Visible = true;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Поиск данного файла в уже открытых в приложении.
                    for (int i = 0; i < tabPanel.TabPages.Count; i++)
                    {
                        if (tabPanel.TabPages[i].Name == openFileDialog1.FileName)
                        {
                            flagFileAlreadyOpen = true;
                            selectedTab = i;
                        }
                    }
                    if (!flagFileAlreadyOpen)
                    {
                        allTextBoxes.Add(new RichTextBox());
                        allTextBoxes[tabPanel.TabPages.Count].Dock = DockStyle.Fill;
                        allTextBoxes[tabPanel.TabPages.Count].TextChanged += TextBoxs_TextChanged;

                        if (openFileDialog1.FileName.EndsWith(".txt"))
                        {
                            allTextBoxes[tabPanel.TabPages.Count].Text = File.ReadAllText(openFileDialog1.FileName);
                            if (flagFormColor)
                            {
                                allTextBoxes[tabPanel.TabPages.Count].BackColor = Color.DimGray;
                                allTextBoxes[tabPanel.TabPages.Count].ForeColor = Color.White;
                            }
                        }
                        if (openFileDialog1.FileName.EndsWith(".rtf"))
                        {
                            allTextBoxes[tabPanel.TabPages.Count].LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                        }

                        string[] fileName = openFileDialog1.FileName.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
                        tabPanel.TabPages.Add(openFileDialog1.FileName, fileName[fileName.Length - 1]);

                        // Установка настроек для RichTextBox и добавление его на вкалдку.
                        SelectingTools();
                        MessageBox.Show("Файл успешно открыт!");
                    }
                    else
                    {
                        tabPanel.SelectedTab = tabPanel.TabPages[selectedTab];
                        MessageBox.Show($"Данный файл уже открыт!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                tabPanelColorStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно открыть данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Установка настроек для RichTextBox и добавление его на вкалдку.
        private void SelectingTools()
        {
            try
            {
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                tabPageCollection[tabPanel.TabPages.Count - 1].Controls.Add(allTextBoxes[tabPanel.TabPages.Count - 1]);

                tabPanel.SelectedTab = tabPageCollection[tabPanel.TabPages.Count - 1];

                allTextBoxes[tabPanel.SelectedIndex].ContextMenuStrip = rightButtomMenuStrip;
                allTextBoxes[tabPanel.SelectedIndex].MouseUp += NotePad_MouseUp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при изменение текста в RichTextBox (добавление в словарь RichTextBox).
        private void TextBoxs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPanel.SelectedTab != null)
                {
                    textBoxsChanged.TryAdd(allTextBoxes[tabPanel.SelectedIndex], true);
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
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                if (tabPanel.SelectedTab != null)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    if (saveFileDialog1.FileName.EndsWith(".txt"))
                    {
                        File.WriteAllText(saveFileDialog1.FileName, allTextBoxes[tabPanel.SelectedIndex].Text);
                    }
                    if (saveFileDialog1.FileName.EndsWith(".rtf"))
                    {
                        allTextBoxes[tabPanel.SelectedIndex].ForeColor = Color.Black;
                        allTextBoxes[tabPanel.SelectedIndex].BackColor = Color.White;
                        allTextBoxes[tabPanel.SelectedIndex].SaveFile(saveFileDialog1.FileName);
                    }

                    string[] fileName = saveFileDialog1.FileName.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

                    tabPageCollection[tabPanel.SelectedIndex].Text = fileName[fileName.Length - 1];
                    tabPageCollection[tabPanel.SelectedIndex].Name = saveFileDialog1.FileName;

                    textBoxsChanged.Remove(allTextBoxes[tabPanel.SelectedIndex]);

                    MessageBox.Show("Файл успешно сохранен!");
                }
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                if (tabPanel.SelectedTab != null)
                {
                    if (tabPageCollection[tabPanel.SelectedIndex].Name != null && tabPageCollection[tabPanel.SelectedIndex].Name != "")
                    {
                        if (File.Exists(tabPageCollection[tabPanel.SelectedIndex].Name))
                        {
                            if (tabPageCollection[tabPanel.SelectedIndex].Name.EndsWith(".txt"))
                            {
                                File.WriteAllText(tabPageCollection[tabPanel.SelectedIndex].Name, allTextBoxes[tabPanel.SelectedIndex].Text);
                            }
                            if (tabPageCollection[tabPanel.SelectedIndex].Name.EndsWith(".rtf"))
                            {
                                allTextBoxes[tabPanel.SelectedIndex].BackColor = Color.White;
                                allTextBoxes[tabPanel.SelectedIndex].ForeColor = Color.Black;
                                allTextBoxes[tabPanel.SelectedIndex].SaveFile(tabPageCollection[tabPanel.SelectedIndex].Name);
                            }

                            textBoxsChanged.Remove(allTextBoxes[tabPanel.SelectedIndex]);

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
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Используйте функцию \"Сохранить как\".\nНевозможно сохранить данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Формат" и "Шрифт".
        private void FontsStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabPanel.SelectedTab != null)
                {
                    if (fontDialog1.ShowDialog() == DialogResult.OK)
                    {
                        allTextBoxes[tabPanel.SelectedIndex].SelectionFont = fontDialog1.Font;
                    }
                }
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Обработка события при нажатии на кнопку "Открыть".
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPanel.Visible = true;

            try
            {
                allTextBoxes.Add(new RichTextBox());
                allTextBoxes[tabPanel.TabPages.Count].Dock = DockStyle.Fill;
                allTextBoxes[tabPanel.TabPages.Count].TextChanged += TextBoxs_TextChanged;

                tabPanel.TabPages.Add($"new{counterNewTabs++}");

                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                tabPanel.SelectedTab = tabPageCollection[tabPanel.TabPages.Count - 1];

                tabPageCollection[tabPanel.TabPages.Count - 1].Controls.Add(allTextBoxes[tabPanel.TabPages.Count - 1]);

                allTextBoxes[tabPanel.SelectedIndex].ContextMenuStrip = rightButtomMenuStrip;
                allTextBoxes[tabPanel.SelectedIndex].MouseUp += NotePad_MouseUp;

                if (flagFormColor)
                {
                    allTextBoxes[tabPanel.SelectedIndex].BackColor = Color.DarkSlateGray;
                    allTextBoxes[tabPanel.SelectedIndex].ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при щелчке по ПКМ.
        private void NotePad_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightButtomMenuStrip.Show((Control)sender, e.Location);
            }
        }

        // Обработка события при при нажатии на кнопку "Закрыть вкладку".
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                if (tabPanel.SelectedTab != null)
                {
                    if (tabPageCollection[tabPanel.SelectedIndex].Name != "" && tabPageCollection[tabPanel.SelectedIndex].Name != null)
                    {
                        if (textBoxsChanged.ContainsKey(allTextBoxes[tabPanel.SelectedIndex]))
                        {
                            DialogResult dialogResult = MessageBox.Show("Вы хотите сохранить изменения перед закрытием вкладки?", "Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.No)
                            {
                                if (tabPanel.SelectedTab != null)
                                {
                                    RichTextBoxRemove();
                                }
                            }
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (File.Exists(tabPageCollection[tabPanel.SelectedIndex].Name))
                                {
                                    SaveExsistFileBeforeCloseTab();

                                    MessageBox.Show("Файл успешно сохранен!");
                                }
                                else
                                {
                                    MessageBox.Show($"Невозможно сохранить файл по данному пути:" +
                                        $"\n{tabPageCollection[tabPanel.SelectedIndex].Name}" +
                                        $"\nВоспользуйтесь функцией \"Сохранить как\"");
                                }
                            }
                        }
                        else
                        {
                            if (tabPanel.SelectedTab != null)
                            {
                                RichTextBoxRemove();
                            }
                        }
                    }
                    else
                    {
                        SaveFileBeforeCloseTab();
                    }
                }
                else
                {
                    MessageBox.Show($"Вкладка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно сохранить данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tabPanel.SelectedTab != null)
                {
                    RichTextBoxRemove();
                }
            }
        }

        // Удаление RichTextBox со словаря изменения текста, листа всех RichTextBox и закрытие выбранной вкладки.
        private void RichTextBoxRemove()
        {
            try
            {
                textBoxsChanged.Remove(allTextBoxes[tabPanel.SelectedIndex]);
                allTextBoxes.Remove(allTextBoxes[tabPanel.SelectedIndex]);
                tabPanel.TabPages.Remove(tabPanel.SelectedTab);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранение файла по указанному пути перед закрытием вкладки.
        private void SaveExsistFileBeforeCloseTab()
        {
            try
            {
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                if (tabPageCollection[tabPanel.SelectedIndex].Name.EndsWith(".txt"))
                {
                    File.WriteAllText(tabPageCollection[tabPanel.SelectedIndex].Name, allTextBoxes[tabPanel.SelectedIndex].Text);
                }
                if (tabPageCollection[tabPanel.SelectedIndex].Name.EndsWith(".rtf"))
                {
                    allTextBoxes[tabPanel.SelectedIndex].SaveFile(tabPageCollection[tabPanel.SelectedIndex].Name);
                }
                if (tabPanel.SelectedTab != null)
                {
                    RichTextBoxRemove();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно сохранить данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tabPanel.SelectedTab != null)
                {
                    RichTextBoxRemove();
                }
            }
        }

        // Сохранение файла с указанием пути перед закрытием вкладки.
        private void SaveFileBeforeCloseTab()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Вы хотите сохранить изменения перед закрытием вкладки?", "Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    if (tabPanel.SelectedTab != null)
                    {
                        RichTextBoxRemove();
                    }
                }
                if (dialogResult == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    if (saveFileDialog1.FileName.EndsWith(".txt"))
                    {
                        File.WriteAllText(saveFileDialog1.FileName, allTextBoxes[tabPanel.SelectedIndex].Text);
                    }
                    if (saveFileDialog1.FileName.EndsWith(".rtf"))
                    {
                        allTextBoxes[tabPanel.SelectedIndex].SaveFile(saveFileDialog1.FileName);
                    }
                    if (tabPanel.SelectedTab != null)
                    {
                        RichTextBoxRemove();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно сохранить данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tabPanel.SelectedTab != null)
                {
                    RichTextBoxRemove();
                }
            }
        }

        // Обработка события перед закрытием формы.
        private void NotePad_FormClosing(object sender, FormClosingEventArgs e)
        {
            int countTabsWithoutPath = 0;

            //if (e.CloseReason != CloseReason.UserClosing)
            //{
            //    MessageBox.Show("lfey!!!");
            //    e.Cancel = true;
            //}

            e.Cancel = true;

            //try
            //{
            //    SaveDataAndSettings();

            //    if (tabPanel.TabPages.Count != 0)
            //    {
            //        if (e.CloseReason != CloseReason.UserClosing)
            //        {
            //            return;
            //        }
            //        if (textBoxsChanged.Count != 0)
            //        {
            //            TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

            //            for (int i = 0; i < tabPanel.TabPages.Count; i++)
            //            {
            //                if (tabPageCollection[i].Name == "" || tabPageCollection[i].Name == null)
            //                {
            //                    countTabsWithoutPath++;
            //                }
            //            }
            //            if (countTabsWithoutPath != tabPanel.TabCount)
            //            {
            //                SaveAllRichtextBoxesFirst(e);
            //            }
            //            else
            //            {
            //                SaveAllRichtextBoxesSecond(e);
            //            }
            //        }
            //        else
            //        {
            //            Application.Exit();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        // MessageBox с уведомлением о ручном сохранении файлов.
        private void SaveAllRichtextBoxesFirst(FormClosingEventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Вы хотите сохранить файлы перед закрытием приложения?" +
                                "\nИнформация в открытых вкладках в приложении будет безвозратно потеряна, если вы не сохраните их вручную!",
                                "Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
                if (dialogResult == DialogResult.Yes)
                {
                    SaveAllOpenFiles();

                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MessageBox с уведомлением о ручном сохранении файлов.
        private void SaveAllRichtextBoxesSecond(FormClosingEventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Информация в открытых вкладках в приложении будет потеряна, если вы не сохраните их содержимое вручную!" +
                                    "\n\nВы желаете сохранить данную информацию вручную?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
                if (dialogResult == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранение всех открытых в приложении файлов.
        private void SaveAllOpenFiles()
        {
            try
            {
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                for (int i = 0; i < tabPanel.TabPages.Count; i++)
                {
                    if (tabPageCollection[i].Name != "" && tabPageCollection[i].Name != null)
                    {
                        if (tabPageCollection[i].Name.EndsWith(".txt"))
                        {
                            File.WriteAllText(tabPageCollection[i].Name, allTextBoxes[i].Text);
                        }
                        if (tabPageCollection[i].Name.EndsWith(".rtf"))
                        {
                            allTextBoxes[i].SaveFile(tabPageCollection[i].Name);
                        }

                        textBoxsChanged.Remove(allTextBoxes[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранение всех открытых файлов по таймеру.
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                for (int i = 0; i < tabPanel.TabPages.Count; i++)
                {
                    if (tabPageCollection[i].Name != "" && tabPageCollection[i].Name != null)
                    {
                        if (tabPageCollection[i].Name.EndsWith(".txt"))
                        {
                            File.WriteAllText(tabPageCollection[i].Name, allTextBoxes[i].Text);
                        }
                        if (tabPageCollection[i].Name.EndsWith(".rtf"))
                        {
                            allTextBoxes[i].SaveFile(tabPageCollection[i].Name);
                        }

                        textBoxsChanged.Remove(allTextBoxes[i]);
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

        // Сохранение путей к открытым файлам и настроек.
        private void SaveDataAndSettings()
        {
            List<string> saveData = new List<string>();

            string stringSave = "";

            try
            {
                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                stringSave = $"{!flagFormColor}";
                stringSave += $"\n{timer1.Interval}";
                stringSave += "\n-Paths";

                for (int i = 0; i < tabPanel.TabPages.Count; i++)
                {
                    stringSave += $"\n{tabPageCollection[i].Name}";
                }

                stringSave += "\n-EndPaths";

                StreamWriter streamWriter = new StreamWriter($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}DataBase.txt", false, Encoding.UTF8);
                streamWriter.WriteLine(stringSave);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении настроек и путей к открытым файлам!" +
                    $"\n{ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Открытие всех файлов до закрытия формы и установка соответсвующих настроек.
        private void OpenFileAndChangeSettings()
        {
            bool flagFilesOpen = false;

            try
            {
                string[] openData = File.ReadAllLines($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}DataBase.txt", Encoding.UTF8);

                if (openData[0] == "True")
                {
                    flagFormColor = true;
                }
                else if (openData[0] == "False")
                {
                    flagFormColor = false;
                }

                int.TryParse(openData[1], out int timer);

                timer1.Interval = timer;

                for (int i = 3; i < openData.Length; i++)
                {
                    if (openData[i] == "-EndPaths")
                    {
                        flagFilesOpen = true;
                    }
                    if (!flagFilesOpen)
                    {
                        if (openData[i] == null || openData[i] == "")
                        {
                            OpenTabs();
                        }
                        else if (File.Exists(openData[i]))
                        {
                            OpenFiles(openData[i]);
                        }
                    }
                }
                Customize();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при восстановлнении сохраненных настроек и открытии файлов!" +
                    $"\n{ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Открытие файлов до закрытия формы.
        public void OpenFiles(string filePath)
        {
            try
            {
                allTextBoxes.Add(new RichTextBox());
                allTextBoxes[tabPanel.TabPages.Count].Dock = DockStyle.Fill;
                allTextBoxes[tabPanel.TabPages.Count].TextChanged += TextBoxs_TextChanged;

                if (filePath.EndsWith(".txt"))
                {
                    allTextBoxes[tabPanel.TabPages.Count].Text = System.IO.File.ReadAllText(filePath);
                }
                if (filePath.EndsWith(".rtf"))
                {
                    allTextBoxes[tabPanel.TabPages.Count].LoadFile(filePath, RichTextBoxStreamType.RichText);
                }

                string[] fileName = filePath.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

                tabPanel.TabPages.Add(filePath, fileName[fileName.Length - 1]);

                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                tabPageCollection[tabPanel.TabPages.Count - 1].Controls.Add(allTextBoxes[tabPanel.TabPages.Count - 1]);

                tabPanel.SelectedTab = tabPageCollection[tabPanel.TabPages.Count - 1];

                allTextBoxes[tabPanel.SelectedIndex].ContextMenuStrip = rightButtomMenuStrip;
                allTextBoxes[tabPanel.SelectedIndex].MouseUp += NotePad_MouseUp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Открытие вкладок до закрытия формы.
        public void OpenTabs()
        {
            try
            {
                allTextBoxes.Add(new RichTextBox());
                allTextBoxes[tabPanel.TabPages.Count].Dock = DockStyle.Fill;
                allTextBoxes[tabPanel.TabPages.Count].TextChanged += TextBoxs_TextChanged;

                tabPanel.TabPages.Add($"new{counterNewTabs++}");

                TabControl.TabPageCollection tabPageCollection = tabPanel.TabPages;

                tabPanel.SelectedTab = tabPageCollection[tabPanel.TabPages.Count - 1];

                tabPageCollection[tabPanel.TabPages.Count - 1].Controls.Add(allTextBoxes[tabPanel.TabPages.Count - 1]);

                allTextBoxes[tabPanel.SelectedIndex].ContextMenuStrip = rightButtomMenuStrip;
                allTextBoxes[tabPanel.SelectedIndex].MouseUp += NotePad_MouseUp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Видимость tabControl.
        private void tabPanelColorStatus()
        {
            if (tabPanel.TabPages.Count == 0)
            {
                tabPanel.Visible = false;
            }
            else
            {
                tabPanel.Visible = true;
            }
        }

        // Обработка события при выборе вкладки.
        private void tabPanel_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabPanel.TabPages.Count > 50)
            {
                MessageBox.Show("При дальнейшем открытии вкладок корректная работоспособность не гарантируется!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (tabPanel.TabPages.Count == 0)
            {
                tabPanel.Visible = false;
            }
            else
            {
                tabPanel.Visible = true;
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
