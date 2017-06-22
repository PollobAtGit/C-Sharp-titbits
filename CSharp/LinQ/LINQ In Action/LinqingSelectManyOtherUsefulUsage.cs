using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqingQithSelectMany
{
    public class Client
    {
        public static void Main()
        {
            string[] words = new string[] { "A,B", "C,D", "E,F" };

            //Poi: Splitting string will return another IEnumerable<string>. In this case, we are getting more strings than we started
            //It's more like a 2D array
            IEnumerable<IEnumerable<string>> rows = words.Select<string, IEnumerable<string>>(str => str.Split(','));
            foreach(var row in rows)
            {
                foreach(var cell in row)
                {
                    Console.WriteLine(cell);
                }
            }

            Console.WriteLine();
            IEnumerable<string> rowsBySelectMany = words.SelectMany<string, string>(str => str.Split(','));
            foreach(var str in rowsBySelectMany)
            {
                Console.WriteLine(str);
            }
        }
    }
}