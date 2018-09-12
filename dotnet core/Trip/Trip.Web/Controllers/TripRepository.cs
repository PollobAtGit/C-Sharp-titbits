using System;
using System.Collections.Generic;

namespace Trip.Web.Controllers
{
    public class TripRepository
    {
        public List<Trip> GetAll() => new List<Trip>
        {
            new Trip
            {
                Id = 1,
                Destination = "destination",
                PickupPoint = "pickup place"
            },
            new Trip
            {
                Id = 2,
                Destination = "destination-xx",
                PickupPoint = "pickup place-xx"
            }
        };
    }
}