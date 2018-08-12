using System;
using System.Net.Http.Headers;
using Ch_11.xUnitTests;

namespace Ch_11.Filters
{
    public class DefaultCacheControlHeaderSetter : ICacheControlHeaderSetter
    {
        public double ClientMaxAge { get; }

        public DefaultCacheControlHeaderSetter(double maxAge)
        {
            ClientMaxAge = maxAge;
        }

        public CacheControlHeaderValue CacheControlInstance => new CacheControlHeaderValue
        {
            MaxAge = TimeSpan.FromSeconds(ClientMaxAge),
            MustRevalidate = false,
            Public = true
        };
    }
}