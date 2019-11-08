using HtmlAgilityPack;
using System.Linq;
using TPDev.SimpleReport.SharedLibrary.Models.Report;
using TPDev.SimpleReport.SharedLibrary.Models.Report.TableData;

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
                TextBuilder.BuildAttributes(node, data);
                TextBuilder.BuildVariables(node, data);

                switch(node.OriginalName)
                {
                    case "table":
                        TableBuilder.BuildTable(node, data, node.Id);
                        break;

                    case "select":
                        SelectionBuilder.BuildSelections(node, data, node.Id);
                        break;
                }
            }

            var firstHtmlNode = reportData.TemplateData.HtmlNodeList.First();
            return FinishReport(reportData, firstHtmlNode.OuterHtml);
        }

        public string BuildTable(SimpleTableData tableData)
        {
            if (tableData == null) return "TableData ist null!";
            var content = TableBuilder.BuildTable(tableData);
            return content;
        }

        public string FinishReport(SimpleReportData reportData, string content)
        {
            if (reportData.ContentData.ListOfVariables != null)
            {
                //Replace varText with variable content
                foreach (var variable in reportData.ContentData.ListOfVariables)
                {
                    content = content.Replace(variable.Key, variable.Value);
                }
            }
            return content;
        }
    }
}
