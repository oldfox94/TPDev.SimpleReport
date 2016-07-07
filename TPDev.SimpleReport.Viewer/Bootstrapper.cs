using CefSharp;
using System.Collections.Generic;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Global;
using TPDev.SimpleReport.SharedLibrary.Models.Viewer;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;
using TPDev.SimpleReport.Viewer.Context;

namespace TPDev.SimpleReport.Viewer
{
    public class Bootstrapper
    {
        public static void Boot()
        {
            if (SLContext.IsViewerInitialized) return;

            SharedLibrary.Bootstrapper.Boot(AppName.Viewer);

            SrvContext.ViewerData = new SimpleViewerData();
            SrvContext.CleanupFiles = new List<string>();


            SLContext.IsViewerInitialized = true;
        }

        public static void Shutdown()
        {
            Cef.Shutdown();
            FileHelper.CleanupFiles(SrvContext.CleanupFiles);

            SharedLibrary.Bootstrapper.Shutdown(AppName.Viewer);
        }
    }
}
