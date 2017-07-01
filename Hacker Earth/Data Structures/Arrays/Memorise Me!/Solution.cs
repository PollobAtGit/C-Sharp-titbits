using System;
using System.Collections.Generic;

internal static class Solution
{
    internal static void Main()
    {
        var n = Int32.Parse(Console.ReadLine());
        var array = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Int32.Parse);

        var hash = new Dictionary<int, int>();

        for(var i = 0; i < array.Length; i++)
        {
            if(hash.ContainsKey(array[i]))
            {
                hash[array[i]] = hash[array[i]] + 1;
            }
            else
            {
                hash.Add(array[i], 1);
            }
        }

        var q = Int32.Parse(Console.ReadLine());
        while(--q >= 0)
        {
            var query = Int32.Parse(Console.ReadLine());

            if(hash.ContainsKey(query))
            {
                Console.WriteLine(hash[query]);
            }
            else
            {
                Console.WriteLine("NOT PRESENT");
            }
        }
    }
}