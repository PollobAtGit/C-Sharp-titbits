using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch_8.Controllers
{
    public class ChatController : Controller
    {
        // GET: Char
        public ActionResult Index()
        {
            return View();
        }
    }
}