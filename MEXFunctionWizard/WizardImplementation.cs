using System;
using System.Collections.Generic;
using Microsoft.Win32;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;

namespace MEXFunctionWizard
{
	public class WizardImplementation : IWizard
	{
		private MatlabRootInputForm.UserInputForm inputForm;

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
				inputForm = new MatlabRootInputForm.UserInputForm(MatlabRootInputForm.Language.CPP);
				if (inputForm.ShowDialog() != DialogResult.OK)
				{
					// abort
					throw new WizardCancelledException();
				}

				MatlabRootInputForm.MatlabConfiguration ml_config = MatlabRootInputForm.UserInputForm.config;

				// Add custom parameters.
				replacementsDictionary.Add("$PROJECTEXT$", ml_config.GetProjectFilenameExtension());
				replacementsDictionary.Add("$FILEEXT$", ml_config.GetFileExtension());
				replacementsDictionary.Add("$SAFEAPI$", ml_config.GetSafeAPIName());
				replacementsDictionary.Add("$MATLABROOT$", ml_config.GetMatlabRoot());
				replacementsDictionary.Add("$PLATFORM$", ml_config.GetPlatformString());
				replacementsDictionary.Add("$MATLAB_INCLUDE_PATH$", ml_config.GetIncludePath());
				replacementsDictionary.Add("$MATLAB_LIBRARY_PATH$", ml_config.GetLibraryPath());
				replacementsDictionary.Add("$MATLAB_DEPENDS$", ml_config.GetDependencies());
				replacementsDictionary.Add("$MATLAB_PREPROCESSOR_DEFINITIONS$", ml_config.GetPreprocessorDefinitions());
				replacementsDictionary.Add("$MEXEXT$", ml_config.GetMEXExtension());
			}
			catch (Exception ex)
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
