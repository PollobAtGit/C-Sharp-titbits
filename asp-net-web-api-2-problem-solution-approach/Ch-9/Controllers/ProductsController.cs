using Ch_9.Filter;
using Service;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

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

        [ResourceNotFoundException]
        public IHttpActionResult Get(int id)
        {
            // POI: May be it's not working because DependencyResolver hasn't really changed
            // we had implemented IHttpControllerActivator. 

            // TODO: Implement IDependencyResolver

            var ps = Request
                .GetConfiguration()
                .DependencyResolver
                .GetService(typeof(ProductService)) as ProductService;

            throw new NotImplementedException();
        }
    }
}