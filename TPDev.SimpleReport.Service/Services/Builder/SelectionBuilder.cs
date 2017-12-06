using HtmlAgilityPack;
using System.Linq;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Report;
using TPDev.SimpleReport.SharedLibrary.Models.Report.SelectionData;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public class SelectionBuilder
    {
        public static void BuildSelections(HtmlNode node, SimpleContentData data, string id)
        {
            if (data.ListOfSelections == null) return;

            var selection = data.ListOfSelections.FirstOrDefault(x => x.Id == id);
            if (selection == null) return;

            BuildSelection(node, selection);
        }

        private static void BuildSelection(HtmlNode node, SimpleSelectionData selectionData)
        {
            if (selectionData == null) return;

            var parentNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
            foreach (var choice in selectionData.Choices)
            {
                var colNode = new HtmlNode(HtmlNodeType.Element, node.OwnerDocument, SLContext.CurrentCtx.TemplateNodeId);
                colNode.Name = "option";

                colNode.SetAttributeValue("value", choice.Value);
                colNode.InnerHtml = string.Format("{0}", choice.DisplayValue);

                parentNode.AppendChild(colNode);
            }

            node.AppendChild(parentNode);
        }
    }
}