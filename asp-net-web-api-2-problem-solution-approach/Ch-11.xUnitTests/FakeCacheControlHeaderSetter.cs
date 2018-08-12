using System;
using System.Net.Http.Headers;

namespace Ch_11.xUnitTests
{
    internal class FakeCacheControlHeaderSetter : ICacheControlHeaderSetter
    {
        public CacheControlHeaderValue CacheControlInstance => new CacheControlHeaderValue
        {
            MaxAge = TimeSpan.FromSeconds(ClientMaxAge),
            MustRevalidate = true,
            Public = true
        };

        public double ClientMaxAge { get; set; }
    }
}