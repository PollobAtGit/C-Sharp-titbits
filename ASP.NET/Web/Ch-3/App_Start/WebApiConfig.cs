using Ch_3.Models;
using Ch_3.TraceWriter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
