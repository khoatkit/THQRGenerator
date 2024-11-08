using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace THQRGenerator.Utils
{
    class ReportUtil
    {
        public static ReportViewer CreateReport(
            string path
            , List<KeyValuePair<string, object>> sourceList
            , List<KeyValuePair<string, string>> paramList
            , string displayName = ""
            )
        {
            ReportViewer viewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                Dock = DockStyle.Fill
            };
            var report = viewer.LocalReport;
            report.ReportPath = path;
            if (sourceList != null)
                foreach (var source in sourceList)
                    report.DataSources.Add(new ReportDataSource(source.Key, source.Value));
            if (paramList != null)
            {
                var paramLst = new List<ReportParameter>();
                foreach (var param in paramList)
                    paramLst.Add(new ReportParameter(param.Key, param.Value));
                report.SetParameters(paramLst);
                if (displayName != "")
                    report.DisplayName = displayName;
            }
            viewer.SetDisplayMode(DisplayMode.PrintLayout);
            viewer.RefreshReport();
            return viewer;
        }

        public static void ExportReportPdf(
            string path
            , List<KeyValuePair<string, object>> sourceList
            , List<KeyValuePair<string, string>> paramList
            , string displayName = ""
            , string savePath = "")
        {
            using (var viewer = new ReportViewer { ProcessingMode = ProcessingMode.Local })
            {
                var report = viewer.LocalReport;
                report.ReportPath = path;
                if (sourceList != null)
                    foreach (var source in sourceList)
                        report.DataSources.Add(new ReportDataSource(source.Key, source.Value));
                if (paramList != null)
                {
                    var paramLst = new List<ReportParameter>();
                    foreach (var param in paramList)
                        paramLst.Add(new ReportParameter(param.Key, param.Value));
                    report.SetParameters(paramLst);
                    if (displayName != "")
                        report.DisplayName = displayName;
                }
                var bytes = report.Render("PDF");
                viewer.Dispose();
                File.WriteAllBytes($@"{savePath}\{displayName}.pdf", bytes);
            }
        }
    }
}