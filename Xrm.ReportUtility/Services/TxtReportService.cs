using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public class TxtReportService : ReportServiceBase
    {
        public TxtReportService(string[] args) : base(args){ }

        protected override DataRow[] GetDataRows(string text)
        {
            var result = new List<DataRow>();

            var lines = text.Split(new[] { "\r\n" }, StringSplitOptions.None).Skip(1);

            foreach (var line in lines)
            {
                var items = Regex.Split(line, @"\s+");

                result.Add(new DataRow
                           {
                               Name = items[0],
                               Volume = decimal.Parse(items[1]),
                               Weight = decimal.Parse(items[2]),
                               Cost = decimal.Parse(items[3]),
                               Count = decimal.Parse(items[4])
                           });
            }

            return result.ToArray();
        }
    }
}