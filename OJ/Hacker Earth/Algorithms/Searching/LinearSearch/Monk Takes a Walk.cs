using System;
using System.Linq;

internal static class Solution
{
    internal static void Main()
    {
        var t = Int32.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var str = Console.ReadLine();
            Console.WriteLine(CountVowels(str));
        }
    }

    private static int CountVowels(string str)
    {
        char[] vowels = { 'A', 'E', 'I', 'O', 'U' ,'a','e','i','o', 'u' };
        return str.Where(ch => vowels.Contains(ch)).Count();
    }
}

