using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Ch_7.Controllers;

namespace Ch_7.ExceptionAttributes
{
    public class ResourceDeletedAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception is ResourceDeletedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Gone,
                    Content = new StringContent(actionExecutedContext.Exception.Message)
                };
            }

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}