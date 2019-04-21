using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatlabInputForm
{
	public class DataAPIPanel : APIPanel, IPanel
	{

		private string[] matlab_registry_x64;

		public DataAPIPanel(APIForm parent, MatlabConfiguration ml_config) : base(parent, ml_config)
		{
			InitializeComponent();
			InitFolderSelect();
		}

		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.MLLabel = new System.Windows.Forms.Label();
			this.FolderSelect = new System.Windows.Forms.ComboBox();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.AbortButton = new System.Windows.Forms.Button();
			this.NextButton = new System.Windows.Forms.Button();
			this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.InterleavedTip = new System.Windows.Forms.ToolTip();
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
			this.tableLayoutPanel1.Controls.Add(this.NextButton, 1, 1);
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
			// NextButton
			// 
			this.NextButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.NextButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.NextButton.Location = new System.Drawing.Point(316, 32);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(75, 23);
			this.NextButton.TabIndex = 6;
			this.NextButton.Text = "OK";
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// FolderBrowser
			// 
			this.FolderBrowser.Description = "Locate the folder where MATLAB is installed. You can also find this by running \'m" +
    "atlabroot\' at the MATLAB prompt.";
			this.FolderBrowser.ShowNewFolderButton = false;
		}

		public new void ShowPanel()
		{
			this.tableLayoutPanel1.SuspendLayout();
			parent.SuspendLayout();
			parent.AcceptButton = this.NextButton;
			parent.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			parent.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			parent.CancelButton = this.AbortButton;
			parent.ClientSize = new System.Drawing.Size(477, 58);
			parent.Controls.Add(this.tableLayoutPanel1);
			parent.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			parent.Icon = ((System.Drawing.Icon)(global::MatlabInputForm.Properties.Resources.matlab_logo));
			parent.Name = "DataAPIForm";
			parent.Text = "MEX Function Wizard - Data API";
			this.tableLayoutPanel1.ResumeLayout(false);
			parent.ResumeLayout(false);
		}

		public new void HidePanel()
		{
			parent.Controls.Remove(this.tableLayoutPanel1);
		}

		private void InitFolderSelect()
		{
			matlab_registry_x64 = GetMatlabRootFromRegistry(Platform.X64);
			APIPanel.SetFolderSelectItems(this.FolderSelect, matlab_registry_x64);
			if(matlab_registry_x64 == null)
			{
				this.FolderSelect.SelectedIndex = -1;
			}
			else
			{
				this.FolderSelect.SelectedIndex = 0;
			}
		}

		private void FolderSelect_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ComboBox cbox = sender as ComboBox;
			if(cbox.SelectedItem.Equals(APIForm.BROWSE_STRING))
			{
				ShowBrowseDialog();
			}
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			ShowBrowseDialog();
		}

		private void ShowBrowseDialog()
		{
			if(this.FolderBrowser.ShowDialog() == DialogResult.OK)
			{
				this.FolderSelect.SelectedIndex = -1;
				this.FolderSelect.SelectedItem = this.FolderBrowser.SelectedPath;
				this.FolderSelect.Text = this.FolderBrowser.SelectedPath;
			}
		}

		private void AbortButton_Click(object sender, EventArgs e)
		{
			parent.Close();
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			ml_config.matlabroot = this.FolderSelect.Text;
			ml_config.GenerateImports();
			this.HidePanel();
			parent.import_panel.ShowPanel();
		}

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label MLLabel;
		private System.Windows.Forms.ComboBox FolderSelect;
		private System.Windows.Forms.Button AbortButton;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.ToolTip InterleavedTip;
	}
}
