echo Merging Binaries ...
"C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe" /ndebug /copyattrs /targetplatform:4.0,"C:\Windows\Microsoft.NET\Framework64\v4.0.30319" /out:Release\TPDev.SimpleReportService.dll Binaries\TPDev.SimpleReport.SharedLibrary.dll Binaries\TPDev.SimpleReport.Logger.dll Binaries\TPDev.SimpleReport.TemplateManager.dll Binaries\TPDev.SimpleReport.Service.dll