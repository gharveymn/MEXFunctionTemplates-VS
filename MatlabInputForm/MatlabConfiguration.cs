using System;
using System.IO;

namespace MatlabInputForm
{
	public class MatlabConfiguration
	{

		private string matlabroot;
		private Platform platform;
		private Language language;
		private string api;
		private bool is_interleaved;

		public MatlabConfiguration(string matlabroot, string platform_str, string api, Language language, bool is_interleaved)
		{
			this.matlabroot = matlabroot;
			if(platform_str.Equals(DataApiForm.PLATFORM_x64))
			{
				this.platform = Platform.x64;
			}
			else
			{
				this.platform = Platform.x86;
			}
			this.language = language;
			this.api = api;
			this.is_interleaved = is_interleaved;
		}

		public static bool CheckMatlabExe(string matlabroot)
		{
			return (File.Exists(matlabroot + @"\bin\matlab.exe"));
		}

		public string GetMatlabRoot()
		{
			return this.matlabroot + @"\";
		}

		public string GetVersionName()
		{
			// checks if version.txt exists and fetches its contents
			string verfile_name = matlabroot + @"\bin\util\mex\version.txt";
			if(File.Exists(verfile_name))
			{
				return File.ReadAllText(verfile_name);
			}
			else
			{
				return null;
			}
		}

		public string GetIncludePath()
		{
			return @"$(MatlabRoot)extern\include\;$(MatlabRoot)simulink\include\";
		}

		public string GetLibraryPath()
		{
			if(this.platform.Equals(DataApiForm.PLATFORM_x64))
			{
				return @"$(MatlabRoot)extern\lib\win64\microsoft\";
			}
			else
			{
				return @"$(MatlabRoot)extern\lib\win32\microsoft\";
			}
		}

		public string GetDependencies()
		{
			string depends = "libmx.lib;libmex.lib;libmat.lib";
			if(this.language == Language.CPP)
			{
				depends += ";libMatlabDataArray.lib;libMatlabEngine.lib";
			}
			return depends;
		}

		public string GetVersionSource()
		{
			string versource_name = matlabroot;
			switch(this.language)
			{
				case Language.C:
					versource_name += @"\extern\version\c_mexapi_version.c";
					break;
				case Language.CPP:
					versource_name += @"\extern\version\cpp_mexapi_version.cpp";
					break;
				case Language.FORTRAN:
					versource_name += @"\extern\version\fortran_mexapi_version.F";
					break;
			}
			return File.Exists(versource_name) ? versource_name : null;
		}

		public string GetVersionSourceExists()
		{
			// looks stupid but it's necessary for conditional parameter substitution
			return (GetVersionSource() != null) ? "true" : "false";
		}

		public string GetAdditionalLinkerOptions()
		{
			string opts = @"/EXPORT:mexFunction ";
			if(GetVersionSource() != null)
			{
				opts += @"/EXPORT:mexfilerequiredapiversion ";
			}

			return opts;
		}

		public string GetPreprocessorDefinitions()
		{
			if(this.is_interleaved)
			{
				return
					@"MX_COMPAT_64;MATLAB_DEFAULT_RELEASE=R2018a;USE_MEX_CMD;_CRT_SECURE_NO_DEPRECATE;_SCL_SECURE_NO_DEPRECATE;_SECURE_SCL=0;MATLAB_MEX_FILE";
			}
			else
			{
				return @"MATLAB_DEFAULT_RELEASE=R2017b;USE_MEX_CMD;_CRT_SECURE_NO_DEPRECATE;_SCL_SECURE_NO_DEPRECATE;_SECURE_SCL=0;MATLAB_MEX_FILE";
			}
		}

		public string GetPlatformString()
		{
			return (this.platform == Platform.x64) ? "x64" : "Win32";
		}

		public string GetMEXExtension()
		{
			return (this.platform == Platform.x64) ? ".mexw64" : ".mexw32";
		}


		public string GetFileExtension()
		{
			switch(language)
			{
				case Language.C:
				{
					return ".c";
				}
				case Language.CPP:
				{
					return ".cpp";
				}
				case Language.FORTRAN:
				{
					return ".F";
				}
			}

			return null;
		}

		public string GetFullAPIName()
		{
			if(this.api.Equals(DataApiForm.DATA_API))
			{
				return "C++ Data API";
			}
			else
			{
				string full_api_name = "";
				switch(language)
				{
					case Language.C:
					{

						full_api_name += "C Matrix API";
						break;
					}
					case Language.CPP:
					{
						full_api_name += "C++ Matrix API";
						break;
					}
					case Language.FORTRAN:
					{
						full_api_name += "Fortran Matrix API";
						break;
					}
				}
				return full_api_name + (this.is_interleaved ? " - Interleaved Complex" : " - Separated Complex");
			}
		}

		public string GetSafeAPIName()
		{
			if(this.api.Equals(DataApiForm.DATA_API))
			{
				return "CPP_DATA";
			}
			else
			{
				string full_api_name = "";
				switch(language)
				{
					case Language.C:
					{

						full_api_name += "C_MATRIX";
						break;
					}
					case Language.CPP:
					{
						full_api_name += "CPP_MATRIX";
						break;
					}
					case Language.FORTRAN:
					{
						full_api_name += "F_MATRIX";
						break;
					}
				}
				return full_api_name + (this.is_interleaved ? "_INTERLEAVED" : "_SEPARATED");
			}
		}

		public string GetAPIShortName()
		{
			if(this.api.Equals(DataApiForm.DATA_API))
			{
				return "CPP_DATA";
			}
			else
			{
				switch(language)
				{
					case Language.C:
					{

						return "C_MATRIX";
					}
					case Language.CPP:
					{
						return "CPP_MATRIX";
					}
					case Language.FORTRAN:
					{
						return "F_MATRIX";
					}
				}
			}

			return "";
		}

		public string GetProjectFilenameExtension()
		{
			switch(language)
			{
				case Language.C:
				case Language.CPP:
				{
					return ".vcxproj";
				}
				case Language.FORTRAN:
				{
					return ".vfproj";
				}
			}

			return null;
		}

		public string GetCompileAs()
		{
			switch(language)
			{
				case Language.C:
				{
					return "CompileAsC";
				}
				case Language.CPP:
				{
					return "CompileAsCpp";
				}
				case Language.FORTRAN:
				{
					return "CompileAsFortran";
				}
			}

			return null;
		}

		public string GetTargetMachine()
		{
			return (this.platform == Platform.x64) ? "MachineX64" : "MachineX86";
		}

	}

	public class MatlabNotFoundException : Exception
	{
		public MatlabNotFoundException()
		{
		}

		public MatlabNotFoundException(string message)
			: base(message)
		{
		}

		public MatlabNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

}
