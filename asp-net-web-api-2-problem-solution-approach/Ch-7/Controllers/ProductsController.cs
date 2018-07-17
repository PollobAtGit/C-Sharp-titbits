using System;
using System.Web.Http;
using Ch_7.DomainExceptions;
using Ch_7.ExceptionAttributes;
using DAL;
using Model;
using Service;
using System.Web.Http.Description;

namespace Ch_7.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductService Service { get; }

        public ProductsController(/*ProductService service*/)
        {
            // TODO: Introduce DI. Remove DAL reference
            Service = new ProductService(new ProductRepository());
        }

        [ResourceDeleted]
        public Product Get(int id)
        {
            // Configuration is HttpConfiguration which also is exposed via RequestContext
            var tracerWriter = Configuration.Services.GetTraceWriter();

            try
            {
                return Service.FindById(id);
            }
            catch (InvalidOperationException expException)
            {
                throw new ResourceDeletedException($"Product with Id {id} has been deleted.", expException);
            }
        }


        public void Get(Product product)
        {
            throw new NotImplementedException();
        }

        // IgnoreApi won't show the controller action in Help
        [ApiExplorerSettings(IgnoreApi = true)]
        public Product Get()
        {
            throw new NotImplementedException();
        }
    }
}
