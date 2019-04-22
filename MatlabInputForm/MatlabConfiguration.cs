using System;
using System.IO;
using System.Windows.Forms;

namespace MatlabInputForm
{

	public enum Language
	{
		C = 0,
		CPP = 1,
		FORTRAN = 2
	};

	public enum API
	{
		MATRIX = 0,
		DATA   = 1
	}

	public enum Platform
	{
		X64 = 0,
		X86 = 1
	}

	public enum ArrayDimensions
	{
		LARGE      = 0,
		COMPATIBLE = 1
	}

	public enum ComplexStorage
	{
		SEPARATED   = 0,
		INTERLEAVED = 1
	}

	public enum GraphicsClass
	{
		OBJECT = 0,
		DOUBLE = 1
	}

	public enum CheckResult
	{
		SUCCESS = 0,
		WARNING = 1,
		FAILURE = 2
	}

	public class MatlabConfiguration
	{
		public static string UnknownRelease = "Unknown Release";
		private string _matlabroot;

		public string matlabroot
		{
			get {return _matlabroot;}
			set
			{
				if(value == null)
				{
					value = "";
				}
				if(!value.EndsWith(@"\"))
				{
					value += @"\";
				}
				_matlabroot = value;
			}
		}

		public Language language;
		public API api;

		public Platform platform{get; set;} = Platform.X64;
		public ArrayDimensions array_dims{get; set;} = ArrayDimensions.LARGE;
		public ComplexStorage complex_storage{get; set;} = ComplexStorage.SEPARATED;
		public GraphicsClass graphics_class{get; set;} = GraphicsClass.OBJECT;

		public ConfigurationImporter imports;

		public MatlabConfiguration()
		{
			this.GenerateImports();
		}

		public void GenerateImports()
		{
			this.imports = new ConfigurationImporter(this);
		}
		
		public string GenerateIncludePath()
		{
			string path = @"$(MatlabRoot)extern\include\";
			if(Directory.Exists(this._matlabroot + @"simulink\include\"))
			{
				path += @";$(MatlabRoot)simulink\include\";
			}
			return path;
		}

		public string GetFullIncludePath()
		{
			string path = _matlabroot + @"extern\include\";
			if(Directory.Exists(_matlabroot + @"simulink\include\"))
			{
				path += ";" + this._matlabroot + @"simulink\include\";
			}
			return path;
		}

		public string GenerateLibraryPath()
		{
			if(this.platform == Platform.X64)
			{
				return @"$(MatlabRoot)extern\lib\win64\microsoft\";
			}
			else
			{
				return @"$(MatlabRoot)extern\lib\win32\microsoft\";
			}
		}

		public string GetLibraryFullPath()
		{
			if(this.platform == Platform.X64)
			{
				return this._matlabroot + @"extern\lib\win64\microsoft\";
			}
			else
			{
				return this._matlabroot + @"extern\lib\win32\microsoft\";
			}
		}

		public string GenerateDependencies()
		{
			string depends = "libmx.lib;libmex.lib;libmat.lib";
			if(this.language == Language.CPP)
			{
				if(File.Exists(GetLibraryFullPath() + "libMatlabDataArray.lib"))
				{
					depends += ";libMatlabDataArray.lib";
				}
				if(File.Exists(GetLibraryFullPath() + "libMatlabEngine.lib"))
				{
					depends += ";libMatlabEngine.lib";
				}
			}
			return depends;
		}

		public string GetVersionSource()
		{
			string versource_name = _matlabroot;
			switch(this.language)
			{
				case Language.C:
					versource_name += @"extern\version\c_mexapi_version.c";
					break;
				case Language.CPP:
					versource_name += @"extern\version\cpp_mexapi_version.cpp";
					break;
				case Language.FORTRAN:
					versource_name += @"extern\version\fortran_mexapi_version.F";
					break;
			}
			return File.Exists(versource_name) ? versource_name : null;
		}

		public string GetVersionSourceExists()
		{
			// looks stupid but it's necessary for conditional parameter substitution
			return (GetVersionSource() != null) ? "true" : "false";
		}

		public string GenerateAdditionalLinkerOptions()
		{
			string opts = @"/EXPORT:mexFunction ";
			if(GetVersionSource() != null)
			{
				opts += @"/EXPORT:mexfilerequiredapiversion ";
			}

			return opts;
		}

		public string GeneratePreprocessorDefinitions()
		{
			string defs = @"USE_MEX_CMD;_CRT_SECURE_NO_DEPRECATE;_SCL_SECURE_NO_DEPRECATE;_SECURE_SCL=0;MATLAB_MEX_FILE";

			if(api == API.DATA)
			{
				return defs;
			}
			else
			{
				if(this.array_dims == ArrayDimensions.COMPATIBLE)
				{
					defs = "MX_COMPAT_32;" + defs;
				}
				else
				{
					defs = "MX_COMPAT_64;" + defs;
				}

				if(this.complex_storage == ComplexStorage.INTERLEAVED)
				{
					defs = "MATLAB_MEXCMD_RELEASE=R2018a;" + defs;
				}
				else
				{
					defs = "MATLAB_MEXCMD_RELEASE=R2017b;" + defs;
				}

				if(this.graphics_class == GraphicsClass.DOUBLE)
				{
					defs = "MEX_DOUBLE_HANDLE;" + defs;
				}

				return defs;
			}
		}

		public string GeneratePlatformString()
		{
			return (this.platform == Platform.X64) ? "x64" : "Win32";
		}

		public string GenerateMEXExtension()
		{
			return (this.platform == Platform.X64) ? ".mexw64" : ".mexw32";
		}


		public string GenerateFileExtension()
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

		public string GenerateAPIFullName()
		{
			if(this.api == API.DATA)
			{
				return "C++ Data API";
			}
			else
			{
				string full_api_name = "";
				switch(this.language)
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

				full_api_name += (this.complex_storage == ComplexStorage.INTERLEAVED)
					? " - Interleaved Complex Numbers"
					: " - Separated Complex Numbers";
				full_api_name += (this.array_dims == ArrayDimensions.COMPATIBLE)
					? ", Compatible Array Dimensions"
					: "";
				full_api_name += (this.graphics_class == GraphicsClass.DOUBLE)? ", 'double' Graphics Class" : "";
				return full_api_name;
			}
		}

		public string GenerateAPIShortName()
		{
			if(this.api == API.DATA)
			{
				return "CPP_DATA";
			}
			else
			{
				switch(this.language)
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
				return "";
			}
		}

		public string GenerateProjectExtension()
		{
			switch(this.language)
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

		public string GenerateCompileAs()
		{
			switch(this.language)
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

		public string GenerateTargetMachine()
		{
			return (this.platform == Platform.X64) ? "MachineX64" : "MachineX86";
		}

		public  string GetRelease()
		{
			// checks if version.txt exists and fetches its contents
			if(this._matlabroot != null)
			{
				string verfile_name = this._matlabroot + @"bin\util\mex\version.txt";
				if(File.Exists(verfile_name))
				{
					return File.ReadAllText(verfile_name);
				}
			}
			return UnknownRelease;
		}

		public static string GetVersionTxtPath(string matlabroot)
		{
			return matlabroot + @"bin\util\mex\version.txt";
		}

		public static string GetMatlabExePath(string matlabroot)
		{
			return matlabroot + @"bin\matlab.exe";
		}

	}

	public class ConfigurationImporter
	{
		public readonly string MatlabRoot;
		public readonly string Release;
		public readonly string API;
		public readonly string Platform;

		public string IncludePath;
		public string PreprocessorDefinitions;
		public string LibraryPath;
		public string Dependencies;

		public readonly string AdditionalLinkerOptions;
		public readonly string MEXExtension;
		public readonly string TargetMachine;
		public readonly string CompileAs;
		public readonly string ProjectExtension;
		public readonly string FileExtension;
		public readonly string APIShortName;

		public ConfigurationImporter(MatlabConfiguration ml_config)
		{
			this.MatlabRoot = ml_config.matlabroot;
			this.Release = ml_config.GetRelease();
			this.API = ml_config.GenerateAPIFullName();
			this.Platform = ml_config.GeneratePlatformString();
			this.IncludePath = ml_config.GenerateIncludePath();
			this.LibraryPath = ml_config.GenerateLibraryPath();
			this.Dependencies = ml_config.GenerateDependencies();
			this.PreprocessorDefinitions = ml_config.GeneratePreprocessorDefinitions();
			this.AdditionalLinkerOptions = ml_config.GenerateAdditionalLinkerOptions();
			this.MEXExtension = ml_config.GenerateMEXExtension();
			this.TargetMachine = ml_config.GenerateTargetMachine();
			this.CompileAs = ml_config.GenerateCompileAs();
			this.ProjectExtension = ml_config.GenerateProjectExtension();
			this.FileExtension = ml_config.GenerateFileExtension();
			this.APIShortName = ml_config.GenerateAPIShortName();
		}

		public string ReplaceMacro(string s)
		{
			return s.Replace("$(MatlabRoot)", this.MatlabRoot);
		}

		public CheckResult CheckRelease(out string chk_s)
		{
			CheckResult res = CheckRelease();
			if(res == CheckResult.SUCCESS)
			{
				chk_s = "Found version.txt at " + MatlabConfiguration.GetVersionTxtPath(MatlabRoot);
			}
			else
			{
				chk_s = "Could not find version.txt at expected location " + MatlabConfiguration.GetVersionTxtPath(MatlabRoot);
			}
			return res;
		}

		public CheckResult CheckRelease()
		{

			return this.Release.Equals(MatlabConfiguration.UnknownRelease) ? CheckResult.WARNING : CheckResult.SUCCESS;
		}

		public CheckResult CheckMatlabRoot(out string chk_s)
		{
			CheckResult res = CheckRelease();
			if(res == CheckResult.SUCCESS)
			{
				chk_s = "Found matlab.exe at " + MatlabConfiguration.GetMatlabExePath(MatlabRoot);
			}
			else
			{
				chk_s = "Could not find matlab.exe at expected location " + MatlabConfiguration.GetMatlabExePath(MatlabRoot);
			}
			return res;
		}

		public CheckResult CheckMatlabRoot()
		{
			return File.Exists(MatlabConfiguration.GetMatlabExePath(MatlabRoot)) ? CheckResult.WARNING : CheckResult.SUCCESS;
		}

		public CheckResult CheckAPI(out string chk_s)
		{
			CheckResult res = CheckAPI();
			if(res == CheckResult.SUCCESS)
			{
				chk_s = "Valid API";
			}
			else
			{
				chk_s = "Invalid API";
			}
			return res;
		}


		public CheckResult CheckAPI()
		{
			return CheckResult.SUCCESS;
		}

		public CheckResult CheckPlatform(out string chk_s)
		{
			CheckResult res = CheckPlatform();
			if(res == CheckResult.SUCCESS)
			{
				if(Platform.Equals("x64"))
				{
					chk_s = "Valid 64-bit platform";
				}
				else
				{
					chk_s = "Valid 32-bit platform";
				}
			}
			else
			{
				if(Platform.Equals("x64"))
				{
					chk_s = "Invalid 64-bit platform";
				}
				else
				{
					chk_s = "Invalid 32-bit platform";
				}
				chk_s = "Invalid API";
			}
			return res;
		}

		public CheckResult CheckPlatform()
		{
			return CheckResult.SUCCESS;
		}

		public CheckResult CheckIncludePath(out string chk_s)
		{
			string[] folders = ReplaceMacro(IncludePath).Split(';');
			foreach(string f in folders)
			{
				string t = f.Trim();
				if(!t.EndsWith(@"\"))
				{
					t += @"\";
				}
				if(File.Exists(t + "mex.h"))
				{
					chk_s = "Found mex.h at " + t + "mex.h";
					return CheckResult.SUCCESS;
				}
			}
			chk_s = "Could not find mex.h with the specified path";
			return CheckResult.FAILURE;
		}

		public CheckResult CheckIncludePath()
		{
			return CheckIncludePath(out _);
		}
		

		public CheckResult CheckPreprocessorDefinitions()
		{
			return CheckResult.SUCCESS;
		}

		public CheckResult CheckLibraryPath(out string chk_s)
		{
			bool valid_path = true;
			string failure_s = "Invalid path: ";
			string[] folders = ReplaceMacro(LibraryPath).Split(';');
			foreach(string f in folders)
			{
				string t = f.Trim();
				if(!t.EndsWith(@"\"))
				{
					t += @"\";
				}
				if(!Directory.Exists(t))
				{
					failure_s += f + ";";
					valid_path = false;
				}
			}
			if(valid_path)
			{
				chk_s = "Valid path";
				return CheckResult.SUCCESS;
			}
			else
			{
				chk_s = failure_s.Substring(0, failure_s.Length - 1);
				return CheckResult.WARNING;
			}
		}

		public CheckResult CheckDependencies(out string chk_s)
		{
			CheckResult res = CheckResult.SUCCESS;
			string success_s = "";
			string failure_s = "Could not find libraries ";
			string[] deps = ReplaceMacro(Dependencies).Split(';');
			string[] folders = ReplaceMacro(LibraryPath).Split(';');

			string[] folders_t = new string[folders.Length];

			for(int i = 0; i < folders.Length; i++)
			{
				string ft = folders[i].Trim();
				if(!ft.EndsWith(@"\"))
				{
					ft += @"\";
				}
				folders_t[i] = ft;
			}

			foreach(string d in deps)
			{
				bool found = false;
				string dt = d.Trim();
				foreach(string f in folders_t)
				{
					if(File.Exists(f + dt))
					{
						success_s += "Found " + dt + " at " + f + dt + "\n";
						found = true;
						break;
					}
				}
				if(!found)
				{
					failure_s += dt + ", ";
					res = CheckResult.FAILURE;
				}
			}

			if(res == CheckResult.SUCCESS)
			{
				chk_s = success_s;
				return res;
			}
			else
			{
				chk_s = failure_s.Substring(0, failure_s.Length - 2);
				return res;
			}
		}

		public CheckResult CheckDependencies()
		{
			return CheckDependencies(out _);
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
