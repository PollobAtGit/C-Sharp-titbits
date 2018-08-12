using Ch_11.xUnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Ch_11.Filters
{
    public sealed class CacheControlHeaderFilter : ActionFilterAttribute
    {
        public ICacheControlHeaderSetter HeaderSetter { get; set; }

        private double ClientTimeSpan { get; set; }

        private CacheControlHeaderFilter()
        {
            HeaderSetter = new DefaultCacheControlHeaderSetter(ClientTimeSpan);
        }

        public CacheControlHeaderFilter(double clientTimeSpan) : base()
        {
            ClientTimeSpan = clientTimeSpan;
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (HeaderSetter == null)
                throw new NullReferenceException(nameof(HeaderSetter));

            // Note the usage of greater than or equal to
            if (actionExecutedContext.Response?.StatusCode < HttpStatusCode.InternalServerError)
                actionExecutedContext.Response.Headers.CacheControl = HeaderSetter.CacheControlInstance;

            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
}