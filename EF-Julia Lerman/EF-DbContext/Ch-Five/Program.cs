using ObjectModel.DAL;
using ObjectModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_Five
{
    class Program
    {
        static Action<object> cl = (object x) => Console.WriteLine(x);
        static Action NewLine = () => Console.WriteLine();

        static void Main(string[] args)
        {
            GetAll();
            GetStateForAll();
        }

        private static void GetStateForAll()
        {
            using (var context = new BreakAwayContext())
            {
                // POI: ToList() doesn't make the objects untrackable
                var destinations = context.Destinations.ToList();

                destinations.ForEach(x => cl($"{x.Name} => {context.Entry(x).State}")); NewLine();

                // POI: Change tracker literally tracks VALUE. As values are same here
                // tracker will keep the state as UnModified
                destinations[1].Name = destinations[1].Name;

                // POI: Setting EntityState to Modified
                destinations[2].Name = $"[{destinations[2].Name}]";
                destinations[3].Name = $"{{{destinations[3].Name}}}";

                GetAllEntityStates(context, destinations);

                // POI: EF doesn't reflect changes of UnModified & Detached entities
                // to DB when SaveChanges() are invoked
                context.Entry(destinations[2]).State = EntityState.Detached;

                GetAllEntityStates(context, destinations);

                context.SaveChanges();

                GetAllEntityStates(context, context.Destinations.ToList());
            }
        }

        private static void GetAllEntityStates(BreakAwayContext context, List<Destination> destinations)
        {
            destinations.ForEach(x =>
            {
                DbEntityEntry<Destination> entityState = context.Entry(x);
                cl($"{x.Name} => {entityState.State}");
            }); NewLine();
        }

        private static void GetAll()
        {
            using (var context = new BreakAwayContext())
            {
                context.Destinations.ToList().ForEach(x => cl(x)); NewLine();
            }
        }
    }
}
