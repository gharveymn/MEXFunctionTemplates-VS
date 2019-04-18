using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabInputForm
{

	public enum Language
	{
		C,
		CPP,
		FORTRAN
	};

	public enum Platform
	{
		x64,
		x86
	}

	public partial class DataApiForm : Form
	{
		

		private Language language;
		
		public static string PLATFORM_x64 = "64-bit";
		public static string PLATFORM_x86 = "32-bit";
		private static string BROWSE_STRING = "Browse...";
		public static string MATRIX_API = "Matrix API";
		public static string DATA_API = "Data API";
		private string[] matlab_registry_x64;
		private string[] matlab_registry_x86;



		public DataApiForm(Language language)
		{
			InitializeComponent();

			this.language = language;

			InitAPISelect(language);
			InitPlatformSelect();
			InitFolderSelect();
			InitBrowseButton();
			InitAbortButton();
			InitOKButton();
			InitFolderBrowser();
			InitInterleavedCheck();
		}

		private void InitAPISelect(Language language)
		{
			this.APISelect.Items.Add(MATRIX_API);
			this.APISelect.Items.Add(DATA_API);
			this.APISelect.SelectedIndex = 0;
			this.APISelect.SelectedIndexChanged += new System.EventHandler(this.APISelect_SelectedIndexChanged);
			if(language != Language.CPP)
			{
				this.APISelect.Enabled = false;
			}
		}

		private void InitPlatformSelect()
		{
			this.PlatformSelect.Items.Add(PLATFORM_x64);
			this.PlatformSelect.Items.Add(PLATFORM_x86);
			this.PlatformSelect.SelectedIndex = 0;
			this.PlatformSelect.SelectedIndexChanged += new System.EventHandler(this.PlatformSelect_SelectedIndexChanged);
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
			this.FolderSelect.SelectionChangeCommitted += new System.EventHandler(this.FolderSelect_SelectionChangeCommitted);
		}

		private void InitBrowseButton()
		{
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
		}

		private void InitAbortButton()
		{
			this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
		}

		private void InitOKButton()
		{
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
		}

		private void InitFolderBrowser()
		{
			// nothing
		}

		private void InitInterleavedCheck()
		{
			// nothing
		}

		private void APISelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cbox = (ComboBox)sender;
			if(!cbox.SelectedItem.Equals(MATRIX_API))
			{
				this.InterleavedCheck.Checked = false;
				this.InterleavedCheck.Enabled = false;
			}
			else
			{
				this.InterleavedCheck.Enabled = true;
			}
		}

		private void PlatformSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cbox = (ComboBox)sender;
			if(cbox.SelectedItem.Equals(PLATFORM_x64))
			{
				SetFolderSelectItems(matlab_registry_x64);
			}
			else
			{
				SetFolderSelectItems(matlab_registry_x86);
			}
		}

		private void FolderSelect_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ComboBox cbox = (ComboBox)sender;
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
			if(!MatlabConfiguration.CheckMatlabExe(matlabroot))
			{
				MessageBox.Show(@"Could not locate matlab.exe from MATLAB root """ + matlabroot + @""".
Example path: C:\Program Files\MATLAB\R2019a", "Invalid MATLAB Root Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			DataApiForm.config = new MatlabConfiguration(matlabroot,
				this.PlatformSelect.SelectedItem.ToString(), 
				this.APISelect.SelectedText.ToString(), 
				this.language, 
				this.InterleavedCheck.Checked);
			this.Close();
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

		public static MatlabConfiguration config{get; set;}

	}
}
