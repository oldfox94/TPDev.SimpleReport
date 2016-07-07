using TPDev.SimpleReport.SharedLibrary.Models.Global;

namespace TPDev.SimpleReport.SharedLibrary.Events
{
    public class SLEvents
    {
        public delegate void SimpleEventHandler(SimpleEventArgs args);

        public static event SimpleEventHandler LoadReport;

        public static void FireLoadReport(SimpleEventArgs args)
        {
            if (LoadReport != null) LoadReport(args);
        }
    }
}
