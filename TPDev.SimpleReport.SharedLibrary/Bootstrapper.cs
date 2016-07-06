using System;
using System.IO;
using TPDev.SimpleReport.SharedLibrary.Context;

namespace TPDev.SimpleReport.SharedLibrary
{
    public class Bootstrapper
    {
        public static void Boot()
        {
            SLContext.CurrentCtx = new CurrentContext();

            SLContext.CurrentCtx.WorkingDirectory = Environment.CurrentDirectory;
            SLContext.CurrentCtx.TempDirectory = Path.Combine(SLContext.CurrentCtx.WorkingDirectory, "Temp");
            SLContext.CurrentCtx.CacheDirectory = Path.Combine(SLContext.CurrentCtx.TempDirectory, "Cache");

            CheckFolders();
        }

        public static void Shutdown()
        {
            ClearFolders();
        }


        private static void CheckFolders()
        {
            if (!Directory.Exists(SLContext.CurrentCtx.TempDirectory))
                Directory.CreateDirectory(SLContext.CurrentCtx.TempDirectory);

            if (!Directory.Exists(SLContext.CurrentCtx.CacheDirectory))
                Directory.CreateDirectory(SLContext.CurrentCtx.CacheDirectory);
        }

        private static void ClearFolders()
        {
            if (Directory.Exists(SLContext.CurrentCtx.TempDirectory))
                Directory.Delete(SLContext.CurrentCtx.TempDirectory, true);
        }
    }
}
