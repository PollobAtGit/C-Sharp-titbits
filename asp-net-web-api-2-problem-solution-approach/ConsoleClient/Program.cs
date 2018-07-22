using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {
            var address = "http://localhost:2783/api/product";

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy("127.0.0.1", 8888)
            };

            var client = new HttpClient(httpClientHandler);
            var request = new HttpRequestMessage(HttpMethod.Get, address);
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var body = await response.Content.ReadAsStreamAsync();

            using (var reader = new StreamReader(body))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }

            Console.ReadLine();
        }
    }
}
