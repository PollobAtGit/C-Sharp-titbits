using System.Net.Http.Headers;

namespace Ch_11.xUnitTests
{
    public interface ICacheControlHeaderSetter
    {
        double ClientMaxAge { get; }

        CacheControlHeaderValue CacheControlInstance { get; }
    }
}