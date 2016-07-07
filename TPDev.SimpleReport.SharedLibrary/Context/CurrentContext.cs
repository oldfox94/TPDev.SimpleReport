namespace TPDev.SimpleReport.SharedLibrary.Context
{
    public class CurrentContext
    {
        public string WorkingDirectory { get; set; }
        public string LogDirectory { get; set; }
        public string TempDirectory { get; set; }
        public string CacheDirectory { get; set; }

        public string ConfigPath { get; set; }
        public string ConfigFileName { get; set; }
    }
}
