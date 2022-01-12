
namespace ExcelMini
{
    partial class OpenFileForm
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.labelSelectDelimiters = new System.Windows.Forms.Label();
            this.labelInfoFirstString = new System.Windows.Forms.Label();
            this.comboBoxAnswer = new System.Windows.Forms.ComboBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.labelSelectFile = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelFileSelect = new System.Windows.Forms.Label();
            this.labelFileNotSelect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.checkBox1.Location = new System.Drawing.Point(28, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 22);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Запятая (\",\")";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.checkBox2.Location = new System.Drawing.Point(28, 85);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(172, 22);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Точка с запятой (\";\")";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.checkBox3.Location = new System.Drawing.Point(28, 113);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(135, 22);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Двоеточие (\":\")";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.checkBox4.Location = new System.Drawing.Point(28, 141);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(100, 22);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Точка (\".\")";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // labelSelectDelimiters
            // 
            this.labelSelectDelimiters.AutoSize = true;
            this.labelSelectDelimiters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSelectDelimiters.Location = new System.Drawing.Point(25, 25);
            this.labelSelectDelimiters.Name = "labelSelectDelimiters";
            this.labelSelectDelimiters.Size = new System.Drawing.Size(360, 20);
            this.labelSelectDelimiters.TabIndex = 4;
            this.labelSelectDelimiters.Text = "Укажите разделитель элементов файла:";
            // 
            // labelInfoFirstString
            // 
            this.labelInfoFirstString.AutoSize = true;
            this.labelInfoFirstString.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelInfoFirstString.Location = new System.Drawing.Point(24, 178);
            this.labelInfoFirstString.Name = "labelInfoFirstString";
            this.labelInfoFirstString.Size = new System.Drawing.Size(400, 20);
            this.labelInfoFirstString.TabIndex = 5;
            this.labelInfoFirstString.Text = "Первая строка содержит названия столбцов?";
            // 
            // comboBoxAnswer
            // 
            this.comboBoxAnswer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnswer.FormattingEnabled = true;
            this.comboBoxAnswer.Items.AddRange(new object[] {
            "Да",
            "Нет"});
            this.comboBoxAnswer.Location = new System.Drawing.Point(443, 178);
            this.comboBoxAnswer.Name = "comboBoxAnswer";
            this.comboBoxAnswer.Size = new System.Drawing.Size(67, 24);
            this.comboBoxAnswer.TabIndex = 6;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(382, 213);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(87, 32);
            this.buttonSelectFile.TabIndex = 7;
            this.buttonSelectFile.Text = "Выбрать";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // labelSelectFile
            // 
            this.labelSelectFile.AutoSize = true;
            this.labelSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSelectFile.Location = new System.Drawing.Point(25, 218);
            this.labelSelectFile.Name = "labelSelectFile";
            this.labelSelectFile.Size = new System.Drawing.Size(339, 20);
            this.labelSelectFile.TabIndex = 8;
            this.labelSelectFile.Text = "Выберите нужный файл для открытия:";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSelect.Location = new System.Drawing.Point(51, 281);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(440, 40);
            this.buttonSelect.TabIndex = 9;
            this.buttonSelect.Text = "Подтвердить";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            // 
            // labelFileSelect
            // 
            this.labelFileSelect.AutoSize = true;
            this.labelFileSelect.ForeColor = System.Drawing.Color.OliveDrab;
            this.labelFileSelect.Location = new System.Drawing.Point(371, 248);
            this.labelFileSelect.Name = "labelFileSelect";
            this.labelFileSelect.Size = new System.Drawing.Size(98, 17);
            this.labelFileSelect.TabIndex = 10;
            this.labelFileSelect.Text = "Файл выбран";
            // 
            // labelFileNotSelect
            // 
            this.labelFileNotSelect.AutoSize = true;
            this.labelFileNotSelect.ForeColor = System.Drawing.Color.Red;
            this.labelFileNotSelect.Location = new System.Drawing.Point(371, 248);
            this.labelFileNotSelect.Name = "labelFileNotSelect";
            this.labelFileNotSelect.Size = new System.Drawing.Size(118, 17);
            this.labelFileNotSelect.TabIndex = 11;
            this.labelFileNotSelect.Text = "Файл не выбран";
            // 
            // OpenFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 333);
            this.Controls.Add(this.labelFileNotSelect);
            this.Controls.Add(this.labelFileSelect);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.labelSelectFile);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.comboBoxAnswer);
            this.Controls.Add(this.labelInfoFirstString);
            this.Controls.Add(this.labelSelectDelimiters);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(540, 380);
            this.MinimumSize = new System.Drawing.Size(539, 365);
            this.Name = "OpenFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenFileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label labelSelectDelimiters;
        private System.Windows.Forms.Label labelInfoFirstString;
        private System.Windows.Forms.ComboBox comboBoxAnswer;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Label labelSelectFile;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelFileSelect;
        private System.Windows.Forms.Label labelFileNotSelect;
    }
}