using System.Collections.Generic;

namespace TPDev.SimpleReport.SharedLibrary.Models.Report.SelectionData
{
    public class SimpleSelectionData
    {
        public string Id { get; set; }
        public List<SimpleSelectionItemData> Choices { get; set; }
    }
}
