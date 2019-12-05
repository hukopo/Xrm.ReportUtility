using System.Collections.Generic;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.ReportPrinter
{
    public class ReportPrinterBuilder : IReportPrinterBuilder
    {
        private string _headerRow = "Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество";
        private string _rowTemplate = "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}";
        private DataRow[] _data;
        private IList<ReportRow> _rows;

        public void AddIndexColumn()
        {
            _headerRow = "№\t" + _headerRow;
            _rowTemplate = "{0}\t" + _rowTemplate;
        }
        public void AddTotalVolumeColumn()
        {
            _headerRow += "\tСуммарный объём";
            _rowTemplate += "\t{6,15}";
        }
        public void AddTotalWeightColumn()
        {
            _headerRow += "\tСуммарный вес";
            _rowTemplate += "\t{7,13}";
        }

        public void SetData(DataRow[] data)
        {
            _data = data;
        } 
        
        public void SetRows(IList<ReportRow> rows)
        {
            _rows = rows;
        }

        public ReportPrinter Build()
        {
            return new ReportPrinter()
            {
                HeaderRow = _headerRow,
                RowTemplate = _rowTemplate,
                Data = _data,
                Rows = _rows
            };
        }
    }
}