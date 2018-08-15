using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch_2.Controllers
{
    public class InvitationController : Controller
    {
        private static IList<GuestResponse> GuestResponses { get; }

        static InvitationController()
        {
            GuestResponses = new List<GuestResponse>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(GuestResponse response)
        {
            if (ModelState.IsValid)
                GuestResponses.Add(response);

            return View("ThanksForJoiningTheParty", GuestResponses);
        }
    }
}