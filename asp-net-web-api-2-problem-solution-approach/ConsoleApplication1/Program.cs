using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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

            var client = new HttpClient();
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
