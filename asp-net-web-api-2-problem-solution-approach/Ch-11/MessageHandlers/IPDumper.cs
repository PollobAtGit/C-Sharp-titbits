using Ch_11.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ch_11.MessageHandlers
{
    public class IpDumper : DelegatingHandler
    {
        private const string IpDumperFileName = @"C:\Users\pollob\Documents\ips.txt";

        private IFileWriter Writer { get; }

        public IpDumper()
        {
            Writer = new WindowsFileWriter(IpDumperFileName);
        }

        public IpDumper(IFileWriter writer)
        {
            Writer = writer;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Properties.ContainsKey(ApplicationSetting.HttpContextPropertyKey))
            {
                var httpContextWrapper = request.Properties[ApplicationSetting.HttpContextPropertyKey] as HttpContextWrapper;

                if (httpContextWrapper == null) throw new NullReferenceException(nameof(httpContextWrapper));

                Writer.AppendAllLines(new string[] { httpContextWrapper.Request.UserHostAddress });
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}