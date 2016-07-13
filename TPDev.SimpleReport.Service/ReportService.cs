using System;
using TPDev.SimpleReport.Logger.Models;
using TPDev.SimpleReport.Service.Services.Builder;
using TPDev.SimpleReport.SharedLibrary;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Report;
using TPDev.SimpleReport.TemplateManager;

namespace TPDev.SimpleReport.Service
{
    public class ReportService
    {
        public TemplateService Templater { get; set; }
        public ReportService()
        {
            try
            {
                Bootstrapper.Boot();

                Templater = new TemplateService(SLContext.Config.ProjectPath);
            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "Init ReportService Error!",
                    Ex = ex,
                });
            }
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

        public SimpleReportPrintData CreateReport(SimpleReportData reportData)
        {
            var data = new SimpleReportPrintData();

            var builder = new ReportBuilder();
            data.HtmlContent = builder.BuildReport(reportData);

            return data;
        }
    }
}
