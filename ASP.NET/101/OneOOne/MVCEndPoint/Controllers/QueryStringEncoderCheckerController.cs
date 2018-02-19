using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEndPoint.Controllers
{
    public class QueryStringEncoderCheckerController : Controller
    {
        // GET: QueryStringEncoderChecker

        [ValidateInput(false)]
        public ActionResult Index()
        {
            var u = Request.QueryString["user"];
            var i = Request.QueryString["nid"];
            var h = Request.QueryString["htmlInput"];

            ViewBag.user = u;
            ViewBag.nid = i;
            ViewBag.Html = h;

            var kCookie = "uCookie";
            var eCookie = Request.Cookies.Get(kCookie);

            if (eCookie != null)
            {
                ViewBag.ECookie = eCookie.Value;
            }

            return View();
        }
    }
}