using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HostWithoutAsyncAwait_OnClick(object sender, RoutedEventArgs e)
        {
            HostAddresses.Text = "";
            foreach (var url in new List<string> { "lipsum.com", "godoc.org" })
                ResolveDnsWithoutAsyncAwait(url);
        }

        private void ResolveDnsWithoutAsyncAwait(string url)
        {
            // await resolves restores context
            Dns
                .GetHostAddressesAsync(url)
                .ContinueWith(x =>
                {
                    // we need application dispatcher here because GetHostAddressesAsync uses a new
                    // Thread but because await is not used context is not restored

                    Application.Current.Dispatcher?.Invoke(() =>
                    {
                        // .Result is not a blocker here as we are in ContinueWith(...) which invokes when Thread is done operating
                        var ipAddresses = x.Result;

                        HostAddresses.Text +=
                            string.Join(", ", ipAddresses.Select(y => y.ToString())) + Environment.NewLine;
                    });
                });
        }

        private async void HostByAsyncAwait_OnClick(object sender, RoutedEventArgs e)
        {
            HostAddresses.Text = "";
            foreach (var url in new List<string> { "jira.stormgeo.com", "github.com", "gitlab.com" })
                HostAddresses.Text +=
                    string.Join(", ", (await Dns.GetHostAddressesAsync(url)).Select(x => x.ToString())) + Environment.NewLine; ;
        }

        private async void TryCatch_OnClick(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //"https://www.oreilly.com/"
                    HostAddresses.Text = await client.GetStringAsync(new Uri("https://www.oreilly.om/"));
                }
                catch (Exception exception)
                {
                    // await ... can be done in catch
                    HostAddresses.Text += $"Exception: {exception.Message}" + Environment.NewLine;
                    HostAddresses.Text = await client.GetStringAsync(new Uri("https://www.oreilly.com/online-learning/individuals.html"));
                }
            }
        }

        private void UiBlock_OnClick(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                using (var client = new HttpClient())
                {
                    // this '.Result' is not blocking UI thread because we are not in UI thread
                    var str = client.GetStringAsync(new Uri("https://www.google.com/")).Result;

                    Application.Current.Dispatcher.Invoke(() => { HostAddresses.Text = str; });
                }
            });
        }
    }
}
