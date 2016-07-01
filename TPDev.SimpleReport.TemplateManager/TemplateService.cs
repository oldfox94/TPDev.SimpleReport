using System;
using TPDev.SimpleReport.Logger.Models;
using TPDev.SimpleReport.SharedLibrary;

namespace TPDev.SimpleReport.TemplateManager
{
    public class TemplateService
    {
        public TemplateService()
        {
            try
            {

            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "Init TemplateService Error!",
                    Ex = ex,
                });
            }
        }

        public void InitLogger(string logFileName, string logPath = null)
        {
            if (string.IsNullOrEmpty(logPath))
                logPath = Environment.CurrentDirectory;

            SLLog.Logger = new Logger.Logger(logPath, logFileName, "SimpleReport.TemplateService");
            SLLog.WriteInfo("InitLogger", "Logger successfully initialized!");
        }
    }
}
