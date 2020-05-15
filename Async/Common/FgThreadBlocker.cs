using System;
using System.Net;
using System.Windows.Controls;

namespace Common
{
    public class FgThreadBlocker : IFaviconGetter
    {
        public Image GetFavicon(string url)
        {
            using (var client = new WebClient())
                return ImageProcessor.MakeImageControl(client.DownloadData($"https://{url}/favicon.ico"));
        }
    }

    public class FgEapAsync
    {
        public void GetFavicon(string url, Action<byte[]> callBack)
        {
            using (var client = new WebClient())
            {
                client.DownloadDataAsync(new Uri($"https://{url}/favicon.ico"));
                client.DownloadDataCompleted += (sender, args) => callBack?.Invoke(args.Result);
            }
        }
    }
}
