namespace MatlabRootInputForm
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
			this.PLabel = new System.Windows.Forms.Label();
			this.PlatformSelect = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.MLLabel = new System.Windows.Forms.Label();
			this.FolderSelect = new System.Windows.Forms.ComboBox();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.AcceptButton = new System.Windows.Forms.Button();
			this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PLabel
			// 
			this.PLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.PLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PLabel.Location = new System.Drawing.Point(3, 0);
			this.PLabel.Name = "PLabel";
			this.PLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.PLabel.Size = new System.Drawing.Size(97, 17);
			this.PLabel.TabIndex = 0;
			this.PLabel.Text = "Platform:";
			this.PLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// PlatformSelect
			// 
			this.PlatformSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.PlatformSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PlatformSelect.FormattingEnabled = true;
			this.PlatformSelect.Location = new System.Drawing.Point(106, 3);
			this.PlatformSelect.Name = "PlatformSelect";
			this.PlatformSelect.Size = new System.Drawing.Size(307, 21);
			this.PlatformSelect.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.75961F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.24039F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
			this.tableLayoutPanel1.Controls.Add(this.PlatformSelect, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.PLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.MLLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.FolderSelect, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.BrowseButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.CancelButton, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.AcceptButton, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 88);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// MLLabel
			// 
			this.MLLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.MLLabel.Location = new System.Drawing.Point(3, 29);
			this.MLLabel.Name = "MLLabel";
			this.MLLabel.Size = new System.Drawing.Size(97, 23);
			this.MLLabel.TabIndex = 2;
			this.MLLabel.Text = "MATLAB Location:";
			this.MLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FolderSelect
			// 
			this.FolderSelect.AllowDrop = true;
			this.FolderSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.FolderSelect.FormattingEnabled = true;
			this.FolderSelect.Location = new System.Drawing.Point(106, 32);
			this.FolderSelect.Name = "FolderSelect";
			this.FolderSelect.Size = new System.Drawing.Size(307, 21);
			this.FolderSelect.TabIndex = 3;
			// 
			// BrowseButton
			// 
			this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.BrowseButton.Location = new System.Drawing.Point(419, 32);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(84, 23);
			this.BrowseButton.TabIndex = 4;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.CancelButton.Location = new System.Drawing.Point(419, 61);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(84, 23);
			this.CancelButton.TabIndex = 5;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// AcceptButton
			// 
			this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.AcceptButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.AcceptButton.Location = new System.Drawing.Point(338, 61);
			this.AcceptButton.Name = "AcceptButton";
			this.AcceptButton.Size = new System.Drawing.Size(75, 24);
			this.AcceptButton.TabIndex = 6;
			this.AcceptButton.Text = "OK";
			this.AcceptButton.UseVisualStyleBackColor = true;
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
			this.ClientSize = new System.Drawing.Size(506, 88);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "UserInputForm";
			this.Text = "MEX Template Wizard";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label PLabel;
		private System.Windows.Forms.ComboBox PlatformSelect;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label MLLabel;
		private System.Windows.Forms.ComboBox FolderSelect;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button AcceptButton;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
		private System.Windows.Forms.Button BrowseButton;
	}
}

