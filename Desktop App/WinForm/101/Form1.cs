using System;
using System.Net;
using System.Windows.Forms;

namespace _101
{
    public partial class DownloadFromUrl : Form
    {
        public DownloadFromUrl()
        {
            InitializeComponent();
        }

        private async void download_Click(object sender, EventArgs e)
        {
            try
            {
                var url = new Uri(mainUrl.Text.Trim());
                var content = "";

                using (var client = new WebClient())
                {
                    // TODO: Why doesn't Result work here?
                    content = await client.DownloadStringTaskAsync(url);
                    contentPlaceHolder.Text = content;
                }
            }
            catch (WebException webExp)
            {
                MessageBox.Show("Server Not Found");
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show("URL Is malformed");
            }

        }
    }
}
