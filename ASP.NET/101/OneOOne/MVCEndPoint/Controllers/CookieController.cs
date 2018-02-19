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
            var eCookie = Request.Cookies.Get(kCookie);

            if (eCookie == null)
            {
                var currentTime = DateTime.Now;

                Response.Cookies.Add(new HttpCookie(kCookie, currentTime.ToString())
                {
                    Expires = currentTime.AddDays(1.0)
                });

                ViewBag.ECookie = null;
            }
            else
            {
                ViewBag.ECookie = eCookie.Value;
            }

            // POI: This statement creates a session id in cookie
            Session["uCookie"] = eCookie.Value;

            return View();
        }
    }
}