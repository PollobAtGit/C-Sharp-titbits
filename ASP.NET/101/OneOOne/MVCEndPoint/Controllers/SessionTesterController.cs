using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEndPoint.Controllers
{
    // Doesn't Route works for MVC?
    //[Route(Name = "session-tester")]
    public class SessionTesterController : Controller
    {
        // GET: SessionTester
        public ActionResult Index()
        {
            Session["session-key"] = "i am stored in session";

            return Redirect("redirection");
        }
    }
}