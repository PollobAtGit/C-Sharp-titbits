using Service;
using System.Web.Http;

namespace Ch_9.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductService Service { get; set; }

        public ProductsController(ProductService service)
        {
            Service = service;
        }

        public IHttpActionResult Get() => Ok(Service.FindAll);
    }
}