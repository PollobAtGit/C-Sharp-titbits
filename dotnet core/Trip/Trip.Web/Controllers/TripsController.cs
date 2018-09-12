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
        TripRepository Repository { get; set; }

        protected TripsController()
        {
            Repository = new TripRepository();
        }

        public TripsController(TripRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Trip>> Get() => Repository.GetAll();

        [HttpPost]

        // not using [FormBody] attribute because we are using [ApiController] REST controller
        // endpoint

        // [ApiController] attribute also validate the model on it's own

        public ActionResult Post(Trip trip)
        {
            // ModelState validation is not required because of [ApiController] 
            //controller attribute

            //ModelState.IsValid

            Repository.Add(trip: trip);

            Trace.WriteLine(Request.GetDisplayUrl());

            return Redirect(Request.GetDisplayUrl());
        }
    }
}