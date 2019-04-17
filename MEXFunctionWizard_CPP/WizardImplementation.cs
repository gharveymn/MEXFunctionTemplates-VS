using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;
using MatlabInputForm;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.Interfaces;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using Microsoft.VisualStudio.Shell;

namespace MEXFunctionWizard_CPP
{
	public class WizardImplementation : IWizard
	{
		private UserInputForm inputForm;

		// This method is called before opening any item that
		// has the OpenInEditor attribute.
		public void BeforeOpeningFile(ProjectItem projectItem)
		{
		}

		public void ProjectFinishedGenerating(Project project)
		{
		}

		// This method is only called for item templates,
		// not for project templates.
		public void ProjectItemFinishedGenerating(ProjectItem
			projectItem)
		{
		}

		// This method is called after the project is created.
		public void RunFinished()
		{
		}

		public void RunStarted(object automationObject,
			Dictionary<string, string> replacementsDictionary,
			WizardRunKind runKind, object[] customParams)
		{
			try
			{
				// Display a form to the user. The form collects
				// input for the custom message.
				using(inputForm = new UserInputForm(MatlabInputForm.Language.CPP))
				{
					if(inputForm.ShowDialog() != DialogResult.OK)
					{
						// abort
						throw new WizardCancelledException();
					}

					MatlabConfiguration ml_config = UserInputForm.config;

					// Add custom parameters.
					string versource = ml_config.GetVersionSource();
					replacementsDictionary.Add("$VERSION_SOURCE$", (versource != null)? versource : "null");
					replacementsDictionary.Add("$PROJECTEXT$", ml_config.GetProjectFilenameExtension());
					replacementsDictionary.Add("$FILEEXT$", ml_config.GetFileExtension());
					replacementsDictionary.Add("$SAFEAPI$", ml_config.GetSafeAPIName());
					replacementsDictionary.Add("$MATLABROOT$", ml_config.GetMatlabRoot());
					replacementsDictionary.Add("$PLATFORM$", ml_config.GetPlatformString());
					replacementsDictionary.Add("$MATLAB_INCLUDE_PATH$", ml_config.GetIncludePath());
					replacementsDictionary.Add("$MATLAB_LIBRARY_PATH$", ml_config.GetLibraryPath());
					replacementsDictionary.Add("$MATLAB_DEPENDS$", ml_config.GetDependencies());
					replacementsDictionary.Add("$MATLAB_PREPROCESSOR_DEFINITIONS$",
						ml_config.GetPreprocessorDefinitions());
					replacementsDictionary.Add("$MEXEXT$", ml_config.GetMEXExtension());

					var serviceProvider = new ServiceProvider((IServiceProvider) automationObject);
					// IServiceProvider serviceProvider = (IServiceProvider) automationObject;
					ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) as ITextTemplating;
					ITextTemplatingSessionHost sessionHost = t4 as ITextTemplatingSessionHost;

					sessionHost.Session = sessionHost.CreateSession();
					sessionHost.Session["$VERSION_SOURCE$"] = (versource != null) ? versource : "null";

					string template_source_folder = Path.GetDirectoryName(customParams[0].ToString());
					string matlab_targets_path = Path.Combine(template_source_folder, "matlab.targets");
					string res = t4.ProcessTemplate(matlab_targets_path, File.ReadAllText(matlab_targets_path));
					File.WriteAllText(Path.Combine(replacementsDictionary["$destinationfolder$"], "matlab.targets"), res);

				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		// This method is only called for item templates,
		// not for project templates.
		public bool ShouldAddProjectItem(string filePath)
		{
			return true;
		}
	}
}
