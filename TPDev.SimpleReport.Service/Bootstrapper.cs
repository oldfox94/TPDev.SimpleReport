using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Global;

namespace TPDev.SimpleReport.Service
{
    public class Bootstrapper
    {
        public static void Boot(SimpleReportConfigData configData)
        {
            if (SLContext.IsServiceInitialized) return;

            SharedLibrary.Bootstrapper.Boot(configData, AppName.Reporter);
        }

        public static void Shutdown()
        {

            SharedLibrary.Bootstrapper.Shutdown(AppName.Reporter);
        }
    }
}
