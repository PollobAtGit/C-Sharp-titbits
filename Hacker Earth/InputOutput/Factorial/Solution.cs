using System;
using System.Linq;

internal static class Solution
{
    internal static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var factorial = 1;
        foreach(var i in Enumerable.Range(1, n))
        {
            factorial = factorial * i;
        }

        Console.WriteLine(factorial);
    }
}
