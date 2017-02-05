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
    }
  }
}
