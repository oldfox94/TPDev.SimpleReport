using System.IO;
using TPDev.SimpleReport.SharedLibrary.Models.Template;

namespace TPDev.SimpleReport.TemplateManager.Services
{
    public class TemplateValidator
    {
        public static string ValidateTemplate(SimpleTemplateData template)
        {
            if (string.IsNullOrEmpty(Settings.TemplateLocation)) return "TemplateLocation not set!";
            if (Directory.Exists(Settings.TemplateLocation)) return string.Format("No directory '{0}' found!", Settings.TemplateLocation);

            if (template == null) return "TemplateData is null!";

            if (string.IsNullOrEmpty(template.Name)) return "Templatename is null or empty!";

            return string.Empty;
        }
    }
}
