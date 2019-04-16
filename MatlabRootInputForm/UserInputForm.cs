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

namespace MatlabRootInputForm
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

	public partial class UserInputForm : Form
	{
		

		private Language language;
		
		public static string PLATFORM_x64 = "64-bit";
		public static string PLATFORM_x86 = "32-bit";
		private static string BROWSE_STRING = "Browse...";
		public static string MATRIX_API = "Matrix API";
		public static string DATA_API = "Data API";
		private string[] matlab_registry_x64;
		private string[] matlab_registry_x86;



		public UserInputForm(Language language)
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
				throw new MatlabNotFoundException(@"Could not locate matlab.exe. An example path: C:\Program Files\MATLAB\R2019a");
			}
			
			UserInputForm.config = new MatlabConfiguration(matlabroot,
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

	public class MatlabConfiguration
	{

		private string matlabroot;
		private Platform platform;
		private Language language;
		private string api;
		private bool is_interleaved;

		public MatlabConfiguration(string matlabroot, string platform_str, string api, Language language, bool is_interleaved)
		{
			this.matlabroot = matlabroot;
			if(platform_str.Equals(UserInputForm.PLATFORM_x64))
			{
				this.platform = Platform.x64;
			}
			else
			{
				this.platform = Platform.x86;
			}
			this.language = language;
			this.api = api;
			this.is_interleaved = is_interleaved;
		}
	
		public static bool CheckMatlabExe(string matlabroot)
		{
			return (File.Exists(matlabroot + @"\bin\matlab.exe"));
		}

		public string GetMatlabRoot()
		{
			return this.matlabroot + @"\";
		}

		public string GetVersionName()
		{
			// checks if version.txt exists and fetches its contents
			string verfile_name = matlabroot + @"\bin\util\mex\version.txt";
			if(File.Exists(verfile_name))
			{
				return File.ReadAllText(verfile_name);
			}
			else
			{
				return null;
			}
		}

		public string GetIncludePath()
		{
			return @"$(MatlabRoot)extern\include;$(MatlabRoot)simulink\include";
		}

		public string GetLibraryPath()
		{
			if(this.platform.Equals(UserInputForm.PLATFORM_x64))
			{
				return @"$(MatlabRoot)extern\lib\win64\microsoft";
			}
			else
			{
				return @"$(MatlabRoot)extern\lib\win32\microsoft";
			}
		}

		public string GetDependencies()
		{
			string depends = "libmx.lib;libmex.lib;libmat.lib";
			if(this.language == Language.CPP)
			{
				depends += ";libMatlabDataArray.lib;libMatlabEngine.lib";
			}
			return depends;
		}

		public string GetVersionSource()
		{
			string versource_name = matlabroot;
			switch(this.language)
			{
				case Language.C:
					versource_name += @"\c_mexapi_version.c";
					break;
				case Language.CPP:
					versource_name += @"\cpp_mexapi_version.cpp";
					break;
				case Language.FORTRAN:
					versource_name += @"\fortran_mexapi_version.F";
					break;
			}
			return File.Exists(versource_name)? versource_name : null;
		}

		public string GetAdditionalLinkerOptions()
		{
			string opts = @"/EXPORT:mexFunction ";
			if(GetVersionSource() != null)
			{
				opts += @"/EXPORT:mexfilerequiredapiversion ";
			}

			return opts;
		}

		public string GetPreprocessorDefinitions()
		{
			if(this.is_interleaved)
			{
				return
					@"MX_COMPAT_64;MATLAB_DEFAULT_RELEASE=R2018a;USE_MEX_CMD;_CRT_SECURE_NO_DEPRECATE;_SCL_SECURE_NO_DEPRECATE;_SECURE_SCL=0;MATLAB_MEX_FILE";
			}
			else
			{
				return @"MATLAB_DEFAULT_RELEASE=R2017b;USE_MEX_CMD;_CRT_SECURE_NO_DEPRECATE;_SCL_SECURE_NO_DEPRECATE;_SECURE_SCL=0;MATLAB_MEX_FILE";
			}
		}

		public string GetPlatformString()
		{
			return (this.platform == Platform.x64)? "x64" : "Win32";
		}

		public string GetMEXExtension()
		{
			return (this.platform == Platform.x64) ? ".mexw64" : ".mexw32";
		}

		public string GetInitialProjectFileResource()
		{
			switch(language)
			{
				case Language.C:
				{
					if(this.is_interleaved)
					{
						return "mexfunction_matrix_interleaved.c";
					}
					else
					{
						return "mexfunction_matrix_separated.c";
					}
				}
				case Language.CPP:
				{
					if(this.api.Equals(UserInputForm.MATRIX_API))
					{
						if(this.is_interleaved)
						{
							return "mexfunction_matrix_interleaved.cpp";
						}
						else
						{
							return "mexfunction_matrix_separated.cpp";
						}
					}
					else
					{
						return "mexfunction_data.cpp";
					}
				}
				case Language.FORTRAN:
				{
					if(this.is_interleaved)
					{
						return "mexfunction_matrix_interleaved.F";
					}
					else
					{
						return "mexfunction_matrix_separated.F";
					}
				}
			}

			return null;
		}

		public string GetFileExtension()
		{
			switch(language)
			{
				case Language.C:
				{
					return ".c";
				}
				case Language.CPP:
				{
					return ".cpp";
				}
				case Language.FORTRAN:
				{
					return ".F";
				}
			}

			return null;
		}

		public string GetFullAPIName()
		{
			if(this.api.Equals(UserInputForm.DATA_API))
			{
				return "C++ Data API";
			}
			else
			{
				string full_api_name = "";
				switch(language)
				{
					case Language.C:
					{

						full_api_name += "C Matrix API";
						break;
					}
					case Language.CPP:
					{
						full_api_name += "C++ Matrix API";
						break;
					}
					case Language.FORTRAN:
					{
						full_api_name += "Fortran Matrix API";
						break;
					}
				}
				return full_api_name + (this.is_interleaved ? " - Interleaved Complex" : " - Separated Complex");
			}
		}

		public string GetSafeAPIName()
		{
			if(this.api.Equals(UserInputForm.DATA_API))
			{
				return "CPP_DATA";
			}
			else
			{
				string full_api_name = "";
				switch(language)
				{
					case Language.C:
					{

						full_api_name += "C_MATRIX";
						break;
					}
					case Language.CPP:
					{
						full_api_name += "CPP_MATRIX";
						break;
					}
					case Language.FORTRAN:
					{
						full_api_name += "F_MATRIX";
						break;
					}
				}
				return full_api_name + (this.is_interleaved ? "_INTERLEAVED" : "_SEPARATED");
			}
		}

		public string GetProjectFilenameExtension()
		{
			switch(language)
			{
				case Language.C:
				case Language.CPP:
				{
					return ".vcxproj";
				}
				case Language.FORTRAN:
				{
					return ".vfproj";
				}
			}

			return null;
		}
	}

	public class MatlabNotFoundException : Exception
	{
		public MatlabNotFoundException()
		{
		}

		public MatlabNotFoundException(string message)
			: base(message)
		{
		}

		public MatlabNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

}
