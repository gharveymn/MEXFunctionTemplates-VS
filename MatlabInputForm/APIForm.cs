using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MatlabInputForm
{
	public class APIForm : Form
	{
		public static MatlabConfiguration ml_config;
		public static string BROWSE_STRING = "Browse...";

		public IPanel api_panel;
		public IPanel import_panel;

		public bool will_create = false;

		public APIForm(Language language, API api)
		{
			APIForm.ml_config = new MatlabConfiguration();
			api_panel = APIPanel.GetAPIPanel(this, ml_config);
			import_panel = new ImportReviewPanel(this, ml_config);
			this.FormClosing += new FormClosingEventHandler(this.APIForm_FormClosing);
			api_panel.ShowPanel();
		}
		
		private void APIForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(will_create)
			{
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				this.DialogResult = DialogResult.Cancel;
			}
		}

	}
}
