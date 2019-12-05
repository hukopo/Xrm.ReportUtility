using System;
using System.Collections.Generic;
using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.ReportPrinter;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static IReportService GetReportService(string[] args)
        {
            var reportServiceSearcher = new ReportServiceSearcher.ReportServiceSearcher();
            return reportServiceSearcher.Search(args);
        }

        private static void PrintReport(Report report)
        {
            new ReportPrinterBuilderDirector(new ReportPrinterBuilder()).Build(report).Print(); 
        }
    }
}