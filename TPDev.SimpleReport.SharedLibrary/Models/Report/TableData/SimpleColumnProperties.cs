﻿namespace TPDev.SimpleReport.SharedLibrary.Models.Report.TableData
{
    public class SimpleColumnProperties
    {
        public string ColumnName { get; set; }

        public string DisplayName { get; set; }
        public bool IsHidden { get; set; }

        public int SortOrder { get; set; }

        public bool IsIdColumn { get; set; }
    }
}
