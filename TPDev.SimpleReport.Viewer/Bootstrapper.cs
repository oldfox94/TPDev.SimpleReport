using CefSharp;

namespace TPDev.SimpleReport.Viewer
{
    public class Bootstrapper
    {
        public static void Boot()
        {
            if (SharedLibrary.Context.SLContext.IsViewerInitialized) return;

            SharedLibrary.Bootstrapper.Boot();

            var settings = new CefSettings();
            settings.LogSeverity = LogSeverity.Verbose;

            Cef.Initialize(settings);
        }

        public static void Shutdown()
        {
            Cef.Shutdown();

            SharedLibrary.Bootstrapper.Shutdown();
        }
    }
}
