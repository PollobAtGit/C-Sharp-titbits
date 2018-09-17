using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T = DataAccessLayer.Model.Trip;

namespace Trips.UI.Pages.Trip
{
    public class CreateModel : PageModel
    {
        internal TripContextRepository Repository { get; }

        public CreateModel(TripContextRepository repository)
        {
            Repository = repository;
        }

        // Bound properties values will be bounded by ModelBinder by
        // getting values from form data

        [BindProperty]
        public T Trip { get; set; }

        public async Task<ActionResult> OnPost()
        {

            // without [BindProperty] attribute Trip wouldn't have been 
            //initialized

            await Repository.AddAsync(Trip);
            await Repository.SaveAsync();

            return RedirectToPage("Index");
        }
    }
}