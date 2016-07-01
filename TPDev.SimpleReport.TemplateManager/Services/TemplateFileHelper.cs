using System.IO;
using TPDev.SimpleReport.SharedLibrary.Models.Template;

namespace TPDev.SimpleReport.TemplateManager.Services
{
    public class TemplateFileHelper
    {
        public static string SaveTemplate(SimpleTemplateData template)
        {
            var validationResult = TemplateValidator.ValidateTemplate(template);
            if (!string.IsNullOrEmpty(validationResult)) return validationResult;

            var templatePath = Path.Combine(Settings.TemplateLocation, template.Name);
            if (!Directory.Exists(templatePath))
                Directory.CreateDirectory(templatePath);



            return string.Empty;
        }


    }
}
