using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatlabInputForm
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//APIForm api_form = new APIForm(Language.CPP, API.MATRIX);
			//Application.Run(api_form);
			//MessageBox.Show("Exit was " + (api_form.DialogResult == DialogResult.OK? "OK" : "Cancel"));
			Application.Run(new MatrixAPIForm());
		}
	}
}
