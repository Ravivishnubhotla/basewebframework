using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Reporting.WebForms;

namespace Legendigital.Framework.Common.Web.UI
{
    public static class ReportViewHelper
    {
        public static void FixReportDefinition(string reportPath)
        {
            string strReport = System.IO.File.ReadAllText(reportPath, System.Text.Encoding.UTF8);
            if (strReport.Contains("http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition"))
            {
                strReport = strReport.Replace("<Report xmlns:rd=\"http://schemas.microsoft.com/SQLServer/reporting/reportdesigner\" xmlns:cl=\"http://schemas.microsoft.com/sqlserver/reporting/2010/01/componentdefinition\" xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition\">", "<Report xmlns:rd=\"http://schemas.microsoft.com/SQLServer/reporting/reportdesigner\" xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition\">");
                strReport = strReport.Replace("<ReportSections>", "").Replace("<ReportSection>", "").Replace("</ReportSection>", "").Replace("</ReportSections>", "");
            }
            byte[] bytReport = System.Text.Encoding.UTF8.GetBytes(strReport);

            if (File.Exists(reportPath))
            {
                File.Delete(reportPath);
            }

            File.WriteAllBytes(reportPath, bytReport);
        }

        public const string ReportViewer_RenderFormat_HTML = "HTML4.0";
        public const string ReportViewer_RenderFormat_Excel = "Excel";
        public const string ReportViewer_RenderFormat_RGDI = "RGDI";
        public const string ReportViewer_RenderFormat_IMAGE = "IMAGE";
        public const string ReportViewer_RenderFormat_PDF = "PDF";
        public const string ReportTitle_ParamsName = "ReportName";

        //result = rvDashlet.ServerReport.Render("HTML4.0", "<DeviceInfo><HTMLFragment>True</HTMLFragment></DeviceInfo>", out mimeType, out encoding, out extension, out streamids, out warnings);

        public static byte[] ExportReport(ReportViewer reportViewer, string format, string deviceInfo, out string mimeType, out string encoding, out string fileNameExtension, out string[] streams, out Microsoft.Reporting.WebForms.Warning[] warnings)
        {
            //reportViewer.GetType().Assembly.
            return reportViewer.LocalReport.Render(format, deviceInfo, out mimeType, out encoding, out fileNameExtension,
                                                   out streams, out warnings);
        }


        public static void BindDataTableToReport(ReportViewer reportViewer, DataTable dataTable, string dataSourceName, string reportName)
        {
            ReportDataSource rds = new ReportDataSource(dataSourceName, dataTable);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);

            ReportParameter rpReportName = new ReportParameter();
            rpReportName.Name = ReportTitle_ParamsName;
            rpReportName.Values.Add(reportName);

            reportViewer.LocalReport.SetParameters(
                new ReportParameter[] { rpReportName });

            reportViewer.LocalReport.Refresh();
        }

        public static void BindListToReport(ReportViewer reportViewer, IEnumerable list, string dataSourceName, string reportName)
        {
            ReportDataSource rds = new ReportDataSource(dataSourceName, list);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);

            ReportParameter rpReportName = new ReportParameter();
            rpReportName.Name = ReportTitle_ParamsName;
            rpReportName.Values.Add(reportName);

            reportViewer.LocalReport.SetParameters(
                new ReportParameter[] { rpReportName });

            reportViewer.LocalReport.Refresh();
        }


        public static byte[] ExportListToExcel(ReportViewer reportViewer, IEnumerable list, string dataSourceName, string reportName)
        {
            ReportDataSource rds = new ReportDataSource(dataSourceName, list);

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);


            ReportParameter rpReportName = new ReportParameter();
            rpReportName.Name = ReportTitle_ParamsName;
            rpReportName.Values.Add(reportName);

            reportViewer.LocalReport.SetParameters(
             new ReportParameter[] { rpReportName });


            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] reportFile = reportViewer.LocalReport.Render(
               "Excel", null, out mimeType, out encoding,
                out extension,
               out streamids, out warnings);

            return reportFile;

        }



        public static void EnableFormat(ReportViewer viewer, string formatName)
        {
            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            FieldInfo m_previewService = viewer.LocalReport.GetType().GetField
           (
               "m_previewService",
              Flags
            );

            MethodInfo ListRenderingExtensions = m_previewService.FieldType.GetMethod
            (
               "ListRenderingExtensions",
                Flags
            );

            object previewServiceInstance = m_previewService.GetValue(viewer.LocalReport);

            IList extensions = ListRenderingExtensions.Invoke(previewServiceInstance, null) as IList;

            PropertyInfo name = extensions[0].GetType().GetProperty("Name", Flags);

            foreach (object extension in extensions)
            {
                if (string.Compare(name.GetValue(extension, null).ToString(), formatName, true) == 0)
                {
                    FieldInfo m_isVisible = extension.GetType().GetField("m_isVisible", BindingFlags.NonPublic | BindingFlags.Instance);
                    FieldInfo m_isExposedExternally = extension.GetType().GetField("m_isExposedExternally", BindingFlags.NonPublic | BindingFlags.Instance);
                    m_isVisible.SetValue(extension, true);
                    m_isExposedExternally.SetValue(extension, true);
                    break;
                }
            }
        }
    }
}
