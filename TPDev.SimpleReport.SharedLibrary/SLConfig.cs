using System;
using TPDev.SimpleReport.Logger.Models;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Global;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;

namespace TPDev.SimpleReport.SharedLibrary
{
    public class SLConfig
    {
        public static SimpleReportConfigData ReadConfig()
        {
            var config = new SimpleReportConfigData();

            try
            {
                var xml = new XmlHelper(SLContext.CurrentCtx.ConfigPath);
                config = xml.Read<SimpleReportConfigData>(SLContext.CurrentCtx.ConfigFileName);
            }
            catch(Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = "SLConfig",
                    FunctionName = "ReadConfig Error!",
                    Ex = ex,
                });
            }

            return config;
        }

        public static void WriteConfig(SimpleReportConfigData data)
        {
            try
            {
                var xml = new XmlHelper(SLContext.CurrentCtx.ConfigPath);
                xml.Write(data, SLContext.CurrentCtx.ConfigFileName);
            }
            catch(Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = "SLConfig",
                    FunctionName = "WriteConfig Error!",
                    Ex = ex,
                });
            }
        }
    }
}
