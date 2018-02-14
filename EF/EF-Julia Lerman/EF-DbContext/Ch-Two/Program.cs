using Ch_Two.DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BreakAwayContext())
            {
                foreach (var destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }

                context
                    .Destinations

                    // POI: This OrderBy(...) translates into SQL because DbSet<T> implements IQuerable<T>
                    .OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Name));

                context
                    .Destinations
                    .ToList()

                    // POI: As expected this OrderBy doesn't translate in SQL
                    .OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Name));
            }
        }
    }
}
