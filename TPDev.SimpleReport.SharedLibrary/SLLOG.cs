using System;
using TPDev.SimpleReport.Logger.Models;
using logger = TPDev.SimpleReport.Logger.Logger;

namespace TPDev.SimpleReport.SharedLibrary
{
    public class SLLog
    {
        public static logger Logger { get; set; }

        public static void WriteInfo(string function, string message, bool onlyBallonTipp = false)
        {
            if (Logger == null)
                Logger = new logger(Environment.CurrentDirectory, "SimpleReport");

            var data = new LogData
            {
                FunctionName = function,
                Message = message,
            };

            Logger.WriteInfo(data, onlyBallonTipp);
        }

        public static void WriteWarning(string function, string source, string message)
        {
            if (Logger == null)
                Logger = new logger(Environment.CurrentDirectory, "SimpleReport");

            var data = new LogData
            {
                FunctionName = function,
                Source = source,
                Message = message,
            };

            Logger.WriteWarnng(data);
        }

        public static void WriteError(LogData data)
        {
            if (Logger == null)
                Logger = new logger(Environment.CurrentDirectory, "SimpleReport");

            Logger.WriteError(data);
        }
    }
}
