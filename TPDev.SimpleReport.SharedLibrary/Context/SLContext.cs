﻿using TPDev.SimpleReport.SharedLibrary.Models.Global;

namespace TPDev.SimpleReport.SharedLibrary.Context
{
    public static class SLContext
    {
        public static CurrentContext CurrentCtx { get; set; }

        public static SimpleReportConfigData Config { get { return SLConfig.ReadConfig(); } set { SLConfig.WriteConfig(value); } }

        public static bool IsViewerInitialized { get; set; }
        public static bool IsServiceInitialized { get; set; }
    }
}
