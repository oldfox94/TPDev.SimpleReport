using HtmlAgilityPack;
using TPDev.SimpleReport.SharedLibrary.Models.Report;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public class TextBuilder
    {
        public static void BuildTexts(HtmlNode node, SimpleContentData data)
        {
            if(data.ListOfTexts.ContainsKey(node.Id))
            {
                node.InnerHtml = data.ListOfTexts[node.Id];
            }
        }
    }
}
