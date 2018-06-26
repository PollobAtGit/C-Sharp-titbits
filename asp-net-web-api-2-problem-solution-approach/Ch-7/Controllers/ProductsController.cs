using System;
using System.Web.Http;
using Ch_7.DomainExceptions;
using Ch_7.ExceptionAttributes;
using DAL;
using Model;
using Service;

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
            try
            {
                return Service.FindById(id);
            }
            catch (InvalidOperationException expException)
            {
                throw new ResourceDeletedException($"Product with Id {id} has been deleted.", expException);
            }
        }
    }
}
