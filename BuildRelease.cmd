echo Cleanup Release folder ...
del _Binaries\*.* /s /q
del _Release\*.*  /s /q

call CopyExternal.cmd

echo Building Project [Service] ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.SharedLibrary\TPDev.SimpleReport.SharedLibrary.csproj /p:Configuration=Release;OutputPath=..\_Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Logger\TPDev.SimpleReport.Logger.csproj /p:Configuration=Release;OutputPath=..\_Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.TemplateManager\TPDev.SimpleReport.TemplateManager.csproj /p:Configuration=Release;OutputPath=..\_Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Service\TPDev.SimpleReport.Service.csproj /p:Configuration=Release;OutputPath=..\_Binaries /t:Rebuild

echo Merging Binaries ...
"C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe" /ndebug /copyattrs /targetplatform:4.0,"C:\Windows\Microsoft.NET\Framework64\v4.0.30319" /out:_Release\TPDev.SimpleReportService.dll _Binaries\TPDev.SimpleReport.SharedLibrary.dll _Binaries\TPDev.SimpleReport.Logger.dll _Binaries\TPDev.SimpleReport.TemplateManager.dll _Binaries\TPDev.SimpleReport.Service.dll


echo Building Project [Viewer] ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Viewer\TPDev.SimpleReport.Viewer.csproj /p:Configuration=Release;OutputPath=..\_Binaries /t:Rebuild

echo Copy to Release
copy _Binaries\TPDev.SimpleReport.Viewer.dll _Release\TPDev.SimpleReport.Viewer.dll

echo finished!
pause