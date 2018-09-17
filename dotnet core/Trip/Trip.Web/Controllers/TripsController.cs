using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using T = DataAccessLayer.Model.Trip;

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
        public async Task<ActionResult<List<T>>> GetAsync() => await Repository.GetAllAsync();

        [HttpPost]

        // not using [FormBody] attribute because we are using [ApiController] REST controller
        // endpoint

        // [ApiController] attribute also validate the model on it's own

        public async Task<ActionResult> PostAsync(T trip)
        {
            // ModelState validation is not required because of [ApiController] 
            //controller attribute

            //ModelState.IsValid

            await Repository.AddAsync(trip: trip);
            Repository.SaveAsync();

            Trace.WriteLine(Request.GetDisplayUrl());

            return Redirect(Request.GetDisplayUrl());
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(T trip)
        {
            var t = await Repository.FindAsync(trip: trip);

            t.Copy(copyInstance: trip);

            return Redirect(Request.GetDisplayUrl());
        }
    }
}