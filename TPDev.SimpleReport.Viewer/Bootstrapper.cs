using CefSharp;
using System.Collections.Generic;
using TPDev.SimpleReport.SharedLibrary.Models.Viewer;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;
using TPDev.SimpleReport.Viewer.Context;

namespace TPDev.SimpleReport.Viewer
{
    public class Bootstrapper
    {
        public static void Boot()
        {
            if (SharedLibrary.Context.SLContext.IsViewerInitialized) return;

            SharedLibrary.Bootstrapper.Boot();

            SrvContext.ViewerData = new SimpleViewerData();
            SrvContext.CleanupFiles = new List<string>();

            //var settings = new CefSettings();
            //settings.LogSeverity = LogSeverity.Verbose;

            //Cef.Initialize(settings);
        }

        public static void Shutdown()
        {
            Cef.Shutdown();
            FileHelper.CleanupFiles(SrvContext.CleanupFiles);

            SharedLibrary.Bootstrapper.Shutdown();
        }
    }
}
