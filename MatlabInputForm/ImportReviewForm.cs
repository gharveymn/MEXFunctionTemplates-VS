using System;

using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MatlabInputForm
{
	public partial class ImportReviewForm : Form
	{
		private MatlabConfiguration ml_config;
		private Form APIForm;

		public ImportReviewForm(Form APIForm, MatlabConfiguration ml_config)
		{
			this.APIForm = APIForm;
			this.ml_config = ml_config;
			InitializeComponent();
			this.ToolTip1.Popup += new PopupEventHandler(this.ToolTip1_Popup);
			this.FormClosing += new FormClosingEventHandler(this.ImportReviewForm_FormClosing);
		}

		private bool is_closing = false;
		private void ImportReviewForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(is_closing)
			{
				return;
			}
			is_closing = true;
			if(e.CloseReason != CloseReason.FormOwnerClosing)
			{
				APIForm.DialogResult = DialogResult.Cancel;
			}
			APIForm.Close();
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			APIForm.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			APIForm.Show();
		}

		public void UpdateConfig()
		{
			this.Location = APIForm.Location;

			this.ReleaseText.Text = ml_config.imports.Release;
			this.ToolTip1.SetToolTip(this.ReleaseText, this.ReleaseText.Text);

			this.MatlabRootText.Text = ml_config.imports.MatlabRoot;
			this.ToolTip1.SetToolTip(this.MatlabRootText, this.MatlabRootText.Text);

			this.APIText.Text = ml_config.imports.APIFullName;
			this.ToolTip1.SetToolTip(this.APIText, this.APIText.Text);

			this.PlatformNameText.Text = ml_config.imports.PlatformName;
			this.ToolTip1.SetToolTip(this.PlatformNameText, this.PlatformNameText.Text);

			this.IncludePathText.Text = ml_config.imports.IncludePath;
			this.ToolTip1.SetToolTip(this.IncludePathText, this.IncludePathText.Text);

			this.PreprocessorText.Text = ml_config.imports.PreprocessorDefinitions;
			this.ToolTip1.SetToolTip(this.PreprocessorText, this.PreprocessorText.Text);

			this.LibPathText.Text = ml_config.imports.LibraryPath;
			this.ToolTip1.SetToolTip(this.LibPathText, this.LibPathText.Text);

			this.DependsText.Text = ml_config.imports.Dependencies;
			this.ToolTip1.SetToolTip(this.DependsText, this.DependsText.Text);

		}

		private bool is_updating_tooltip = false;
		private void ToolTip1_Popup(object sender, PopupEventArgs e)
		{
			if(is_updating_tooltip)
			{
				return;
			}
			ToolTip tt = sender as ToolTip;
			string text = "";
			if(e.AssociatedControl == this.PlatformNameText)
			{
				text = this.PlatformNameText.Text;
			}
			else if(e.AssociatedControl == this.IncludePathText)
			{
				text = this.IncludePathText.Text.Replace("$(MatlabRoot)", this.MatlabRootText.Text);
			}
			else if(e.AssociatedControl == this.PreprocessorText)
			{
				text = this.PreprocessorText.Text;
			}
			else if(e.AssociatedControl == this.LibPathText)
			{
				text = this.LibPathText.Text.Replace("$(MatlabRoot)", this.MatlabRootText.Text);
			}
			else if(e.AssociatedControl == this.DependsText)
			{
				text = this.DependsText.Text;
			}
			else
			{
				return;
			}
			is_updating_tooltip = true;
			tt.SetToolTip(e.AssociatedControl, text);
			is_updating_tooltip = false;
		}

		public new void Show()
		{
			this.UpdateConfig();
			base.Show();
		}
	}
}
