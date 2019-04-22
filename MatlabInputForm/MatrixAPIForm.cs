using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabInputForm
{

	public partial class MatrixAPIForm : Form
	{

		public static MatlabConfiguration ml_config;
		public static string BROWSE_STRING = "Browse...";

		private string[] matlab_registry_x64;
		private string[] matlab_registry_x86;

		public MatrixAPIForm()
		{
			InitializeComponent();
			InitFolderSelect();
		}

		public void InitFolderSelect()
		{
			matlab_registry_x64 = GetMatlabRootFromRegistry(Platform.X64);
			matlab_registry_x86 = GetMatlabRootFromRegistry(Platform.X86);
			SetFolderSelectItems(matlab_registry_x64);
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
			if(cbox.SelectedItem.Equals(BROWSE_STRING))
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
			this.Close();
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			ml_config.matlabroot = this.FolderSelect.Text;
			ml_config.platform = this.PlatformRadio_32.Checked? Platform.X86 : Platform.X64;
			ml_config.language = this.LanguageRadio_CPP.Checked? Language.CPP : Language.C;
			ml_config.api = this.APIRadio_Data.Checked? API.DATA : API.MATRIX;
			ml_config.array_dims = this.ArrayDimsRadio_Compatible.Checked
				? ArrayDimensions.COMPATIBLE
				: ArrayDimensions.LARGE;
			ml_config.complex_storage =
				this.ComplexRadio_Interleaved.Checked? ComplexStorage.INTERLEAVED : ComplexStorage.SEPARATED;
			ml_config.graphics_class =
				this.GraphicsRadio_double.Checked? GraphicsClass.DOUBLE : GraphicsClass.OBJECT;
			ml_config.GenerateImports();
		}

		private void SetFolderSelectItems(string[] items)
		{
			this.FolderSelect.Items.Clear();
			if(items != null)
			{
				this.FolderSelect.Items.AddRange(items);
			}
			else
			{
				this.FolderSelect.Items.Add(BROWSE_STRING);
			}
		}

		private void PlatformRadio_64_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				bool had_idx = (this.FolderSelect.SelectedIndex != -1);
				SetFolderSelectItems(matlab_registry_x64);
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
				SetFolderSelectItems(matlab_registry_x86);
				if(had_idx)
				{
					this.FolderSelect.SelectedItem = this.FolderSelect.Items[0];
				}
			}
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

}
