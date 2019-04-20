using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabInputForm
{

	public partial class DataAPIForm : APIForm
	{
		private string[] matlab_registry_x64;

		public DataAPIForm() : base(Language.CPP, API.DATA)
		{
			InitializeComponent();
			InitFolderSelect();
		}

		private void InitFolderSelect()
		{
			matlab_registry_x64 = GetMatlabRootFromRegistry(Platform.X64);
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
			review_form.Close();
			this.Close();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			configuration.matlabroot = this.FolderSelect.Text;
			if(!configuration.CheckMatlabExe())
			{
				MessageBox.Show(@"Could not locate matlab.exe from MATLAB root """ + this.FolderSelect.Text + @""".
Example path: C:\Program Files\MATLAB\R2019a", "Invalid MATLAB Root Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			configuration.GenerateConfiguration();
			this.Hide();
			review_form.Show();
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

	}
}
