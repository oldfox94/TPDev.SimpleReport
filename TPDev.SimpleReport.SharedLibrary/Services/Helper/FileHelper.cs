using System;
using System.Collections.Generic;
using System.IO;
using TPDev.SimpleReport.Logger.Models;
using TPDev.SimpleReport.SharedLibrary.Context;

namespace TPDev.SimpleReport.SharedLibrary.Services.Helper
{
    public class FileHelper
    {
        public static string StringToFile(string content)
        {
            string fileName = string.Format("tmp_{0}.html", Guid.NewGuid().ToString());
            string filePath = SLContext.CurrentCtx.CacheDirectory;

            return StringToFile(content, fileName, filePath);
        }
        public static string StringToFile(string content, string fileName, string filePath)
        {
            try
            {
                var writer = new StreamWriter(Path.Combine(filePath, fileName), true);
                writer.Write(content);

                writer.Flush();
                writer.Close();
            }
            catch(Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = "FileHelper",
                    FunctionName = "StringToFile Error!",
                    Ex = ex,
                });
            }

            return Path.Combine(filePath, fileName);
        }

        public static string FileToString(string fileName)
        {
            try
            {
                var reader = new StreamReader(fileName);
                var content = reader.ReadToEnd();

                reader.Close();
                return content;
            }
            catch(Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = "FileHelper",
                    FunctionName = "FileToString Error!",
                    Ex = ex,
                });
            }

            return string.Empty;
        }

        public static void CleanupFiles(List<string> files)
        {
            try
            {
                foreach (var file in files)
                {
                    if (File.Exists(file))
                        File.Delete(file);
                }
            }
            catch(Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = "FileHelper",
                    FunctionName = "CleanupFiles Error!",
                    Ex = ex,
                });
            }
        }

        public static void CleanupCacheFiles()
        {
            CleanupCacheFiles(new List<string>());
        }
        public static void CleanupCacheFiles(List<string> excludeFiles)
        {
            try
            {
                foreach (var file in Directory.GetFiles(SLContext.CurrentCtx.CacheDirectory))
                {
                    if (!File.Exists(file)) continue;

                    var fileFound = excludeFiles.Find(x => x == file);
                    if (fileFound != null) continue;

                    File.Delete(file);
                }
            }
            catch(Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = "FileHelper",
                    FunctionName = "CleanupCacheFiles Error!",
                    Ex = ex,
                });
            }
        }
    }
}
