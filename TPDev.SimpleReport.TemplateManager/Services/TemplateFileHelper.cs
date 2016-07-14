using System.Collections.Generic;
using System.IO;
using TPDev.SimpleReport.SharedLibrary.Models.Template;
using TPDev.SimpleReport.SharedLibrary.Services.Viewer;

namespace TPDev.SimpleReport.TemplateManager.Services
{
    public class TemplateFileHelper
    {
        public static Dictionary<string, SimpleTemplateData> BuildTemplateList()
        {
            var templateList = new Dictionary<string, SimpleTemplateData>();

            if(!Directory.Exists(Settings.TemplateLocation))
            {
                return templateList;
            }

            var files = Directory.GetFiles(Settings.TemplateLocation);
            foreach(var file in files)
            {
                var fileInf = new FileInfo(file);
                if(fileInf.Extension == ".srtpl")
                {
                    var templateData = LoadTemplateFromFile(file);
                    templateData.StyleFiles = TemplateBuilder.LoadStyleFromTemplate(templateData);

                    templateList.Add(templateData.Name, templateData);
                }
            }

            return templateList;
        }

        public static SimpleTemplateData LoadTemplateFromFile(string file)
        {
            var fileInf = new FileInfo(file);

            var templateData = new SimpleTemplateData { Name = Path.GetFileNameWithoutExtension(fileInf.Name), FileName = fileInf.Name, FilePath = fileInf.DirectoryName };
            templateData.HtmlNodeList = HtmlHelper.ParseHtml(file);

            return templateData;
        }     

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
