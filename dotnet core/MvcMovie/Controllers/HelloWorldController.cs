using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        private static int VisitCountToAdminPanel;

        public string Index() => "Dotnet Core App";

        // POI: Escape everything
        public string Welcome(string id, string name) => HtmlEncoder.Default.Encode($"{name} (Id: {id}), Welcome To Dotnet Core App");

        public IActionResult AdminPanel(string name)
        {
            ViewData["user"] = HtmlEncoder.Default.Encode(name);
            ViewData["admin-panel-visit-count"] = (++VisitCountToAdminPanel);

            return View();
        }
    }
}