using HtmlAgilityPack;
using System.Linq;
using TPDev.SimpleReport.SharedLibrary.Models.Report;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public class ReportBuilder
    {
        public string BuildReport(SimpleReportData reportData)
        {
            if (reportData == null) return string.Empty;
            if (reportData.ContentData == null) return string.Empty;

            var data = reportData.ContentData;

            foreach(HtmlNode node in reportData.TemplateData.HtmlNodeList)
            {
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
