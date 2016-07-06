echo Building Project [Viewer] ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SimpleReport.Viewer\TPDev.SimpleReport.Viewer.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild

echo Copy to Release
copy Binaries\TPDev.SimpleReport.Viewer.dll Release\TPDev.SimpleReportViewer.dll