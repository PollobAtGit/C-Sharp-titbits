using System;

internal static class Solution
{
    internal static void Main()
    {
        var input = Console.ReadLine();

        while(input != default(string) && int.Parse(input) != 42)
        {
            Console.WriteLine(input);
            input = Console.ReadLine();
        }
    }
}
