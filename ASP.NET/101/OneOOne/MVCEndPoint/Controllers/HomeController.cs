using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEndPoint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // POI: Why not Abandon() working?
            // Why not session id is changing
            // Why session Id is being changed for main browser instance

            //var sessionId = Session.SessionID;
            //Session.Abandon();
            //sessionId = Session.SessionID;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}