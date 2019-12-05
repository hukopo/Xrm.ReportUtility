using System.Collections.Generic;

namespace Xrm.ReportUtility.Models
{
    public class Report
    {
        public ReportConfig Config { get; set; }
        public DataRow[] Data { get; set; }
        public IList<ReportRow> Rows { get; set; }
    }
}
