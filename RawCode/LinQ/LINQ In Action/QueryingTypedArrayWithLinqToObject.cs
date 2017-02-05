using System;
using System.Linq;

namespace LinqToObjectOnTypedArray
{
  public class Client
  {
    public static void Main()
    {
      object[] array = new object[] { "HELMET", 12, 89.023, 00.23m, 100.0f };
      
      foreach(var result in array.Select(elem => elem.GetType().Name).OrderByDescending(elem => elem))
      {
        Console.WriteLine(result);
      }      
    }
  }
}

