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
            var cnt = 1;
            foreach(DataRow dr in tbl.Rows)
            {
                var drHtml = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, cnt);
                drHtml.Name = "tr";

                cnt++;

                foreach(DataColumn col in tbl.Columns)
                {
                    var colHtml = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, cnt);
                    colHtml.Name = "td";

                    colHtml.InnerHtml = string.Format("{0}", dr[col.ColumnName].ToString());

                    drHtml.AppendChild(colHtml);

                    cnt++;
                }

                node.AppendChild(drHtml);
            }
        }
    }
}
