using System;
using System.Linq;

internal static class Solution
{
    internal static void Main()
    {
        var n = Int32.Parse(Console.ReadLine());

        foreach(var item in Enumerable.Range(1, n))
        {
            if(IsPrime(item))
            {
                Console.Write(item + " ");
            }
        }
    }

    internal static bool IsPrime(int n)
    {
        //POI: 1 is not prime
        if(n == 1) return false;

        //POI: 2 & 3 is prime
        if(n <= 3) return true;

        //POI: Check for even numbers at the very beginning of the routine
        if(n % 2 == 0) return false;

        var sqrt = (int)Math.Sqrt((double)n);

        //POI: Start sequencing from 3 & increment by 2
        for (int i = 3; i <= sqrt; i = i + 2)
        {
            if(n % i == 0) return false;
        }

        return true;
    }
}