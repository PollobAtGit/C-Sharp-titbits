using Ch_9.Controllers;
using DAL;
using Service;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;

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

            // POI: A HTTP request contains contains it's scope within itself (though its actually a extension method itself)
            // POI: An IDependencyScope is unique to a HTTP request
            // POI: When the request is disposed the IDependencyScope is disposed too
            // POI: IOCs provide per request dependency scope (implementation of IDependencyScope)

            request.GetDependencyScope();

            // POI: HttpRequestMessage contains itself HttpConfiguration
            request.GetConfiguration();

            // POI: HttpRequestMessage (via HttpConfiguration) contains dependency resolver (that
            // implements IDependencyResolver

            var dependencyResolver = request.GetConfiguration().DependencyResolver;

            return null;
        }

        private IDependencyScope GetDependencyScopeFromHttpRequestMessage(HttpRequestMessage request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            object result;

            if (!request.Properties.TryGetValue(HttpPropertyKeys.DependencyScope, out result))
            {
                var dependencyScope = request.GetConfiguration().DependencyResolver.BeginScope();

                if (dependencyScope == null)
                    throw new InvalidOperationException("Begin scope returns <null>");

                request.Properties[HttpPropertyKeys.DependencyScope] = dependencyScope;
                request.RegisterForDispose(dependencyScope);
            }

            var perHttpRequestDependencyScope = request.GetDependencyScope();
            var globalDependencyScope = request.GetConfiguration().DependencyResolver.BeginScope();

            return result as IDependencyScope;
        }
    }
}