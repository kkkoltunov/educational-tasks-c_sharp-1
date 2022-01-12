
namespace NotePad__
{
    partial class NotePad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rightButtomMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNewFormStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.developersStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabPage1);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanel.Location = new System.Drawing.Point(0, 28);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(783, 725);
            this.tabPanel.TabIndex = 2;
            this.tabPanel.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabPanel_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(775, 692);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "new1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(769, 686);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // rightButtomMenuStrip
            // 
            this.rightButtomMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rightButtomMenuStrip.Name = "rightButtomMenuStrip";
            this.rightButtomMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.aboutToolStripMenuItem.Text = "&О программе";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openNewFormStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.createToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.createToolStripMenuItem.Text = "&Создать новую вкладку";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.closeToolStripMenuItem.Text = "&Закрыть вкладку";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.openToolStripMenuItem.Text = "&Открыть";
            // 
            // openNewFormStripMenuItem
            // 
            this.openNewFormStripMenuItem.Name = "openNewFormStripMenuItem";
            this.openNewFormStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.openNewFormStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.openNewFormStripMenuItem.Text = "Открыть в новом окне";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.saveToolStripMenuItem.Text = "&Сохранить";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.saveAsToolStripMenuItem.Text = "Сохранить &как";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.saveAllToolStripMenuItem.Text = "&Сохранить все файлы";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoStripMenuItem,
            this.redoStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.cutToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.editToolStripMenuItem.Text = "&Правка";
            // 
            // undoStripMenuItem
            // 
            this.undoStripMenuItem.Name = "undoStripMenuItem";
            this.undoStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.undoStripMenuItem.Text = "&Отменить действие";
            // 
            // redoStripMenuItem
            // 
            this.redoStripMenuItem.Name = "redoStripMenuItem";
            this.redoStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.redoStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.redoStripMenuItem.Text = "&Повторить";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.copyToolStripMenuItem.Text = "&Копировать";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.pasteToolStripMenuItem.Text = "&Вставить";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.selectAllToolStripMenuItem.Text = "Выбрать все";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.cutToolStripMenuItem.Text = "Вырезать";
            // 
            // formatStripMenuItem
            // 
            this.formatStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontsStripMenuItem});
            this.formatStripMenuItem.Name = "formatStripMenuItem";
            this.formatStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.formatStripMenuItem.Text = "&Формат";
            // 
            // fontsStripMenuItem
            // 
            this.fontsStripMenuItem.Name = "fontsStripMenuItem";
            this.fontsStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.fontsStripMenuItem.Text = "&Шрифт";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.developersStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.toolsToolStripMenuItem.Text = "&Настройки";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.customizeToolStripMenuItem.Text = "&Изменить тему";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intervalStripMenuItem1,
            this.intervalStripMenuItem2,
            this.intervalStripMenuItem3,
            this.intervalStripMenuItem4,
            this.intervalStripMenuItem5,
            this.intervalStripMenuItem6,
            this.intervalStripMenuItem7,
            this.intervalStripMenuItem8,
            this.intervalStripMenuItem9});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.optionsToolStripMenuItem.Text = "&Интервал сохранения";
            // 
            // intervalStripMenuItem1
            // 
            this.intervalStripMenuItem1.Name = "intervalStripMenuItem1";
            this.intervalStripMenuItem1.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem1.Text = "5 секунд";
            // 
            // intervalStripMenuItem2
            // 
            this.intervalStripMenuItem2.Name = "intervalStripMenuItem2";
            this.intervalStripMenuItem2.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem2.Text = "15 секунд";
            // 
            // intervalStripMenuItem3
            // 
            this.intervalStripMenuItem3.Name = "intervalStripMenuItem3";
            this.intervalStripMenuItem3.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem3.Text = "30 секунд";
            // 
            // intervalStripMenuItem4
            // 
            this.intervalStripMenuItem4.Name = "intervalStripMenuItem4";
            this.intervalStripMenuItem4.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem4.Text = "1 минута";
            // 
            // intervalStripMenuItem5
            // 
            this.intervalStripMenuItem5.Name = "intervalStripMenuItem5";
            this.intervalStripMenuItem5.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem5.Text = "2 минута";
            // 
            // intervalStripMenuItem6
            // 
            this.intervalStripMenuItem6.Name = "intervalStripMenuItem6";
            this.intervalStripMenuItem6.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem6.Text = "5 минут";
            // 
            // intervalStripMenuItem7
            // 
            this.intervalStripMenuItem7.Name = "intervalStripMenuItem7";
            this.intervalStripMenuItem7.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem7.Text = "15 минут";
            // 
            // intervalStripMenuItem8
            // 
            this.intervalStripMenuItem8.Name = "intervalStripMenuItem8";
            this.intervalStripMenuItem8.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem8.Text = "30 минут";
            // 
            // intervalStripMenuItem9
            // 
            this.intervalStripMenuItem9.Name = "intervalStripMenuItem9";
            this.intervalStripMenuItem9.Size = new System.Drawing.Size(158, 26);
            this.intervalStripMenuItem9.Text = "1 час";
            // 
            // developersStripMenuItem
            // 
            this.developersStripMenuItem.Name = "developersStripMenuItem";
            this.developersStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.developersStripMenuItem.Text = "&Режим разработчика";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.helpToolStripMenuItem.Text = "&Помощь";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Silver;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(783, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.Color.Blue;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NotePad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 753);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "NotePad";
            this.Text = "NotePad+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotePad_FormClosing);
            this.tabPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ContextMenuStrip rightButtomMenuStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem formatStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem openNewFormStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developersStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoStripMenuItem;
    }
}

