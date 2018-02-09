using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEndPoint.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult Index()
        {
            var kCookie = "uCookie";

            //var eCookie = Request.Cookies.Get(kCookie);

            //if (eCookie == null) Response.Cookies.Add(new HttpCookie(kCookie, DateTime.Now.ToString()));
            //else ViewBag.ECookie = eCookie.Value;

            Response.Cookies.Add(new HttpCookie(kCookie, DateTime.Now.ToString()));

            return View();
        }
    }
}