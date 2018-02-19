using System;
using System.Linq;

internal class Ans
{
    internal static void Main()
    {
        foreach(var item in Enumerable.Range(1, 100))
            Console.WriteLine(StatusByValue(item));
    }

    internal static string StatusByValue(int item)
    {
        if(item % 3 == 0 & item % 5 == 0) return "FizzBuzz";
        if(item % 5 == 0) return "Buzz";
        return item % 3 == 0 ? "Fizz" : item.ToString();
    }
}