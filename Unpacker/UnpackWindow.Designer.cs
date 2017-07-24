
namespace Unpacker
{
    partial class UnpackWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnpackWindow));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkLabel1 = new System.Windows.Forms.Label();
			this.checkLabel2 = new System.Windows.Forms.Label();
			this.checkLabel3 = new System.Windows.Forms.Label();
			this.checkLabel4 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.progressBar1 = new Unpacker.ProgressBarText();
			this.progressBar2 = new Unpacker.ProgressBarText();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(14, 14);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select ROM:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(20, 30);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(335, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Select a ROM file.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Click += new System.EventHandler(this.button1_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(360, 30);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(35, 20);
			this.button1.TabIndex = 1;
			this.button1.Text = "•••";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(14, 61);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Select Folder:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoEllipsis = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Enabled = false;
			this.label4.Location = new System.Drawing.Point(20, 75);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(335, 20);
			this.label4.TabIndex = 0;
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.Click += new System.EventHandler(this.button2_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
			this.button2.Enabled = false;
			this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(360, 75);
			this.button2.Margin = new System.Windows.Forms.Padding(0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(35, 20);
			this.button2.TabIndex = 2;
			this.button2.Text = "•••";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(14, 105);
			this.label5.Margin = new System.Windows.Forms.Padding(0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Extra Functions:";
			// 
			// checkBox1
			// 
			this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
			this.checkBox1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.checkBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
			this.checkBox1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.checkBox1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox1.ForeColor = System.Drawing.Color.White;
			this.checkBox1.Location = new System.Drawing.Point(20, 129);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(0);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(12, 12);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.UseVisualStyleBackColor = false;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			this.checkBox1.GotFocus += new System.EventHandler(this.checkBox_GotFocus);
			this.checkBox1.LostFocus += new System.EventHandler(this.checkBox_LostFocus);
			// 
			// checkBox2
			// 
			this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
			this.checkBox2.Enabled = false;
			this.checkBox2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.checkBox2.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
			this.checkBox2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.checkBox2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox2.ForeColor = System.Drawing.Color.White;
			this.checkBox2.Location = new System.Drawing.Point(20, 147);
			this.checkBox2.Margin = new System.Windows.Forms.Padding(0);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(12, 12);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.UseVisualStyleBackColor = false;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			this.checkBox2.GotFocus += new System.EventHandler(this.checkBox_GotFocus);
			this.checkBox2.LostFocus += new System.EventHandler(this.checkBox_LostFocus);
			// 
			// checkBox3
			// 
			this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
			this.checkBox3.Enabled = false;
			this.checkBox3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.checkBox3.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
			this.checkBox3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.checkBox3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox3.ForeColor = System.Drawing.Color.White;
			this.checkBox3.Location = new System.Drawing.Point(140, 129);
			this.checkBox3.Margin = new System.Windows.Forms.Padding(0);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(12, 12);
			this.checkBox3.TabIndex = 5;
			this.checkBox3.UseVisualStyleBackColor = false;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			this.checkBox3.GotFocus += new System.EventHandler(this.checkBox_GotFocus);
			this.checkBox3.LostFocus += new System.EventHandler(this.checkBox_LostFocus);
			// 
			// checkBox4
			// 
			this.checkBox4.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
			this.checkBox4.Enabled = false;
			this.checkBox4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.checkBox4.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
			this.checkBox4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.checkBox4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox4.ForeColor = System.Drawing.Color.White;
			this.checkBox4.Location = new System.Drawing.Point(140, 147);
			this.checkBox4.Margin = new System.Windows.Forms.Padding(0);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(12, 12);
			this.checkBox4.TabIndex = 6;
			this.checkBox4.UseVisualStyleBackColor = false;
			this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			this.checkBox4.GotFocus += new System.EventHandler(this.checkBox_GotFocus);
			this.checkBox4.LostFocus += new System.EventHandler(this.checkBox_LostFocus);
			// 
			// checkLabel1
			// 
			this.checkLabel1.AutoSize = true;
			this.checkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkLabel1.ForeColor = System.Drawing.Color.White;
			this.checkLabel1.Location = new System.Drawing.Point(35, 128);
			this.checkLabel1.Margin = new System.Windows.Forms.Padding(0);
			this.checkLabel1.Name = "checkLabel1";
			this.checkLabel1.Size = new System.Drawing.Size(83, 13);
			this.checkLabel1.TabIndex = 0;
			this.checkLabel1.Text = "Unpack NARCs";
			this.checkLabel1.Click += new System.EventHandler(this.checkLabel_Click);
			// 
			// checkLabel2
			// 
			this.checkLabel2.AutoSize = true;
			this.checkLabel2.Enabled = false;
			this.checkLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkLabel2.ForeColor = System.Drawing.Color.White;
			this.checkLabel2.Location = new System.Drawing.Point(35, 146);
			this.checkLabel2.Margin = new System.Windows.Forms.Padding(0);
			this.checkLabel2.Name = "checkLabel2";
			this.checkLabel2.Size = new System.Drawing.Size(82, 13);
			this.checkLabel2.TabIndex = 0;
			this.checkLabel2.Text = "Unpack SDATs";
			this.checkLabel2.Click += new System.EventHandler(this.checkLabel_Click);
			// 
			// checkLabel3
			// 
			this.checkLabel3.AutoSize = true;
			this.checkLabel3.Enabled = false;
			this.checkLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkLabel3.ForeColor = System.Drawing.Color.White;
			this.checkLabel3.Location = new System.Drawing.Point(155, 128);
			this.checkLabel3.Margin = new System.Windows.Forms.Padding(0);
			this.checkLabel3.Name = "checkLabel3";
			this.checkLabel3.Size = new System.Drawing.Size(98, 13);
			this.checkLabel3.TabIndex = 0;
			this.checkLabel3.Text = "Decompress ARMs";
			this.checkLabel3.Click += new System.EventHandler(this.checkLabel_Click);
			// 
			// checkLabel4
			// 
			this.checkLabel4.AutoSize = true;
			this.checkLabel4.Enabled = false;
			this.checkLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkLabel4.ForeColor = System.Drawing.Color.White;
			this.checkLabel4.Location = new System.Drawing.Point(155, 146);
			this.checkLabel4.Margin = new System.Windows.Forms.Padding(0);
			this.checkLabel4.Name = "checkLabel4";
			this.checkLabel4.Size = new System.Drawing.Size(110, 13);
			this.checkLabel4.TabIndex = 0;
			this.checkLabel4.Text = "Decompress Overlays";
			this.checkLabel4.Click += new System.EventHandler(this.checkLabel_Click);
			// 
			// button3
			// 
			this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
			this.button3.Enabled = false;
			this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.White;
			this.button3.Location = new System.Drawing.Point(98, 175);
			this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(70, 25);
			this.button3.TabIndex = 13;
			this.button3.Text = "Unpack!";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
			this.button4.Enabled = false;
			this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.ForeColor = System.Drawing.Color.White;
			this.button4.Location = new System.Drawing.Point(240, 175);
			this.button4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(70, 25);
			this.button4.TabIndex = 13;
			this.button4.Text = "Cancel!";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
			this.progressBar1.ForeColor = System.Drawing.Color.Black;
			this.progressBar1.Location = new System.Drawing.Point(0, 213);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(409, 17);
			this.progressBar1.Step = 1;
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 14;
			// 
			// progressBar2
			// 
			this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
			this.progressBar2.ForeColor = System.Drawing.Color.Black;
			this.progressBar2.Location = new System.Drawing.Point(0, 229);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(409, 17);
			this.progressBar2.Step = 1;
			this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar2.TabIndex = 14;
			// 
			// UnpackWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
			this.ClientSize = new System.Drawing.Size(409, 246);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.checkLabel1);
			this.Controls.Add(this.checkLabel2);
			this.Controls.Add(this.checkLabel3);
			this.Controls.Add(this.checkLabel4);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.progressBar2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UnpackWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = " Nintendo DS ROM Unpacker";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Label checkLabel1;
		private System.Windows.Forms.Label checkLabel2;
		private System.Windows.Forms.Label checkLabel3;
		private System.Windows.Forms.Label checkLabel4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private Unpacker.ProgressBarText progressBar1;
		private Unpacker.ProgressBarText progressBar2;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
	}
}