using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Ch_11.Controllers
{
    public class ItemsController : ApiController
    {
        IService Service { get; }

        public ItemsController()
        {
            Service = new ItemService();
        }

        public ItemsController(IService service)
        {
            Service = service;
        }

        public Item Get(int id) => Service.GetById(id);

        public IHttpActionResult Post(Item newItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Service.AddItem(newItem);

                    // TODO: 
                    return Redirect($"{Request.RequestUri.AbsoluteUri}/{newItem.Id}");
                }

                return InternalServerError();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}