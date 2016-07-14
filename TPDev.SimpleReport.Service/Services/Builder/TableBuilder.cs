using HtmlAgilityPack;
using System.Data;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Report;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public static class TableBuilder
    {
        public static void BuildTable(HtmlNode node, SimpleContentData data, string tableName)
        {
            foreach(var tbl in data.ListOfTables)
            {
                if(tbl.TableName == tableName)
                {
                    BuildHeaders(node, tbl);
                    BuildRows(node, tbl);
                    break;
                }
            }
        }

        private static void BuildHeaders(HtmlNode node, DataTable tbl)
        {
            var headNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
            headNode.Name = "thead";

            var rowNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
            rowNode.Name = "tr";

            foreach (DataColumn col in tbl.Columns)
            {
                var colNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
                colNode.Name = "th";

                colNode.InnerHtml = string.Format("{0}", col.ColumnName);

                rowNode.AppendChild(colNode);
            }

            headNode.AppendChild(rowNode);
            node.AppendChild(headNode);
        }

        private static void BuildRows(HtmlNode node, DataTable tbl)
        {
            foreach(DataRow dr in tbl.Rows)
            {
                var drNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
                drNode.Name = "tr";

                foreach(DataColumn col in tbl.Columns)
                {
                    var colNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
                    colNode.Name = "td";

                    colNode.InnerHtml = string.Format("{0}", dr[col.ColumnName].ToString());

                    drNode.AppendChild(colNode);
                }

                node.AppendChild(drNode);
            }
        }
    }
}
