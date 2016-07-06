using CefSharp.Wpf;
using System.Windows;
using System.Windows.Controls;
using TPDev.SimpleReport.SharedLibrary.Services.Helper;
using TPDev.SimpleReport.SharedLibrary.Services.Viewer;
using TPDev.SimpleReport.Viewer.Context;

namespace TPDev.SimpleReport.Viewer.Views
{
    /// <summary>
    /// Interaktionslogik für WebBrowserOverlay.xaml
    /// </summary>
    public partial class WebBrowserOverlay : UserControl
    {
        public ViewerHelperService Helper { get; set; }
        private ChromiumWebBrowser m_Browser { get; set; }
        public WebBrowserOverlay()
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

            m_Browser.FrameLoadStart += OnFrameLoadStart;
            m_Browser.FrameLoadEnd += OnFrameLoadEnd;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Dispose();
        }

        public void Dispose()
        {
            m_Browser.Unloaded -= OnBrowserUnloaded;

            m_Browser.FrameLoadStart -= OnFrameLoadStart;
            m_Browser.FrameLoadEnd -= OnFrameLoadEnd;

            Bootstrapper.Shutdown();
            m_Browser.Dispose();
        }

        private void OnBrowserUnloaded(object sender, RoutedEventArgs e)
        {
        }

        private void OnFrameLoadStart(object sender, CefSharp.FrameLoadStartEventArgs e)
        {

        }

        private void OnFrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {

        }


        public void LoadUrl(string url)
        {
            if (m_Browser == null) return;
            m_Browser.Load(url);
        }

        public void LoadHtml(string content)
        {
            if (m_Browser == null) return;

            var tmpFile = FileHelper.StringToFile(content);
            LoadUrl(@"file://" + tmpFile);

            SrvContext.CleanupFiles.Add(tmpFile);
        }

        public void Refresh()
        {
            m_Browser.ReloadCommand.Execute(null);
        }

        public void Back()
        {
            m_Browser.BackCommand.Execute(null);
        }

        public void Forward()
        {
            m_Browser.ForwardCommand.Execute(null);
        }


        //public bool BrowserIsEnabled
        //{
        //    get { return (bool)GetValue(BrowserIsEnabledProperty); }
        //    set { SetValue(BrowserIsEnabledProperty, value); }
        //}
        //public static DependencyProperty BrowserIsEnabledProperty =
        //    DependencyProperty.Register(
        //        "BrowserIsEnabled",
        //        typeof(bool),
        //        typeof(WebBrowserOverlay));
    }
}
