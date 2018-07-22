using DAL;
using Model;
using Service;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ch_8.Controllers
{
    public class ValuesController : ApiController
    {
        private ProductService Service { get; }

        public ValuesController()
        {
            Service = new ProductService(new ProductRepository());
        }

        // GET api/values
        public IList<Product> Get()
        {
            return Service.FindAll;
        }

        public HttpResponseMessage GetAsStream(bool isAsStreamed = false)
        {
            return new HttpResponseMessage
            {
                Content = new PushStreamContent(async (rStream, content, context) =>
                {
                    using (var writer = new StreamWriter(rStream))
                    {
                        foreach (var p in Service.FindAll)
                        {
                            await writer.WriteAsync(p.ToString());
                            await writer.FlushAsync();
                            await Task.Delay(millisecondsDelay: 250);
                        }
                    }
                })
            };
        }
    }
}
