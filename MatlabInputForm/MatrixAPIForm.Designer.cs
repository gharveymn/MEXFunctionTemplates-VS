namespace MatlabInputForm
{
	partial class MatrixAPIForm
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.MLLabel = new System.Windows.Forms.Label();
			this.FolderSelect = new System.Windows.Forms.ComboBox();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.AbortButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.InterleavedTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.36792F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.63208F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
			this.tableLayoutPanel1.Controls.Add(this.MLLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.FolderSelect, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.BrowseButton, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.AbortButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.OKButton, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 64);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// MLLabel
			// 
			this.MLLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.MLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MLLabel.Location = new System.Drawing.Point(3, 0);
			this.MLLabel.Name = "MLLabel";
			this.MLLabel.Size = new System.Drawing.Size(114, 29);
			this.MLLabel.TabIndex = 2;
			this.MLLabel.Text = "MATLAB Location:";
			this.MLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FolderSelect
			// 
			this.FolderSelect.AllowDrop = true;
			this.FolderSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.FolderSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FolderSelect.FormattingEnabled = true;
			this.FolderSelect.Location = new System.Drawing.Point(123, 3);
			this.FolderSelect.Name = "FolderSelect";
			this.FolderSelect.Size = new System.Drawing.Size(256, 21);
			this.FolderSelect.TabIndex = 3;
			// 
			// BrowseButton
			// 
			this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.BrowseButton.Location = new System.Drawing.Point(385, 3);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(89, 23);
			this.BrowseButton.TabIndex = 4;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			// 
			// AbortButton
			// 
			this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.AbortButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AbortButton.Location = new System.Drawing.Point(385, 32);
			this.AbortButton.Name = "AbortButton";
			this.AbortButton.Size = new System.Drawing.Size(89, 30);
			this.AbortButton.TabIndex = 5;
			this.AbortButton.Text = "Cancel";
			this.AbortButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.OKButton.Location = new System.Drawing.Point(304, 32);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 30);
			this.OKButton.TabIndex = 6;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// FolderBrowser
			// 
			this.FolderBrowser.Description = "Locate the folder where MATLAB is installed. You can also find this by running \'m" +
    "atlabroot\' at the MATLAB prompt.";
			this.FolderBrowser.ShowNewFolderButton = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(12, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(85, 52);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Platform";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Dock = System.Windows.Forms.DockStyle.Top;
			this.radioButton1.Location = new System.Drawing.Point(3, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(79, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "64-bit";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.radioButton2.Location = new System.Drawing.Point(3, 32);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(79, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "32-bit";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Location = new System.Drawing.Point(103, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(117, 52);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Array Dimensions";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.radioButton3.Location = new System.Drawing.Point(3, 32);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(111, 17);
			this.radioButton3.TabIndex = 1;
			this.radioButton3.Text = "Compatible";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Checked = true;
			this.radioButton4.Dock = System.Windows.Forms.DockStyle.Top;
			this.radioButton4.Location = new System.Drawing.Point(3, 16);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(111, 17);
			this.radioButton4.TabIndex = 0;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Large";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioButton5);
			this.groupBox3.Controls.Add(this.radioButton6);
			this.groupBox3.Location = new System.Drawing.Point(226, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(127, 52);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Complex Numbers";
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.radioButton5.Location = new System.Drawing.Point(3, 32);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(121, 17);
			this.radioButton5.TabIndex = 1;
			this.radioButton5.Text = "Interleaved";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Checked = true;
			this.radioButton6.Dock = System.Windows.Forms.DockStyle.Top;
			this.radioButton6.Location = new System.Drawing.Point(3, 16);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(121, 17);
			this.radioButton6.TabIndex = 0;
			this.radioButton6.TabStop = true;
			this.radioButton6.Text = "Separated";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.radioButton7);
			this.groupBox4.Controls.Add(this.radioButton8);
			this.groupBox4.Location = new System.Drawing.Point(359, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(106, 52);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Graphics Class";
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.radioButton7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButton7.Location = new System.Drawing.Point(3, 32);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(100, 17);
			this.radioButton7.TabIndex = 1;
			this.radioButton7.Text = "double";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Checked = true;
			this.radioButton8.Dock = System.Windows.Forms.DockStyle.Top;
			this.radioButton8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButton8.Location = new System.Drawing.Point(3, 16);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(100, 17);
			this.radioButton8.TabIndex = 0;
			this.radioButton8.TabStop = true;
			this.radioButton8.Text = "object";
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(477, 119);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form2";
			this.Text = "MEX Function Template Wizard - Matrix API";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label MLLabel;
		private System.Windows.Forms.ComboBox FolderSelect;
		private System.Windows.Forms.Button AbortButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.ToolTip InterleavedTip;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton8;
	}
}

