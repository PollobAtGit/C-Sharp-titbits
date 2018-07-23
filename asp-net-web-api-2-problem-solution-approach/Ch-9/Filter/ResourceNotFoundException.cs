using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace Ch_9.Filter
{
    public sealed class ResourceNotFoundException : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            // POI: Dependency can be obtained here!
            var dependencyScope = actionExecutedContext.Request.GetDependencyScope();

            // POI: May be it's not working because DependencyResolver hasn't really changed
            // we had implemented IHttpControllerActivator. 

            // TODO: Implement IDependencyResolver

            var productServiceDI = actionExecutedContext.Request.GetConfiguration().DependencyResolver.GetService(typeof(ProductService)) as ProductService;
            var productService = dependencyScope.GetService(typeof(ProductService)) as ProductService;

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }

        private void OnExceptionDoNothing(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext
                .Request
                .GetConfiguration()
                .DependencyResolver

                // POI: Dependency resolver itself is a IDependencyScope
                .BeginScope();
        }
    }
}