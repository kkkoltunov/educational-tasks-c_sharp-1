
namespace ExcelMini
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonOpenCSV = new System.Windows.Forms.Button();
            this.buttonAnalyzeData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 414);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonOpenCSV
            // 
            this.buttonOpenCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenCSV.Location = new System.Drawing.Point(0, 417);
            this.buttonOpenCSV.Name = "buttonOpenCSV";
            this.buttonOpenCSV.Size = new System.Drawing.Size(396, 34);
            this.buttonOpenCSV.TabIndex = 1;
            this.buttonOpenCSV.Text = "Открыть новый файл";
            this.buttonOpenCSV.UseVisualStyleBackColor = true;
            this.buttonOpenCSV.Click += new System.EventHandler(this.buttonOpenCSV_Click);
            // 
            // buttonAnalyzeData
            // 
            this.buttonAnalyzeData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalyzeData.Location = new System.Drawing.Point(402, 417);
            this.buttonAnalyzeData.Name = "buttonAnalyzeData";
            this.buttonAnalyzeData.Size = new System.Drawing.Size(398, 34);
            this.buttonAnalyzeData.TabIndex = 2;
            this.buttonAnalyzeData.Text = "Анализировать данные таблицы";
            this.buttonAnalyzeData.UseVisualStyleBackColor = true;
            this.buttonAnalyzeData.Click += new System.EventHandler(this.buttonAnalyzeData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAnalyzeData);
            this.Controls.Add(this.buttonOpenCSV);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(1400, 1000);
            this.MinimumSize = new System.Drawing.Size(817, 496);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExcelMini";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonOpenCSV;
        private System.Windows.Forms.Button buttonAnalyzeData;
    }
}

