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
    public class DeleteModel : PageModel
    {
        internal TripContextRepository Repository { get; }

        public DeleteModel(TripContextRepository repository)
        {
            Repository = repository;
        }

        public async Task<ActionResult> OnGet(int id)
        {
            Repository.Remove(new T { Id = id });
            await Repository.SaveAsync();

            return RedirectToPage("Index");
        }
    }
}