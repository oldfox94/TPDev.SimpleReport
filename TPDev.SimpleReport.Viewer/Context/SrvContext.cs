using System.Collections.Generic;
using TPDev.SimpleReport.SharedLibrary.Models.Viewer;

namespace TPDev.SimpleReport.Viewer.Context
{
    public class SrvContext
    {
        public static SimpleViewerData ViewerData { get; set; }

        public static List<string> CleanupFiles { get; set; }
    }
}
