using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqingAggregateQueryOperator
{
    public class Book { public decimal Price { get; set; } }

    public class Client
    {
        public static void Main()
        {
            IEnumerable<Book> books = new List<Book>
            {
                new Book { Price = 23.02m },
                new Book { Price = 100.12m },
                new Book { Price = 0.56m }
            };

            decimal totalPrice = books.Sum<Book>(book => book.Price);
            decimal maxPrice = books.Max<Book>(book => book.Price);
            decimal minPrice = books.Min<Book>(book => book.Price);

            //Poi: Identical to above. 1st Step gives 'IEnumerable<decimal>' & '.Sum<decimal>()' is invoked on that
            decimal totalBookPrice = books.Select<Book, decimal>(book => book.Price).Sum<decimal>(price => price);
            decimal maxBookPrice = books.Select<Book, decimal>(book => book.Price).Max<decimal>();
            decimal minBookPrice = books.Select<Book, decimal>(book => book.Price).Min<decimal>();

            Console.WriteLine(totalPrice);
            Console.WriteLine(totalBookPrice);

            Console.WriteLine(maxPrice);
            Console.WriteLine(maxBookPrice);

            Console.WriteLine(minPrice);
            Console.WriteLine(minBookPrice);
        }
    }
}