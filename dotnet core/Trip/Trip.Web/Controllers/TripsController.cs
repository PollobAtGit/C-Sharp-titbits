using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Trip.Web.Controllers
{
    // ApiController is enough to make the Type and it's derived Types to be a REST controller
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        TripContextRepository Repository { get; set; }

        public TripsController(TripContextRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trip>>> GetAsync() => await Repository.GetAllAsync();

        [HttpPost]

        // not using [FormBody] attribute because we are using [ApiController] REST controller
        // endpoint

        // [ApiController] attribute also validate the model on it's own

        public async Task<ActionResult> PostAsync(Trip trip)
        {
            // ModelState validation is not required because of [ApiController] 
            //controller attribute

            //ModelState.IsValid

            await Task.Run(() => new TripRepository().Add(trip: trip));
            //await Repository.AddAsync(trip: trip);

            Trace.WriteLine(Request.GetDisplayUrl());

            return Redirect(Request.GetDisplayUrl());
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Trip trip)
        {
            var t = await Repository.FindAsync(trip: trip);

            t.Copy(copyInstance: trip);

            return Redirect(Request.GetDisplayUrl());
        }
    }
}