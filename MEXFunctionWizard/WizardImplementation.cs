using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;
using MatlabInputForm;

namespace MEXFunctionWizard
{
	public class WizardImplementation : IWizard
	{
		private DataApiForm inputForm;
		//private string test;

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
			//test = "stop run finished";
		}

		public void RunStarted(object automationObject,
			Dictionary<string, string> replacementsDictionary,
			WizardRunKind runKind, object[] customParams)
		{

			string dest_dir = replacementsDictionary["$destinationdirectory$"];

			try
			{
				// first element of customParams is the vstemplate file
				string template_source_path = customParams[0].ToString();
				string template_source_folder = Path.GetDirectoryName(template_source_path);
				string template_source_file = Path.GetFileNameWithoutExtension(template_source_path);

				MatlabInputForm.Language language;
				if(template_source_file.EndsWith("C"))
				{
					language = MatlabInputForm.Language.C;
				}
				else if(template_source_file.EndsWith("CPP"))
				{
					language = MatlabInputForm.Language.CPP;
				}
				else if(template_source_file.EndsWith("F"))
				{
					language = MatlabInputForm.Language.FORTRAN;
				}
				else
				{
					throw new System.Exception();
				}

				// Display a form to the user. The form collects
				// input for the custom message.
				using(inputForm = new DataApiForm(language))
				{
					if(inputForm.ShowDialog() != DialogResult.OK)
					{
						// abort
						throw new WizardCancelledException();
					}

					MatlabConfiguration ml_config = DataApiForm.config;

					// Add custom parameters.
					replacementsDictionary.Add("$TARGET_MACHINE$", ml_config.GetTargetMachine());
					replacementsDictionary.Add("$COMPILE_AS$", ml_config.GetCompileAs());
					replacementsDictionary.Add("$TARGETS_FILE$", Path.Combine(template_source_folder, "matlab.targets"));
					replacementsDictionary.Add("$RULE_FILE$", Path.Combine(template_source_folder, "matlab.xml"));
					replacementsDictionary.Add("$PROJECTEXT$", ml_config.GetProjectFilenameExtension());
					replacementsDictionary.Add("$FILEEXT$", ml_config.GetFileExtension());
					replacementsDictionary.Add("$API_SHORT_NAME$", ml_config.GetAPIShortName());
					replacementsDictionary.Add("$MATLABROOT$", ml_config.GetMatlabRoot());
					replacementsDictionary.Add("$PLATFORM$", ml_config.GetPlatformString());
					replacementsDictionary.Add("$MATLAB_INCLUDE_PATH$", ml_config.GetIncludePath());
					replacementsDictionary.Add("$MATLAB_LIBRARY_PATH$", ml_config.GetLibraryPath());
					replacementsDictionary.Add("$MATLAB_DEPENDS$", ml_config.GetDependencies());
					replacementsDictionary.Add("$MATLAB_PREPROCESSOR_DEFINITIONS$",
						ml_config.GetPreprocessorDefinitions());
					replacementsDictionary.Add("$MEXEXT$", ml_config.GetMEXExtension());


				}
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				if(ex is WizardCancelledException || ex is WizardBackoutException)
				{
					// Clean up the template that was written to disk
					if(Directory.Exists(dest_dir))
					{
						Directory.Delete(dest_dir, true);
					}
				}
				else
				{
					throw;
				}
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
