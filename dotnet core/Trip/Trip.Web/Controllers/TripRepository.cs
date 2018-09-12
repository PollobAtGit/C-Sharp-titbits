using System;
using System.Collections.Generic;

namespace Trip.Web.Controllers
{
    public class TripRepository
    {
        static List<Trip> _trips = new List<Trip>
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

        static List<Trip> Trips => _trips;

        internal List<Trip> GetAll() => Trips;

        internal void Add(Trip trip) => Trips.Add(item: trip);
    }
}