using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers.Abstract
{
    public abstract class ReportServiceTransformerBase : IDataTransformer
    {
        protected readonly IDataTransformer DataTransformer;

        protected ReportServiceTransformerBase(IDataTransformer dataTransformer)
        {
            DataTransformer = dataTransformer;
        }
        //todo это TEMPLATE METHOD, где ReportServiceTransformerBase - AbstractClass,
        //CostSumReportTransformer, CountSumReportTransformer и т.д. - ConcreteClass
        //А TransformDate - TemplateMethod
        public abstract Report TransformData(DataRow[] data);
    }
}
