using Ch_11.App_Start;
using Ch_11.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace Ch_11.xUnitTests
{
    public class IpDumperMessageHandlerTests
    {
        private HttpMessageInvoker MessageHandlerInvoker { get; }

        public IpDumperMessageHandlerTests()
        {
            MessageHandlerInvoker = new HttpMessageInvoker(new IpDumper());
        }

        [Fact]
        public async Task Handler_Must_BeAbleToRetrieveHttpContext()
        {
            Assert.True(false, "Complete Implementation");
            //const string localHostAddress = "http://localhost";

            //using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, localHostAddress))
            //{
            //    httpRequestMessage
            //        .Properties[ApplicationSetting.HttpContextPropertyKey] =
            //        new HttpContextWrapper(null);

            //    //new HttpContext(new HttpRequest(null, localHostAddress, null), null)

            //    // TODO: Dependency on File
            //    await MessageHandlerInvoker.SendAsync(httpRequestMessage, new CancellationToken());
            //}
        }
    }
}
