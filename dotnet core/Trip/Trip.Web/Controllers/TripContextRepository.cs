using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.Web.Controllers
{
    public class TripContextRepository
    {
        TripContext Context { get; set; }

        public TripContextRepository(TripContext context)
        {
            Context = context;
        }

        internal async Task<List<Trip>> GetAllAsync() => await Context.Trips.ToListAsync();

        internal async Task AddAsync(Trip trip) => await Context.Trips.AddAsync(entity: trip);

        internal async Task<Trip> FindAsync(Trip trip) => await Context.Trips.FindAsync(trip);

        internal void SaveAsync() => Context.SaveChangesAsync();
    }
}
