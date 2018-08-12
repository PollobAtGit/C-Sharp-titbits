using Ch_11.Filters;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Xunit;

namespace Ch_11.xUnitTests
{
    public class CacheControlFilterTests
    {
        [Fact]
        public async Task Filter_Must_SetCacheControlHeadersProperly()
        {
            // Arrange
            const double timeSpan = 50;
            var filter = new CacheControlHeaderFilter(timeSpan)
            {
                HeaderSetter = new FakeCacheControlHeaderSetter
                {
                    ClientMaxAge = timeSpan
                }
            };

            var actionExecutedContext =
                new HttpActionExecutedContext
                {
                    // ActionContext must be set for Response to work properly
                    ActionContext = new Mock<HttpActionContext>().Object,
                    Response = new Mock<HttpResponseMessage>().Object
                };

            // Act
            await filter.OnActionExecutedAsync(actionExecutedContext, CancellationToken.None);

            // Assert
            Assert.NotNull(actionExecutedContext.Response.Headers.CacheControl);
            Assert
                .Equal(TimeSpan.FromSeconds(timeSpan),
                actionExecutedContext.Response.Headers.CacheControl.MaxAge.GetValueOrDefault());
            Assert.True(actionExecutedContext.Response.Headers.CacheControl.MustRevalidate, "Cache will not be revalidated");
            Assert.True(actionExecutedContext.Response.Headers.CacheControl.Public, "Cache headers ar non public");
        }

        [Fact]
        public async Task Filter_Must_NotInvokeCacheControlHeaderSetterIfInternalServerErrorOccurred()
        {
            // Arrange
            var cacheControlSetterMock = new Mock<ICacheControlHeaderSetter>();

            var filter = new CacheControlHeaderFilter(0)
            {
                HeaderSetter = cacheControlSetterMock.Object
            };

            var actionExecutedContext = new HttpActionExecutedContext
            {
                ActionContext = new Mock<HttpActionContext>().Object,
                Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            };

            // Act
            await filter.OnActionExecutedAsync(actionExecutedContext, CancellationToken.None);

            // Assert
            Assert.Null(actionExecutedContext.Response.Headers.CacheControl);
            cacheControlSetterMock.Verify(x => x.CacheControlInstance, Times.Never());
        }
    }
}
