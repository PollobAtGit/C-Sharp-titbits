using System;
using System.Linq;
using System.Collections.Generic;

namespace Enum_103
{
    internal enum DAY
    {
        SAT,
        MON,
        TUE
    }

    internal static class Client
    {
        public static void Main()
        {
            //Poi: System.Array is not same as array of any type (Type[])
            //Poi: System.Array contains all elements as 'object'
            DAY[] days = Enum.GetValues(typeof(DAY)) as DAY[];

            //Poi:LINQ query operator 'OfType' & 'Cast' are extension methods for 'IEnumerable'
            IEnumerable<DAY> daysSeq = Enum.GetValues(typeof(DAY)).OfType<DAY>();

            //Poi: Enum.GetValues(Type) returns a System.Array type
            foreach(object enumElement in Enum.GetValues(typeof(DAY)))
            {
                Console.WriteLine(enumElement);
            }

            Console.WriteLine();
            daysSeq.ForEach((el) => Console.WriteLine(el));

            Console.WriteLine();

            //This predicate does nothing
            Action<DAY> predicate = el => { };
            predicate(DAY.SAT);
        }

        private static void ForEach(this IEnumerable<DAY> source, Action<DAY> predicate)
        {
            //Poi: For all elements in source apply the PLUGGED IN predicate
            foreach(DAY el in source)
            {
                predicate(el);
            }
        }
    }
}
