using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Trips.UI.Pages
{
    public class TripsModel : PageModel
    {
        internal TripContextRepository Repository { get; }

        public List<Trip> Trips { get; set; }

        public bool DoesAnyTripExist => Trips.Any();

        public TripsModel(TripContextRepository repository)
        {
            Repository = repository;
        }

        public async Task OnGet()
        {
            Trips = await Repository.GetAllAsync();
        }
    }
}