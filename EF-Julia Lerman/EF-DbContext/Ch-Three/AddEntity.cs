using ObjectModel.DAL;
using ObjectModel.Model;
using System;
using System.Linq;

namespace Ch_Three
{
    static class AddEntity
    {
        static Action<object> cl = (object x) => Console.WriteLine(x);

        public static void Main()
        {
            Page_44Async();
        }

        private static void Page_44Async()
        {
            // TODO: Why EntityFramework is needed when only dependency is on BreakAwayContext? 'Is A' relationship?
            using (var context = new BreakAwayContext())
            {
                context.Destinations.ToList().ForEach(x => cl(x.Name));

                // POI: This operation goes to DB even if data is available in Local
                // POI: It's such because operaiton is being done against DbSet<T>
                if (!context.Destinations.Any(x => x.DestinationId == 4))
                {
                    var d = new Destination
                    {
                        Name = "Maldives",
                        Description = "Paradise",
                        Country = "Bangladesh"
                    };

                    context.Destinations.Add(d);

                    cl("Saving Changes");

                    // TODO: Why await/async not working here?
                    context.SaveChanges();

                    cl(d.DestinationId); // 4
                }
            }
        }
    }
}
