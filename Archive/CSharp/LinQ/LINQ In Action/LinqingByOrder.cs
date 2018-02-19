using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqingByOrder
{
    public class Book
    {
        public IEnumerable<Author> Authors { get; set; }
        public String Isbn { get; set; }
        public Decimal Price { get; set; }
        public String Title { get; set; }

        public override String ToString()
        {
          return Title + " || ISBN => " + Isbn;
        }
    }

    public class Author
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String WebSite { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    internal class Client
    {
        public static void Main()
        {

            //Poi: IOrderedEnumerable<TElement> implements IEnumerable<TElement>
            IOrderedEnumerable<Book> booksOrderedByTitle = _books.OrderBy<Book, string>(book => book.Title);
            IOrderedEnumerable<Book> booksOrderByTitleThenByPriceAsc = _books
                .OrderBy<Book, string>(book => book.Title)
                .ThenBy<Book, decimal>(book => book.Price);

            IOrderedEnumerable<Book> booksOrderByTitleDescThenByPriceDesc = _books
                .OrderByDescending<Book, string>(book => book.Title)
                .ThenByDescending<Book, decimal>(book => book.Price);

            IterateOverSequence<Book>(booksOrderedByTitle);
            IterateOverSequence<Book>(booksOrderByTitleThenByPriceAsc);
            IterateOverSequence<Book>(booksOrderByTitleDescThenByPriceDesc);

        }

        private static void IterateOverSequence<T>(IEnumerable<T> source)
        {
            Console.WriteLine();
            foreach(T item in source)
            {
                Console.WriteLine(item);
            }
        }

        private static Author[] _authors = new Author[]
        {
            new Author { FirstName="Johnny", LastName="Good" },
            new Author { FirstName="Graziella", LastName="Simplegame" },
            new Author { FirstName="Octavio", LastName="Prince" },
            new Author { FirstName="Jeremy", LastName="Legrand" }
        };

        private static Book[] _books = new Book[]
        {
          new Book
          {
            Title="Funny Stories",
            Authors=new[]{_authors[0], _authors[1]},
            Price=25.55M,
            Isbn="0-000-77777-2"
          },
          new Book
          {
            Title="Funny Stories",
            Authors=new[]{_authors[0], _authors[1]},
            Price=25.00M,
            Isbn="0-000-77777-0"
          },
          new Book
          {
            Title="LINQ rules",
            Authors=new[]{_authors[2]},
            Price=12M,
            Isbn="0-111-77777-2"
          },
          new Book
          {
            Title="C# on Rails",
            Authors=new[]{_authors[2]},
            Price=35.5M,
            Isbn="0-222-77777-2"
          },
          new Book
          {
            Title="All your base are belong to us",
            Authors=new[]{_authors[3]},
            Price=35.5M,
            Isbn="0-333-77777-2"
          },
          new Book
          {
            Title="Bonjour mon Amour",
            Authors=new[]{_authors[1], _authors[0]},
            Price=29M,
            Isbn="2-444-77777-2"
          }
        };
    }
}