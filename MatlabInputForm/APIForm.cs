using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabInputForm
{
	public class APIForm : Form
	{
		public static MatlabConfiguration configuration;
		protected ImportReviewForm review_form;
		protected static string BROWSE_STRING = "Browse...";

		public APIForm(Language language, API api)
		{
			APIForm.configuration = new MatlabConfiguration(language, api);
			review_form = new ImportReviewForm(this, APIForm.configuration);
			this.FormClosing += new FormClosingEventHandler(this.APIForm_FormClosing);
		}

		protected  string[] GetMatlabRootFromRegistry(Platform platform)
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

		public static APIForm GetAPIForm(Language language, API api)
		{
			if(api == API.DATA)
			{
				return new DataAPIForm();
			}
			else
			{
				return new MatrixAPIForm(language);
			}
		}

		private bool is_closing = false;
		private void APIForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(is_closing)
			{
				return;
			}
			is_closing = true;
			if(e.CloseReason != CloseReason.FormOwnerClosing)
			{
				this.DialogResult = DialogResult.Cancel;
			}
			review_form.Close();
		}

	}
}
