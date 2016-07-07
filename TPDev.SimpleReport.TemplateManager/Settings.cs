using System.Collections.Generic;
using TPDev.SimpleReport.SharedLibrary.Models.Template;

namespace TPDev.SimpleReport.TemplateManager
{
    public class Settings
    {
        public static string TemplateLocation { get; set; }

        public static Dictionary<string, SimpleTemplateData> TemplateList { get; set; }
    }
}
