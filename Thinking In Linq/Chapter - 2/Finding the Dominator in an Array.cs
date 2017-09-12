using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class ToLookup
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 2, 2, 2, 3, 2, 3, 3, 2, 2 };
            foreach (var e in array.Where(i => array.Where(k => k == i).Count() > array.Length / 2).Distinct())
            {
                Console.WriteLine(e);
            }

            var lookup = array.ToLookup(x => x).Where(x => x.Count() >= array.Length / 2);

            foreach (var k in lookup)
            {
                Console.WriteLine($"{k.Key} => {k.Count()}");
            }


            Console.ReadKey();
        }
    }
}
