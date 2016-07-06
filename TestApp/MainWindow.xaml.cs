using System.Windows;
using TPDev.SimpleReport.SharedLibrary;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;

namespace TestApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
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
            Bootstrapper.Boot();
            FileHelper.CleanupCacheFiles();
        }
    }
}
