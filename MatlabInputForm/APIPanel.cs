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

		protected APIForm parent;
		protected MatlabConfiguration ml_config;

		public APIPanel(APIForm parent, MatlabConfiguration ml_config)
		{
			this.parent = parent;
			this.ml_config = ml_config;
		}

		public static APIPanel GetAPIPanel(APIForm parent, MatlabConfiguration ml_config)
		{
			if(ml_config.api == API.DATA)
			{
				return new DataAPIPanel(parent, ml_config);
			}
			else
			{
				return new MatrixAPIPanel(parent, ml_config);
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

		public void ShowPanel()
		{
			throw new NotImplementedException();
		}

		public void HidePanel()
		{
			throw new NotImplementedException();
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
