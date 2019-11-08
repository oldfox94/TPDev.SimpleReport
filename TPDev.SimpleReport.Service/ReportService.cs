using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using TPDev.SimpleReport.Logger.Models;
using TPDev.SimpleReport.Service.Services.Builder;
using TPDev.SimpleReport.SharedLibrary;
using TPDev.SimpleReport.SharedLibrary.Context;
using TPDev.SimpleReport.SharedLibrary.Models.Global;
using TPDev.SimpleReport.SharedLibrary.Models.Report;
using TPDev.SimpleReport.SharedLibrary.Models.Report.TableData;
using TPDev.SimpleReport.TemplateManager;

namespace TPDev.SimpleReport.Service
{
    public class ReportService
    {
        public TemplateService Templater { get; set; }
        public ReportService(SimpleReportConfigData configData)
        {
            try
            {
                Bootstrapper.Boot(configData);

                Templater = new TemplateService(SLContext.Config.ProjectPath);
            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "Init ReportService Error!",
                    Ex = ex,
                });
            }
        }

        public void InitLogger(string logFileName, string logPath = null)
        {
            if (string.IsNullOrEmpty(logPath))
                logPath = SLContext.CurrentCtx.LogDirectory;
            else
                SLContext.CurrentCtx.LogDirectory = logPath;

            SLLog.Logger = new Logger.Logger(logPath, logFileName, "SimpleReport.ReportService");
            SLLog.WriteInfo("InitLogger", "Logger successfully initialized!");
        }

        public void Shutdown()
        {
            Bootstrapper.Shutdown();
        }

        public SimplePrintData CreateReport(SimpleReportData reportData)
        {
            var data = new SimplePrintData();

            var builder = new ReportBuilder();
            data.HtmlContent = builder.BuildReport(reportData);

            Cleanup(reportData);
            return data;
        }

        public SimplePrintData CreateTable(SimpleTableData tableData)
        {
            var data = new SimplePrintData();

            var builder = new ReportBuilder();
            data.HtmlContent = builder.BuildTable(tableData);

            Cleanup(new SimpleReportData { ContentData = new SimpleContentData { ListOfTables = new List<SimpleTableData> { tableData } } });
            return data;
        }

        private void Cleanup(SimpleReportData reportData)
        {
            try
            {
                if (reportData.ContentData != null)
                {
                    if (reportData.ContentData.ListOfAttributes != null) reportData.ContentData.ListOfAttributes.Clear();
                    if (reportData.ContentData.ListOfSelections != null) reportData.ContentData.ListOfSelections.Clear();
                    if (reportData.ContentData.ListOfTables != null) reportData.ContentData.ListOfTables.Clear();
                    if (reportData.ContentData.ListOfTexts != null) reportData.ContentData.ListOfTexts.Clear();
                    if (reportData.ContentData.ListOfVariables != null) reportData.ContentData.ListOfVariables.Clear();
                }
                if (reportData.TemplateData != null)
                {
                    if (reportData.TemplateData.HtmlNodeList != null) reportData.TemplateData.HtmlNodeList = new List<HtmlNode>();
                    if (reportData.TemplateData.StyleFiles != null) reportData.TemplateData.StyleFiles.Clear();
                }
            }
            catch(Exception ex)
            {
                SLLog.WriteError(new LogData
                {
                    Source = ToString(),
                    FunctionName = "Cleanup Error!",
                    Ex = ex,
                });
            }
            GC.Collect();
        }
    }
}
