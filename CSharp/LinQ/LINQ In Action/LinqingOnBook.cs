using System;
using System.Linq;
using System.Collections.Generic;

namespace QueryOnBook
{

  public class Book { public string Title { get; set; } }

  public class Client
  {
    public static void Main()
    {
        var books = new Book[]
        {
          new Book { Title = "LINQ For Fun" },
          new Book { Title = "LINQ In Action" },
          new Book { Title = "Extreme LINQ" }
        };

        //Poi: 'Where' LINQ function will return a IEnumerable<T>. In this case 'T' is 'Book'
        IEnumerable<Book> selectedBooksQuery = books.Where(book => book.Title.Contains("In"));

        foreach(var selectedBook in selectedBooksQuery)
        {
          Console.WriteLine(selectedBook.Title);
        }

        Console.WriteLine("There Are " + books.Count<Book>(book => book.Title.Contains("Fun")) + " Books With Word 'Fun'");
        Console.WriteLine("There Are " + books.Where<Book>(book => book.Title.Contains("Fun")).Count<Book>() + " Books With Word 'Fun'");
        Console.WriteLine();

        //Poi: Anonymous type member's property has been declared with the property name. It could have been written as 'new { book.Title }'
        //but in that case constant value '100.23' cannot be used as 'new { book.Title, 100.23 }'

        IEnumerable<dynamic> anonymousBooks = from book in books
          where book.Title.ToUpper().StartsWith("LINQ")
          select new { BookTitle = book.Title, Price = 100.23 };

        foreach(var book in anonymousBooks)
        {
          Console.WriteLine(book.BookTitle + " || " + book.Price);
        }
    }
  }
}
