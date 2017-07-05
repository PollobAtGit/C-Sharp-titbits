using System;
using System.Linq;
using System.Collections.Generic;

internal static class Solution
{
    internal static void Main()
    {
        var n = Int32.Parse(Console.ReadLine());

        var callingOrder = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Int32.Parse);
        var idealOrder = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Int32.Parse);

        var callingOrderQueue = new Queue<int>(callingOrder);

        if(callingOrder.Length != idealOrder.Length) throw new Exception();

        var totalTime = 0;
        foreach(var process in idealOrder)
        {
            while(callingOrderQueue.Any())
            {
                var currentProcess = callingOrderQueue.Dequeue();

                totalTime = totalTime + 1;
                if(currentProcess == process) break;
                callingOrderQueue.Enqueue(currentProcess);
            }
        }

        Console.WriteLine(totalTime);
    }
}