using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel.DAL;
using ObjectModel.Model;

namespace Ch_Two
{
    static class Deletion
    {
        static Action<Destination> DisplayDestination = x => Console.WriteLine(x.DestinationId + " | " + x.Name);

        public static void Main()
        {
            //Delete();
            //DeleteWithSQL();
            //FailureToDeleteWithFKRelation();
            //DeleteWithFK();
        }

        static void DeleteWithFK()
        {
            using (var context = new BreakAwayContext())
            {
                var d = context.Destinations.Find(1);

                context.Entry(d).Collection(x => x.Lodgings).Load();// Loading related entity

                d.Lodgings.ForEach(x => context.Entry(x).Collection(y => y.InternetSpecials).Load());// Loading related entity

                // This single deletion will take care of all other cascading relation. Only requirement is
                // related entities need to be loaded in memory otherwise EF will not be able to generate required
                // SQL
                context.Destinations.Remove(d);

                context.SaveChanges();
            }
        }

        static void FailureToDeleteWithFKRelation()
        {
            using (var context = new BreakAwayContext())
            {
                var d = new Destination { DestinationId = 1 };

                // This statement locally attaches the Destination instance
                context.Destinations.Attach(d);

                // 1
                context.Destinations.Local.ToList().ForEach(DisplayDestination);

                // This will fail generally because Lodging is related with this destination
                context.Destinations.Remove(d);

                context.SaveChanges();
            }
        }

        static void DeleteWithSQL()
        {
            using (var context = new BreakAwayContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Destinations] WHERE [DestinationId] = 4");
            }
        }

        static void Delete()
        {
            using (var context = new BreakAwayContext())
            {
                var d = new Destination { DestinationId = 2 };// Stub

                context.Entry(d).State = EntityState.Unchanged;

                // Operation will fail if destinationId doesn't exist in DB
                context.Destinations.Remove(d);
                context.SaveChanges();

                context.Destinations.ToList().ForEach(DisplayDestination);
            }
        }
    }
}
