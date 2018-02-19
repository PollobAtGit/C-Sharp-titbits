using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.API
{
    public class RequestProcessorController : ApiController
    {
        // GET api/<controller>
        public string Get(HttpRequestMessage req) => req.RequestUri.ToString();

        // GET api/<controller>/5
        public string Get(int id, HttpRequestMessage req) => id + " => " + req.RequestUri.ToString();

        // POI: This action causes confusion for the ASP.NET runtime because for C# this method 
        // is overload for the above method but from URI's perspective this method is not a overload
        // besides HttpRequestMessage isn't passed via URI/HTTP message body
        public string Get(int id) => id.ToString();

        // POST api/<controller>
        public void Post([FromBody]string value) { }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) { }

        // DELETE api/<controller>/5
        public void Delete(int id) { }
    }
}