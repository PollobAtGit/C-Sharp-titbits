using Ch_Two.DAL;
using Model;
using System;
using System.Linq;

namespace Ch_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BreakAwayContext())
            {
                var notFoundMsg = "Destination Not Found";

                // POI: Destination is not found because Local... is not initialized (!). Data has never been asked for (till now)
                var xDDestination = context.Destinations.Local.SingleOrDefault(x => x.Name == "xD");

                Console.WriteLine(xDDestination == null ? notFoundMsg : xDDestination.ToString());

                // POI: Data is being asked for now. So Local... will be initialized after this statement
                foreach (var destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }

                Console.WriteLine("");

                // POI: This Destination will not be shown retrieved when Select(...) 'ing via DbSet<T> because DbSet<T> by default 
                // goes to DB but this destination is not in DB still
                var newDst = context.Destinations.Add(new Destination { Name = "aTy" });

                context
                    .Destinations

                    // POI: This OrderBy(...) translates into SQL because DbSet<T> implements IQuerable<T>
                    .OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x));

                Console.WriteLine("");

                context
                    .Destinations
                    .ToList()

                    // POI: As expected this OrderBy doesn't translate in SQL
                    .OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x));

                var id = int.Parse(Console.ReadLine());

                // POI: If id is 0 then context will be able to find a destination with that id because Find(...) searches for that 
                // id in in-memory (local) data also
                // POI: Find(...) s pool of interest = DB + [local storage that haven't been saved in DB yet]
                // POI: Find(...) depends on [Key] annotation defined for that model
                // POI: Model can have composite key. In that case Find(..., ...) will take multiple arguments & will use the combination 
                // of those values to identify the content
                Console.WriteLine(context.Destinations.Find(id) == null ? notFoundMsg : context.Destinations.Find(id).ToString());

                var strName = Console.ReadLine();

                // POI: Single(...) or SingleOrDefault(...) goes to DB to search for data. It's not similar to Find(...) which takes 
                // local memory into account
                Console.WriteLine(context.Destinations.SingleOrDefault(x => x.Name == strName));

                // POI: Unsaved Dstination will be available here
                Console.WriteLine(context.Destinations.Local.SingleOrDefault(x => x.Name == strName));
            }
        }
    }
}
