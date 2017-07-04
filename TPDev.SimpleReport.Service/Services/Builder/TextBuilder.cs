using HtmlAgilityPack;
using System.Collections.Generic;
using TPDev.SimpleReport.SharedLibrary.Models.Report;

namespace TPDev.SimpleReport.Service.Services.Builder
{
    public class TextBuilder
    {
        public static void BuildTexts(HtmlNode node, SimpleContentData data)
        {
            if (data.ListOfTexts == null) return;
            if(data.ListOfTexts.ContainsKey(node.Id))
            {
                node.InnerHtml = data.ListOfTexts[node.Id];
            }
        }

        public static void BuildAttributes(HtmlNode node, SimpleContentData data)
        {
            var attrToDelete = new List<HtmlAttribute>();
            foreach(var attr in node.Attributes)
            {
                if(data.ListOfAttributes != null && data.ListOfAttributes.ContainsKey(attr.Name))
                {
                    if (!string.IsNullOrEmpty(data.ListOfAttributes[attr.Name]))
                        attr.Value = data.ListOfAttributes[attr.Name];
                    else
                        attrToDelete.Add(attr);
                    continue;
                }


                if (data.ListOfVariables != null && data.ListOfVariables.ContainsKey(attr.Value))
                {
                    attr.Value = data.ListOfVariables[attr.Value];
                    continue;
                }
            }

            foreach(var attr in attrToDelete)
            {
                node.Attributes.Remove(attr);
            }
        }

        public static void BuildVariables(HtmlNode node, SimpleContentData data)
        {
        }
    }
}
