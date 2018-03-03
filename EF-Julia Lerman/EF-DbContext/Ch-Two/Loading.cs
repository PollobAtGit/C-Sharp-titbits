using ObjectModel.DAL;
using System;
using System.Data.Entity;
using System.Linq;

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
            //Example_2_23_Eager_Single_With_Include();
            //Page_38();
            //Page_38_Load_All_Navigation();
            //Page_38_Query_On_Collection_Ref();
            //Page_38_Lazy_Loading_ToDB_Even_If_Local_IsLoaded();
            //Page_39_Query_Lodging_Distance();
        }

        private static void Page_39_Query_Lodging_Distance()
        {
            using (var context = new BreakAwayContext())
            {
                var d = context.Destinations.First();

                cl(d.Lodgings == null);

                // When Lazy loading is no enabled for navigation property
                var distanceQuery =
                    d.Lodgings
                    .Where(x => x.MilesFromNearestAirport <= 10);

                distanceQuery.ToList().ForEach(x => cl(x.Name));
            }
        }

        private static void Page_38_Lazy_Loading_ToDB_Even_If_Local_IsLoaded()
        {
            using (var context = new BreakAwayContext())
            {
                var d = context
                    .Destinations
                    .Where(x => x.Lodgings.Count != 0)
                    .First();// Last(...) not recognized?

                d.Lodgings.ToList();

                cl(context.Lodgings.Local.Count);

                // POI: Interesting! This statement is not issue-ing a query to DB seems like it's 
                // using the previous loaded result
                d.Lodgings.ToList();
            }
        }

        private static void Page_38_Query_On_Collection_Ref()
        {
            using (var context = new BreakAwayContext())
            {
                var l = context.Lodgings.First();
                var cll = context
                    .Entry(l)
                    .Collection(x => x.InternetSpecials);

                cll
                    .Query()
                    .Where(x => x.Id == 123) // No data will be returned for this query
                    .Load();

                // TODO: Why IsLoaded not working properly when used with Query()
                cl(cll.IsLoaded);// False

                //cl(l.InternetSpecials.First().Id);

                // POI: Query() returned IQuerable<T> which returned no records so navigation property is null
                cl(l.InternetSpecials == null);// True
            }
        }

        private static void Page_38_Load_All_Navigation()
        {
            using (var context = new BreakAwayContext())
            {
                var l = context.Lodgings.First();

                var e = context.Entry(l);
                var cll = e.Collection(x => x.InternetSpecials);
                var r = e.Reference(x => x.PrimaryContact);
                var sr = e.Reference(x => x.SecondaryContact);

                cll.Load();
                r.Load();

                // POI: Better approach then checking null against collection or reference
                cl(cll.IsLoaded);// True
                cl(r.IsLoaded);// True
                cl(sr.IsLoaded);// False
            }
        }

        private static void Page_38()
        {
            using (var context = new BreakAwayContext())
            {
                var l = context.Lodgings.First();

                cl(l.PrimaryContact == null);// True
                cl(context.Lodgings.Local.First().PrimaryContact == null);// True

                context
                    .Entry(l)
                    .Reference(x => x.PrimaryContact)
                    .Load();

                // POI: Referencing navigation property using the parent object
                cl(l.PrimaryContact != null);// True
                cl(l.PrimaryContact.Id);// 1

                // POI: Though Local cache coul have been used too
                cl(context.Lodgings.Local.First().PrimaryContact != null);// True

                // POI: Reference(...) has been used to explicitly load a Navigation property that is
                // not a collection that's why the Collection property is not initialized
                cl(l.InternetSpecials == null);// True
            }
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
