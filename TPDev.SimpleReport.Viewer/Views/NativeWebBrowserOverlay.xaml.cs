using System.Windows;
using System.Windows.Controls;
using TPDev.SimpleReport.SharedLibrary.Events;
using TPDev.SimpleReport.SharedLibrary.Models.Global;
using TPDev.SimpleReport.SharedLibrary.Services.Viewer;

namespace TPDev.SimpleReport.Viewer.Views
{
    /// <summary>
    /// Interaktionslogik für NativeWebBrowserOverlay.xaml
    /// </summary>
    public partial class NativeWebBrowserOverlay : UserControl
    {
        public ViewerHelperService Helper { get; set; }
        private WebBrowser m_Browser { get; set; }
        public NativeWebBrowserOverlay()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;

            Bootstrapper.Boot();
            Helper = new ViewerHelperService();

            m_Browser = browserCtrl;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            m_Browser.Unloaded += OnBrowserUnloaded;

            m_Browser.Loaded += OnFrameLoaded;

            SLEvents.LoadReport += OnLoadReport;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Dispose();
        }

        private void OnBrowserUnloaded(object sender, RoutedEventArgs e)
        {
        }

        private void OnFrameLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void OnLoadReport(SimpleEventArgs args)
        {
            LoadHtml(args.HtmlContent);
        }


        public void Dispose()
        {
            m_Browser.Dispose();
            Bootstrapper.Shutdown();
        }

        public void LoadUrl(string url)
        {
            if (m_Browser == null) return;
            m_Browser.Navigate(url);
        }

        public void LoadHtml(string content)
        {
            if (m_Browser == null) return;
            m_Browser.NavigateToString(content);
        }

        public void Refresh()
        {
            m_Browser.Refresh();
        }

        public void Back()
        {
            m_Browser.GoBack();
        }

        public void Forward()
        {
            m_Browser.GoForward();
        }
    }
}
