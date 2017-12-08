using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TPDev.SimpleReport.Logger.Events;
using TPDev.SimpleReport.Logger.Models;

namespace TPDev.SimpleReport.Logger
{
    public class Logger
    {
        private List<LogData> m_LogDataList { get; set; }
        public Logger(string logPath, string logFileName, string logId = "NoId")
        {
            m_LogDataList = new List<LogData>();

            Settings.LogId = logId;
            Settings.LogFile = Path.Combine(logPath, logFileName + ".log");
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            SLLogEvents.ShowLogFile += OnShowLogFile;
        }

        private void OnShowLogFile(SLLogEventArgs args)
        {
            if (!File.Exists(Settings.LogFile)) return;
            Process.Start(Settings.LogFile);
        }

        public void WriteInfo(LogData data, bool onlyToolTipp = false)
        {
            data.Type = LogType.Info;
            data.ExDate = DateTime.Now;

            CreateBallonTipp(data);
            if (!onlyToolTipp)
            {
                m_LogDataList.Add(data);
                LogToFile();
            }
        }

        public void WriteWarnng(LogData data)
        {
            data.Type = LogType.Warning;
            data.ExDate = DateTime.Now;

            m_LogDataList.Add(data);
            CreateBallonTipp(data);

            LogToFile();
        }

        public void WriteError(LogData data)
        {
            data.Type = LogType.Error;
            data.ExDate = DateTime.Now;

            if (data.Ex != null)
            {
                data.StackTrace = data.Ex.StackTrace;
                data.Message = data.Ex.Message;
            }

            m_LogDataList.Add(data);
            CreateBallonTipp(data);

            LogToFile();
        }

        private void CreateBallonTipp(LogData data)
        {
            var title = string.Empty;

            SLLogEvents.FireShowBallonTipp(new SLLogEventArgs { Type = data.Type, Titel = "SimpleReport " + data.Type.ToString() + "!", LogMessage = data.Message });
        }

        private void LogToFile()
        {
            foreach (var logEntry in m_LogDataList)
            {
                if (logEntry.IsInLogFile) continue;

                var line = string.Empty;
                try
                {
                    switch (logEntry.Type)
                    {
                        case LogType.Info:
                            line = string.Format(@"[Info]{1} => {2}: {0}Function: {3} {0}Message: {4}{0}{0}",
                                    Environment.NewLine, Settings.LogId, logEntry.ExDate.ToString(), logEntry.FunctionName, logEntry.Message);
                            break;

                        case LogType.Warning:
                            line = string.Format(@"[Warning]{1} => {2}: {0}Function: {3} {0}Source: {4} {0}Message: {5}{0}{0}",
                                    Environment.NewLine, Settings.LogId, logEntry.ExDate.ToString(), logEntry.FunctionName, logEntry.Source, logEntry.Message);
                            break;

                        case LogType.Error:
                            line = string.Format(@"[Error]{1} => {2}: {0}Function: {3} {0}Source: {4} {0}Message: {5} {0}StackTrace: {6}{0}{0}",
                                    Environment.NewLine, Settings.LogId, logEntry.ExDate.ToString(), logEntry.FunctionName, logEntry.Source, logEntry.Message,
                                    logEntry.StackTrace);
                            break;
                    }

                    WriteAsync(Settings.LogFile, line);
                    logEntry.IsInLogFile = true;
                }
                catch (Exception)
                {

                    logEntry.IsInLogFile = false;
                }
            }
        }

        private ReaderWriterLock locker = new ReaderWriterLock();
        private void WriteAsync(string path, string line)
        {
            locker.AcquireWriterLock(int.MaxValue);
            File.AppendAllLines(path, new[] { line });
        }
    }
}
