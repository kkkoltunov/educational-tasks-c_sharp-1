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
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace NotePad__
{
    public partial class DevelopersForm : Form
    {
        // Путь к открытому файлу.
        string filePath;

        // Метка изменения текста в fastColoredTextBox1.
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

        public DevelopersForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            // Обработка событий при выборе элементов в menuStrip и fastColoredTextBox1.
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;

            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;

            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;

            undoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;

            redoToolStripMenuItem.Click += RedoToolStripMenuItem_Click;

            // Обработка событий при нажатии на кнопку в пункте "Настройки".
            toolStripMenuItem1.Click += ToolStripMenuItem1_Click;

            // Установка форматов для открытия и сохранения файлов с указанным расширением.
            openFileDialog1.Filter = "C# Source File(*.cs)|*.cs";
            saveFileDialog1.Filter = "C# Source File(*.cs)|*.cs";
        }

        public string UsingRoslyn(string csCode)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(csCode);
            SyntaxNode root = tree.GetRoot().NormalizeWhitespace();
            return root.ToFullString();
        }

        // Отмена действия.
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fastColoredTextBox1.Redo();
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
                fastColoredTextBox1.Undo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Применить форматирование".
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                fastColoredTextBox1.Text = UsingRoslyn(fastColoredTextBox1.Text);
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
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, fastColoredTextBox1.Text);
                    filePath = saveFileDialog1.FileName;
                    MessageBox.Show("Файл успешно сохранен!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при нажатии на кнопку "Сохранить".
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (filePath != null && filePath != "")
                {
                    File.WriteAllText(filePath, fastColoredTextBox1.Text);
                    MessageBox.Show("Файл успешно сохранен!");
                }
                else
                {
                    MessageBox.Show("Воспользуйтесь функцией \"Сохранить как\"!");
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
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    filePath = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработка события при изменении текста в fastColoredTextBox1.
        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
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
                BackColor = Color.Black;

                menuStrip1.BackColor = Color.Black;

                foreach (ToolStripMenuItem toolStripMenuItem in MainMenuStrip.Items)
                {
                    SetOrangeColor(toolStripMenuItem);
                }

                MainMenuStrip.Renderer = new ToolStripProfessionalRenderer(new ColorsDarkTheme());
            }
            else
            {
                BackColor = Color.White;

                menuStrip1.BackColor = Color.Silver;

                foreach (ToolStripMenuItem toolStripMenuItem in MainMenuStrip.Items)
                {
                    ResetColor(toolStripMenuItem);
                }

                MainMenuStrip.Renderer = new ToolStripProfessionalRenderer(new ColorsWhiteTheme());
            }
        }

        // Обработка события перед закрытием формы.
        private void DevelopersForm_FormClosing(object sender, FormClosingEventArgs e)
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
                            File.WriteAllText(filePath, fastColoredTextBox1.Text);
                        }
                        else
                        {
                            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                            {
                                return;
                            }
                            File.WriteAllText(saveFileDialog1.FileName, fastColoredTextBox1.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно сохранить данный файл по причине: {ex}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
