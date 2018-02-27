using Ch_3.MediaTypeFormatter;
using Ch_3.Models;
using Ch_3.TraceWriter;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace Ch_3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableSystemDiagnosticsTracing();

            config.Services.Replace(typeof(ITraceWriter), new TextTraceWriter());

            // POI: Content negotiation gives negotiation via Query String the highest precedence
            // So for this example when Accept is application/xml but query string contains frmt=json
            // then response will be serialized in JSON not in XML because query string has higher precedence

            // POI: We are saying that if query string contains key frmt with value json then it's media type
            // will be application/json
            config
                .Formatters
                .JsonFormatter
                .MediaTypeMappings
                .Add(new QueryStringMapping("frmt", "json", "application/json"));

            // POI: We are denoting that if a query string key is frmt that contains value not-json-but-xml
            // then media Type for that request should set to application/xml
            config
                .Formatters
                .XmlFormatter
                .MediaTypeMappings
                .Add(new QueryStringMapping("frmt", "not-json-but-xml", "application/xml"));

            // POI: Custom header has higher precedence than any other way of Content negotiation
            // Precedence: Custom Header => Query String => Accept Header => Content-Type
            config
                .Formatters
                .JsonFormatter
                .MediaTypeMappings
                .Add(new RequestHeaderMapping(
                    "X-Media-Type",
                    "hJson",
                    StringComparison.InvariantCultureIgnoreCase,
                    false,
                    "application/json"));

            config
                .Formatters
                .JsonFormatter
                .MediaTypeMappings

                // POI: MediaTypeMapping has two constructors and both having arguments still we are
                // not providing anything for custom media type mapping because we ar invoking base with
                // a default instance of the desired Type
                .Add(new IPBasedMediaTypeMapping());

            config.Formatters.JsonFormatter.MediaTypeMappings.ToList()
                .ForEach(x => Trace.WriteLine(x.MediaType.MediaType));// application/json

            // POI: Removing XML Formatter
            // POI: Any GET request where Accept header is application/xml will fail to 
            // get an appropriate formatter & in that case will grab the first formatter that
            // can handle the request

            // POI: If there's no formatter that can handle the request then response will be empty

            // POI: If any GET request comes with Accept header application/json then XML formatter
            // will be used because that will be the first formatter in order that can format the
            // response

            // POI: Web API looks to Content-Type as fall back approach when Accept header is
            // empty (is Accept header is not sent then server might consider that as Accept: */*
            // which is not the same as Accept: '')

            // POI: If Accept & Content-Type both are empty in GET request only then API look into the
            // Formatter collection & takes the first Formatter (that can serialize the response) 
            // to resolve the request

            //config.Formatters.RemoveAt(0);// Removing JSON formatter
            //config.Formatters.RemoveAt(0);

            // POI: Serializers can tell if they are capable if serializing any Type
            config.Formatters.ToList().ForEach(x =>
                Trace.WriteLine($"Serializer: {x.GetType().Name} | {x.CanReadType(typeof(Employee))} | {x.CanWriteType(typeof(Employee))}"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
