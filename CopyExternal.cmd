echo Copy files from _External ...
copy _External\*.dll _Debug
copy _External\*.dll _Release

copy _External\*.* TPDev.SimpleReport.Viewer\bin\Debug
copy _External\*.* TPDev.SimpleReport.Viewer\bin\Release
copy _External\*.* TestApp\bin\Debug
copy _External\*.* TestApp\bin\Release