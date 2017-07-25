
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
			this.fileTitleLabel = new System.Windows.Forms.Label();
			this.fileButtonLabel = new System.Windows.Forms.Label();
			this.fileButton = new System.Windows.Forms.Button();
			this.pathTitleLabel = new System.Windows.Forms.Label();
			this.pathButtonLabel = new System.Windows.Forms.Label();
			this.pathButton = new System.Windows.Forms.Button();
			this.extrasLabel = new System.Windows.Forms.Label();
			this.narcCheckBox = new System.Windows.Forms.CheckBox();
			this.sdatCheckBox = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.narcCheckBoxLabel = new System.Windows.Forms.Label();
			this.sdatCheckBoxLabel = new System.Windows.Forms.Label();
			this.checkpathTitleLabel = new System.Windows.Forms.Label();
			this.checkpathButtonLabel = new System.Windows.Forms.Label();
			this.unpackButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.romWorker = new System.ComponentModel.BackgroundWorker();
			this.progressBar1 = new Unpacker.ProgressBarText();
			this.progressBar2 = new Unpacker.ProgressBarText();
			this.narcWorker = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// fileTitleLabel
			// 
			this.fileTitleLabel.AutoSize = true;
			this.fileTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileTitleLabel.ForeColor = System.Drawing.Color.White;
			this.fileTitleLabel.Location = new System.Drawing.Point(14, 14);
			this.fileTitleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.fileTitleLabel.Name = "fileTitleLabel";
			this.fileTitleLabel.Size = new System.Drawing.Size(79, 13);
			this.fileTitleLabel.TabIndex = 0;
			this.fileTitleLabel.Text = "ROM Or Archive:";
			// 
			// fileButtonLabel
			// 
			this.fileButtonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fileButtonLabel.BackColor = System.Drawing.Color.White;
			this.fileButtonLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.fileButtonLabel.Location = new System.Drawing.Point(20, 30);
			this.fileButtonLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.fileButtonLabel.Name = "fileButtonLabel";
			this.fileButtonLabel.Size = new System.Drawing.Size(335, 20);
			this.fileButtonLabel.TabIndex = 0;
			this.fileButtonLabel.Text = "Select a ROM or archive to unpack,";
			this.fileButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.fileButtonLabel.Click += new System.EventHandler(this.fileButton_Click);
			// 
			// fileButton
			// 
			this.fileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
			this.fileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.fileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.fileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.fileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.fileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileButton.ForeColor = System.Drawing.Color.White;
			this.fileButton.Location = new System.Drawing.Point(360, 30);
			this.fileButton.Margin = new System.Windows.Forms.Padding(0);
			this.fileButton.Name = "fileButton";
			this.fileButton.Size = new System.Drawing.Size(35, 20);
			this.fileButton.TabIndex = 1;
			this.fileButton.Text = "•••";
			this.fileButton.UseVisualStyleBackColor = false;
			this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
			// 
			// pathTitleLabel
			// 
			this.pathTitleLabel.AutoSize = true;
			this.pathTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pathTitleLabel.ForeColor = System.Drawing.Color.White;
			this.pathTitleLabel.Location = new System.Drawing.Point(14, 61);
			this.pathTitleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.pathTitleLabel.Name = "pathTitleLabel";
			this.pathTitleLabel.Size = new System.Drawing.Size(86, 13);
			this.pathTitleLabel.TabIndex = 0;
			this.pathTitleLabel.Text = "Destination Folder:";
			// 
			// pathButtonLabel
			// 
			this.pathButtonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pathButtonLabel.AutoEllipsis = true;
			this.pathButtonLabel.BackColor = System.Drawing.Color.White;
			this.pathButtonLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pathButtonLabel.Enabled = false;
			this.pathButtonLabel.Location = new System.Drawing.Point(20, 75);
			this.pathButtonLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pathButtonLabel.Name = "pathButtonLabel";
			this.pathButtonLabel.Size = new System.Drawing.Size(335, 20);
			this.pathButtonLabel.TabIndex = 0;
			this.pathButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.pathButtonLabel.Click += new System.EventHandler(this.pathButton_Click);
			// 
			// pathButton
			// 
			this.pathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pathButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
			this.pathButton.Enabled = false;
			this.pathButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.pathButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.pathButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.pathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.pathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pathButton.ForeColor = System.Drawing.Color.White;
			this.pathButton.Location = new System.Drawing.Point(360, 75);
			this.pathButton.Margin = new System.Windows.Forms.Padding(0);
			this.pathButton.Name = "pathButton";
			this.pathButton.Size = new System.Drawing.Size(35, 20);
			this.pathButton.TabIndex = 2;
			this.pathButton.Text = "•••";
			this.pathButton.UseVisualStyleBackColor = false;
			this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
			// 
			// extrasLabel
			// 
			this.extrasLabel.AutoSize = true;
			this.extrasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.extrasLabel.ForeColor = System.Drawing.Color.White;
			this.extrasLabel.Location = new System.Drawing.Point(14, 105);
			this.extrasLabel.Margin = new System.Windows.Forms.Padding(0);
			this.extrasLabel.Name = "extrasLabel";
			this.extrasLabel.Size = new System.Drawing.Size(99, 13);
			this.extrasLabel.TabIndex = 0;
			this.extrasLabel.Text = "Extra Functions:";
			// 
			// narcCheckBox
			// 
			this.narcCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			this.narcCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
			this.narcCheckBox.Enabled = false;
			this.narcCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.narcCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
			this.narcCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.narcCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.narcCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.narcCheckBox.ForeColor = System.Drawing.Color.White;
			this.narcCheckBox.Location = new System.Drawing.Point(20, 129);
			this.narcCheckBox.Margin = new System.Windows.Forms.Padding(0);
			this.narcCheckBox.Name = "narcCheckBox";
			this.narcCheckBox.Size = new System.Drawing.Size(12, 12);
			this.narcCheckBox.TabIndex = 3;
			this.narcCheckBox.UseVisualStyleBackColor = false;
			this.narcCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			this.narcCheckBox.GotFocus += new System.EventHandler(this.checkBox_GotFocus);
			this.narcCheckBox.LostFocus += new System.EventHandler(this.checkBox_LostFocus);
			// 
			// sdatCheckBox
			// 
			this.sdatCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			this.sdatCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
			this.sdatCheckBox.Enabled = false;
			this.sdatCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.sdatCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
			this.sdatCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.sdatCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.sdatCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sdatCheckBox.ForeColor = System.Drawing.Color.White;
			this.sdatCheckBox.Location = new System.Drawing.Point(20, 147);
			this.sdatCheckBox.Margin = new System.Windows.Forms.Padding(0);
			this.sdatCheckBox.Name = "sdatCheckBox";
			this.sdatCheckBox.Size = new System.Drawing.Size(12, 12);
			this.sdatCheckBox.TabIndex = 4;
			this.sdatCheckBox.UseVisualStyleBackColor = false;
			this.sdatCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			this.sdatCheckBox.GotFocus += new System.EventHandler(this.checkBox_GotFocus);
			this.sdatCheckBox.LostFocus += new System.EventHandler(this.checkBox_LostFocus);
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
			// narcCheckBoxLabel
			// 
			this.narcCheckBoxLabel.AutoSize = true;
			this.narcCheckBoxLabel.Enabled = false;
			this.narcCheckBoxLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.narcCheckBoxLabel.ForeColor = System.Drawing.Color.White;
			this.narcCheckBoxLabel.Location = new System.Drawing.Point(35, 128);
			this.narcCheckBoxLabel.Margin = new System.Windows.Forms.Padding(0);
			this.narcCheckBoxLabel.Name = "narcCheckBoxLabel";
			this.narcCheckBoxLabel.Size = new System.Drawing.Size(83, 13);
			this.narcCheckBoxLabel.TabIndex = 0;
			this.narcCheckBoxLabel.Text = "Unpack NARCs";
			this.narcCheckBoxLabel.Click += new System.EventHandler(this.checkLabel_Click);
			// 
			// sdatCheckBoxLabel
			// 
			this.sdatCheckBoxLabel.AutoSize = true;
			this.sdatCheckBoxLabel.Enabled = false;
			this.sdatCheckBoxLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sdatCheckBoxLabel.ForeColor = System.Drawing.Color.White;
			this.sdatCheckBoxLabel.Location = new System.Drawing.Point(35, 146);
			this.sdatCheckBoxLabel.Margin = new System.Windows.Forms.Padding(0);
			this.sdatCheckBoxLabel.Name = "sdatCheckBoxLabel";
			this.sdatCheckBoxLabel.Size = new System.Drawing.Size(82, 13);
			this.sdatCheckBoxLabel.TabIndex = 0;
			this.sdatCheckBoxLabel.Text = "Unpack SDATs";
			this.sdatCheckBoxLabel.Click += new System.EventHandler(this.checkLabel_Click);
			// 
			// checkpathTitleLabel
			// 
			this.checkpathTitleLabel.AutoSize = true;
			this.checkpathTitleLabel.Enabled = false;
			this.checkpathTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkpathTitleLabel.ForeColor = System.Drawing.Color.White;
			this.checkpathTitleLabel.Location = new System.Drawing.Point(155, 128);
			this.checkpathTitleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.checkpathTitleLabel.Name = "checkpathTitleLabel";
			this.checkpathTitleLabel.Size = new System.Drawing.Size(98, 13);
			this.checkpathTitleLabel.TabIndex = 0;
			this.checkpathTitleLabel.Text = "Decompress ARMs";
			this.checkpathTitleLabel.Click += new System.EventHandler(this.checkLabel_Click);
			// 
			// checkpathButtonLabel
			// 
			this.checkpathButtonLabel.AutoSize = true;
			this.checkpathButtonLabel.Enabled = false;
			this.checkpathButtonLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkpathButtonLabel.ForeColor = System.Drawing.Color.White;
			this.checkpathButtonLabel.Location = new System.Drawing.Point(155, 146);
			this.checkpathButtonLabel.Margin = new System.Windows.Forms.Padding(0);
			this.checkpathButtonLabel.Name = "checkpathButtonLabel";
			this.checkpathButtonLabel.Size = new System.Drawing.Size(110, 13);
			this.checkpathButtonLabel.TabIndex = 0;
			this.checkpathButtonLabel.Text = "Decompress Overlays";
			this.checkpathButtonLabel.Click += new System.EventHandler(this.checkLabel_Click);
			// 
			// unpackButton
			// 
			this.unpackButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.unpackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
			this.unpackButton.Enabled = false;
			this.unpackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.unpackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.unpackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.unpackButton.ForeColor = System.Drawing.Color.White;
			this.unpackButton.Location = new System.Drawing.Point(98, 175);
			this.unpackButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.unpackButton.Name = "unpackButton";
			this.unpackButton.Size = new System.Drawing.Size(70, 25);
			this.unpackButton.TabIndex = 13;
			this.unpackButton.Text = "Unpack!";
			this.unpackButton.UseVisualStyleBackColor = false;
			this.unpackButton.Click += new System.EventHandler(this.unpackButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
			this.cancelButton.Enabled = false;
			this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.ForeColor = System.Drawing.Color.White;
			this.cancelButton.Location = new System.Drawing.Point(240, 175);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(70, 25);
			this.cancelButton.TabIndex = 13;
			this.cancelButton.Text = "Cancel!";
			this.cancelButton.UseVisualStyleBackColor = false;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
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
			this.Controls.Add(this.fileTitleLabel);
			this.Controls.Add(this.fileButtonLabel);
			this.Controls.Add(this.fileButton);
			this.Controls.Add(this.pathTitleLabel);
			this.Controls.Add(this.pathButtonLabel);
			this.Controls.Add(this.pathButton);
			this.Controls.Add(this.extrasLabel);
			this.Controls.Add(this.narcCheckBox);
			this.Controls.Add(this.sdatCheckBox);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.narcCheckBoxLabel);
			this.Controls.Add(this.sdatCheckBoxLabel);
			this.Controls.Add(this.checkpathTitleLabel);
			this.Controls.Add(this.checkpathButtonLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.unpackButton);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.progressBar2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UnpackWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = " NDS ROM Unpacker (By HiroTDK)";
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.UnpackWindow_HelpButtonClicked);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label fileTitleLabel;
		private System.Windows.Forms.Label fileButtonLabel;
		private System.Windows.Forms.Button fileButton;
		private System.Windows.Forms.Label pathTitleLabel;
		private System.Windows.Forms.Label pathButtonLabel;
		private System.Windows.Forms.Button pathButton;
		private System.Windows.Forms.Label extrasLabel;
		private System.Windows.Forms.CheckBox narcCheckBox;
		private System.Windows.Forms.CheckBox sdatCheckBox;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Label narcCheckBoxLabel;
		private System.Windows.Forms.Label sdatCheckBoxLabel;
		private System.Windows.Forms.Label checkpathTitleLabel;
		private System.Windows.Forms.Label checkpathButtonLabel;
		private System.Windows.Forms.Button unpackButton;
		private System.Windows.Forms.Button cancelButton;
		private Unpacker.ProgressBarText progressBar1;
		private Unpacker.ProgressBarText progressBar2;
		private System.ComponentModel.BackgroundWorker romWorker;
		private System.ComponentModel.BackgroundWorker narcWorker;
	}
}