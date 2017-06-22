using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqIngOnDictionary
{
    public class Client
    {
        public static void Main()
        {
            Dictionary<int, string> frenchNumbers = new Dictionary<int, string>
            {
                { 0, "zero" },
                { 1, "un" },
                { 2, "duex" },
                { 3, "trois" },
                { 4, "quatre" }
            };

            //Poi: Note the mentioned Types in 'Where' & 'Select' LINQ queries. For each Dictionary entry one PAIR of entry will be injected
            //inside LINQ query & that pair is of type KeyValuePair<int, string>

            //Poi: Note the second type mentioned in 'Select' Query & that is 'string'. Select performs TRANSFORMATION. Second mentioned type
            //is the resultant type

            IEnumerable<string> evenFrenchNumbers = frenchNumbers
                .Where<KeyValuePair<int, string>>(pair => (pair.Key % 2 == 0))
                    .Select<KeyValuePair<int, string>, string>(pair => pair.Value);

            Console.WriteLine("EVEN NUMBERS\n\n");
            foreach(var evenNumber in evenFrenchNumbers)
            {
                Console.WriteLine(evenNumber);
            }

            Console.WriteLine("\n\nODD NUMBERS\n");
            var oddFrenchNumbers = from entry in frenchNumbers where (entry.Key % 2 != 0) select entry.Value;
            foreach(var oddNumber in oddFrenchNumbers)
            {
                Console.WriteLine(oddNumber);
            }
        }
    }
}
