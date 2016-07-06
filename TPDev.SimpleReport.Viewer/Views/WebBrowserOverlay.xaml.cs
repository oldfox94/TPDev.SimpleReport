using CefSharp.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace TPDev.SimpleReport.Viewer.Views
{
    /// <summary>
    /// Interaktionslogik für WebBrowserOverlay.xaml
    /// </summary>
    public partial class WebBrowserOverlay : UserControl
    {
        private ChromiumWebBrowser m_Browser { get; set; }
        public WebBrowserOverlay()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;

            Bootstrapper.Boot();

            m_Browser = new ChromiumWebBrowser();
            m_Browser.SetBinding(IsEnabledProperty, "BrowserIsEnabled");

            MainGrid.Children.Add(m_Browser);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Bootstrapper.Shutdown();
        }

        public void GoToUrl(string url)
        {
            if (m_Browser == null) return;
            m_Browser.Load(url);
        }

        public void SetHtmlContent(string content)
        {
            if (m_Browser == null) return;
        }

        public bool BrowserIsLoaded { get { return m_Browser.IsLoaded; } }
        public bool BrowserIsLoading { get { return m_Browser.IsLoading; } }

        //public bool BrowserIsEnabled { get { return m_Browser.IsEnabled; } set { m_Browser.IsEnabled = value; } }

        public bool BrowserHasContent { get { return m_Browser.HasContent; } }


        public bool BrowserIsEnabled
        {
            get { return (bool)GetValue(BrowserIsEnabledProperty); }
            set { SetValue(BrowserIsEnabledProperty, value); }
        }
        public static DependencyProperty BrowserIsEnabledProperty =
            DependencyProperty.Register(
                "BrowserIsEnabled",
                typeof(bool),
                typeof(WebBrowserOverlay));
    }
}
