using System.Collections.Generic;
using System.Windows;
using Common;

namespace FaviconBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFaviconGetter _faviconGetter = new FgThreadBlocker();
        private readonly FgEapAsync _faviconGetterByEap = new FgEapAsync();

        private static readonly List<string> SDomains = new List<string>
        {
            "google.com",
            "bing.com",
            "facebook.com",
            "reddit.com",
            "baidu.com",
            "bbc.co.uk"
        };

        public MainWindow() => InitializeComponent();

        private void GetButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var domain in SDomains)
                m_WrapPanel.Children.Add(_faviconGetter.GetFavicon(domain));
        }

        private void AsyncGetFavicon_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var domain in SDomains) 
                _faviconGetterByEap.GetFavicon(domain, x => m_WrapPanel.Children.Add(ImageProcessor.MakeImageControl(x)));
        }
    }
}
