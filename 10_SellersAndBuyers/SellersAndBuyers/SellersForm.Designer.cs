
namespace SellersAndBuyers
{
    partial class SellersForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkClientsButton = new System.Windows.Forms.Button();
            this.checkOrdersButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1179, 685);
            this.dataGridView1.TabIndex = 0;
            // 
            // checkClientsButton
            // 
            this.checkClientsButton.Location = new System.Drawing.Point(3, 691);
            this.checkClientsButton.Name = "checkClientsButton";
            this.checkClientsButton.Size = new System.Drawing.Size(387, 50);
            this.checkClientsButton.TabIndex = 1;
            this.checkClientsButton.Text = "Просмотреть список клиентов";
            this.checkClientsButton.UseVisualStyleBackColor = true;
            this.checkClientsButton.Click += new System.EventHandler(this.checkClientsButton_Click);
            // 
            // checkOrdersButton
            // 
            this.checkOrdersButton.Location = new System.Drawing.Point(396, 691);
            this.checkOrdersButton.Name = "checkOrdersButton";
            this.checkOrdersButton.Size = new System.Drawing.Size(387, 50);
            this.checkOrdersButton.TabIndex = 2;
            this.checkOrdersButton.Text = "Просмотреть список заказов";
            this.checkOrdersButton.UseVisualStyleBackColor = true;
            this.checkOrdersButton.Click += new System.EventHandler(this.checkOrdersButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(789, 691);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(387, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Просмотреть список активных заказов";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SellersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 744);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkOrdersButton);
            this.Controls.Add(this.checkClientsButton);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(1280, 791);
            this.MinimumSize = new System.Drawing.Size(1080, 791);
            this.Name = "SellersForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интерфейс продавца";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SellersForm_FormClosing);
           
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button checkClientsButton;
        private System.Windows.Forms.Button checkOrdersButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

