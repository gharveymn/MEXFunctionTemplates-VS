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
		private System.Windows.Forms.ToolTip InterleavedTip;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton PlatformRadio_32;
		private System.Windows.Forms.RadioButton PlatformRadio_64;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton ArrayDimsRadio_Compatible;
		private System.Windows.Forms.RadioButton ArrayDimsRadio_Large;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton ComplexRadio_Interleaved;
		private System.Windows.Forms.RadioButton ComplexRadio_Separated;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton GraphicsRadio_double;
		private System.Windows.Forms.RadioButton GraphicsRadio_object;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RadioButton LanguageRadio_CPP;
		private System.Windows.Forms.RadioButton LanguageRadio_C;
		private System.Windows.Forms.GroupBox groupBox6;
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
			this.InterleavedTip = new System.Windows.Forms.ToolTip();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PlatformRadio_32 = new System.Windows.Forms.RadioButton();
			this.PlatformRadio_64 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ArrayDimsRadio_Compatible = new System.Windows.Forms.RadioButton();
			this.ArrayDimsRadio_Large = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ComplexRadio_Interleaved = new System.Windows.Forms.RadioButton();
			this.ComplexRadio_Separated = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.GraphicsRadio_double = new System.Windows.Forms.RadioButton();
			this.GraphicsRadio_object = new System.Windows.Forms.RadioButton();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.LanguageRadio_C = new System.Windows.Forms.RadioButton();
			this.LanguageRadio_CPP = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.APIRadio_Matrix = new System.Windows.Forms.RadioButton();
			this.APIRadio_Data = new System.Windows.Forms.RadioButton();
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
			this.MLLabel.Location = new System.Drawing.Point(39, 0);
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
			this.FolderSelect.Location = new System.Drawing.Point(150, 3);
			this.FolderSelect.Name = "FolderSelect";
			this.FolderSelect.Size = new System.Drawing.Size(362, 21);
			this.FolderSelect.TabIndex = 3;
			this.FolderSelect.SelectionChangeCommitted += new System.EventHandler(this.FolderSelect_SelectionChangeCommitted);
			// 
			// BrowseButton
			// 
			this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseButton.Location = new System.Drawing.Point(518, 3);
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
			this.AbortButton.Location = new System.Drawing.Point(518, 32);
			this.AbortButton.Name = "AbortButton";
			this.AbortButton.Size = new System.Drawing.Size(77, 23);
			this.AbortButton.TabIndex = 5;
			this.AbortButton.Text = "Cancel";
			this.AbortButton.UseVisualStyleBackColor = true;
			this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
			// 
			// NextButton
			// 
			this.NextButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.NextButton.Location = new System.Drawing.Point(437, 32);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PlatformRadio_32);
			this.groupBox1.Controls.Add(this.PlatformRadio_64);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(64, 59);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Platform";
			// 
			// PlatformRadio_32
			// 
			this.PlatformRadio_32.AutoSize = true;
			this.PlatformRadio_32.Location = new System.Drawing.Point(3, 36);
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
			this.PlatformRadio_64.Dock = System.Windows.Forms.DockStyle.Top;
			this.PlatformRadio_64.Location = new System.Drawing.Point(3, 18);
			this.PlatformRadio_64.Name = "PlatformRadio_64";
			this.PlatformRadio_64.Size = new System.Drawing.Size(58, 17);
			this.PlatformRadio_64.TabIndex = 0;
			this.PlatformRadio_64.TabStop = true;
			this.PlatformRadio_64.Text = "64-bit";
			this.PlatformRadio_64.UseVisualStyleBackColor = true;
			this.PlatformRadio_64.CheckedChanged += new System.EventHandler(this.PlatformRadio_64_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ArrayDimsRadio_Compatible);
			this.groupBox2.Controls.Add(this.ArrayDimsRadio_Large);
			this.groupBox2.Location = new System.Drawing.Point(251, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(111, 59);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Array Dimensions";
			// 
			// ArrayDimsRadio_Compatible
			// 
			this.ArrayDimsRadio_Compatible.AutoSize = true;
			this.ArrayDimsRadio_Compatible.Location = new System.Drawing.Point(3, 36);
			this.ArrayDimsRadio_Compatible.Name = "ArrayDimsRadio_Compatible";
			this.ArrayDimsRadio_Compatible.Size = new System.Drawing.Size(84, 17);
			this.ArrayDimsRadio_Compatible.TabIndex = 1;
			this.ArrayDimsRadio_Compatible.Text = "Compatible";
			this.ArrayDimsRadio_Compatible.UseVisualStyleBackColor = true;
			// 
			// ArrayDimsRadio_Large
			// 
			this.ArrayDimsRadio_Large.AutoSize = true;
			this.ArrayDimsRadio_Large.Checked = true;
			this.ArrayDimsRadio_Large.Dock = System.Windows.Forms.DockStyle.Top;
			this.ArrayDimsRadio_Large.Location = new System.Drawing.Point(3, 18);
			this.ArrayDimsRadio_Large.Name = "ArrayDimsRadio_Large";
			this.ArrayDimsRadio_Large.Size = new System.Drawing.Size(105, 17);
			this.ArrayDimsRadio_Large.TabIndex = 0;
			this.ArrayDimsRadio_Large.TabStop = true;
			this.ArrayDimsRadio_Large.Text = "Large";
			this.ArrayDimsRadio_Large.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ComplexRadio_Interleaved);
			this.groupBox3.Controls.Add(this.ComplexRadio_Separated);
			this.groupBox3.Location = new System.Drawing.Point(368, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(114, 59);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Complex Numbers";
			// 
			// ComplexRadio_Interleaved
			// 
			this.ComplexRadio_Interleaved.AutoSize = true;
			this.ComplexRadio_Interleaved.Location = new System.Drawing.Point(3, 36);
			this.ComplexRadio_Interleaved.Name = "ComplexRadio_Interleaved";
			this.ComplexRadio_Interleaved.Size = new System.Drawing.Size(82, 17);
			this.ComplexRadio_Interleaved.TabIndex = 1;
			this.ComplexRadio_Interleaved.Text = "Interleaved";
			this.ComplexRadio_Interleaved.UseVisualStyleBackColor = true;
			// 
			// ComplexRadio_Separated
			// 
			this.ComplexRadio_Separated.AutoSize = true;
			this.ComplexRadio_Separated.Checked = true;
			this.ComplexRadio_Separated.Dock = System.Windows.Forms.DockStyle.Top;
			this.ComplexRadio_Separated.Location = new System.Drawing.Point(3, 18);
			this.ComplexRadio_Separated.Name = "ComplexRadio_Separated";
			this.ComplexRadio_Separated.Size = new System.Drawing.Size(108, 17);
			this.ComplexRadio_Separated.TabIndex = 0;
			this.ComplexRadio_Separated.TabStop = true;
			this.ComplexRadio_Separated.Text = "Separated";
			this.ComplexRadio_Separated.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.GraphicsRadio_double);
			this.groupBox4.Controls.Add(this.GraphicsRadio_object);
			this.groupBox4.Location = new System.Drawing.Point(488, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(102, 59);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Graphics Class";
			// 
			// GraphicsRadio_double
			// 
			this.GraphicsRadio_double.AutoSize = true;
			this.GraphicsRadio_double.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GraphicsRadio_double.Location = new System.Drawing.Point(3, 36);
			this.GraphicsRadio_double.Name = "GraphicsRadio_double";
			this.GraphicsRadio_double.Size = new System.Drawing.Size(61, 17);
			this.GraphicsRadio_double.TabIndex = 1;
			this.GraphicsRadio_double.Text = "double";
			this.GraphicsRadio_double.UseVisualStyleBackColor = true;
			// 
			// GraphicsRadio_object
			// 
			this.GraphicsRadio_object.AutoSize = true;
			this.GraphicsRadio_object.Checked = true;
			this.GraphicsRadio_object.Dock = System.Windows.Forms.DockStyle.Top;
			this.GraphicsRadio_object.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GraphicsRadio_object.Location = new System.Drawing.Point(3, 18);
			this.GraphicsRadio_object.Name = "GraphicsRadio_object";
			this.GraphicsRadio_object.Size = new System.Drawing.Size(96, 17);
			this.GraphicsRadio_object.TabIndex = 0;
			this.GraphicsRadio_object.TabStop = true;
			this.GraphicsRadio_object.Text = "object";
			this.GraphicsRadio_object.UseVisualStyleBackColor = true;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.groupBox1);
			this.flowLayoutPanel1.Controls.Add(this.groupBox5);
			this.flowLayoutPanel1.Controls.Add(this.groupBox6);
			this.flowLayoutPanel1.Controls.Add(this.groupBox2);
			this.flowLayoutPanel1.Controls.Add(this.groupBox3);
			this.flowLayoutPanel1.Controls.Add(this.groupBox4);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(598, 65);
			this.flowLayoutPanel1.TabIndex = 7;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.LanguageRadio_CPP);
			this.groupBox5.Controls.Add(this.LanguageRadio_C);
			this.groupBox5.Location = new System.Drawing.Point(73, 3);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(80, 59);
			this.groupBox5.TabIndex = 7;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Language";
			// 
			// LanguageRadio_C
			// 
			this.LanguageRadio_C.AutoSize = true;
			this.LanguageRadio_C.Checked = true;
			this.LanguageRadio_C.Location = new System.Drawing.Point(7, 18);
			this.LanguageRadio_C.Name = "LanguageRadio_C";
			this.LanguageRadio_C.Size = new System.Drawing.Size(32, 17);
			this.LanguageRadio_C.TabIndex = 0;
			this.LanguageRadio_C.TabStop = true;
			this.LanguageRadio_C.Text = "C";
			this.LanguageRadio_C.UseVisualStyleBackColor = true;
			this.LanguageRadio_C.CheckedChanged += new System.EventHandler(this.LanguageRadio_C_CheckedChanged);
			// 
			// LanguageRadio_CPP
			// 
			this.LanguageRadio_CPP.AutoSize = true;
			this.LanguageRadio_CPP.Location = new System.Drawing.Point(7, 36);
			this.LanguageRadio_CPP.Name = "LanguageRadio_CPP";
			this.LanguageRadio_CPP.Size = new System.Drawing.Size(48, 17);
			this.LanguageRadio_CPP.TabIndex = 1;
			this.LanguageRadio_CPP.Text = "C++";
			this.LanguageRadio_CPP.UseVisualStyleBackColor = true;
			this.LanguageRadio_CPP.CheckedChanged += new System.EventHandler(this.LanguageRadio_CPP_CheckedChanged);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.APIRadio_Data);
			this.groupBox6.Controls.Add(this.APIRadio_Matrix);
			this.groupBox6.Location = new System.Drawing.Point(159, 3);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(86, 59);
			this.groupBox6.TabIndex = 8;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "API";
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
			// 
			// APIRadio_Data
			// 
			this.APIRadio_Data.AutoSize = true;
			this.APIRadio_Data.Enabled = false;
			this.APIRadio_Data.Location = new System.Drawing.Point(7, 36);
			this.APIRadio_Data.Name = "APIRadio_Data";
			this.APIRadio_Data.Size = new System.Drawing.Size(68, 17);
			this.APIRadio_Data.TabIndex = 1;
			this.APIRadio_Data.Text = "Data API";
			this.APIRadio_Data.UseVisualStyleBackColor = true;
			this.APIRadio_Data.CheckedChanged += new System.EventHandler(this.APIRadio_Data_CheckedChanged);
		}

		public void ShowPanel()
		{
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
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
			parent.Text = "MEX Function Wizard - API Selection";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
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

		private void PlatformRadio_64_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				bool had_idx = (this.FolderSelect.SelectedIndex != -1);
				APIPanel.SetFolderSelectItems(this.FolderSelect, matlab_registry_x64);
				if(had_idx)
				{
					this.FolderSelect.SelectedItem = this.FolderSelect.Items[0];
				}
			}
		}

		private void PlatformRadio_32_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				bool had_idx = (this.FolderSelect.SelectedIndex != -1);
				APIPanel.SetFolderSelectItems(this.FolderSelect, matlab_registry_x86);
				if(had_idx)
				{
					this.FolderSelect.SelectedItem = this.FolderSelect.Items[0];
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

		private void LanguageRadio_CPP_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.APIRadio_Data.Enabled = true;
			}
		}

		private void APIRadio_Data_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ArrayDimsRadio_Large.Enabled = false;
				this.ArrayDimsRadio_Compatible.Enabled = false;
				this.ComplexRadio_Separated.Enabled = false;
				this.ComplexRadio_Interleaved.Enabled = false;
				this.GraphicsRadio_object.Enabled = false;
				this.GraphicsRadio_double.Enabled = false;
			}
		}

		private void APIRadio_Matrix_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ArrayDimsRadio_Large.Enabled = true;
				this.ArrayDimsRadio_Compatible.Enabled = true;
				this.ComplexRadio_Separated.Enabled = true;
				this.ComplexRadio_Interleaved.Enabled = true;
				this.GraphicsRadio_object.Enabled = true;
				this.GraphicsRadio_double.Enabled = true;
			}
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
