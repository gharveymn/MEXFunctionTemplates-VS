using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabRootInputForm
{
	public partial class UserInputForm : Form
	{
		private static string PLATFORM_x64 = "64-bit";
		private static string PLATFORM_x86 = "32-bit";
		private static string BROWSE_STRING = "Browse...";
		private string[] matlab_registry_x64;
		private string[] matlab_registry_x86;

		public UserInputForm()
		{
			InitializeComponent();

			InitPlatformSelect();
			InitFolderSelect();
			InitBrowseButton();
			InitCancelButton();
			InitAcceptButton();
			InitFolderBrowser();
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
			SetFolderSelectItems(ref matlab_registry_x64);
			this.FolderSelect.SelectionChangeCommitted += new System.EventHandler(this.FolderSelect_SelectionChangeCommitted);
		}

		private void InitBrowseButton()
		{
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
		}

		private void InitCancelButton()
		{
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
		}

		private void InitAcceptButton()
		{
			this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
		}

		private void InitFolderBrowser()
		{
			// nothing
		}

		private void PlatformSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cbox = (ComboBox) sender;
			if (cbox.SelectedItem.Equals(PLATFORM_x64))
			{
				SetFolderSelectItems(ref matlab_registry_x64);
			}
			else
			{
				SetFolderSelectItems(ref matlab_registry_x86);
			}
		}

		private void FolderSelect_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ComboBox cbox = (ComboBox)sender;
			if (cbox.SelectedItem.Equals(BROWSE_STRING))
			{
				BrowseButton_Click(null, null);
			}
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			this.FolderBrowser.ShowDialog();
			this.FolderSelect.Text = this.FolderBrowser.SelectedPath;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AcceptButton_Click(object sender, EventArgs e)
		{
			object folder = this.FolderSelect.SelectedItem;
			if (folder != null)
			{
				if (!folder.Equals(BROWSE_STRING))
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

			if (this.PlatformSelect.SelectedItem.Equals(PLATFORM_x64))
			{
				platform = "x64";
			}
			else
			{
				platform = "Win32";
			}

			this.Close();
		}

		private string[] GetMatlabRootFromRegistry_x64()
		{
			using (RegistryKey lm_x64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				return GetMatlabRootFromRegistry(lm_x64);
			}
		}

		private string[] GetMatlabRootFromRegistry_x86()
		{
			using (RegistryKey lm_x86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
			{
				return GetMatlabRootFromRegistry(lm_x86);
			}
		}

		private string[] GetMatlabRootFromRegistry(RegistryKey lm)
		{

			using (RegistryKey MATLAB_key = lm.OpenSubKey(@"SOFTWARE\MathWorks\MATLAB"))
			{
				if (MATLAB_key == null || MATLAB_key.SubKeyCount == 0)
				{
					return null;
				}
				
				var versions = new List<Version>();
				foreach (string version_str in MATLAB_key.GetSubKeyNames())
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
				for (int i = 0; i < versions.Count; i++)
				{
					using (RegistryKey MATLABROOT_key = MATLAB_key.OpenSubKey(versions[i].ToString()))
					{
						object matlabroot_str = MATLABROOT_key?.GetValue("MATLABROOT");
						if (matlabroot_str == null)
						{
							return null;
						}
						ret[i] = matlabroot_str.ToString();
					}
				}
				return ret;
			}
			
		}

		private void SetFolderSelectItems(ref string[] items)
		{
			this.FolderSelect.Items.Clear();
			if (items != null)
			{
				this.FolderSelect.Items.AddRange(items);
				this.FolderSelect.SelectedIndex = 0;
			}
			else
			{
				this.FolderSelect.Items.Add(BROWSE_STRING);
				this.FolderSelect.SelectedIndex = -1;
			}
		}

		public static string matlabroot { get; set; }
		public static string platform { get; set; }
	}
}
