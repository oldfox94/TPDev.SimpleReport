using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;

namespace TPDev.SimpleReport.SharedLibrary.Models.Template
{
    public class SimpleTemplateData
    {
        public string Name { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool FileExists { get { return File.Exists(Path.Combine(FilePath, FileName)); } }

        public IEnumerable<HtmlNode> HtmlNodeList { get; set; }
    }
}
