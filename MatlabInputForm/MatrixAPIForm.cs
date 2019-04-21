using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabInputForm
{

	public partial class MatrixAPIForm : APIForm
	{
		private string[] matlab_registry_x64;
		private string[] matlab_registry_x86;

		public MatrixAPIForm(Language language) : base(language, API.MATRIX)
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
	}

}
