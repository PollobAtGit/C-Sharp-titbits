using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T = DataAccessLayer.Model.Trip;

namespace Trips.UI.Pages
{
    public class TripIndexModel : PageModel
    {
        internal TripContextRepository Repository { get; }

        public List<T> Trips { get; set; }

        public bool DoesAnyTripExist => Trips.Any();

        public TripIndexModel(TripContextRepository repository)
        {
            Repository = repository;
        }

        public async Task OnGet()
        {
            Trips = await Repository.GetAllAsync();
        }
    }
}