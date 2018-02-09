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

            //var eCookie = Request.Cookies.Get("uCookie");
            //if (eCookie != null) ViewBag.ECookie = eCookie.Value;

            var kCookie = "uCookie";
            Response.Cookies.Add(new HttpCookie(kCookie, DateTime.Now.ToString()));

            return View();
        }
    }
}