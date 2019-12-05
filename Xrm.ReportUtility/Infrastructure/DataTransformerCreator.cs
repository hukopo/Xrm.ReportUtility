using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {
        // это фабричный метод?
        public static IDataTransformer CreateTransformer(ReportConfig config)
        {
            IDataTransformer service = new DataTransformer(config);
// это паттерн декоратор, где IDataTransformer - компонент,
// дата трансформ - конкретная реализация компонента
// , а WithDataReportTransformer,
// VolumeSumReportTransformer... - конкретные декораторы,
// ReportServiceTransformerBase - декоратор 
            if (config.WithData)
            {
                service = new WithDataReportTransformer(service);
            }

            if (config.VolumeSum)
            {
                service = new VolumeSumReportTransformer(service);
            }

            if (config.WeightSum)
            {
                service = new WeightSumReportTransfomer(service);
            }

            if (config.CostSum)
            {
                service = new CostSumReportTransformer(service);
            }

            if (config.CountSum)
            {
                service = new CountSumReportTransformer(service);
            }

            return service;
        }
    }
}