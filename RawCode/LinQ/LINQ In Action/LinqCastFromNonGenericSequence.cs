using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinqCastFromNonGenericSequence
{
    internal static class Client
    {
        private static ArrayList ListOfObjects;
        private static ArrayList ListOfBooks;

        static Client()
        {
            ListOfObjects = new ArrayList
            {
                new Publisher { Name="Fun Books Publisher" },
                new Publisher { Name="Joe Publishing" },
                new Publisher { Name="I Publisher" },
                new Author { FirstName="Johnny", LastName="Good" },
                new Author { FirstName="Graziella", LastName="Simplegame" },
                new Author { FirstName="Octavio", LastName="Prince" },
                new Author { FirstName="Jeremy", LastName="Legrand" }
            };

            ListOfBooks = new ArrayList
            {
                new Fiction { Title = "War & Peace" },
                new NonFiction { Title = "Mao" },
                new Fiction { Title = "Catch-22" },
                new NonFiction { Title = "The Politics" }
            };
        }

        public static void Main()
        {
            IEnumerable<Publisher> publishers = ListOfObjects.OfType<Publisher>();
            publishers.IterateOverSequence<Publisher>();

            IEnumerable<Author> authors = ListOfObjects.OfType<Author>();
            authors.IterateOverSequence<Author>();

            ListOfObjects.IterateOverSequence();

            IEnumerable<IBook> books = ListOfBooks.Cast<IBook>();
            books.IterateOverSequence<IBook>();

            IEnumerable<Fiction> fictions = ListOfBooks.Cast<Fiction>();

            //Poi: LINQ operates on deferred execution. That is the above line DIDN'T cast the objects to 'Fiction' but
            //during iteration (via foreach) below Cast<T> will be applied. So cast operation will fail than

            fictions.IterateOverSequence<Fiction>();

            IEnumerable<NonFiction> nonFictions = ListOfBooks.Cast<NonFiction>();
            //nonFictions.IterateOverSequence<NonFiction>();

            //Poi: On generic collection it's enough to Cast that to object to have access to IEnumerable<T> extension methods
            new ArrayList().IterateOverSequence();
        }

        private static void IterateOverSequence(this IEnumerable source)
        {
            if(source == null || !source.Cast<object>().Any()) return;

            try
            {
                Console.WriteLine();
                foreach(object model in source)
                {
                    //Qry: Why is the proper name printed in console? Type is 'object' it should print the default ToString() value unless casted
                    //to proper TYPE
                    Console.WriteLine(model);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void IterateOverSequence<TModel>(this IEnumerable<TModel> source)
        {
            if(source == null || !source.Any()) return;

            try
            {
                Console.WriteLine();
                foreach(TModel model in source)
                {
                    Console.WriteLine(model);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        private interface IBook
        {
            string Title { get; set; }
        }

        private class Fiction : IBook
        {
            public string Title { get; set; }

            public override string ToString() => Title;
        }

        private class NonFiction : IBook
        {
            public string Title { get; set; }

            public override string ToString() => Title;
        }
    }
}
