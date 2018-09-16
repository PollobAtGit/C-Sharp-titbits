using DataAccessLayer.Context;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class TripContextRepository
    {
        TripContext Context { get; set; }

        public TripContextRepository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<Trip>> GetAllAsync() => await Context.Trips.ToListAsync();

        public async Task AddAsync(Trip trip) => await Context.Trips.AddAsync(entity: trip);

        public async Task<Trip> FindAsync(Trip trip) => await Context.Trips.FindAsync(trip);

        public void SaveAsync() => Context.SaveChangesAsync();
    }
}
