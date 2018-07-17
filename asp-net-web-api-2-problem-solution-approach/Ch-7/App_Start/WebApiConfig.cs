using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using Ch_7.GlobalExceptions;
using Microsoft.Owin.Security.OAuth;
using WebApiContrib.Tracing.Nlog;

namespace Ch_7
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Register services

            config
                .Services
                .Replace(typeof(IExceptionHandler), new ContentNegotiatedExceptionHandler());

            // TODO: NLog tracing is not working now

            // System Diagnostics Trace Writer is pretty good
            config
                .Services
                .Replace(typeof(ITraceWriter), new SystemDiagnosticsTraceWriter());

        }
    }
}
