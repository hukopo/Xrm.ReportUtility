using System;
using System.Collections.Generic;
using System.Linq;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.ReportPrinter
{
    public class ReportPrinter
    {
        public string HeaderRow { get; set; }
        public string RowTemplate { get; set; }
        public DataRow[] Data { get; set; }
        public IList<ReportRow> Rows { get; set; }

        public void Print()
        {
            PrintData();

            PrintRows();
        }

        private void PrintRows()
        {
            if (Rows == null || !Rows.Any()) return;
            Console.WriteLine("Итого:");
            foreach (var reportRow in Rows)
                Console.WriteLine($"  {reportRow.Name,-20}\t{reportRow.Value}");
        }

        private void PrintData()
        {
            if (Data == null || !Data.Any()) return;
            Console.WriteLine(HeaderRow);

            for (var i = 0; i < Data.Length; i++)
            {
                var dataRow = Data[i];
                Console.WriteLine(RowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight,
                    dataRow.Cost, dataRow.Count, dataRow.Volume * dataRow.Count,
                    dataRow.Weight * dataRow.Count);
            }

            Console.WriteLine();
        }
    }
}