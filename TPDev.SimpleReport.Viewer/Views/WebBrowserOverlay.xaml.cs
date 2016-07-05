using System.Windows.Controls;

namespace TPDev.SimpleReport.Viewer.Views
{
    /// <summary>
    /// Interaktionslogik für WebBrowserOverlay.xaml
    /// </summary>
    public partial class WebBrowserOverlay : UserControl
    {
        public WebBrowserOverlay()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;

            Bootstrapper.Boot();
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void OnUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Bootstrapper.Shutdown();
        }

        public void GoTo(string url)
        {
            browserCtrl.Load(url);
        }

        //public new bool IsLoaded { get { return browserCtrl.IsLoaded; } }
        //public bool IsLoading { get { return browserCtrl.IsLoading; } }

        //public new bool IsEnabled { get { return browserCtrl.IsEnabled; } set { browserCtrl.IsEnabled = value; } }
    }
}
