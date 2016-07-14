using System.Collections.Generic;
using System.Data;

namespace TPDev.SimpleReport.SharedLibrary.Models.Report
{
    public class SimpleContentData
    {
        public Dictionary<string, string> ListOfTexts { get; set; }
        public List<DataTable> ListOfTables { get; set; }
    }
}
