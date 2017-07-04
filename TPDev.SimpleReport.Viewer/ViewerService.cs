using TPDev.SimpleReport.SharedLibrary;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Events;
using TPDev.SimpleReport.SharedLibrary.Models.Global;
using TPDev.SimpleReport.SharedLibrary.Models.Report;

namespace TPDev.SimpleReport.Viewer
{
    public class ViewerService
    {
        public ViewerService(SimpleReportConfigData configData)
        {
            Bootstrapper.Boot(configData);
        }

        public void InitLogger(string logFileName, string logPath = null)
        {
            if (string.IsNullOrEmpty(logPath))
                logPath = SLContext.CurrentCtx.LogDirectory;
            else
                SLContext.CurrentCtx.LogDirectory = logPath;

            SLLog.Logger = new Logger.Logger(logPath, logFileName, "SimpleReport.ReportService");
            SLLog.WriteInfo("InitLogger", "Logger successfully initialized!");
        }

        public void Shutdown()
        {
            Bootstrapper.Shutdown();
        }

        public void LoadReport(SimplePrintData reportPrintData)
        {

            SLEvents.FireLoadReport(new SimpleEventArgs { HtmlContent = reportPrintData.HtmlContent });
        }
    }
}
