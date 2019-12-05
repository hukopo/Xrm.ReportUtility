using CsvHelper.Configuration;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public sealed class RowDataMapper : CsvClassMap<DataRow>
    {
        public RowDataMapper()
        {
            Map(m => m.Name).Index(0);
            Map(m => m.Volume).Index(1);
            Map(m => m.Weight).Index(2);
            Map(m => m.Cost).Index(3);
            Map(m => m.Count).Index(4);
        }
    }
}
