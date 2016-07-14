echo Copy files from _External ...
copy _External\*.dll Release
copy _External\*.pak Release
copy _External\*.exe Release
copy _External\*.dat Release
copy _External\*.bin Release
copy _External\locales\*.* Release\locales

copy _External\*.* TPDev.SimpleReport.Viewer\bin\x86\Debug
copy _External\*.* TPDev.SimpleReport.Viewer\bin\x86\Release
copy _External\*.* TestApp\bin\Debug