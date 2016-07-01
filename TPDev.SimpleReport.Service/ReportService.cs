using System;
using TPDev.SimpleReport.Logger.Models;
using TPDev.SimpleReport.SharedLibrary;

namespace TPDev.SimpleReport.Service
{
    public class ReportService
    {
        public ReportService()
        {
            try
            {

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
                logPath = Environment.CurrentDirectory;

            SLLog.Logger = new Logger.Logger(logPath, logFileName, "SimpleReport.ReportService");
            SLLog.WriteInfo("InitLogger", "Logger successfully initialized!");
        }
    }
}
