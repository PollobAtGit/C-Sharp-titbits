using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqingWithDistinct
{

    public class Author : IEquatable<Author>
    {
        public string Name { get; set; }

        public bool Equals(Author otherAthr) => this.Name == otherAthr.Name;

        //Qry: Why override 'GetHashCode()' to make comparison work?
        public override int GetHashCode() => Name == null ? 0 : Name.GetHashCode();
    }

    public class Book { public IEnumerable<Author> Authors { get; set; } }

    public class Client
    {
        public static void Main()
        {
            IEnumerable<Book> books = new List<Book>
            {
                new Book
                {
                    Authors = new Author[]
                    {
                        new Author { Name = "SONJIB" },
                        new Author { Name = "EDITH" }
                    }
                },
                new Book
                {
                    Authors = new Author[]
                    {
                        new Author { Name = "EDITH" },
                        new Author { Name = "HARUN" }
                    }
                }
            };

            //Poi: This combination / chaining of '...SelectMany' & '...Select' is useful & it's more like FLAT-MAP
            //  #1st get the flattened list by using '...SelectMany' if relationship with 'TSource' to 'TResult' is one to many
            //  #2nd transform / map the flattened list using '...Select'

            string[] authorNames = books
                .SelectMany<Book, Author>(book => book.Authors)
                .Select<Author, string>(author => author.Name)
                .ToArray<string>();

            foreach(var authorName in authorNames.Distinct<string>())
            {
                Console.WriteLine(authorName);
            }

            string[] distinctNames = books
                .SelectMany<Book, Author>(book => book.Authors)
                .Select<Author, string>(author => author.Name)
                .Distinct<string>()
                .ToArray<string>();

            Console.WriteLine();
            foreach(var name in distinctNames)
            {
                Console.WriteLine(name);
            }

            string[] authors = books
                .SelectMany<Book, Author>(book => book.Authors)
                //.Distinct() //Poi: Distinct<Author> here will have no impact if 'IEquatable<T>' isn't implemented for 'Author'
                .Select<Author, string>(author => author.Name)
                .ToArray<string>();

            Console.WriteLine();
            foreach(var names in authors)
            {
                Console.WriteLine(names);
            }

            Author[] distinctAuthors = books
                .SelectMany<Book, Author>(book => book.Authors)
                .Distinct<Author>()
                .ToArray<Author>();

            Console.WriteLine();
            foreach(var names in distinctAuthors)
            {
                Console.WriteLine(names.Name);
            }
        }
    }
}