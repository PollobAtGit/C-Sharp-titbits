using System;

internal static class Solution
{
    internal static void Main()
    {
        Console.ReadLine();

        var array = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Int32.Parse);

        long moduloSum = 1;

        foreach(var item in array)
        {
            moduloSum = (moduloSum * item) % 1000000007;
        }

        Console.WriteLine(moduloSum);
    }
}