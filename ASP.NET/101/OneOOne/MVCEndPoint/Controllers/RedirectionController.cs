using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEndPoint.Controllers
{
    //[Route(Name = "redirected-to")]
    public class RedirectionController : Controller
    {
        // GET: Redirection
        public ActionResult Index()
        {
            var sessionData = Session["session-key"];

            ViewBag.sessionData = sessionData == null ? "session data is null" : sessionData;
            Response.Cookies.Add(new HttpCookie("asp", "whatever"));
            Response.Cookies.Add(new HttpCookie("other-asp", "i am a http only cookie")
            {
                // Browser can't read cookie via document.cookie when that cookie is set as HttpOnly
                HttpOnly = true
            });

            var sessionCookie = Request.Cookies.Get("ASP.NET_SessionId");

            if (sessionCookie != null)
            {
                ViewBag.AspSessionId = sessionCookie.Value;
            }

            return View();
        }
    }
}