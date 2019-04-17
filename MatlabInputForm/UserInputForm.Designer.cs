namespace MatlabInputForm
{
	partial class UserInputForm
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
			this.PLabel = new System.Windows.Forms.Label();
			this.PlatformSelect = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.APISelect = new System.Windows.Forms.ComboBox();
			this.MLLabel = new System.Windows.Forms.Label();
			this.FolderSelect = new System.Windows.Forms.ComboBox();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.AbortButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.APILabel = new System.Windows.Forms.Label();
			this.InterleavedCheck = new System.Windows.Forms.CheckBox();
			this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.InterleavedTip = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PLabel
			// 
			this.PLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.PLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PLabel.Location = new System.Drawing.Point(20, 27);
			this.PLabel.Name = "PLabel";
			this.PLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.PLabel.Size = new System.Drawing.Size(97, 27);
			this.PLabel.TabIndex = 0;
			this.PLabel.Text = "Platform:";
			this.PLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// PlatformSelect
			// 
			this.PlatformSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.PlatformSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PlatformSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlatformSelect.FormattingEnabled = true;
			this.PlatformSelect.Location = new System.Drawing.Point(123, 30);
			this.PlatformSelect.Name = "PlatformSelect";
			this.PlatformSelect.Size = new System.Drawing.Size(257, 21);
			this.PlatformSelect.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.36792F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.63207F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
			this.tableLayoutPanel1.Controls.Add(this.APISelect, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.PlatformSelect, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.PLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.MLLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.FolderSelect, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.BrowseButton, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.AbortButton, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.OKButton, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.APILabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.InterleavedCheck, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 118);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// APISelect
			// 
			this.APISelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.APISelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.APISelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.APISelect.FormattingEnabled = true;
			this.APISelect.Location = new System.Drawing.Point(123, 3);
			this.APISelect.Name = "APISelect";
			this.APISelect.Size = new System.Drawing.Size(257, 21);
			this.APISelect.TabIndex = 8;
			// 
			// MLLabel
			// 
			this.MLLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.MLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MLLabel.Location = new System.Drawing.Point(3, 54);
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
			this.FolderSelect.Location = new System.Drawing.Point(123, 57);
			this.FolderSelect.Name = "FolderSelect";
			this.FolderSelect.Size = new System.Drawing.Size(257, 21);
			this.FolderSelect.TabIndex = 3;
			// 
			// BrowseButton
			// 
			this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.BrowseButton.Location = new System.Drawing.Point(386, 57);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(88, 23);
			this.BrowseButton.TabIndex = 4;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			// 
			// AbortButton
			// 
			this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.AbortButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AbortButton.Location = new System.Drawing.Point(386, 86);
			this.AbortButton.Name = "AbortButton";
			this.AbortButton.Size = new System.Drawing.Size(88, 30);
			this.AbortButton.TabIndex = 5;
			this.AbortButton.Text = "Cancel";
			this.AbortButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.OKButton.Location = new System.Drawing.Point(305, 86);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 30);
			this.OKButton.TabIndex = 6;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// APILabel
			// 
			this.APILabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.APILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.APILabel.Location = new System.Drawing.Point(19, 0);
			this.APILabel.Name = "APILabel";
			this.APILabel.Size = new System.Drawing.Size(98, 27);
			this.APILabel.TabIndex = 7;
			this.APILabel.Text = "MEX API:";
			this.APILabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// InterleavedCheck
			// 
			this.InterleavedCheck.AutoSize = true;
			this.InterleavedCheck.Dock = System.Windows.Forms.DockStyle.Left;
			this.InterleavedCheck.Location = new System.Drawing.Point(386, 3);
			this.InterleavedCheck.Name = "InterleavedCheck";
			this.InterleavedCheck.Size = new System.Drawing.Size(79, 21);
			this.InterleavedCheck.TabIndex = 9;
			this.InterleavedCheck.Text = "Interleaved";
			this.InterleavedTip.SetToolTip(this.InterleavedCheck, "Use the interleaved complex API rather than the seperate complex API.");
			this.InterleavedCheck.UseVisualStyleBackColor = true;
			// 
			// FolderBrowser
			// 
			this.FolderBrowser.Description = "Locate the folder where MATLAB is installed. You can also find this by running \'m" +
    "atlabroot\' at the MATLAB prompt.";
			this.FolderBrowser.ShowNewFolderButton = false;
			// 
			// UserInputForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(477, 118);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "UserInputForm";
			this.Text = "MEX Template Wizard";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label PLabel;
		private System.Windows.Forms.ComboBox PlatformSelect;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label MLLabel;
		private System.Windows.Forms.ComboBox FolderSelect;
		private System.Windows.Forms.Button AbortButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.ComboBox APISelect;
		private System.Windows.Forms.Label APILabel;
		private System.Windows.Forms.ToolTip InterleavedTip;
		private System.Windows.Forms.CheckBox InterleavedCheck;
	}
}

