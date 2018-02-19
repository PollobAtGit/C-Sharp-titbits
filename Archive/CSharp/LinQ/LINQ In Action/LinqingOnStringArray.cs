using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqingOnStringArray
{
    public class Client
    {
        public static void Main()
        {
            string[] strs = new string[]
            {
                "CORE I3",
                "INTEL",
                "MS",
                "HP",
                "FLUX"
            };

            IEnumerable<string> resultSet = from str in strs where str.Length > 3 orderby str descending select str.ToLower();
            foreach(var str in resultSet)
            {
                Console.WriteLine(str);
            }

            IEnumerable<string> result = strs
                .Where<string>(str => str.Length < 3)
                .Select<string, string>(str => str)
                .OrderBy<string, string>(str => str);//Poi: 'OrderBy<string, string>(...)' can be used before/after 'Select<string, string>(...)'

            Console.WriteLine();
            foreach(var str in result)
            {
                Console.WriteLine(str);
            }

            //Poi: There isn't any LINQ query expression equivalent for LINQ query operator 'Where<TSource>(..., Func<TSource, int, bool>)'
            IEnumerable<string> evenIndexedStrs = strs
                .Where<string>((str, i) => (i % 2 == 0))
                .Select<string, string>(str => ("EVEN_INDEXED: " + str));

            Console.WriteLine();
            foreach(var str in evenIndexedStrs)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();

            //Poi: 'Where<TSource>(..., Func<TSource, int, bool>)' takes 'Func<...>' that is a delegate
            //So any defined (non-anonymous) methods can be provided as parameter too

            //Poi: Here 'Select<TSource, TResult>(..., Func<TSource, TResult>)' hasn't been used. There's no necessity as no transformation is required
            IEnumerable<string> oddIndexStrs = strs.Where<string>((str, i) => isOdd(str, i));
            foreach(var str in oddIndexStrs)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
            IEnumerable<string> satisfactoryStrs = strs.Where<string>((str, i) => isSatisfyCriteria(str, i));
            foreach(var str in satisfactoryStrs)
            {
                Console.WriteLine(str);
            }
        }

        public static bool isOdd(string str, int i) => i % 2 != 0;
        public static bool isSatisfyCriteria(string str, int i) => str.Length > 2 && i == 1;
    }
}