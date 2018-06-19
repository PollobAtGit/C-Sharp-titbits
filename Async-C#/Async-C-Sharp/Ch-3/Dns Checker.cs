using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch_3
{
    public partial class dnsChecker : Form
    {
        public dnsChecker()
        {
            InitializeComponent();
        }

        private void checkDns_Click(object sender, EventArgs e)
        {
            var hostName = txtBoxHost.Text.Trim();

            if (string.IsNullOrWhiteSpace(hostName)) return;

            Dns
                .BeginGetHostAddresses(hostName, OnHostNameResolved, null);
        }

        private void OnHostNameResolved(IAsyncResult ar)
        {
            ipsListBox.DataSource = Dns
                .EndGetHostAddresses(ar)
                .Select(x => new { IP = x })
                .ToList();

            ipsListBox.DisplayMember = "IP";
            ipsListBox.ValueMember = "IP";
        }

        private async void AddFavicon(string host)
        {
            var client = new WebClient();
            var byeBytes = await client
                .DownloadDataTaskAsync(new Uri($"https://{host}"));

            faviconListBox.DataSource = new List<object> { new { byeBytes.Length } };
            faviconListBox.DisplayMember = "Length";
            faviconListBox.ValueMember = "Length";
        }

        private void checkDnsAsync_Click(object sender, EventArgs e)
        {
            var host = txtBoxHost.Text.Trim();

            if (string.IsNullOrWhiteSpace(host)) return;

            Task<IPAddress[]> hostAddressesTask = Dns.GetHostAddressesAsync(host);

            // What is the advantage with ContinueWith?
            hostAddressesTask.ContinueWith(_ =>
            {
                ipsListBox.DataSource = hostAddressesTask
                    .Result
                    .Select(x => new { IP = x })
                    .ToList();

                ipsListBox.DisplayMember = "IP";
                ipsListBox.ValueMember = "IP";
            });

            AddFavicon(host);
            AddAnotherFavicon(host);
            MultipleFaviconDownload();

            //Thread.Sleep(5000);
        }

        private async Task MultipleFaviconDownload()
        {
            var hostOne = "https://google.com";
            var hostTwo = "https://yahoo.com";

            using (var client = new WebClient())
            {
                // download/ long running operation that is represented by Task<T>
                // starts whenever Task<T> is created. How to prove?
                var hostOneAsync = client.DownloadDataTaskAsync(new Uri(hostOne));
                var hostTwoAsync = client.DownloadDataTaskAsync(new Uri(hostTwo));

                var hostOneBytes = await hostOneAsync;
                var hostTwoBytes = await hostTwoAsync;

                faviconListBoxAn.DataSource = new List<object> { new { hostOneBytes.Length } };

                faviconListBoxAn.DisplayMember = "Length";
                faviconListBoxAn.ValueMember = "Length";

                faviconListBoxAn.DataSource = new List<object> { new { hostTwoBytes.Length } };
            }
        }

        private async Task AddAnotherFavicon(string host)
        {
            using (var client = new WebClient())
            {
                // Following is a Task<T> not T. await needs to be applied on Task<T> to get T
                var downloadTask = client.DownloadDataTaskAsync(new Uri($"https://{host}"));

                // Now compiler is doing something special
                // await is the magic keyword that spuns a new Thread
                var bytes = await downloadTask;

                faviconListBoxAn.DataSource = new List<object> { new { bytes.Length } };
                faviconListBoxAn.DisplayMember = "Length";
                faviconListBoxAn.ValueMember = "Length";
            }
        }

        private async void btnLongRunningProcess_Click(object sender, EventArgs e)
        {
            // Awaiting for multiple long running operation in the following way is not
            // a desirable approach because second (or any operation done after the first one)
            // operations' Exception will be shadowed by the first operations exception
            // (if occurs)

            // This is bad specially because the second operation might have started already

            // Exception is not thrown when Task<T> has just returned
            var personTask = CreatePerson();
            var anotherPersonTask = AnotherCreatePerson();

            // Exception will be thrown when the Task<T> is being awaited
            var person = await personTask;

            // Exception from second long running operation is lost because of the previous
            // long running operation has thrown exception
            var anotherPerson = await anotherPersonTask;
        }

        private async Task CreatePersonNoReturn()
        {
            await Task.Run(() => { throw new Exception("Void Return"); });
        }

        private async Task<Person> CreatePerson()
        {
            return await Task.Run(() =>
            {
                throw new Exception("From _CreatePerson");
                return new Person();
            });
        }

        private async Task<Person> AnotherCreatePerson()
        {
            return await Task.Run(() =>
            {
                throw new Exception("From AnotherCreatePerson");
                return new Person();
            });
        }

        private async void btnVoidReturn_Click(object sender, EventArgs e)
        {
            var voidReturn = CreatePersonNoReturn();
            await voidReturn;
        }

        private async void btnLargestContent_Click(object sender, EventArgs e)
        {
            var urlDetails = await new FindWebPageWithHighestCharactersInIt()
                .FindHighestCharacterContainingUrl(new[]
                {
                    "https://mail.google.com",
                    "https://docs.python.org/3/tutorial/controlflow.html",
                    "https://www.hairlosstalk.com"
                });

            lblUrl.Text = urlDetails.ToString();
        }
    }

    internal class Person
    {
    }
}
