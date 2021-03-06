﻿using System;
using System.IO;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Global;

namespace TPDev.SimpleReport.SharedLibrary
{
    public class Bootstrapper
    {
        public static void Boot(SimpleReportConfigData configData, AppName appName)
        {
            if (SLContext.CurrentCtx != null) return;
            SLContext.CurrentCtx = new CurrentContext();

            SLContext.Config = configData;
            if (SLContext.Config == null || string.IsNullOrEmpty(SLContext.Config.ProjectPath))
                SLContext.Config = new SimpleReportConfigData { ProjectPath = Path.Combine(SLContext.CurrentCtx.WorkingDirectory, "Projects") };

            if (string.IsNullOrEmpty(SLContext.Config.TempPath))
                SLContext.Config.TempPath = Path.Combine(SLContext.CurrentCtx.WorkingDirectory, "Temp");


            CheckFolders();

            switch(appName)
            {
                case AppName.Reporter:
                    break;

                case AppName.Viewer:
                    break;

                case AppName.Templater:
                    break;
            }
        }

        public static void Shutdown(AppName appName)
        {
            ClearTempFolders();

            switch (appName)
            {
                case AppName.Reporter:
                    break;

                case AppName.Viewer:
                    break;

                case AppName.Templater:
                    break;
            }
        }


        private static void CheckFolders()
        {
            SLContext.CurrentCtx.WorkingDirectory = Environment.CurrentDirectory;
            SLContext.CurrentCtx.LogDirectory = Path.Combine(SLContext.CurrentCtx.WorkingDirectory, "Log");
            SLContext.CurrentCtx.TempDirectory = SLContext.Config.TempPath;
            SLContext.CurrentCtx.CacheDirectory = Path.Combine(SLContext.CurrentCtx.TempDirectory, "Cache");

            if (!Directory.Exists(SLContext.CurrentCtx.TempDirectory))
                Directory.CreateDirectory(SLContext.CurrentCtx.TempDirectory);

            if (!Directory.Exists(SLContext.CurrentCtx.CacheDirectory))
                Directory.CreateDirectory(SLContext.CurrentCtx.CacheDirectory);

            if (!Directory.Exists(SLContext.Config.ProjectPath))
                Directory.CreateDirectory(SLContext.Config.ProjectPath);
        }

        private static void ClearTempFolders()
        {
            if (Directory.Exists(SLContext.CurrentCtx.TempDirectory))
                Directory.Delete(SLContext.CurrentCtx.TempDirectory, true);
        }
    }
}
