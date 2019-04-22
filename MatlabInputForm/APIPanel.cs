using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabInputForm
{

	public interface IPanel
	{
		void ShowPanel();
		void HidePanel();
	}

	public class APIPanel : IPanel
	{

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label MLLabel;
		private System.Windows.Forms.ComboBox FolderSelect;
		private System.Windows.Forms.Button AbortButton;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.ToolTip ToolTip1;
		private System.Windows.Forms.GroupBox PlatformBox;
		private System.Windows.Forms.RadioButton PlatformRadio_32;
		private System.Windows.Forms.RadioButton PlatformRadio_64;
		private System.Windows.Forms.GroupBox ArrayDimsBox;
		private System.Windows.Forms.RadioButton ArrayDimsRadio_Compatible;
		private System.Windows.Forms.RadioButton ArrayDimsRadio_Large;
		private System.Windows.Forms.GroupBox ComplexBox;
		private System.Windows.Forms.RadioButton ComplexRadio_Interleaved;
		private System.Windows.Forms.RadioButton ComplexRadio_Separated;
		private System.Windows.Forms.GroupBox GraphicsBox;
		private System.Windows.Forms.RadioButton GraphicsRadio_double;
		private System.Windows.Forms.RadioButton GraphicsRadio_object;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.GroupBox LanguageBox;
		private System.Windows.Forms.RadioButton LanguageRadio_CPP;
		private System.Windows.Forms.RadioButton LanguageRadio_C;
		private System.Windows.Forms.GroupBox APIBox;
		private System.Windows.Forms.RadioButton APIRadio_Data;
		private System.Windows.Forms.RadioButton APIRadio_Matrix;

		private string[] matlab_registry_x64;
		private string[] matlab_registry_x86;

		protected APIForm parent;
		protected MatlabConfiguration ml_config;

		public APIPanel(APIForm parent, MatlabConfiguration ml_config)
		{
			this.parent = parent;
			this.ml_config = ml_config;
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
			this.ToolTip1 = new System.Windows.Forms.ToolTip();
			this.PlatformBox = new System.Windows.Forms.GroupBox();
			this.PlatformRadio_32 = new System.Windows.Forms.RadioButton();
			this.PlatformRadio_64 = new System.Windows.Forms.RadioButton();
			this.ArrayDimsBox = new System.Windows.Forms.GroupBox();
			this.ArrayDimsRadio_Compatible = new System.Windows.Forms.RadioButton();
			this.ArrayDimsRadio_Large = new System.Windows.Forms.RadioButton();
			this.ComplexBox = new System.Windows.Forms.GroupBox();
			this.ComplexRadio_Interleaved = new System.Windows.Forms.RadioButton();
			this.ComplexRadio_Separated = new System.Windows.Forms.RadioButton();
			this.GraphicsBox = new System.Windows.Forms.GroupBox();
			this.GraphicsRadio_double = new System.Windows.Forms.RadioButton();
			this.GraphicsRadio_object = new System.Windows.Forms.RadioButton();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.LanguageBox = new System.Windows.Forms.GroupBox();
			this.LanguageRadio_CPP = new System.Windows.Forms.RadioButton();
			this.LanguageRadio_C = new System.Windows.Forms.RadioButton();
			this.APIBox = new System.Windows.Forms.GroupBox();
			this.APIRadio_Data = new System.Windows.Forms.RadioButton();
			this.APIRadio_Matrix = new System.Windows.Forms.RadioButton();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.875F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.125F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
			this.tableLayoutPanel1.Controls.Add(this.MLLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.FolderSelect, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.BrowseButton, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.AbortButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.NextButton, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 65);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 58);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// MLLabel
			// 
			this.MLLabel.AutoSize = true;
			this.MLLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.MLLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MLLabel.Location = new System.Drawing.Point(4, 0);
			this.MLLabel.Name = "MLLabel";
			this.MLLabel.Size = new System.Drawing.Size(105, 29);
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
			this.FolderSelect.Size = new System.Drawing.Size(394, 21);
			this.FolderSelect.TabIndex = 3;
			this.FolderSelect.SelectionChangeCommitted += new System.EventHandler(this.FolderSelect_SelectionChangeCommitted);
			// 
			// BrowseButton
			// 
			this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseButton.Location = new System.Drawing.Point(515, 3);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(80, 23);
			this.BrowseButton.TabIndex = 4;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
			// 
			// AbortButton
			// 
			this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.AbortButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AbortButton.Location = new System.Drawing.Point(515, 32);
			this.AbortButton.Name = "AbortButton";
			this.AbortButton.Size = new System.Drawing.Size(80, 23);
			this.AbortButton.TabIndex = 5;
			this.AbortButton.Text = "Cancel";
			this.AbortButton.UseVisualStyleBackColor = true;
			this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
			// 
			// NextButton
			// 
			this.NextButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.NextButton.Location = new System.Drawing.Point(434, 32);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(75, 23);
			this.NextButton.TabIndex = 6;
			this.NextButton.Text = "Next";
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// FolderBrowser
			// 
			this.FolderBrowser.Description = "Locate the folder where MATLAB is installed. You can also find this by running \'m" +
    "atlabroot\' at the MATLAB prompt.";
			this.FolderBrowser.ShowNewFolderButton = false;
			// 
			// PlatformBox
			// 
			this.PlatformBox.Controls.Add(this.PlatformRadio_32);
			this.PlatformBox.Controls.Add(this.PlatformRadio_64);
			this.PlatformBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlatformBox.Location = new System.Drawing.Point(3, 3);
			this.PlatformBox.Name = "PlatformBox";
			this.PlatformBox.Size = new System.Drawing.Size(64, 59);
			this.PlatformBox.TabIndex = 3;
			this.PlatformBox.TabStop = false;
			this.PlatformBox.Text = "Platform";
			// 
			// PlatformRadio_32
			// 
			this.PlatformRadio_32.AutoSize = true;
			this.PlatformRadio_32.Location = new System.Drawing.Point(7, 36);
			this.PlatformRadio_32.Name = "PlatformRadio_32";
			this.PlatformRadio_32.Size = new System.Drawing.Size(55, 17);
			this.PlatformRadio_32.TabIndex = 1;
			this.PlatformRadio_32.Text = "32-bit";
			this.PlatformRadio_32.UseVisualStyleBackColor = true;
			this.PlatformRadio_32.CheckedChanged += new System.EventHandler(this.PlatformRadio_32_CheckedChanged);
			// 
			// PlatformRadio_64
			// 
			this.PlatformRadio_64.AutoSize = true;
			this.PlatformRadio_64.Checked = true;
			this.PlatformRadio_64.Location = new System.Drawing.Point(7, 18);
			this.PlatformRadio_64.Name = "PlatformRadio_64";
			this.PlatformRadio_64.Size = new System.Drawing.Size(55, 17);
			this.PlatformRadio_64.TabIndex = 0;
			this.PlatformRadio_64.TabStop = true;
			this.PlatformRadio_64.Text = "64-bit";
			this.PlatformRadio_64.UseVisualStyleBackColor = true;
			this.PlatformRadio_64.CheckedChanged += new System.EventHandler(this.PlatformRadio_64_CheckedChanged);
			// 
			// ArrayDimsBox
			// 
			this.ArrayDimsBox.Controls.Add(this.ArrayDimsRadio_Compatible);
			this.ArrayDimsBox.Controls.Add(this.ArrayDimsRadio_Large);
			this.ArrayDimsBox.Location = new System.Drawing.Point(251, 3);
			this.ArrayDimsBox.Name = "ArrayDimsBox";
			this.ArrayDimsBox.Size = new System.Drawing.Size(111, 59);
			this.ArrayDimsBox.TabIndex = 4;
			this.ArrayDimsBox.TabStop = false;
			this.ArrayDimsBox.Text = "Array Dimensions";
			// 
			// ArrayDimsRadio_Compatible
			// 
			this.ArrayDimsRadio_Compatible.AutoSize = true;
			this.ArrayDimsRadio_Compatible.Location = new System.Drawing.Point(7, 36);
			this.ArrayDimsRadio_Compatible.Name = "ArrayDimsRadio_Compatible";
			this.ArrayDimsRadio_Compatible.Size = new System.Drawing.Size(84, 17);
			this.ArrayDimsRadio_Compatible.TabIndex = 1;
			this.ArrayDimsRadio_Compatible.Text = "Compatible";
			this.ToolTip1.SetToolTip(this.ArrayDimsRadio_Compatible, "Support for variables with up to 2^31-1 elements");
			this.ArrayDimsRadio_Compatible.UseVisualStyleBackColor = true;
			this.ArrayDimsRadio_Compatible.CheckedChanged += new System.EventHandler(this.ArrayDimsRadio_Compatible_CheckedChanged);
			// 
			// ArrayDimsRadio_Large
			// 
			this.ArrayDimsRadio_Large.AutoSize = true;
			this.ArrayDimsRadio_Large.Checked = true;
			this.ArrayDimsRadio_Large.Location = new System.Drawing.Point(7, 18);
			this.ArrayDimsRadio_Large.Name = "ArrayDimsRadio_Large";
			this.ArrayDimsRadio_Large.Size = new System.Drawing.Size(53, 17);
			this.ArrayDimsRadio_Large.TabIndex = 0;
			this.ArrayDimsRadio_Large.TabStop = true;
			this.ArrayDimsRadio_Large.Text = "Large";
			this.ToolTip1.SetToolTip(this.ArrayDimsRadio_Large, "Support for variables with up to 2^48-1 elements");
			this.ArrayDimsRadio_Large.UseVisualStyleBackColor = true;
			this.ArrayDimsRadio_Large.CheckedChanged += new System.EventHandler(this.ArrayDimsRadio_Large_CheckedChanged);
			// 
			// ComplexBox
			// 
			this.ComplexBox.Controls.Add(this.ComplexRadio_Interleaved);
			this.ComplexBox.Controls.Add(this.ComplexRadio_Separated);
			this.ComplexBox.Location = new System.Drawing.Point(368, 3);
			this.ComplexBox.Name = "ComplexBox";
			this.ComplexBox.Size = new System.Drawing.Size(114, 59);
			this.ComplexBox.TabIndex = 5;
			this.ComplexBox.TabStop = false;
			this.ComplexBox.Text = "Complex Numbers";
			// 
			// ComplexRadio_Interleaved
			// 
			this.ComplexRadio_Interleaved.AutoSize = true;
			this.ComplexRadio_Interleaved.Location = new System.Drawing.Point(6, 36);
			this.ComplexRadio_Interleaved.Name = "ComplexRadio_Interleaved";
			this.ComplexRadio_Interleaved.Size = new System.Drawing.Size(82, 17);
			this.ComplexRadio_Interleaved.TabIndex = 1;
			this.ComplexRadio_Interleaved.Text = "Interleaved";
			this.ToolTip1.SetToolTip(this.ComplexRadio_Interleaved, "Store real and imaginary parts of complex numbers side-by-side in memory");
			this.ComplexRadio_Interleaved.UseVisualStyleBackColor = true;
			this.ComplexRadio_Interleaved.CheckedChanged += new System.EventHandler(this.ComplexRadio_Interleaved_CheckedChanged);
			// 
			// ComplexRadio_Separated
			// 
			this.ComplexRadio_Separated.AutoSize = true;
			this.ComplexRadio_Separated.Checked = true;
			this.ComplexRadio_Separated.Location = new System.Drawing.Point(6, 18);
			this.ComplexRadio_Separated.Name = "ComplexRadio_Separated";
			this.ComplexRadio_Separated.Size = new System.Drawing.Size(77, 17);
			this.ComplexRadio_Separated.TabIndex = 0;
			this.ComplexRadio_Separated.TabStop = true;
			this.ComplexRadio_Separated.Text = "Separated";
			this.ToolTip1.SetToolTip(this.ComplexRadio_Separated, "Store real and imaginary parts of complex numbers separately");
			this.ComplexRadio_Separated.UseVisualStyleBackColor = true;
			this.ComplexRadio_Separated.CheckedChanged += new System.EventHandler(this.ComplexRadio_Separated_CheckedChanged);
			// 
			// GraphicsBox
			// 
			this.GraphicsBox.Controls.Add(this.GraphicsRadio_double);
			this.GraphicsBox.Controls.Add(this.GraphicsRadio_object);
			this.GraphicsBox.Location = new System.Drawing.Point(488, 3);
			this.GraphicsBox.Name = "GraphicsBox";
			this.GraphicsBox.Size = new System.Drawing.Size(102, 59);
			this.GraphicsBox.TabIndex = 6;
			this.GraphicsBox.TabStop = false;
			this.GraphicsBox.Text = "Graphics Class";
			// 
			// GraphicsRadio_double
			// 
			this.GraphicsRadio_double.AutoSize = true;
			this.GraphicsRadio_double.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GraphicsRadio_double.Location = new System.Drawing.Point(7, 37);
			this.GraphicsRadio_double.Name = "GraphicsRadio_double";
			this.GraphicsRadio_double.Size = new System.Drawing.Size(61, 17);
			this.GraphicsRadio_double.TabIndex = 1;
			this.GraphicsRadio_double.Text = "double";
			this.ToolTip1.SetToolTip(this.GraphicsRadio_double, "Use graphics object handles with class \'double\'");
			this.GraphicsRadio_double.UseVisualStyleBackColor = true;
			this.GraphicsRadio_double.CheckedChanged += new System.EventHandler(this.GraphicsRadio_double_CheckedChanged);
			// 
			// GraphicsRadio_object
			// 
			this.GraphicsRadio_object.AutoSize = true;
			this.GraphicsRadio_object.Checked = true;
			this.GraphicsRadio_object.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GraphicsRadio_object.Location = new System.Drawing.Point(7, 18);
			this.GraphicsRadio_object.Name = "GraphicsRadio_object";
			this.GraphicsRadio_object.Size = new System.Drawing.Size(61, 17);
			this.GraphicsRadio_object.TabIndex = 0;
			this.GraphicsRadio_object.TabStop = true;
			this.GraphicsRadio_object.Text = "object";
			this.ToolTip1.SetToolTip(this.GraphicsRadio_object, "Use graphics object handles with class \'object \'");
			this.GraphicsRadio_object.UseVisualStyleBackColor = true;
			this.GraphicsRadio_object.CheckedChanged += new System.EventHandler(this.GraphicsRadio_object_CheckedChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.PlatformBox);
			this.flowLayoutPanel1.Controls.Add(this.LanguageBox);
			this.flowLayoutPanel1.Controls.Add(this.APIBox);
			this.flowLayoutPanel1.Controls.Add(this.ArrayDimsBox);
			this.flowLayoutPanel1.Controls.Add(this.ComplexBox);
			this.flowLayoutPanel1.Controls.Add(this.GraphicsBox);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(598, 65);
			this.flowLayoutPanel1.TabIndex = 7;
			// 
			// LanguageBox
			// 
			this.LanguageBox.Controls.Add(this.LanguageRadio_CPP);
			this.LanguageBox.Controls.Add(this.LanguageRadio_C);
			this.LanguageBox.Location = new System.Drawing.Point(73, 3);
			this.LanguageBox.Name = "LanguageBox";
			this.LanguageBox.Size = new System.Drawing.Size(80, 59);
			this.LanguageBox.TabIndex = 7;
			this.LanguageBox.TabStop = false;
			this.LanguageBox.Text = "Language";
			// 
			// LanguageRadio_CPP
			// 
			this.LanguageRadio_CPP.AutoSize = true;
			this.LanguageRadio_CPP.Checked = true;
			this.LanguageRadio_CPP.Location = new System.Drawing.Point(6, 18);
			this.LanguageRadio_CPP.Name = "LanguageRadio_CPP";
			this.LanguageRadio_CPP.Size = new System.Drawing.Size(48, 17);
			this.LanguageRadio_CPP.TabIndex = 1;
			this.LanguageRadio_CPP.TabStop = true;
			this.LanguageRadio_CPP.Text = "C++";
			this.LanguageRadio_CPP.UseVisualStyleBackColor = true;
			this.LanguageRadio_CPP.CheckedChanged += new System.EventHandler(this.LanguageRadio_CPP_CheckedChanged);
			// 
			// LanguageRadio_C
			// 
			this.LanguageRadio_C.AutoSize = true;
			this.LanguageRadio_C.Location = new System.Drawing.Point(6, 36);
			this.LanguageRadio_C.Name = "LanguageRadio_C";
			this.LanguageRadio_C.Size = new System.Drawing.Size(32, 17);
			this.LanguageRadio_C.TabIndex = 0;
			this.LanguageRadio_C.Text = "C";
			this.LanguageRadio_C.UseVisualStyleBackColor = true;
			this.LanguageRadio_C.CheckedChanged += new System.EventHandler(this.LanguageRadio_C_CheckedChanged);
			// 
			// APIBox
			// 
			this.APIBox.Controls.Add(this.APIRadio_Data);
			this.APIBox.Controls.Add(this.APIRadio_Matrix);
			this.APIBox.Location = new System.Drawing.Point(159, 3);
			this.APIBox.Name = "APIBox";
			this.APIBox.Size = new System.Drawing.Size(86, 59);
			this.APIBox.TabIndex = 8;
			this.APIBox.TabStop = false;
			this.APIBox.Text = "API";
			// 
			// APIRadio_Data
			// 
			this.APIRadio_Data.AutoSize = true;
			this.APIRadio_Data.Location = new System.Drawing.Point(7, 36);
			this.APIRadio_Data.Name = "APIRadio_Data";
			this.APIRadio_Data.Size = new System.Drawing.Size(68, 17);
			this.APIRadio_Data.TabIndex = 1;
			this.APIRadio_Data.Text = "Data API";
			this.APIRadio_Data.UseVisualStyleBackColor = true;
			this.APIRadio_Data.CheckedChanged += new System.EventHandler(this.APIRadio_Data_CheckedChanged);
			// 
			// APIRadio_Matrix
			// 
			this.APIRadio_Matrix.AutoSize = true;
			this.APIRadio_Matrix.Checked = true;
			this.APIRadio_Matrix.Location = new System.Drawing.Point(7, 18);
			this.APIRadio_Matrix.Name = "APIRadio_Matrix";
			this.APIRadio_Matrix.Size = new System.Drawing.Size(76, 17);
			this.APIRadio_Matrix.TabIndex = 0;
			this.APIRadio_Matrix.TabStop = true;
			this.APIRadio_Matrix.Text = "Matrix API";
			this.APIRadio_Matrix.UseVisualStyleBackColor = true;
			this.APIRadio_Matrix.CheckedChanged += new System.EventHandler(this.APIRadio_Matrix_CheckedChanged);
		}

		public void ShowPanel()
		{
			this.tableLayoutPanel1.SuspendLayout();
			this.PlatformBox.SuspendLayout();
			this.ArrayDimsBox.SuspendLayout();
			this.ComplexBox.SuspendLayout();
			this.GraphicsBox.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.LanguageBox.SuspendLayout();
			this.APIBox.SuspendLayout();
			parent.SuspendLayout();
			parent.AcceptButton = this.NextButton;
			parent.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			parent.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			parent.CancelButton = this.AbortButton;
			parent.ClientSize = new System.Drawing.Size(598, 123);
			parent.Controls.Add(this.flowLayoutPanel1);
			parent.Controls.Add(this.tableLayoutPanel1);
			parent.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			parent.Icon = global::MatlabInputForm.Properties.Resources.matlab_logo;
			parent.Name = "APIForm";
			parent.Text = "MEX Function Wizard";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.PlatformBox.ResumeLayout(false);
			this.PlatformBox.PerformLayout();
			this.ArrayDimsBox.ResumeLayout(false);
			this.ArrayDimsBox.PerformLayout();
			this.ComplexBox.ResumeLayout(false);
			this.ComplexBox.PerformLayout();
			this.GraphicsBox.ResumeLayout(false);
			this.GraphicsBox.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.LanguageBox.ResumeLayout(false);
			this.LanguageBox.PerformLayout();
			this.APIBox.ResumeLayout(false);
			this.APIBox.PerformLayout();
			parent.ResumeLayout(false);
		}

		public void HidePanel()
		{
			parent.Controls.Remove(this.flowLayoutPanel1);
			parent.Controls.Remove(this.tableLayoutPanel1);
		}

		protected string[] GetMatlabRootFromRegistry(Platform platform)
		{
			if(platform == Platform.X64)
			{
				using(RegistryKey lm_x64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
				{
					return GetMatlabRootFromRegistry(lm_x64);
				}
			}
			else
			{
				using(RegistryKey lm_x86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
				{
					return GetMatlabRootFromRegistry(lm_x86);
				}
			}
		}

		private string[] GetMatlabRootFromRegistry(RegistryKey lm)
		{

			using(RegistryKey MATLAB_key = lm.OpenSubKey(@"SOFTWARE\MathWorks\MATLAB"))
			{
				if(MATLAB_key == null || MATLAB_key.SubKeyCount == 0)
				{
					return null;
				}

				var versions = new List<Version>();
				foreach(string version_str in MATLAB_key.GetSubKeyNames())
				{
					try
					{
						versions.Add(new Version(version_str));
					}
					catch
					{
						return null;
					}
				}
				versions.Sort();
				versions.Reverse();
				string[] ret = new string[versions.Count];
				for(int i = 0; i < versions.Count; i++)
				{
					using(RegistryKey MATLABROOT_key = MATLAB_key.OpenSubKey(versions[i].ToString()))
					{
						object matlabroot_str = MATLABROOT_key?.GetValue("MATLABROOT");
						if(matlabroot_str == null)
						{
							return null;
						}
						ret[i] = matlabroot_str.ToString();
						if(ret[i].EndsWith(@"\"))
						{
							ret[i] = ret[i].Substring(0, ret[i].Length - 1);
						}
					}
				}
				return ret;
			}
		}

		protected static void SetFolderSelectItems(ComboBox folder_select, string[] items)
		{
			folder_select.Items.Clear();
			if(items != null)
			{
				folder_select.Items.AddRange(items);
			}
			else
			{
				folder_select.Items.Add(APIForm.BROWSE_STRING);
			}
		}

		public void InitFolderSelect()
		{
			matlab_registry_x64 = GetMatlabRootFromRegistry(Platform.X64);
			matlab_registry_x86 = GetMatlabRootFromRegistry(Platform.X86);
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
			ml_config.platform = this.PlatformRadio_32.Checked ? Platform.X86 : Platform.X64;
			ml_config.language = this.LanguageRadio_CPP.Checked ? Language.CPP : Language.C;
			ml_config.api = this.APIRadio_Data.Checked ? API.DATA : API.MATRIX;
			ml_config.array_dims = this.ArrayDimsRadio_Compatible.Checked
				? ArrayDimensions.COMPATIBLE
				: ArrayDimensions.LARGE;
			ml_config.complex_storage =
				this.ComplexRadio_Interleaved.Checked ? ComplexStorage.INTERLEAVED : ComplexStorage.SEPARATED;
			ml_config.graphics_class =
				this.GraphicsRadio_double.Checked ? GraphicsClass.DOUBLE : GraphicsClass.OBJECT;
			ml_config.GenerateImports();
			this.HidePanel();
			parent.import_panel.ShowPanel();
		}

		/* note: these only affect boxes to the right */

		private void PlatformRadio_64_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				bool had_idx = (this.FolderSelect.SelectedIndex != -1);
				SetFolderSelectItems(this.FolderSelect, matlab_registry_x64);
				if(had_idx)
				{
					this.FolderSelect.SelectedItem = this.FolderSelect.Items[0];
				}
				this.APIRadio_Data.Enabled = true;
				this.ArrayDimsRadio_Large.Enabled = true;
				this.ComplexRadio_Interleaved.Enabled = true;
			}
		}

		private void PlatformRadio_32_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				bool had_idx = (this.FolderSelect.SelectedIndex != -1);
				SetFolderSelectItems(this.FolderSelect, matlab_registry_x86);
				if(had_idx)
				{
					this.FolderSelect.SelectedItem = this.FolderSelect.Items[0];
				}
				this.APIRadio_Matrix.Checked = true;
				this.APIRadio_Data.Enabled = false;

				this.ArrayDimsRadio_Compatible.Checked = true;
				this.ArrayDimsRadio_Large.Enabled = false;

				this.ComplexRadio_Separated.Checked = true;
				this.ComplexRadio_Interleaved.Enabled = false;
			}
		}
		private void LanguageRadio_CPP_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				if(this.PlatformRadio_64.Checked)
				{
					this.APIRadio_Data.Enabled = true;
				}
			}
		}

		private void LanguageRadio_C_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.APIRadio_Matrix.Checked = true;
				this.APIRadio_Data.Enabled = false;
			}
		}

		private void APIRadio_Matrix_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ArrayDimsRadio_Large.Enabled = true;
				this.ArrayDimsRadio_Compatible.Enabled = true;
				this.ArrayDimsBox.Visible = true;

				this.ComplexRadio_Separated.Enabled = true;
				this.ComplexRadio_Interleaved.Enabled = true;
				this.ComplexBox.Visible = true;

				this.GraphicsRadio_object.Enabled = true;
				this.GraphicsRadio_double.Enabled = true;
				this.GraphicsBox.Visible = true;
			}
		}

		private void APIRadio_Data_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ArrayDimsRadio_Large.Enabled = false;
				this.ArrayDimsRadio_Compatible.Enabled = false;
				this.ArrayDimsBox.Visible = false;

				this.ComplexRadio_Separated.Enabled = false;
				this.ComplexRadio_Interleaved.Enabled = false;
				this.ComplexBox.Visible = false;

				this.GraphicsRadio_object.Enabled = false;
				this.GraphicsRadio_double.Enabled = false;
				this.GraphicsBox.Visible = false;

			}
		}

		private void ArrayDimsRadio_Large_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				if(this.PlatformRadio_64.Checked)
				{
					this.ComplexRadio_Interleaved.Enabled = true;
				}
			}
		}

		private void ArrayDimsRadio_Compatible_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ComplexRadio_Separated.Checked = true;
				this.ComplexRadio_Interleaved.Enabled = false;
			}
		}

		private void ComplexRadio_Interleaved_CheckedChanged(object sender, EventArgs e)
		{
			// nothing
		}

		private void ComplexRadio_Separated_CheckedChanged(object sender, EventArgs e)
		{
			// nothing
		}

		private void GraphicsRadio_object_CheckedChanged(object sender, EventArgs e)
		{
			// nothing
		}

		private void GraphicsRadio_double_CheckedChanged(object sender, EventArgs e)
		{
			// nothing
		}

	}

	public class ToolTip : System.Windows.Forms.ToolTip
	{
		public ToolTip() : base() { }

		public ToolTip(System.ComponentModel.IContainer components) : base(components) { }

		public new void SetToolTip(System.Windows.Forms.Control ctl, string caption)
		{
			ctl.MouseEnter -= new System.EventHandler(toolTip_MouseEnter);
			base.SetToolTip(ctl, caption);
			if(caption != string.Empty)
			{
				ctl.MouseEnter += new System.EventHandler(toolTip_MouseEnter);
			}
		}

		private void toolTip_MouseEnter(object sender, EventArgs e)
		{
			this.Active = false;
			this.Active = true;
		}
	}

}
