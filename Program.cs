using System;

namespace SolidRefactoringLab
{
    // Interface for report formatting
    public interface IReportFormatter
    {
        void FormatReport();
    }

    // PDF Formatter
    public class PdfFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a PDF...");
        }
    }

    // Word Formatter
    public class WordFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }

    // Plain Text Formatter
    public class PlainTextFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as plain text...");
        }
    }

    // Report Manager
    public class ReportManager
    {
        private readonly IReportFormatter _formatter;

        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GenerateReport()
        {
            _formatter.FormatReport();
        }
    }

    // Separate class for saving reports
    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Choose the formatter (OCP)
            IReportFormatter formatter = new PdfFormatter();

            // 2. Pass it to the manager
            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();

            // 3. Use the dedicated saver (SRP)
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}
