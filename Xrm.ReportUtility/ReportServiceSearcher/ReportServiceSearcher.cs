using System;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.ReportServiceSearcher
{
    public class ReportServiceSearcher
    {
        private readonly ReportServiceHandler _handler;

        public ReportServiceSearcher()
        {
            _handler = new CsvReportServiceHandler(null);
            _handler = new TxtReportServiceHandler(_handler);
            _handler = new XlsxReportServiceHandler(_handler);
        }

        public IReportService Search(string[] args)
        {
            return _handler.Search(args);
        }
    }

    public class CsvReportServiceHandler : ReportServiceHandler
    {
        public CsvReportServiceHandler(ReportServiceHandler nextHandler) : base(nextHandler)
        {
        }

        protected override IReportService GetService(string[] args)
        {
            return new CsvReportService(args);
        }

        protected override bool Accept(string fileName)
        {
            return fileName.EndsWith(".csv");
        }
    }

    public class TxtReportServiceHandler : ReportServiceHandler
    {
        public TxtReportServiceHandler(ReportServiceHandler nextHandler) : base(nextHandler)
        {
        }

        protected override IReportService GetService(string[] args)
        {
            return new TxtReportService(args);
        }

        protected override bool Accept(string fileName)
        {
            return fileName.EndsWith(".txt");
        }
    }

    public class XlsxReportServiceHandler : ReportServiceHandler
    {
        public XlsxReportServiceHandler(ReportServiceHandler nextHandler) : base(nextHandler)
        {
        }

        protected override IReportService GetService(string[] args)
        {
            return new XlsxReportService(args);
        }

        protected override bool Accept(string fileName)
        {
            return fileName.EndsWith(".xlsx");
        }
    }

    public abstract class ReportServiceHandler
    {
        private readonly ReportServiceHandler _nextHandler;

        protected ReportServiceHandler(ReportServiceHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public IReportService Search(string[] args)
        {
            var fileName = args[0];
            if (Accept(fileName))
                return GetService(args);
            if (_nextHandler != null) return _nextHandler.Search(args);
            throw new NotSupportedException("this extension not supported");
        }

        protected abstract IReportService GetService(string[] args);
        protected abstract bool Accept(string fileName);
    }
}