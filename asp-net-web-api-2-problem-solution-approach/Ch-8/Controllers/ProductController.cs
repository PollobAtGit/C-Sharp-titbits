using DAL;
using Service;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ch_8.Controllers
{
    public class ProductController : ApiController
    {
        public ProductService Service { get; set; }

        public ProductController()
        {
            Service = new ProductService(new ProductRepository());
        }

        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
                Content = new PushStreamContent(async (rS, con, contect) =>
                {
                    try
                    {
                        using (var writer = new StreamWriter(rS))
                        {
                            foreach (var p in Service.FindAll.Concat(Service.FindAll.Concat(Service.FindAll)))
                            {
                                await writer.WriteLineAsync(p.ToString());
                                await writer.FlushAsync();
                                await Task.Delay(millisecondsDelay: 700);
                            }
                        }
                    }
                    catch (System.Exception)
                    {
                        return;
                    }
                    finally
                    {
                        rS.Close();
                    }
                }, "text/plain")
            };
        }
    }
}
