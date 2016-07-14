using HtmlAgilityPack;
using System.Linq;
using TPDev.SimpleReport.SharedLibrary.Models.Report;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public class ReportBuilder
    {
        public string BuildReport(SimpleReportData reportData)
        {
            if (reportData == null) return "ReportData ist null!";
            if (reportData.TemplateData == null) return "Template wurde nicht definiert!";
            if (reportData.ContentData == null) return "ContentData ist null!";

            var data = reportData.ContentData;

            foreach(HtmlNode node in reportData.TemplateData.HtmlNodeList)
            {
                TextBuilder.BuildTexts(node, data);

                switch(node.OriginalName)
                {
                    case "table":
                        TableBuilder.BuildTable(node, data, node.Id);
                        break;
                }
            }

            var firstHtmlNode = reportData.TemplateData.HtmlNodeList.First();
            return firstHtmlNode.OuterHtml;
        }
    }
}
