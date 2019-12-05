using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.ReportPrinter
{
    public class ReportPrinterBuilderDirector
    {
        private readonly IReportPrinterBuilder _builder;

        public ReportPrinterBuilderDirector(IReportPrinterBuilder builder)
        {
            _builder = builder;
        }

        public ReportPrinter Build(Report report)
        {
            if (report.Config.WithIndex)
            {
                _builder.AddIndexColumn();
            }

            if (report.Config.WithTotalVolume)
            {
                _builder.AddTotalVolumeColumn();
            }

            if (report.Config.WithTotalWeight)
            {
                _builder.AddTotalWeightColumn();
            }
            
            _builder.SetData(report.Data);
            _builder.SetRows(report.Rows);

            return _builder.Build();
        }
    }
}