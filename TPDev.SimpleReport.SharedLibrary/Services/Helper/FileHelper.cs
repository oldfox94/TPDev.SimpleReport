using System;
using System.Collections.Generic;
using System.IO;
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
            var writer = new StreamWriter(Path.Combine(filePath, fileName), true);
            writer.Write(content);

            writer.Flush();
            writer.Close();

            return Path.Combine(filePath, fileName);
        }

        public static void CleanupFiles(List<string> files)
        {
            foreach(var file in files)
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
        }

        public static void CleanupCacheFiles()
        {
            CleanupCacheFiles(new List<string>());
        }
        public static void CleanupCacheFiles(List<string> excludeFiles)
        {
            foreach(var file in Directory.GetFiles(SLContext.CurrentCtx.CacheDirectory))
            {
                if (!File.Exists(file)) continue;

                var fileFound = excludeFiles.Find(x => x == file);
                if (fileFound != null) continue;

                File.Delete(file);
            }
        }
    }
}
