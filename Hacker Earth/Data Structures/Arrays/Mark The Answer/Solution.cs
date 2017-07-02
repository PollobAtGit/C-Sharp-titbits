using System;

internal static class Solution
{
    internal static void Main()
    {
        var line = Console.ReadLine().Trim().Split(' ');
        
        var n = Int32.Parse(line[0]);
        var x = Int32.Parse(line[1]);
        var array = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Int32.Parse);

        var isSkippedOnce = false;
        var questionsAnswered = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if(array[i] <= x)
            {
                questionsAnswered++;
            }
            else if(array[i] > x && !isSkippedOnce)
            {
                isSkippedOnce = true;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(questionsAnswered);
    }
}
