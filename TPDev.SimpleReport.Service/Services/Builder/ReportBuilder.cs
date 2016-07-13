using HtmlAgilityPack;
using TPDev.SimpleReport.SharedLibrary.Models.Report;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public class ReportBuilder
    {
        public void BuildReport(SimpleReportData reportData)
        {
            if (reportData == null) return;
            if (reportData.ContentData == null) return;

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

        }
    }
}
