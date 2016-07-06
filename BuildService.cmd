echo Building Project [Service] ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.SharedLibrary\TPDev.SimpleReport.SharedLibrary.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Logger\TPDev.SimpleReport.Logger.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.TemplateManager\TPDev.SimpleReport.TemplateManager.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Service\TPDev.SimpleReport.Service.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild

call MergeService.cmd