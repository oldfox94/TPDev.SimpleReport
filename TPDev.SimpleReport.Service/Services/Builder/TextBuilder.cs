using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
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
            if (data.ListOfAttributes == null) return;

            var attrToDelete = new List<HtmlAttribute>();
            foreach(var attr in node.Attributes)
            {
                var tmpAttrData = new SimpleAttributeData { Id = node.Id, AttrName = attr.Name };
                if(data.ListOfAttributes != null && data.ListOfAttributes.Keys.FirstOrDefault(x => x.Id == tmpAttrData.Id && x.AttrName == tmpAttrData.AttrName) != null)
                {
                    tmpAttrData = data.ListOfAttributes.Keys.FirstOrDefault(x => x.Id == tmpAttrData.Id && x.AttrName == tmpAttrData.AttrName);
                    if (!string.IsNullOrEmpty(data.ListOfAttributes[tmpAttrData]))
                        attr.Value = data.ListOfAttributes[tmpAttrData];
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
