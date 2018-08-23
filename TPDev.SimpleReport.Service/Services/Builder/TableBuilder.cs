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
            if (data.ListOfTables == null) return;

            var tblData = data.ListOfTables.FirstOrDefault(x => x.Table.TableName == tableName);
            if (tblData == null) return;

            if (tblData.ListOfColumnProperties == null) tblData.ListOfColumnProperties = new List<SimpleColumnProperties>();
            if(tblData.Table.TableName == tableName)
            {
                ArrangeColumns(tblData.Table, tblData.ListOfColumnProperties);
                if(!tblData.HeaderAlreadyExists)
                    BuildHeaders(node, tblData);

                BuildRows(node, tblData);
            }
        }

        private static void ArrangeColumns(DataTable tbl, List<SimpleColumnProperties> columnProperties)
        {
            if (tbl == null) return;
            if (columnProperties == null) return;

            int columnIndex = 0;
            foreach(var colProp in columnProperties.OrderBy(x => x.SortOrder))
            {
                if (!tbl.Columns.Contains(colProp.ColumnName)) continue;
                tbl.Columns[colProp.ColumnName].SetOrdinal(columnIndex);
                columnIndex++;
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
                var colProps = GetColumnProps(data, col);
                var colNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
                colNode.Name = "th";

                colNode.InnerHtml = string.Format("{0}", colProps.DisplayName);

                if (colProps.IsHidden) continue;
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

                    if (GetColumnIsHidden(data, col)) continue;
                    drNode.AppendChild(colNode);
                }

                node.AppendChild(drNode);
            }
        }

        private static bool GetColumnIsHidden(SimpleTableData data, DataColumn col)
        {
            return GetColumnProps(data, col).IsHidden;
        }
        private static SimpleColumnProperties GetColumnProps(SimpleTableData data, DataColumn col)
        {
            var columnProps = data.ListOfColumnProperties.FirstOrDefault(x => x.ColumnName == col.ColumnName);
            return columnProps != null ? columnProps : new SimpleColumnProperties { ColumnName = col.ColumnName, DisplayName = col.ColumnName };
        }
    }
}
