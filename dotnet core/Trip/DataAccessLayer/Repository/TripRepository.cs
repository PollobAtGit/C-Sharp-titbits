using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
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

        public async Task<List<Trip>> GetAllAsync() => await Task.Run(() => Trips);

        public async Task AddAsync(Trip trip) => await Task.Run(() => Trips.Add(item: trip));

        public async Task<Trip> FindAsync(Trip trip) => await Task.Run(() => Trips.Find(x => x.Id == trip.Id));
    }
}