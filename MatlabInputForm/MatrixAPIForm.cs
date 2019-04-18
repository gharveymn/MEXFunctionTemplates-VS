using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabInputForm
{

	public partial class MatrixAPIForm : Form
	{
		private MatlabConfiguration ml_config;
		private Language language;
		
		private static string BROWSE_STRING = "Browse...";
		private string[] matlab_registry_x64;
		private string[] matlab_registry_x86;

		public MatrixAPIForm(MatlabConfiguration ml_config)
		{
			this.ml_config = ml_config;
			InitializeComponent();
			InitFolderSelect();
		}

		private void InitFolderSelect()
		{
			matlab_registry_x64 = GetMatlabRootFromRegistry_x64();
			matlab_registry_x86 = GetMatlabRootFromRegistry_x86();
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
				cbox.SelectedIndex = -1;
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
				this.FolderSelect.Text = this.FolderBrowser.SelectedPath;
			}
		}

		private void AbortButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			object folder = this.FolderSelect.SelectedItem;
			string matlabroot;
			if(folder != null)
			{
				if(!folder.Equals(BROWSE_STRING))
				{
					matlabroot = folder.ToString();
				}
				else
				{
					matlabroot = null;
				}
			}
			else
			{
				matlabroot = this.FolderSelect.Text;
			}
			ml_config.matlabroot = matlabroot;
			ml_config.platform = this.PlatformRadio_32.Checked? Platform.X86 : Platform.X64;
			ml_config.array_dims = this.ArrayDimsRadio_Compatible.Checked
				? ArrayDimensions.COMPATIBLE
				: ArrayDimensions.LARGE;
			ml_config.complex_storage =
				this.ComplexRadio_Interleaved.Checked? ComplexStorage.INTERLEAVED : ComplexStorage.SEPARATED;
			ml_config.graphics_class =
				this.GraphicsRadio_double.Checked? GraphicsClass.DOUBLE : GraphicsClass.OBJECT;
			if(!ml_config.CheckMatlabExe())
			{
				MessageBox.Show(@"Could not locate matlab.exe from MATLAB root """ + matlabroot + @""".
Example path: C:\Program Files\MATLAB\R2019a", "Invalid MATLAB Root Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private string[] GetMatlabRootFromRegistry_x64()
		{
			using(RegistryKey lm_x64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				return GetMatlabRootFromRegistry(lm_x64);
			}
		}

		private string[] GetMatlabRootFromRegistry_x86()
		{
			using(RegistryKey lm_x86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
			{
				return GetMatlabRootFromRegistry(lm_x86);
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
				SetFolderSelectItems(matlab_registry_x64);
				if(this.FolderSelect.SelectedIndex != -1)
				{
					this.FolderSelect.SelectedIndex = 0;
				}
			}
		}

		private void PlatformRadio_32_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				SetFolderSelectItems(matlab_registry_x86);
				if(this.FolderSelect.SelectedIndex != -1)
				{
					this.FolderSelect.SelectedIndex = 0;
				}
			}
		}

		/*
		private void ArrayDimsRadio_Large_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ml_config.array_dims = ArrayDimensions.LARGE;
			}
		}

		private void ArrayDimsRadio_Compatible_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ml_config.array_dims = ArrayDimensions.COMPATIBLE;
			}
		}

		private void ComplexRadio_Separated_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ml_config.complex_storage = ComplexStorage.SEPARATED;
			}
		}

		private void ComplexRadio_Interleaved_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ml_config.complex_storage = ComplexStorage.INTERLEAVED;
			}
		}

		private void GraphicsRadio_object_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ml_config.graphics_class = GraphicsClass.OBJECT;
			}
		}

		private void GraphicsRadio_double_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton r = sender as RadioButton;
			if(r.Checked)
			{
				this.ml_config.graphics_class = GraphicsClass.DOUBLE;
			}
		}
		*/

	}

}
