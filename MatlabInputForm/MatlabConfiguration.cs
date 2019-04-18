using System;
using System.IO;

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

	public class MatlabConfiguration
	{

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
		private Language _language;

		public Language language
		{
			get {return _language;}
		}
		private API _api;

		public API api
		{
			get {return _api;}
		}

		public Platform platform{get; set;} = Platform.X64;
		public ArrayDimensions array_dims{get; set;} = ArrayDimensions.LARGE;
		public ComplexStorage complex_storage{get; set;} = ComplexStorage.SEPARATED;
		public GraphicsClass graphics_class{get; set;} = GraphicsClass.OBJECT;

		public ConfigurationImporter imports;

		public MatlabConfiguration(Language language, API api)
		{
			this._language = language;
			this._api = api;
		}

		public void GenerateConfiguration()
		{
			this.imports.Release = GetRelease();
			this.imports.MatlabRoot = _matlabroot;
			this.imports.APIFullName = GenerateAPIFullName();
			this.imports.PlatformName = GeneratePlatformString();
			this.imports.IncludePath = GenerateIncludePath();
			this.imports.LibraryPath = GenerateLibraryPath();
			this.imports.Dependencies = GenerateDependencies();
			this.imports.PreprocessorDefinitions = GeneratePreprocessorDefinitions();
			this.imports.AdditionalLinkerOptions = GenerateAdditionalLinkerOptions();
			this.imports.MEXExtension = GenerateMEXExtension();
			this.imports.TargetMachine = GenerateTargetMachine();
			this.imports.CompileAs = GenerateCompileAs();
			this.imports.ProjectExtension = GenerateProjectExtension();
			this.imports.FileExtension = GenerateFileExtension();
			this.imports.APIShortName = GenerateAPIShortName();
		}

		public string GetRelease()
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
			return "Unknown Release";
		}

		public bool CheckMatlabExe()
		{
			return (File.Exists(this._matlabroot + @"bin\matlab.exe"));
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
			if(this._language == Language.CPP)
			{
				depends += ";libMatlabDataArray.lib;libMatlabEngine.lib";
			}
			return depends;
		}

		public string GetVersionSource()
		{
			string versource_name = _matlabroot;
			switch(this._language)
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
					defs += "MX_COMPAT_32";
				}
				else
				{
					defs += "MX_COMPAT_64";
				}

				if(this.complex_storage == ComplexStorage.INTERLEAVED)
				{
					defs += "MATLAB_MEXCMD_RELEASE=R2018a";
				}
				else
				{
					defs += "MATLAB_MEXCMD_RELEASE=R2017b";
				}

				if(this.graphics_class == GraphicsClass.DOUBLE)
				{
					defs += "MEX_DOUBLE_HANDLE";
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
			switch(_language)
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
				switch(_language)
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
					? " - Interleaved Complex"
					: " - Separated Complex";
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
				switch(_language)
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
			switch(_language)
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
			switch(_language)
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

		public class ConfigurationImporter
		{
			public string Release = "";
			public string MatlabRoot = "";
			public string APIFullName = "";
			public string PlatformName = "";
			public string IncludePath = "";
			public string PreprocessorDefinitions = "";
			public string LibraryPath = "";
			public string Dependencies = "";
			public string AdditionalLinkerOptions = "";
			public string MEXExtension = "";
			public string TargetMachine = "";
			public string CompileAs = "";
			public string ProjectExtension = "";
			public string FileExtension = "";
			public string APIShortName = "";
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
