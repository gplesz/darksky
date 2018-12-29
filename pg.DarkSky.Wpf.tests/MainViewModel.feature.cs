We could not find a data exchange file at the path Unhandled Exception: System.BadImageFormatException: The module was expected to contain an assembly manifest. (Exception from HRESULT: 0x80131018)

Please open an issue at https://github.com/techtalk/SpecFlow/issues/
Complete output: 

Unhandled Exception: System.BadImageFormatException: The module was expected to contain an assembly manifest. (Exception from HRESULT: 0x80131018)
   at System.Reflection.RuntimeAssembly.nLoadFile(String path, Evidence evidence)
   at System.Reflection.Assembly.LoadFile(String path)
   at TechTalk.SpecFlow.VisualStudio.CodeBehindGenerator.CommandLineHandling.PreLoadAssemblies()
   at TechTalk.SpecFlow.VisualStudio.CodeBehindGenerator.CommandLineHandling.PreLoadAssemblies()
   at TechTalk.SpecFlow.VisualStudio.CodeBehindGenerator.Program.Main(String[] args)



Command: c:\users\admin\appdata\local\microsoft\visualstudio\15.0_bb3a19f5\extensions\qtevslrz.xh5\TechTalk.SpecFlow.VisualStudio.CodeBehindGenerator.exe
Parameters: GenerateTestFile --featurefile C:\Users\admin\AppData\Local\Temp\tmp2D2A.tmp --outputdirectory C:\Users\admin\AppData\Local\Temp --projectsettingsfile C:\Users\admin\AppData\Local\Temp\tmp2D1A.tmp
Working Directory: 
