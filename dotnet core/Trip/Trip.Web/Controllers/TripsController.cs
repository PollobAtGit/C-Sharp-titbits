﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    }
}