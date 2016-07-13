using System.Collections.Generic;
using System.Data;
using System.Windows;
using TestApp.Helpers;
using TPDev.SimpleReport.Service;
using TPDev.SimpleReport.SharedLibrary.Models.Report;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;
using TPDev.SimpleReport.Viewer;

namespace TestApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ReportService m_Reporter { get; set; }
        private ViewerService m_ReportViewer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;

            m_Reporter = new ReportService();
            m_Reporter.InitLogger("ReporterLog");

            m_ReportViewer = new ViewerService();
            m_ReportViewer.InitLogger("ReporterLog");
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            browserOverlay.Dispose();
        }


        private void OnRefreshClick(object sender, RoutedEventArgs e)
        {
            browserOverlay.Refresh();
        }

        private void OnLoadHtmlClick(object sender, RoutedEventArgs e)
        {
            var html = Properties.Resources.SampleReportTemplate;
            browserOverlay.LoadHtml(html);
        }

        private void OnLoadUrlClick(object sender, RoutedEventArgs e)
        {
            browserOverlay.LoadUrl("www.google.com");
        }

        private void OnCleanupCacheClick(object sender, RoutedEventArgs e)
        {
            FileHelper.CleanupCacheFiles();
        }

        private void OnLoadSampleReportClick(object sender, RoutedEventArgs e)
        {
            var template = m_Reporter.Templater.LoadTemplate("SampleTemplate");

            var sampleTbl = SampleDataGenerator.GenerateSampleTable();
            var reportData = new SimpleReportData
            {
                TemplateData = template,
                ContentData = new SimpleReportContentData
                {
                    ListOfTables = new List<DataTable> { sampleTbl },
                },
            };

            var printData = m_Reporter.CreateReport(reportData);
            m_ReportViewer.LoadReport(printData);
        }
    }
}
