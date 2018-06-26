using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Ch_7.Models;

namespace Ch_7.GlobalExceptions
{
    public class ContentNegotiatedExceptionHandler : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            // ITraceWriter is exposed via HttpConfiguration which is exposed in RequestContext
            var traceWriter = context.RequestContext.Configuration.Services
                .GetTraceWriter();

            context.Result = new ResponseMessageResult(context.Request.CreateResponse(
                HttpStatusCode.InternalServerError, new ErrorData
                {
                    Id = Guid.NewGuid(),
                    Uri = context.Request.RequestUri.AbsolutePath,
                    Time = DateTime.Now,
                    Message = context.ExceptionContext.Exception?.Message
                }));

            return base.HandleAsync(context, cancellationToken);
        }
    }
}