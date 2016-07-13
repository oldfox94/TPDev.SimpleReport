using HtmlAgilityPack;
using System.Data;
using TPDev.SimpleReport.SharedLibrary.Models.Report;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public static class TableBuilder
    {
        public static void BuildTable(HtmlNode node, SimpleReportContentData data, string tableName)
        {
            foreach(var tbl in data.ListOfTables)
            {
                if(tbl.TableName == tableName)
                {
                    //node.AppendChild(new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, 1));
                    Build(node, tbl);
                    break;
                }
            }
        }

        private static void Build(HtmlNode node, DataTable tbl)
        {
            foreach(DataRow dr in tbl.Rows)
            {
                var drHtml = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, 1);
                drHtml.InnerHtml = "<tr></tr>";

                foreach(DataColumn col in tbl.Columns)
                {
                    var colHtml = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, 1);
                    colHtml.InnerHtml = string.Format("<td>{0}</td>", dr[col.ColumnName].ToString());

                    drHtml.AppendChild(colHtml);
                }

                node.AppendChild(drHtml);
            }
        }
    }
}
