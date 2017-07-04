using System.Collections.Generic;
using TPDev.SimpleReport.SharedLibrary.Models.Report.TableData;

namespace TPDev.SimpleReport.SharedLibrary.Models.Report
{
    public class SimpleContentData
    {
        public Dictionary<string, string> ListOfTexts { get; set; }
        public Dictionary<string, string> ListOfVariables { get; set; }
        public Dictionary<string, string> ListOfAttributes { get; set; }
        public List<SimpleTableData> ListOfTables { get; set; }
    }
}
