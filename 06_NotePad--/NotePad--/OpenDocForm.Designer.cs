
namespace NotePad__
{
    partial class OpenDocForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rightButtomMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightButtomMenuStrip
            // 
            this.rightButtomMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rightButtomMenuStrip.Name = "contextMenuStrip1";
            this.rightButtomMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(783, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.saveToolStripMenuItem.Text = "&Сохранить";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.saveAsToolStripMenuItem.Text = "Сохранить &как";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.editToolStripMenuItem.Text = "&Правка";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(293, 26);
            this.undoToolStripMenuItem.Text = "&Отменить изменение";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(293, 26);
            this.redoToolStripMenuItem.Text = "&Повторить";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(293, 26);
            this.cutToolStripMenuItem.Text = "&Вырезать";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(293, 26);
            this.copyToolStripMenuItem.Text = "&Копировать";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(293, 26);
            this.pasteToolStripMenuItem.Text = "&Вставить";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(293, 26);
            this.selectAllToolStripMenuItem.Text = "Выбрать &все";
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
            this.fontsStripMenuItem.Text = "Шрифт";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.toolsToolStripMenuItem.Text = "&Настройки";
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
            this.intervalStripMenuItem5.Text = "2 минуты";
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
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(783, 725);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OpenDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 753);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "OpenDocForm";
            this.Text = "NewDocument";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OpenDocForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip rightButtomMenuStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem fontsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem intervalStripMenuItem9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}