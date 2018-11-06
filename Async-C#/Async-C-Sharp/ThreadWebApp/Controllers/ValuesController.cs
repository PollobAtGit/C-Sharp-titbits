using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace ThreadWebApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<int> Get()
        {
            ThreadPool.GetMinThreads(out int workerThreads, out int ioCompletionPortThreads);
            ThreadPool.GetMaxThreads(out int workerMaxThreads, out int ioCompletionPortMaxThreads);

            //[4,4,8191,1000,4]
            return new int[] {
                workerThreads,
                ioCompletionPortThreads,
                workerMaxThreads,
                ioCompletionPortMaxThreads,
                Environment.ProcessorCount
            };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
