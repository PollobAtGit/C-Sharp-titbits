using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch_3
{
    class FindWebPageWithHighestCharactersInIt
    {
        public async Task<UrlDetails> FindHighestCharacterContainingUrl(string[] urls)
        {
            var dummyUrlDetails = new UrlDetails
            {
                ContentLength = int.MinValue,
                Url = string.Empty
            };

            foreach (var url in urls)
            {
                var length = await GetPageLength(url);
                if (length <= dummyUrlDetails.ContentLength) continue;

                dummyUrlDetails.ContentLength = length;
                dummyUrlDetails.Url = url;
            }

            // Return Type is Task<T> because of await
            return dummyUrlDetails;
        }

        private async Task<int> GetPageLength(string url)
        {
            using (var client = new WebClient())
            {
                var content = await client.DownloadStringTaskAsync(url);
                return content.Length;
            }
        }
    }
}
