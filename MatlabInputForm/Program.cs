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
			MatlabConfiguration ml_config = new MatlabConfiguration(Language.CPP, API.MATRIX);
			Application.Run(new MatrixAPIForm(ml_config));
		}
	}
}
