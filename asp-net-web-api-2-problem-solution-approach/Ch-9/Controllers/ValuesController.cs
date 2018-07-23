using System.Web.Http;

namespace Ch_9.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult Get() => Ok("Ok");
    }
}
