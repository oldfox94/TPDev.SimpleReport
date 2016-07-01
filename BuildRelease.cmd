echo Copy files from _External ...
copy _External\*.* Release
copy _External\*.* TPDev.SimpleReport.Viewer\bin\Debug
copy _External\*.* TPDev.SimpleReport.Viewer\bin\Release
REM copy SQLiteLibrary\SQLite.Interop.dll DbFactory\bin\Release
REM copy MySQLLibrary\bin\Release\MySql.Data.dll DbFactory\bin\Release
REM copy MySQLLibrary\bin\Release\MySql.Data.Entity.EF5.dll DbFactory\bin\Release
REM copy MySQLLibrary\bin\Release\MySql.Data.Entity.EF6.dll DbFactory\bin\Release
REM copy MySQLLibrary\bin\Release\MySql.Fabric.Plugin.dll DbFactory\bin\Release


echo Building Project [Service] ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.SharedLibrary\TPDev.SimpleReport.SharedLibrary.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Logger\TPDev.SimpleReport.Logger.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.TemplateManager\TPDev.SimpleReport.TemplateManager.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Service\TPDev.SimpleReport.Service.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild


echo Cleanup Release folder ...
del Release\*.*  /s /q


echo Merging Binaries ...
"C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe" /ndebug /copyattrs /targetplatform:4.0,"C:\Windows\Microsoft.NET\Framework64\v4.0.30319" /out:Release\TPDev.SimpleReportService.dll Binaries\TPDev.SimpleReport.SharedLibrary.dll Binaries\TPDev.SimpleReport.Logger.dll Binaries\TPDev.SimpleReport.TemplateManager.dll Binaries\TPDev.SimpleReport.Service.dll


echo Building Project [Viewer] ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Viewer\TPDev.SimpleReport.Viewer.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild

echo Copy to Release
copy Binaries\TPDev.SimpleReport.Viewer.dll Release\TPDev.SimpleReportViewer.dll

echo finished!
pause