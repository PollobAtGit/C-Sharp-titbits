using Ch_9.Controllers;
using DAL;
using Service;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Ch_9.DI
{
    public class ControllerDependencyInjector : IHttpControllerActivator
    {
        private DependencyResolver Resolver { get; set; }

        public ControllerDependencyInjector()
        {
            Resolver = new DependencyResolver();
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == typeof(ProductsController))
            {
                var productService = DependencyResolver.Resolve<ProductService>() as ProductService;
                //return new ProductsController(new ProductService(new ProductRepository()));
                return new ProductsController(productService);
            }

            if (controllerType == typeof(ValuesController))
                return new ValuesController();

            return null;
        }
    }
}