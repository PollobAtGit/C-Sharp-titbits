using System.Collections.Generic;
using System.Web.Http;
using Service;

namespace Ch_7.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // Intentional. Constructor initialization will fail that will trigger ContentNegotiatedException
        public ValuesController(ProductService service) { }

        [AllowAnonymous]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
