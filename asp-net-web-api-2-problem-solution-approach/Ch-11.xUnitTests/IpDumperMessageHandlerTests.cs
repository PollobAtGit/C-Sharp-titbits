using Ch_11.App_Start;
using Ch_11.Controllers;
using Ch_11.MessageHandlers;
using Model;
using Moq;
using Service;
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
        private Mock<IFileWriter> FileWriterMock { get; }

        private HttpMessageInvoker MessageHandlerInvoker { get; }

        public IpDumperMessageHandlerTests()
        {
            FileWriterMock = new Mock<IFileWriter>();

            MessageHandlerInvoker = new HttpMessageInvoker(new IpDumper(FileWriterMock.Object)
            {
                InnerHandler = new Mock<HttpMessageHandler>(MockBehavior.Loose).Object
            });
        }

        [Fact]
        public async Task Handler_Must_NotInvokeWriterIfContextIsNotAvailable()
        {
            using (var httpRequestMessage = new HttpRequestMessage())
            {
                await MessageHandlerInvoker.SendAsync(httpRequestMessage, CancellationToken.None);

                FileWriterMock.Verify(x => x.AppendAllLines(It.IsAny<string[]>()), Times.Never());
            }
        }
    }
}
