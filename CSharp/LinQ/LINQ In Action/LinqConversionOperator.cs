using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqConversionOperator
{
    //Poi: Extension method must be defined in a non-generic static class
    public static class KeyValuePairExtensionMethods
    {
        public static string ToStringExt<TKey, TValue>(this KeyValuePair<TKey, TValue> pair)
        {
            return pair.Key + " => " + pair.Value;
        }
    }

    public class Book
    {
        public string ISBN { get; set; }

        public override String ToString()
        {
            return ISBN;
        }
    }

    public class Client{
        public static void Main()
        {
            Book[] books = new Book[]
            {
                new Book { ISBN = "DFT" },
                new Book { ISBN = "XCDF" },
                new Book { ISBN = "123" },
                new Book { ISBN = "895" },
                new Book { ISBN = "EMPTY" }
            };

            //Poi: At this stage, 'filteredBooksQry' doesn't contain any Book objects
            IEnumerable<Book> filteredBooksQry = books.Where<Book>(book => book.ISBN.Contains("F"));

            //Poi: At this stage, 'filteredBooks' contains one or more 'Book' objects because '.ToList<Book>()' has been invoked on
            //IEnumerable<Book>. So the query has been materialized
            IList<Book> filteredBooks = books.Where<Book>(book => !book.ISBN.Contains("F")).ToList<Book>();

            //Poi: For Query Operator using '.Select<TSource, TResult>()' is optional. It needs to be used only when mapping or conversion
            //is required. BUT for query expression, 'select' is REQUIRED (think it like SQL)
            IList<Book> booksQueryExpression = (from book in books where book.ISBN.Contains("F") select book).ToList<Book>();

            //Poi: IEnumerable<T> can consume T[] but vice versa isn't true. That is T[] can't consume IEnumerable<T>
            Book[] booksArray = books.Where<Book>(book => !String.IsNullOrEmpty(book.ISBN)).ToArray<Book>();

            int dumpNmbr;
            IDictionary<string, Book> booksDic = books
                .Where<Book>(book => Int32.TryParse(book.ISBN, out dumpNmbr))
                .ToDictionary<Book, string>(book => book.ISBN);

            IDictionary<string, Book> booksDictionary = books.ToDictionary<Book, string>(book => book.ISBN);

            IterateOverSequence(booksDictionary);
            IterateOverSequence(booksDic);
            IterateOverSequence(booksArray);
            IterateOverSequence(filteredBooksQry);
            IterateOverSequence(filteredBooks);
            IterateOverSequence(booksQueryExpression);
        }

        public static void IterateOverSequence(IEnumerable<Book> books)
        {
            Console.WriteLine("\n");
            foreach(Book book in books)
            {
                Console.WriteLine(book);
            }
        }

        public static void IterateOverSequence<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> dic)
        {
            Console.WriteLine("\n");
            foreach(KeyValuePair<TKey, TValue> pair in dic)
            {
                Console.WriteLine(pair.ToStringExt<TKey, TValue>());
            }
        }
    }
}