using System;

namespace TPDev.SimpleReport.Logger.Models
{
    public class LogData
    {
        public LogType Type { get; set; }

        public DateTime ExDate { get; set; }

        public string FunctionName { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }

        public Exception Ex { get; set; }

        public bool IsInLogFile { get; set; }
    }
}
