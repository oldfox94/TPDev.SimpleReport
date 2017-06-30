using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows;
using TestApp.Helpers;
using TPDev.SimpleReport.Service;
using TPDev.SimpleReport.SharedLibrary.Models.Global;
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
            DataContext = this;

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;

            var configData = new SimpleReportConfigData { };

            m_Reporter = new ReportService(configData);
            m_Reporter.InitLogger("ReporterLog");

            m_ReportViewer = new ViewerService(configData);
            m_ReportViewer.InitLogger("ReporterLog");
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            TemplateSelection.ItemsSource = new List<string>
            {
                "SampleTemplate",
                "SampleBootstrapTemplate",
                "SampleAngularJsTemplate"
            };
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
            browserOverlay.LoadUrl("http://www.google.com");
        }

        private void OnCleanupCacheClick(object sender, RoutedEventArgs e)
        {
            FileHelper.CleanupCacheFiles();
        }

        private void OnLoadTemplateClick(object sender, RoutedEventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;


            var template = m_Reporter.Templater.LoadTemplate(TemplateSelection.SelectedValue.ToString());

            var sampleTbl = SampleDataGenerator.GenerateSampleTable();
            var reportData = new SimpleReportData
            {
                TemplateData = template,
                ContentData = new SimpleContentData
                {
                    ListOfTexts = new Dictionary<string, string> { { "appVersion", version } },
                    ListOfTables = new List<DataTable> { sampleTbl },
                },
            };

            var printData = m_Reporter.CreateReport(reportData);
            m_ReportViewer.LoadReport(printData);
        }
    }
}
