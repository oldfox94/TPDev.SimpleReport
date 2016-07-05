using TPDev.SimpleReport.SharedLibrary.Context;

namespace TPDev.SimpleReport.SharedLibrary
{
    public class Bootstrapper
    {
        public static void Boot()
        {
            SLContext.CurrentCtx = new CurrentContext();
        }

        public static void Shutdown()
        {

        }
    }
}
