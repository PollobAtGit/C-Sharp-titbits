using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ch_8.Controllers
{
    public class ChatApiController : ApiController
    {
        private static object Locker = new object();
        private static int T = -1;

        private static List<StreamWriter> Subscribers { get; set; }

        static ChatApiController()
        {
            Subscribers = new List<StreamWriter>();
        }

        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
                Content = new PushStreamContent(async (rS, content, context) =>
                {
                    var subscriber = new StreamWriter(rS) { AutoFlush = true };

                    lock (Locker)
                        Subscribers.Add(subscriber);

                    await subscriber.WriteLineAsync("data: \n");
                }, "text/event-stream")
            };
        }

        public async Task Post(Message message)
        {
            message.DateTime = DateTime.Now;
            await MessageCallBack(message);
        }

        private async Task MessageCallBack(Message message)
        {
            for (var i = Subscribers.Count - 1; i >= 0; i--)
            {
                try
                {
                    await Subscribers[i].WriteAsync($"data: {JsonConvert.SerializeObject(message)} \n");
                    await Subscribers[i].WriteLineAsync("");
                    await Subscribers[i].FlushAsync();
                }
                catch (Exception exp)
                {
                    lock (Locker)
                        Subscribers.RemoveAt(i);
                }
            }
        }
    }
}
