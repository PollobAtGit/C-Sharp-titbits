using Ch_Two.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_Two
{
    static class Loading
    {
        static Action<object> cl = (object x) => Console.WriteLine(x);

        public static void Main()
        {
            //Example_2_23();
            //Example_2_23_Explicit_Loading();
            //Example_2_23_Eager_Single();
            Example_2_23_Eager_Single_With_Include();
        }

        private static void Example_2_23_Eager_Single_With_Include()
        {
            using (var context = new BreakAwayContext())
            {
                // POI: If Single/First etc. are required then for eager loading perform thos actions on Include
                // POI: Single fetch with JOIN for Lodgings

                // POI: Because it's eager loading we are loading even if Lodgings are not used
                // POI: Explicit loading/lazy loading can help solve the problem

                var firstDestination =
                    context
                    .Destinations
                    .Include(x => x.Lodgings)
                    .First();

                cl(firstDestination.Lodgings != null);
            }
        }

        private static void Example_2_23_Eager_Single()
        {
            using (var context = new BreakAwayContext())
            {
                // POI: Single Query without JOIN
                var firstDestination = context.Destinations.First();

                // POI: At this place we have no other way to load Lodgings if that's not virtual 
                // & also we don't use explicit loading

                // POI: Because Lodgings is not virtual
                cl(firstDestination.Lodgings == null);
            }
        }

        private static void Example_2_23_Explicit_Loading()
        {
            using (var context = new BreakAwayContext())
            {
                // POI: Single query to DB
                var firstDestination = context.Destinations.First();

                context
                    .Entry(firstDestination)

                    // POI: Alternative for using virtual on POCO navigation property
                    .Collection(x => x.Lodgings)

                    // POI: Another Query to DB
                    .Load();

                firstDestination.Lodgings.ForEach(x => cl(x.Name));
            }
        }

        static void Example_2_23()
        {
            using (var context = new BreakAwayContext())
            {
                context.Destinations.Load();

                // POI: Getting data from Local
                context.Destinations.Local.ToList().ForEach(x => cl(x.Name));

                cl("");

                // POI: Because Lodging is not virtual. EF didn't create dynamic proxy class. 
                // So navigation properties are null
                context.Destinations.Local.ToList().ForEach(x => cl(x.Lodgings != null));// False .....
            }

            using (var context = new BreakAwayContext())
            {
                // POI: Because of .Include(...) SQL query will contain a JOIN
                context.Destinations.Include(x => x.Lodgings).Load();

                cl("");

                // POI: Navigation properties are valid objects (not null) even though they 
                // might not have any data
                context.Destinations.Local.ToList().ForEach(x => cl(x.Lodgings != null));// True ......
            }

            using (var context = new BreakAwayContext())
            {
                cl("");

                context.Destinations.Load();
                context.Destinations.Local.ToList().ForEach(x => cl(x.Lodgings != null));

                cl("");

                // POI: Include returns IQuerable<T>. So it doesn't load data unless Load() 
                // is invoked in that IQuerable<T>
                context.Destinations.Include(x => x.Lodgings);
                context.Destinations.Local.ToList().ForEach(x => cl(x.Lodgings != null));
            }
        }
    }
}
