using System;
using System.Linq;
using System.Collections.Generic;

namespace AnonymousObjectsWithLinqQueryOperator
{
    public class Client
    {
        private interface IBook { }

        private class Book : IBook
        {
            public string Title { get; set; }
            public decimal Price { get; set; }
        }

        private class NumberInfo
        {
            public int Index { get; set; }
            public int Value { get; set; }
            public bool IsOdd { get; set; }
        }

        public static void Main()
        {
            int[] intArray = new int[] { 30, 589, 23 };

            Console.WriteLine("DATA TYPE\tVALUE");

            IEnumerable<string> stringRepresentation = intArray.Select<int, string>(nmbr => nmbr.ToString());
            foreach(var str in stringRepresentation)
            {
                Console.WriteLine(str.GetType() + "\t" + str);
            }

            Console.WriteLine();
            Console.WriteLine("TYPE\tVALUE");

            IEnumerable<dynamic> anonymousList = intArray.Select<int, dynamic>(nmbr => new { Type = "STRING", Value = nmbr });
            foreach(var anonymousObj in anonymousList)
            {
                Console.WriteLine(anonymousObj.Type + "\t" + anonymousObj.Value);
            }

            Console.WriteLine();
            Console.WriteLine("BOOK TITLE\tBOOK PRICE");

            //Poi: This approach is extremely useful for creating 'ViewModel' from retrieved data
            IEnumerable<IBook> books = intArray.Select<int, IBook>(price => new Book { Title = "N/A", Price = price });
            foreach(var book in books)
            {
                Console.WriteLine((book as Book).Title + "\t\t" + (book as Book).Price);
            }

            Console.WriteLine();
            Console.WriteLine("INDEX\tVALUE\tIsOdd");

            IEnumerable<NumberInfo> numberInfoArray = intArray
                .Select<int, NumberInfo>((nmbr, i) => new NumberInfo { Index = i, Value = nmbr, IsOdd = nmbr % 2 != 0 });

            foreach(var numberInfo in numberInfoArray)
            {
                Console.WriteLine(numberInfo.Index + "\t" + numberInfo.Value + "\t" + numberInfo.IsOdd);
            }
        }
    }
}