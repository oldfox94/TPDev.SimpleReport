using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;

namespace TPDev.SimpleReport.SharedLibrary.Services.Viewer
{
    public class HtmlHelper
    {
        public static IEnumerable<HtmlNode> ParseHtml(string fileName)
        {
            var content = FileHelper.FileToString(fileName);

            content = WebUtility.HtmlDecode(content);
            HtmlDocument resultat = new HtmlDocument();
            resultat.LoadHtml(content);

            return resultat.DocumentNode.Descendants();
        }
    }
}
