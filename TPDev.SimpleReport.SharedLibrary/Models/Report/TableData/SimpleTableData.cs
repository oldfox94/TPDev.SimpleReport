using System.Collections.Generic;
using System.Data;

namespace TPDev.SimpleReport.SharedLibrary.Models.Report.TableData
{
    public class SimpleTableData
    {
        public DataTable Table { get; set; }
        public List<SimpleColumnProperties> ListOfColumnProperties { get; set; }
    }
}
