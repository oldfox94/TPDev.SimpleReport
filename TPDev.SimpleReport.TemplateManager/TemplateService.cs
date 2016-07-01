using System;
using TPDev.SimpleReport.Logger.Models;
using TPDev.SimpleReport.SharedLibrary;
using TPDev.SimpleReport.SharedLibrary.Models.Template;

namespace TPDev.SimpleReport.TemplateManager
{
    public class TemplateService
    {
        public TemplateService(string templateLocation)
        {
            try
            {
                Settings.TemplateLocation = templateLocation;
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

        public void SaveTemplate(SimpleTemplateData data)
        {
            try
            {

            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "SaveTemplate Error!",
                    Ex = ex,
                });
            }
        }

        public SimpleTemplateData LoadTemplate(string templateName)
        {
            try
            {
                var data = new SimpleTemplateData
                {

                };

                return data;
            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "LoadTemplate Error!",
                    Ex = ex,
                });
            }

            return null;
        }
    }
}
