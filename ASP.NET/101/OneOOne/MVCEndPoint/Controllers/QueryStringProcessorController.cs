using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEndPoint.Controllers
{
    public class QueryStringProcessorController : Controller
    {
        // GET: QueryStringProcessor

        // POI: Exception occurs for dangerous input in query string when inout data is flowing from server entry
        // point to controller & but before control reaches controller action
        // POI: Actually validation is performed at controller level

        // POI: This attribute disables input validation at controller level
        // POI: ValidateInput attribute disables validation rule in Controller level but if QueryString is used in Action
        // exception will be thrown from QueryString manager (!)
        // POI: ASP.NET MVC has security imposed when getting input data from client side
        [ValidateInput(false)]
        public ActionResult Index(string user, string nid, string htmlInput)
        {
            // POI: Query strings can be retreived from Request.QueryString as well as via parameter
            // POI: Without disabling/numbing down ASP.NET default security following statement would have thrown exception
            // POI: To retrieve data from QueryString that (might) contain dangerous data we must numb down security for
            // System.Web using 'requestValidationMode = "2.0"'

            var u = Request.QueryString["user"];
            var i = Request.QueryString["nid"];
            var h = Request.QueryString["htmlInput"];

            ViewBag.IsQueryStringMatch = u == user && nid == i;

            ViewBag.UFromRequest = u;
            ViewBag.IFromRequest = i;

            ViewBag.UTStringFromRequest = Request.QueryString["user"].ToString();
            ViewBag.ITStringFromRequest = Request.QueryString["nid"].ToString();

            ViewBag.UFromParameter = user;
            ViewBag.IFromParameter = nid;

            // POI: Actions/views should also sanitize data that will be sent back to the client
            ViewBag.htmlInputHtmlString = htmlInput;
            ViewBag.qHtmlInputHtmlString = h;

            return View();
        }
    }
}