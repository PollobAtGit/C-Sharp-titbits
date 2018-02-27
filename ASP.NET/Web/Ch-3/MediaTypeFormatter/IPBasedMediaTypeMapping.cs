using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;
using System.Web;

namespace Ch_3.MediaTypeFormatter
{
    // POI: MediaTypeMapping is a abstract class that that's the base of each media type Mappers
    // TODO: What's the difference between MediaTypeMapping & MediaTypeFormatter?
    // POI: This Mapped wll chose media type based on IP (!)
    public class IPBasedMediaTypeMapping : MediaTypeMapping
    {
        // POI: Avoiding having a constructor with argument by initializing a Mapper in base(...) invocation
        public IPBasedMediaTypeMapping() : base(new MediaTypeHeaderValue("application/json")) { }

        public override double TryMatchMediaType(HttpRequestMessage request)
        {
            var ip = IPAddress(request);

            Trace.WriteLine("IP: " + ip);

            // TODO: What does it mean?
            return "::1".Equals(ip) ? 1.0 : 0.0;
        }

        string IPAddress(HttpRequestMessage req)
        {
            var httpContextKey = "MS_HttpContext";

            if (req.Properties.ContainsKey(httpContextKey) && req.Properties[httpContextKey] is HttpContextBase)
                return (req.Properties[httpContextKey] as HttpContextBase).Request.UserHostAddress;

            if (req.Properties.ContainsKey(RemoteEndpointMessageProperty.Name) && req.Properties[RemoteEndpointMessageProperty.Name] is RemoteEndpointMessageProperty)
                return (req.Properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty).Address;

            return string.Empty;
        }
    }
}