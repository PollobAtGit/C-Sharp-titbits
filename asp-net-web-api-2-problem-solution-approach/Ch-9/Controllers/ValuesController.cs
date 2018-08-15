using Ch_9.Filter;
using System;
using System.Web.Http;

namespace Ch_9.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult Get() => Ok("Ok");

        [ResourceNotFoundException]
        public IHttpActionResult Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
