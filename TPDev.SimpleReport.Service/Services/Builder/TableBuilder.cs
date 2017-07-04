using HtmlAgilityPack;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Report;
using TPDev.SimpleReport.SharedLibrary.Models.Report.TableData;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public static class TableBuilder
    {
        public static void BuildTable(HtmlNode node, SimpleContentData data, string tableName)
        {
            foreach(var tblData in data.ListOfTables)
            {
                if (tblData.Table == null) tblData.Table = new DataTable();
                if (tblData.ListOfColumnProperties == null) tblData.ListOfColumnProperties = new List<SimpleColumnProperties>();

                if(tblData.Table.TableName == tableName)
                {
                    BuildHeaders(node, tblData);
                    BuildRows(node, tblData);
                    break;
                }
            }
        }

        private static void BuildHeaders(HtmlNode node, SimpleTableData data)
        {
            var tbl = data.Table;

            var headNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
            headNode.Name = "thead";

            var rowNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
            rowNode.Name = "tr";

            foreach (DataColumn col in tbl.Columns)
            {
                var colNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
                colNode.Name = "th";

                colNode.InnerHtml = string.Format("{0}", col.ColumnName);

                if (!ValidateColumnProbs(col, colNode, data)) continue;
                rowNode.AppendChild(colNode);
            }

            headNode.AppendChild(rowNode);
            node.AppendChild(headNode);
        }

        private static void BuildRows(HtmlNode node, SimpleTableData data)
        {
            var tbl = data.Table;

            foreach(DataRow dr in tbl.Rows)
            {
                var drNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
                drNode.Name = "tr";

                foreach(DataColumn col in tbl.Columns)
                {
                    var colNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
                    colNode.Name = "td";

                    colNode.InnerHtml = string.Format("{0}", dr[col.ColumnName].ToString());

                    if (!ValidateColumnProbs(col, colNode, data)) continue;
                    drNode.AppendChild(colNode);
                }

                node.AppendChild(drNode);
            }
        }

        private static bool ValidateColumnProbs(DataColumn col, HtmlNode colNode, SimpleTableData data)
        {
            var columnProps = data.ListOfColumnProperties.FirstOrDefault(x => x.ColumnName == col.ColumnName);
            if (columnProps != null)
            {
                if (columnProps.IsHidden) return false;
            }

            return true;
        }
    }
}
