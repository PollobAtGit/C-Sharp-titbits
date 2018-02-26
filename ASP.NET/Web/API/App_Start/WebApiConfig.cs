using System.Diagnostics;
using System.IO;
using System.Web.Http;
using System.Web.Http.Tracing;
using API.MessageHandler;
using API.Tracer;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = false;

            //config.Services.Replace(typeof(ITraceWriter), new WebApiTracer());
            //config.Services.Replace(typeof(ITraceWriter), new EntryExitTracer());
            //config.MessageHandlers.Add(new CustomLogHandler());
            //Debug.Listeners.Add(new TextWriterTraceListener(@"C:\Users\pollob\Documents\log.txt"));

            config.Services.Replace(typeof(ITraceWriter), new TextTracer());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "web-api/{orgId}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { orgId = @"\d+" }
            );

            foreach (var formatter in config.Formatters)
            {
                // TODO: Why not working?
                Trace.WriteLine("Type: " + formatter.GetType().Name);
            }

        }
    }
}
