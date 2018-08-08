using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}