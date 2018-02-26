using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API.MessageHandler
{
    public class CustomLogHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestMetadata = BuildRequestLog(request);
            HttpResponseMessage processedResponse = new HttpResponseMessage();

            try
            {
                processedResponse = await base.SendAsync(request, cancellationToken);
            }
            catch (HttpResponseException ex)
            {
                processedResponse = ex.Response;
            }
            finally
            {
                Log(await BuildResponseMetadata(processedResponse, requestMetadata));
            }

            return processedResponse;
        }

        void Log(LogMetadata requestMetadata)
        {
            Trace.Write(requestMetadata);
        }

        LogMetadata BuildRequestLog(HttpRequestMessage reqMessage)
        {
            return new LogMetadata
            {
                RequestMethod = reqMessage.Method.Method,
                RequestTimeStamp = DateTime.Now,
                RequestUri = reqMessage.RequestUri.ToString(),
                RequestAcceptType = string.Join(", ", reqMessage.Headers.Accept)
            };
        }

        async Task<LogMetadata> BuildResponseMetadata(HttpResponseMessage resMessage, LogMetadata logData)
        {
            logData.ResponseContentType = resMessage.Content != null ? resMessage.Content.Headers.ContentType.MediaType : "";
            logData.ResponseTimeStamp = DateTime.Now;
            logData.ResponseStatusCode = resMessage.StatusCode;
            logData.ResponseBodyContent = await InspectResponseBody(resMessage);

            return logData;
        }

        async Task<string> InspectResponseBody(HttpResponseMessage responseMessage)
        {
            if (responseMessage.Content == null) return "";

            var contentstream = await responseMessage.Content.ReadAsStreamAsync();
            var reader = new StreamReader(contentstream);
            return reader.ReadToEnd();
        }
    }
}