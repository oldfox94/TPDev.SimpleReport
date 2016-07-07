using System;
using System.Data;

namespace TestApp.Helpers
{
    public class SampleDataGenerator
    {
        public static DataTable GenerateSampleTable()
        {
            var dt = new DataTable("TestTbl");

            dt.Columns.Add("pk");
            dt.Columns.Add("Name");

            var rnd = new Random();
            var maxRecords = rnd.Next(10, 100);

            for (int i = 0; i < maxRecords; i++)
            {
                var dr = dt.NewRow();

                dr["pk"] = Guid.NewGuid().ToString();
                dr["Name"] = "TestPerson " + i.ToString();

                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
