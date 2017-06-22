using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqingWithGroupBy
{
    internal class Client
    {
        private static Publisher[] Publishers;
        private static Author[] Authors;
        private static Book[] Books;

        static Client()
        {
            Publishers = new Publisher[]
            {
                new Publisher { Name="FunBooks" },
                new Publisher { Name="Joe Publishing" },
                new Publisher { Name="I Publisher" }
            };

            Authors = new Author[]
            {
                new Author { FirstName="Johnny", LastName="Good" },
                new Author { FirstName="Graziella", LastName="Simplegame" },
                new Author { FirstName="Octavio", LastName="Prince" },
                new Author { FirstName="Jeremy", LastName="Legrand" }
            };

            Books = new Book[]
            {
                new Book
                {
                    Title = "Funny Stories",
                    Publisher = Publishers[0],
                    Authors = new [] { Authors[0], Authors[1] },
                    Price = 25.55M,
                    Isbn = "0-000-77777-2"
                },
                new Book
                {
                    Title = "Funny Stories",
                    Publisher = Publishers[1],
                    Authors = new [] { Authors[0], Authors[1] },
                    Price = 25.00M,
                    Isbn = "0-000-77777-0"
                },
                new Book
                {
                    Title = "LINQ rules",
                    Publisher = Publishers[1],
                    Authors = new [] { Authors[2] },
                    Price = 12M,
                    Isbn = "0-111-77777-2"
                },
                new Book
                {
                    Title = "C# on Rails",
                    Publisher = Publishers[1],
                    Authors = new[]{ Authors[2] },
                    Price = 35.5M,
                    Isbn = "0-222-77777-2"
                },
                new Book
                {
                    Title = "All your base are belong to us",
                    Publisher = Publishers[1],
                    Authors = new [] { Authors[2] },
                    Price = 35.5M,
                    Isbn = "0-333-77777-2"
                },
                new Book
                {
                    Title = "Bonjour mon Amour",
                    Publisher = Publishers[1],
                    Authors = new [] { Authors[3] },
                    Price = 29M,
                    Isbn = "2-444-77777-2"
                }
            };
        }

        public static void Main()
        {
            IEnumerable<IGrouping<Publisher, Book>> resultSet = Books.GroupBy<Book, Publisher>(book => book.Publisher);
            IEnumerable<string> bookTitles = Books.Select<Book, string>(book => book.Title);

            IEnumerable<Book> booksByPublisher = Books
                .GroupBy<Book, Publisher>(book => book.Publisher)
                .SelectMany<IGrouping<Publisher, Book>, Book>(group => group);

            IEnumerable<string> rsltSet = Books
                .GroupBy<Book, Publisher>(book => book.Publisher)
                .Select<IGrouping<Publisher, Book>, string>(group =>
                    group.Key + " => " + string.Join(", ", group.Select<Book, string>(book => book.ToString()))
                );

            IterateOverSequence(resultSet);
            IterateOverSequence<string>(rsltSet);
            IterateOverSequence<Book>(booksByPublisher);
        }

        private static void IterateOverSequence<T>(IEnumerable<T> source)
        {
            if(source == null || !source.Any()) return;

            Console.WriteLine();
            foreach(T model in source)
            {
                Console.WriteLine(model);
            }
        }

        private static void IterateOverSequence(IEnumerable<IGrouping<Publisher, Book>> source)
        {
            if(source == null || !source.Any()) return;

            Console.WriteLine();
            foreach(IGrouping<Publisher, Book> group in source)
            {
                foreach(Book book in group)
                {
                    Console.WriteLine(group.Key + "\t" + book);
                }
            }
        }

        private class Book
        {
            public IEnumerable<Author> Authors { get; set; }
            public String Isbn { get; set; }
            public Decimal Price { get; set; }
            public String Title { get; set; }
            public Publisher Publisher {get; set;}

            public override String ToString()
            {
                return Title + " || ISBN => " + Isbn;
            }
        }

        private class Author
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String WebSite { get; set; }

            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
        }

        private class Publisher
        {
            public String Name {get; set;}
            public String WebSite {get; set;}

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
