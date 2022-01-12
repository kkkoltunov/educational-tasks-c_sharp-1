
namespace SellersAndBuyers
{
    partial class BuyersForm
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
            this.addProductButton = new System.Windows.Forms.Button();
            this.basketButton = new System.Windows.Forms.Button();
            this.allOrdersButton = new System.Windows.Forms.Button();
            this.changeUserButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1059, 590);
            this.dataGridView1.TabIndex = 0;
            // 
            // addProductButton
            // 
            this.addProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addProductButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addProductButton.Location = new System.Drawing.Point(0, 596);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(262, 55);
            this.addProductButton.TabIndex = 1;
            this.addProductButton.Text = "Добавить в корзину";
            this.addProductButton.UseVisualStyleBackColor = false;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // basketButton
            // 
            this.basketButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.basketButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.basketButton.Location = new System.Drawing.Point(268, 596);
            this.basketButton.Name = "basketButton";
            this.basketButton.Size = new System.Drawing.Size(262, 55);
            this.basketButton.TabIndex = 2;
            this.basketButton.Text = "Корзина";
            this.basketButton.UseVisualStyleBackColor = false;
            this.basketButton.Click += new System.EventHandler(this.basketButton_Click);
            // 
            // allOrdersButton
            // 
            this.allOrdersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.allOrdersButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.allOrdersButton.Location = new System.Drawing.Point(536, 596);
            this.allOrdersButton.Name = "allOrdersButton";
            this.allOrdersButton.Size = new System.Drawing.Size(262, 55);
            this.allOrdersButton.TabIndex = 3;
            this.allOrdersButton.Text = "Просмотреть список заказов";
            this.allOrdersButton.UseVisualStyleBackColor = false;
            this.allOrdersButton.Click += new System.EventHandler(this.allOrdersButton_Click);
            // 
            // changeUserButton
            // 
            this.changeUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.changeUserButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.changeUserButton.Location = new System.Drawing.Point(804, 596);
            this.changeUserButton.Name = "changeUserButton";
            this.changeUserButton.Size = new System.Drawing.Size(255, 55);
            this.changeUserButton.TabIndex = 4;
            this.changeUserButton.Text = "Сменить пользователя";
            this.changeUserButton.UseVisualStyleBackColor = false;
            this.changeUserButton.Click += new System.EventHandler(this.changeUserButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // BuyersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1060, 653);
            this.Controls.Add(this.changeUserButton);
            this.Controls.Add(this.allOrdersButton);
            this.Controls.Add(this.basketButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(1078, 700);
            this.MinimumSize = new System.Drawing.Size(1078, 700);
            this.Name = "BuyersForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интерфейс покупателя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuyersForm_FormClosing);
           
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button basketButton;
        private System.Windows.Forms.Button allOrdersButton;
        private System.Windows.Forms.Button changeUserButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

