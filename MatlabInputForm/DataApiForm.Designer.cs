namespace MatlabInputForm
{
	partial class DataAPIForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataAPIForm));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.MLLabel = new System.Windows.Forms.Label();
			this.FolderSelect = new System.Windows.Forms.ComboBox();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.AbortButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.InterleavedTip = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.53535F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.46465F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			this.tableLayoutPanel1.Controls.Add(this.MLLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.FolderSelect, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.BrowseButton, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.AbortButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.OKButton, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 58);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// MLLabel
			// 
			this.MLLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.MLLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MLLabel.Location = new System.Drawing.Point(3, 0);
			this.MLLabel.Name = "MLLabel";
			this.MLLabel.Size = new System.Drawing.Size(106, 29);
			this.MLLabel.TabIndex = 2;
			this.MLLabel.Text = "MATLAB Location:";
			this.MLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FolderSelect
			// 
			this.FolderSelect.AllowDrop = true;
			this.FolderSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.FolderSelect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FolderSelect.FormattingEnabled = true;
			this.FolderSelect.Location = new System.Drawing.Point(115, 3);
			this.FolderSelect.Name = "FolderSelect";
			this.FolderSelect.Size = new System.Drawing.Size(276, 21);
			this.FolderSelect.TabIndex = 3;
			this.FolderSelect.SelectionChangeCommitted += new System.EventHandler(this.FolderSelect_SelectionChangeCommitted);
			// 
			// BrowseButton
			// 
			this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseButton.Location = new System.Drawing.Point(397, 3);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(77, 23);
			this.BrowseButton.TabIndex = 4;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
			// 
			// AbortButton
			// 
			this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.AbortButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AbortButton.Location = new System.Drawing.Point(397, 32);
			this.AbortButton.Name = "AbortButton";
			this.AbortButton.Size = new System.Drawing.Size(77, 23);
			this.AbortButton.TabIndex = 5;
			this.AbortButton.Text = "Cancel";
			this.AbortButton.UseVisualStyleBackColor = true;
			this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.OKButton.Location = new System.Drawing.Point(316, 32);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 6;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// FolderBrowser
			// 
			this.FolderBrowser.Description = "Locate the folder where MATLAB is installed. You can also find this by running \'m" +
    "atlabroot\' at the MATLAB prompt.";
			this.FolderBrowser.ShowNewFolderButton = false;
			// 
			// DataAPIForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.AbortButton;
			this.ClientSize = new System.Drawing.Size(477, 58);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(global::MatlabInputForm.Properties.Resources.matlab_logo));
			this.Name = "DataAPIForm";
			this.Text = "MEX Function Wizard - Data API";
			this.tableLayoutPanel1.ResumeLayout(false);
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
	}
}

