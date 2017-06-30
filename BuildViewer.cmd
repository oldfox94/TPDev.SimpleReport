echo Building Project [Viewer] ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Viewer\TPDev.SimpleReport.Viewer.csproj /p:Configuration=Release;OutputPath=..\_Binaries /t:Rebuild

echo Copy to Release
copy _Binaries\TPDev.SimpleReport.Viewer.dll _Release\TPDev.SimpleReport.Viewer.dll