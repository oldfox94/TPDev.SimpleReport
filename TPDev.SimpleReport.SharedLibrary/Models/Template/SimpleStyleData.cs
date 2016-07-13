using System.IO;

namespace TPDev.SimpleReport.SharedLibrary.Models.Template
{
    public class SimpleStyleData
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool FileExists { get { return File.Exists(Path.Combine(FilePath, FileName)); } }
    }
}
