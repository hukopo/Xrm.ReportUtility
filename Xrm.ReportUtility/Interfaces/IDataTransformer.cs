using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Interfaces
{
    public interface IDataTransformer
    {
        Report TransformData(DataRow[] data);
    }
}