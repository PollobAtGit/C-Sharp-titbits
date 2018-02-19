using System;
using System.Collections.Generic;

internal static class Solution
{
    internal static void Main()
    {
        var q = int.Parse(Console.ReadLine());
        var container = new Stack<int>();

        while(--q >= 0)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            if(input[0] == 2)
            {
                container.Push(input[1]);
            }
            else
            {
                if(container.Count == 0)
                {
                    Console.WriteLine("No Food");
                }
                else
                {
                    var c = container.Pop();
                    Console.WriteLine(c);
                }
            }
        }
    }
}
