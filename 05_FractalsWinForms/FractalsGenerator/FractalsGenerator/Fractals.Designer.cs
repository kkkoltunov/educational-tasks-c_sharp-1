namespace FractalsGenerator
{
    partial class Fractals
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
            this.fractalPictureBox = new System.Windows.Forms.PictureBox();
            this.treeLengthBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.treeAngleBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.fractalImageLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.treeAngleBar2 = new System.Windows.Forms.TrackBar();
            this.treeDegreeLabel2 = new System.Windows.Forms.Label();
            this.treeDegreeLabel1 = new System.Windows.Forms.Label();
            this.treeLengthLabel = new System.Windows.Forms.Label();
            this.fractalChooseIteration = new System.Windows.Forms.Label();
            this.depthUpDown = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fractalScaleLabel = new System.Windows.Forms.Label();
            this.fractalSaveImage = new System.Windows.Forms.Button();
            this.fractalComboBox = new System.Windows.Forms.ComboBox();
            this.fractalTreePanel = new System.Windows.Forms.Panel();
            this.fractalCantorPanel = new System.Windows.Forms.Panel();
            this.cantorLayerLabel = new System.Windows.Forms.Label();
            this.cantorLayerBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.nonTreeLengthLabel = new System.Windows.Forms.Label();
            this.fractalsLengthBar = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.fractalKochCurvePanel = new System.Windows.Forms.Panel();
            this.fractalLimit = new System.Windows.Forms.Button();
            this.fractalChooseLabel = new System.Windows.Forms.Label();
            this.fractalExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeLengthBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeAngleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeAngleBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthUpDown)).BeginInit();
            this.fractalTreePanel.SuspendLayout();
            this.fractalCantorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantorLayerBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractalsLengthBar)).BeginInit();
            this.fractalKochCurvePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fractalPictureBox
            // 
            this.fractalPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fractalPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fractalPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fractalPictureBox.Location = new System.Drawing.Point(412, 38);
            this.fractalPictureBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.fractalPictureBox.Name = "fractalPictureBox";
            this.fractalPictureBox.Size = new System.Drawing.Size(566, 570);
            this.fractalPictureBox.TabIndex = 0;
            this.fractalPictureBox.TabStop = false;
            this.fractalPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.fractalPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.fractalPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // treeLengthBar
            // 
            this.treeLengthBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeLengthBar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.treeLengthBar.Location = new System.Drawing.Point(20, 40);
            this.treeLengthBar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.treeLengthBar.Maximum = 200;
            this.treeLengthBar.Name = "treeLengthBar";
            this.treeLengthBar.Size = new System.Drawing.Size(277, 56);
            this.treeLengthBar.TabIndex = 1;
            this.treeLengthBar.Value = 75;
            this.treeLengthBar.ValueChanged += new System.EventHandler(this.treeLengthBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(41, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "МАСШТАБ ПОБОЧНЫХ ВЕТВЕЙ";
            // 
            // treeAngleBar1
            // 
            this.treeAngleBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeAngleBar1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.treeAngleBar1.Location = new System.Drawing.Point(20, 136);
            this.treeAngleBar1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.treeAngleBar1.Maximum = 100;
            this.treeAngleBar1.Name = "treeAngleBar1";
            this.treeAngleBar1.Size = new System.Drawing.Size(277, 56);
            this.treeAngleBar1.TabIndex = 1;
            this.treeAngleBar1.Value = 50;
            this.treeAngleBar1.ValueChanged += new System.EventHandler(this.treeAngleBar1_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(20, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "УГОЛ НАКЛОНА ПЕРВОГО ОТРЕЗКА";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fractalImageLabel
            // 
            this.fractalImageLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fractalImageLabel.AutoSize = true;
            this.fractalImageLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fractalImageLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.fractalImageLabel.Location = new System.Drawing.Point(599, 9);
            this.fractalImageLabel.Name = "fractalImageLabel";
            this.fractalImageLabel.Size = new System.Drawing.Size(281, 28);
            this.fractalImageLabel.TabIndex = 2;
            this.fractalImageLabel.Text = "ИЗОБРАЖЕНИЕ ФРАКТАЛА";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(20, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "УГОЛ НАКЛОНА ВТОРОГО ОТРЕЗКА";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeAngleBar2
            // 
            this.treeAngleBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeAngleBar2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.treeAngleBar2.Location = new System.Drawing.Point(20, 231);
            this.treeAngleBar2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.treeAngleBar2.Maximum = 100;
            this.treeAngleBar2.Name = "treeAngleBar2";
            this.treeAngleBar2.Size = new System.Drawing.Size(277, 56);
            this.treeAngleBar2.TabIndex = 1;
            this.treeAngleBar2.Value = 50;
            this.treeAngleBar2.ValueChanged += new System.EventHandler(this.treeAngleBar2_ValueChanged);
            // 
            // treeDegreeLabel2
            // 
            this.treeDegreeLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeDegreeLabel2.AutoSize = true;
            this.treeDegreeLabel2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeDegreeLabel2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.treeDegreeLabel2.Location = new System.Drawing.Point(293, 232);
            this.treeDegreeLabel2.Name = "treeDegreeLabel2";
            this.treeDegreeLabel2.Size = new System.Drawing.Size(30, 19);
            this.treeDegreeLabel2.TabIndex = 2;
            this.treeDegreeLabel2.Text = "45°";
            this.treeDegreeLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeDegreeLabel1
            // 
            this.treeDegreeLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeDegreeLabel1.AutoSize = true;
            this.treeDegreeLabel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeDegreeLabel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.treeDegreeLabel1.Location = new System.Drawing.Point(293, 139);
            this.treeDegreeLabel1.Name = "treeDegreeLabel1";
            this.treeDegreeLabel1.Size = new System.Drawing.Size(30, 19);
            this.treeDegreeLabel1.TabIndex = 2;
            this.treeDegreeLabel1.Text = "45°";
            this.treeDegreeLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeLengthLabel
            // 
            this.treeLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeLengthLabel.AutoSize = true;
            this.treeLengthLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeLengthLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.treeLengthLabel.Location = new System.Drawing.Point(293, 41);
            this.treeLengthLabel.Name = "treeLengthLabel";
            this.treeLengthLabel.Size = new System.Drawing.Size(36, 19);
            this.treeLengthLabel.TabIndex = 2;
            this.treeLengthLabel.Text = "75%";
            this.treeLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fractalChooseIteration
            // 
            this.fractalChooseIteration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fractalChooseIteration.AutoSize = true;
            this.fractalChooseIteration.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fractalChooseIteration.ForeColor = System.Drawing.SystemColors.Desktop;
            this.fractalChooseIteration.Location = new System.Drawing.Point(73, 384);
            this.fractalChooseIteration.Name = "fractalChooseIteration";
            this.fractalChooseIteration.Size = new System.Drawing.Size(290, 30);
            this.fractalChooseIteration.TabIndex = 2;
            this.fractalChooseIteration.Text = "КОЛИЧЕСТВО ИТЕРАЦИЙ";
            this.fractalChooseIteration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // depthUpDown
            // 
            this.depthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.depthUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.depthUpDown.Location = new System.Drawing.Point(287, 447);
            this.depthUpDown.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.depthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.depthUpDown.Name = "depthUpDown";
            this.depthUpDown.Size = new System.Drawing.Size(52, 24);
            this.depthUpDown.TabIndex = 3;
            this.depthUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.depthUpDown.ValueChanged += new System.EventHandler(this.depthValueControl_ValueChanged);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.DimGray;
            // 
            // fractalScaleLabel
            // 
            this.fractalScaleLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fractalScaleLabel.AutoSize = true;
            this.fractalScaleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fractalScaleLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.fractalScaleLabel.Location = new System.Drawing.Point(610, 609);
            this.fractalScaleLabel.Name = "fractalScaleLabel";
            this.fractalScaleLabel.Size = new System.Drawing.Size(173, 28);
            this.fractalScaleLabel.TabIndex = 5;
            this.fractalScaleLabel.Text = "МАСШТАБ:100%";
            // 
            // fractalSaveImage
            // 
            this.fractalSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fractalSaveImage.BackColor = System.Drawing.Color.IndianRed;
            this.fractalSaveImage.FlatAppearance.BorderSize = 0;
            this.fractalSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fractalSaveImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fractalSaveImage.Location = new System.Drawing.Point(59, 496);
            this.fractalSaveImage.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.fractalSaveImage.Name = "fractalSaveImage";
            this.fractalSaveImage.Size = new System.Drawing.Size(293, 55);
            this.fractalSaveImage.TabIndex = 4;
            this.fractalSaveImage.Text = "СОХРАНИТЬ ИЗОБРАЖЕНИЕ";
            this.fractalSaveImage.UseVisualStyleBackColor = false;
            this.fractalSaveImage.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // fractalComboBox
            // 
            this.fractalComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.fractalComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fractalComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fractalComboBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.fractalComboBox.FormattingEnabled = true;
            this.fractalComboBox.Location = new System.Drawing.Point(89, 59);
            this.fractalComboBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.fractalComboBox.Name = "fractalComboBox";
            this.fractalComboBox.Size = new System.Drawing.Size(209, 26);
            this.fractalComboBox.TabIndex = 8;
            this.fractalComboBox.SelectedIndexChanged += new System.EventHandler(this.fractalComboBox_SelectedIndexChanged);
            this.fractalComboBox.SelectedValueChanged += new System.EventHandler(this.fractalComboBox_SelectedValueChanged);
            // 
            // fractalTreePanel
            // 
            this.fractalTreePanel.Controls.Add(this.treeLengthLabel);
            this.fractalTreePanel.Controls.Add(this.treeAngleBar2);
            this.fractalTreePanel.Controls.Add(this.treeDegreeLabel2);
            this.fractalTreePanel.Controls.Add(this.treeLengthBar);
            this.fractalTreePanel.Controls.Add(this.treeDegreeLabel1);
            this.fractalTreePanel.Controls.Add(this.label1);
            this.fractalTreePanel.Controls.Add(this.label4);
            this.fractalTreePanel.Controls.Add(this.treeAngleBar1);
            this.fractalTreePanel.Controls.Add(this.label2);
            this.fractalTreePanel.Location = new System.Drawing.Point(48, 96);
            this.fractalTreePanel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.fractalTreePanel.Name = "fractalTreePanel";
            this.fractalTreePanel.Size = new System.Drawing.Size(332, 296);
            this.fractalTreePanel.TabIndex = 9;
            // 
            // fractalCantorPanel
            // 
            this.fractalCantorPanel.Controls.Add(this.cantorLayerLabel);
            this.fractalCantorPanel.Controls.Add(this.cantorLayerBar);
            this.fractalCantorPanel.Controls.Add(this.label5);
            this.fractalCantorPanel.Location = new System.Drawing.Point(28, 152);
            this.fractalCantorPanel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.fractalCantorPanel.Name = "fractalCantorPanel";
            this.fractalCantorPanel.Size = new System.Drawing.Size(353, 109);
            this.fractalCantorPanel.TabIndex = 9;
            // 
            // cantorLayerLabel
            // 
            this.cantorLayerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cantorLayerLabel.AutoSize = true;
            this.cantorLayerLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cantorLayerLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cantorLayerLabel.Location = new System.Drawing.Point(312, 41);
            this.cantorLayerLabel.Name = "cantorLayerLabel";
            this.cantorLayerLabel.Size = new System.Drawing.Size(39, 19);
            this.cantorLayerLabel.TabIndex = 2;
            this.cantorLayerLabel.Text = "10px";
            this.cantorLayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cantorLayerBar
            // 
            this.cantorLayerBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cantorLayerBar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cantorLayerBar.Location = new System.Drawing.Point(40, 40);
            this.cantorLayerBar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.cantorLayerBar.Maximum = 100;
            this.cantorLayerBar.Name = "cantorLayerBar";
            this.cantorLayerBar.Size = new System.Drawing.Size(277, 56);
            this.cantorLayerBar.TabIndex = 1;
            this.cantorLayerBar.Value = 10;
            this.cantorLayerBar.ValueChanged += new System.EventHandler(this.cantorLayerBar_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(71, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "ДИСТАНЦИЯ МЕЖДУ СЛОЯМИ";
            // 
            // nonTreeLengthLabel
            // 
            this.nonTreeLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nonTreeLengthLabel.AutoSize = true;
            this.nonTreeLengthLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nonTreeLengthLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.nonTreeLengthLabel.Location = new System.Drawing.Point(330, 41);
            this.nonTreeLengthLabel.Name = "nonTreeLengthLabel";
            this.nonTreeLengthLabel.Size = new System.Drawing.Size(44, 19);
            this.nonTreeLengthLabel.TabIndex = 2;
            this.nonTreeLengthLabel.Text = "100%";
            this.nonTreeLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fractalsLengthBar
            // 
            this.fractalsLengthBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fractalsLengthBar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fractalsLengthBar.Location = new System.Drawing.Point(64, 40);
            this.fractalsLengthBar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.fractalsLengthBar.Maximum = 200;
            this.fractalsLengthBar.Name = "fractalsLengthBar";
            this.fractalsLengthBar.Size = new System.Drawing.Size(277, 56);
            this.fractalsLengthBar.TabIndex = 1;
            this.fractalsLengthBar.Value = 100;
            this.fractalsLengthBar.ValueChanged += new System.EventHandler(this.nonTreeLengthBar_ValueChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(129, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(163, 23);
            this.label16.TabIndex = 2;
            this.label16.Text = "ДЛИНА ОТРЕЗКОВ";
            // 
            // fractalKochCurvePanel
            // 
            this.fractalKochCurvePanel.Controls.Add(this.nonTreeLengthLabel);
            this.fractalKochCurvePanel.Controls.Add(this.fractalsLengthBar);
            this.fractalKochCurvePanel.Controls.Add(this.label16);
            this.fractalKochCurvePanel.Location = new System.Drawing.Point(11, 166);
            this.fractalKochCurvePanel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.fractalKochCurvePanel.Name = "fractalKochCurvePanel";
            this.fractalKochCurvePanel.Size = new System.Drawing.Size(377, 112);
            this.fractalKochCurvePanel.TabIndex = 9;
            // 
            // fractalLimit
            // 
            this.fractalLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fractalLimit.BackColor = System.Drawing.Color.IndianRed;
            this.fractalLimit.FlatAppearance.BorderSize = 0;
            this.fractalLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fractalLimit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fractalLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fractalLimit.Location = new System.Drawing.Point(59, 429);
            this.fractalLimit.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.fractalLimit.Name = "fractalLimit";
            this.fractalLimit.Size = new System.Drawing.Size(212, 56);
            this.fractalLimit.TabIndex = 4;
            this.fractalLimit.Text = "ВЫКЛЮЧИТЬ ОГРАНИЧЕНИЕ";
            this.fractalLimit.UseVisualStyleBackColor = false;
            this.fractalLimit.Click += new System.EventHandler(this.limitButton_Click);
            // 
            // fractalChooseLabel
            // 
            this.fractalChooseLabel.AutoSize = true;
            this.fractalChooseLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fractalChooseLabel.Location = new System.Drawing.Point(99, 18);
            this.fractalChooseLabel.Name = "fractalChooseLabel";
            this.fractalChooseLabel.Size = new System.Drawing.Size(217, 30);
            this.fractalChooseLabel.TabIndex = 10;
            this.fractalChooseLabel.Text = "ВЫБОР ФРАКТАЛА";
            // 
            // fractalExit
            // 
            this.fractalExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fractalExit.BackColor = System.Drawing.Color.IndianRed;
            this.fractalExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fractalExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fractalExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fractalExit.Location = new System.Drawing.Point(59, 564);
            this.fractalExit.Name = "fractalExit";
            this.fractalExit.Size = new System.Drawing.Size(293, 55);
            this.fractalExit.TabIndex = 11;
            this.fractalExit.Text = "ВЫХОД ИЗ ПРОГРАММЫ";
            this.fractalExit.UseVisualStyleBackColor = false;
            this.fractalExit.Click += new System.EventHandler(this.fractalExit_Click);
            // 
            // Fractals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(988, 640);
            this.Controls.Add(this.fractalExit);
            this.Controls.Add(this.fractalChooseLabel);
            this.Controls.Add(this.fractalCantorPanel);
            this.Controls.Add(this.fractalLimit);
            this.Controls.Add(this.fractalKochCurvePanel);
            this.Controls.Add(this.depthUpDown);
            this.Controls.Add(this.fractalComboBox);
            this.Controls.Add(this.fractalChooseIteration);
            this.Controls.Add(this.fractalSaveImage);
            this.Controls.Add(this.fractalScaleLabel);
            this.Controls.Add(this.fractalImageLabel);
            this.Controls.Add(this.fractalPictureBox);
            this.Controls.Add(this.fractalTreePanel);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.MinimumSize = new System.Drawing.Size(1006, 687);
            this.Name = "Fractals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fractal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Fractals_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeLengthBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeAngleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeAngleBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthUpDown)).EndInit();
            this.fractalTreePanel.ResumeLayout(false);
            this.fractalTreePanel.PerformLayout();
            this.fractalCantorPanel.ResumeLayout(false);
            this.fractalCantorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantorLayerBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractalsLengthBar)).EndInit();
            this.fractalKochCurvePanel.ResumeLayout(false);
            this.fractalKochCurvePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fractalPictureBox;
        private System.Windows.Forms.TrackBar treeLengthBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar treeAngleBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fractalImageLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar treeAngleBar2;
        private System.Windows.Forms.Label treeDegreeLabel2;
        private System.Windows.Forms.Label treeDegreeLabel1;
        private System.Windows.Forms.Label treeLengthLabel;
        private System.Windows.Forms.Label fractalChooseIteration;
        private System.Windows.Forms.NumericUpDown depthUpDown;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label fractalScaleLabel;
        private System.Windows.Forms.Button fractalSaveImage;
        private System.Windows.Forms.ComboBox fractalComboBox;
        private System.Windows.Forms.Panel fractalTreePanel;
        private System.Windows.Forms.Label nonTreeLengthLabel;
        private System.Windows.Forms.TrackBar fractalsLengthBar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel fractalKochCurvePanel;
        private System.Windows.Forms.Button fractalLimit;
        private System.Windows.Forms.Label cantorLayerLabel;
        private System.Windows.Forms.TrackBar cantorLayerBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel fractalCantorPanel;
        private System.Windows.Forms.Label fractalChooseLabel;
        private System.Windows.Forms.Button fractalExit;
    }
}

