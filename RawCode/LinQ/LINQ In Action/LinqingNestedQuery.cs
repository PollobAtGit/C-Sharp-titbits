using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqingNestedQuery
{
    public class Client
    {
        public static void Main()
        {
            IEnumerable<string> costlyBookAuthors = _books
                .Where<Book>(book => book.Price >= 25.00m)
                .SelectMany<Book, Author>(book => book.Authors)
                .OrderBy<Author, string>(author => author.ToString())
                .Select<Author, string>(author => author.ToString())
                .Distinct<string>();

            IterateOverSequence<string>(costlyBookAuthors);

            IEnumerable<PublisherBooksViewModel> booksPerPublisher = _publishers
                .Select<Publisher, PublisherBooksViewModel>(publisher =>
                    new PublisherBooksViewModel
                    {
                        PublisherName = publisher.ToString(),
                        BookNames = _books
                            .Where<Book>(book => book.Publisher.ToString() == publisher.ToString())
                            .Select<Book, string>(book => book.Title)
                    });

            IterateOverSequence<PublisherBooksViewModel>(booksPerPublisher);

            IterateOverSequence<PublisherBooksViewModel>(GetPublisherBooksViewModelByGroupBy());
        }

        private static IEnumerable<PublisherBooksViewModel> GetPublisherBooksViewModelByGroupBy()
        {
            IEnumerable<PublisherBooksViewModel> booksPerPublisher = _books
                .GroupBy<Book, string>(book => book.Publisher.Name)
                .Select<IGrouping<string, Book>, PublisherBooksViewModel>(groupedBooks =>
                    new PublisherBooksViewModel
                    {
                        PublisherName = groupedBooks.Key,
                        BookNames = groupedBooks.Select<Book, string>(book => book.Title)
                    });

            return booksPerPublisher;
        }

        private static void IterateOverSequence<T>(IEnumerable<T> source)
        {
            if(source == null) return;

            Console.WriteLine();
            foreach(T item in source)
            {
                Console.WriteLine(item);
            }
        }

        private static Publisher[] _publishers = new Publisher[]
        {
            new Publisher {Name="FunBooks"},
            new Publisher {Name="Joe Publishing"},
            new Publisher {Name="I Publisher"}
        };

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
            Publisher=_publishers[0],
            Authors=new[]{_authors[0], _authors[1]},
            Price=25.55M,
            Isbn="0-000-77777-2"
          },
          new Book
          {
            Title="Funny Stories",
            Publisher=_publishers[1],
            Authors=new[]{_authors[0], _authors[1]},
            Price=25.00M,
            Isbn="0-000-77777-0"
          },
          new Book
          {
            Title="LINQ rules",
            Publisher=_publishers[1],
            Authors=new[]{_authors[2]},
            Price=12M,
            Isbn="0-111-77777-2"
          },
          new Book
          {
            Title="C# on Rails",
            Publisher=_publishers[1],
            Authors=new[]{_authors[2]},
            Price=35.5M,
            Isbn="0-222-77777-2"
          },
          new Book
          {
            Title="All your base are belong to us",
            Publisher=_publishers[1],
            Authors=new[]{_authors[3]},
            Price=35.5M,
            Isbn="0-333-77777-2"
          },
          new Book
          {
            Title="Bonjour mon Amour",
            Publisher=_publishers[0],
            Authors=new[]{_authors[1], _authors[0]},
            Price=29M,
            Isbn="2-444-77777-2"
          }
        };

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

        private class PublisherBooksViewModel
        {
            public string PublisherName { get; set; }
            public IEnumerable<string> BookNames { get; set; }

            public override string ToString()
            {
                return "Publisher Name: " + PublisherName + " || Books: " + String.Join<string>(", ", BookNames);
            }
        }
    }
}