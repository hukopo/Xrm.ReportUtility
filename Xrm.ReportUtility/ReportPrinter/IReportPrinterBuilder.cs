using System.Collections.Generic;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.ReportPrinter
{
    public interface IReportPrinterBuilder
    {
        void AddIndexColumn();
        void AddTotalVolumeColumn();
        void AddTotalWeightColumn();
        void SetData(DataRow[] data);
        void SetRows(IList<ReportRow> rows);
        ReportPrinter Build();
    }
}