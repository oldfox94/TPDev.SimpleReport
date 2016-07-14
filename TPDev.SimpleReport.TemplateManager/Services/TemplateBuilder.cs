using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TPDev.SimpleReport.SharedLibrary;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Template;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;

namespace TPDev.SimpleReport.TemplateManager.Services
{
    public class TemplateBuilder
    {
        public static SimpleTemplateData BuildTemplate(string templateName)
        {
            if (string.IsNullOrEmpty(templateName)) return null;

            var data = new SimpleTemplateData();
            if (Settings.TemplateList.ContainsKey(templateName) && Settings.TemplateList[templateName].FileExists)
                data = Settings.TemplateList[templateName];
            else
            {
                var templateFile = Path.Combine(SLContext.Config.ProjectPath, templateName);
                data = TemplateFileHelper.LoadTemplateFromFile(templateFile);

                if(!data.FileExists)
                {
                    SLLog.WriteWarning("BuildTemplate", "TemplateBuilder", "Template wurde nicht gefunden!");
                    return null;
                }
            }

            CopyStyleToTemplate(data);

            return data;
        }

        public static SimpleTemplateData LoadTemplateFromTemplateData(SimpleTemplateData data)
        {



            return data;
        }

        public static List<SimpleStyleData> LoadStyleFromTemplate(SimpleTemplateData data)
        {
            var styleList = new List<SimpleStyleData>();

            var linkNodeList = data.HtmlNodeList.Where(x => x.OriginalName == "link");
            foreach (HtmlNode node in linkNodeList)
            {
                foreach (HtmlAttribute attr in node.Attributes)
                {
                    if (attr.OriginalName == "rel" && attr.Value == "stylesheet")
                    {
                        var stylePathAttr = node.Attributes.FirstOrDefault(x => x.OriginalName == "href");
                        if (stylePathAttr.Value.StartsWith("http")) break;

                        var styleFilePath = Path.Combine(SLContext.Config.ProjectPath, stylePathAttr.Value);
                        if (!File.Exists(styleFilePath)) break;

                        var styleFileInfo = new FileInfo(styleFilePath);
                        styleList.Add(new SimpleStyleData
                        {
                            Name = Path.GetFileNameWithoutExtension(styleFileInfo.Name),
                            FileName = styleFileInfo.Name,
                            FilePath = styleFileInfo.DirectoryName,
                            Content = FileHelper.FileToString(styleFilePath),
                            Node = node,
                        });
                        break;
                    }
                }
            }

            return styleList;
        }

        public static void CopyStyleToTemplate(SimpleTemplateData data)
        {
            var styleContent = string.Empty;
            foreach(var style in data.StyleFiles)
            {
                styleContent += style.Content + Environment.NewLine;
                style.Node.Remove();
            }

            if (string.IsNullOrEmpty(styleContent)) return;

            var headNode = data.HtmlNodeList.FirstOrDefault(x => x.OriginalName == "head");
            if (headNode == null) return;

            var styleNode = new HtmlNode(HtmlNodeType.Element, headNode.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
            styleNode.Name = "style";
            styleNode.InnerHtml = styleContent;

            headNode.AppendChild(styleNode);
        }
    }
}
