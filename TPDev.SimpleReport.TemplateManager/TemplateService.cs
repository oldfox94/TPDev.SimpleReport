using System;
using TPDev.SimpleReport.Logger.Models;
using TPDev.SimpleReport.SharedLibrary;
using TPDev.SimpleReport.SharedLibrary.Models.Template;
using TPDev.SimpleReport.TemplateManager.Services;

namespace TPDev.SimpleReport.TemplateManager
{
    public class TemplateService
    {
        public TemplateService(string templateLocation)
        {
            try
            {
                Settings.TemplateLocation = templateLocation;
                Settings.TemplateList = TemplateFileHelper.BuildTemplateList();


            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "Init TemplateService Error!",
                    Ex = ex,
                });
            }
        }

        public void SaveTemplate(SimpleTemplateData data)
        {
            try
            {

            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "SaveTemplate Error!",
                    Ex = ex,
                });
            }
        }

        public SimpleTemplateData LoadTemplate(string templateName)
        {
            try
            {
                if (Settings.TemplateList.ContainsKey(templateName) && Settings.TemplateList[templateName].FileExists)
                    return Settings.TemplateList[templateName];
                else
                    SLLog.WriteWarning("LoadTemplate", ToString(), "Template wurde nicht gefunden!");
            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "LoadTemplate Error!",
                    Ex = ex,
                });
            }

            return null;
        }
    }
}
