using Ch_11.App_Start;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<Item> Get(int id) => await Service.GetById(id);

        public IHttpActionResult Post(Item newItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Service.AddItem(newItem);

                    var uri = new Uri(Url
                        .Link(ApplicationSetting.DefaultApiRouteName, new { id = newItem.Id }));

                    // TODO: 
                    return Redirect(uri);
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