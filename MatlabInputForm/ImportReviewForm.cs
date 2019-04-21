using System;

using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MatlabInputForm
{
	public partial class ImportReviewForm : Form
	{
		private MatlabConfiguration ml_config;
		private Form api_form;

		public ImportReviewForm(Form APIForm, MatlabConfiguration ml_config)
		{
			this.api_form = APIForm;
			this.ml_config = ml_config;
			InitializeComponent();
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
				api_form.DialogResult = DialogResult.Cancel;
			}
			api_form.Close();
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			api_form.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			api_form.Location = this.Location;
			this.Hide();
			api_form.Show();
		}

		public void UpdateConfig()
		{
			CheckResult check_result;
			string check_text;
			this.Location = api_form.Location;

			this.MatlabRootText.Text = ml_config.imports.MatlabRoot;
			this.ToolTip1.SetToolTip(this.MatlabRootText, this.MatlabRootText.Text);
			check_result = ml_config.imports.CheckMatlabRoot(out check_text);
			SetCheckInfo(this.MatlabRootCheck, check_result, check_text);

			this.ReleaseText.Text = ml_config.imports.Release;
			this.ToolTip1.SetToolTip(this.ReleaseText, this.ReleaseText.Text);
			check_result = ml_config.imports.CheckRelease(out check_text);
			SetCheckInfo(this.ReleaseCheck, check_result, check_text);

			this.APIText.Text = ml_config.imports.API;
			this.ToolTip1.SetToolTip(this.APIText, this.APIText.Text);
			check_result = ml_config.imports.CheckAPI(out check_text);
			SetCheckInfo(this.APICheck, check_result, check_text);

			this.PlatformText.Text = ml_config.imports.Platform;
			this.ToolTip1.SetToolTip(this.PlatformText, this.PlatformText.Text);
			check_result = ml_config.imports.CheckPlatform(out check_text);
			SetCheckInfo(this.PlatformCheck, check_result, check_text);

			this.IncludePathText.Text = ml_config.imports.IncludePath;
			this.ToolTip1.SetToolTip(this.IncludePathText, ml_config.imports.ReplaceMacro(this.IncludePathText.Text));

			this.PreprocessorText.Text = ml_config.imports.PreprocessorDefinitions;
			this.ToolTip1.SetToolTip(this.PreprocessorText, ml_config.imports.ReplaceMacro(this.PreprocessorText.Text));

			this.LibPathText.Text = ml_config.imports.LibraryPath;
			this.ToolTip1.SetToolTip(this.LibPathText, ml_config.imports.ReplaceMacro(this.LibPathText.Text));

			this.DependsText.Text = ml_config.imports.Dependencies;
			this.ToolTip1.SetToolTip(this.DependsText, ml_config.imports.ReplaceMacro(this.DependsText.Text));

		}

		public new void Show()
		{
			this.UpdateConfig();
			base.Show();
		}

		private void SetCheckInfo(Label label, CheckResult chk, string text)
		{
			switch(chk)
			{
				case CheckResult.SUCCESS:
				{
					label.Image = global::MatlabInputForm.Properties.Resources.success;
					break;
				}
				case CheckResult.WARNING:
				{
					label.Image = global::MatlabInputForm.Properties.Resources.warning;
					break;
				}
				case CheckResult.FAILURE:
				{
					label.Image = global::MatlabInputForm.Properties.Resources.failure;
					break;
				}
			}
			ToolTip1.SetToolTip(label, text);
		}

		private void IncludePathText_TextChanged(object sender, EventArgs e)
		{
			TextBox t = sender as TextBox;
			ml_config.imports.IncludePath = t.Text;
			string tooltip_text;
			CheckResult chk = ml_config.imports.CheckIncludePath(out tooltip_text);
			SetCheckInfo(IncludePathCheck, chk, tooltip_text);
			tooltip_text = ml_config.imports.ReplaceMacro(this.IncludePathText.Text);
			ToolTip1.SetToolTip(IncludePathText, tooltip_text);
		}

		private void LibPathText_TextChanged(object sender, EventArgs e)
		{
			TextBox t = sender as TextBox;
			ml_config.imports.LibraryPath = t.Text;
			string tooltip_text;
			CheckResult chk = ml_config.imports.CheckLibraryPath(out tooltip_text);
			SetCheckInfo(LibraryPathCheck, chk, tooltip_text);
			tooltip_text = ml_config.imports.ReplaceMacro(this.LibPathText.Text);
			ToolTip1.SetToolTip(LibPathText, tooltip_text);

			/* check depends */
			chk = ml_config.imports.CheckDependencies(out tooltip_text);
			SetCheckInfo(DependsCheck, chk, tooltip_text);
			tooltip_text = ml_config.imports.ReplaceMacro(this.DependsText.Text);
			ToolTip1.SetToolTip(DependsText, tooltip_text);
		}

		private void DependsText_TextChanged(object sender, EventArgs e)
		{
			TextBox t = sender as TextBox;
			ml_config.imports.Dependencies = t.Text;
			string tooltip_text;
			CheckResult chk = ml_config.imports.CheckDependencies(out tooltip_text);
			SetCheckInfo(DependsCheck, chk, tooltip_text);
			tooltip_text = ml_config.imports.ReplaceMacro(this.DependsText.Text);
			ToolTip1.SetToolTip(DependsText, tooltip_text);
		}

		private void PreprocessorText_TextChanged(object sender, EventArgs e)
		{
			TextBox t = sender as TextBox;
			ml_config.imports.PreprocessorDefinitions = t.Text;
			string tooltip_text = ml_config.imports.ReplaceMacro(this.PreprocessorText.Text);
			ToolTip1.SetToolTip(PreprocessorText, tooltip_text);
		}

		private void AbortButton_Click(object sender, EventArgs e)
		{
			api_form.DialogResult = DialogResult.Cancel;
			api_form.Close();
			this.Close();
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
