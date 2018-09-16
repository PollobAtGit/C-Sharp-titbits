using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        internal async Task<List<Trip>> GetAllAsync() => await Task.Run(() => Trips);

        internal async Task AddAsync(Trip trip) => await Task.Run(() => Trips.Add(item: trip));

        internal async Task<Trip> FindAsync(Trip trip) => await Task.Run(() => Trips.Find(x => x.Id == trip.Id));
    }
}