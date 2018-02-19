using System;

internal static class Ans
{
    internal static void Main()
    {

        var t = Int32.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var sumToCheck = Int32.Parse(Console.ReadLine());
            var inputArray = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            Console.WriteLine(GetOperandsForSummation(inputArray, sumToCheck));
        }
    }

    //Complexity: O(n^2)
    private static string GetOperandsForSummation(Int32[] input, Int32 summation)
    {
        for(var i = 0; i < input.Length; i++)
            for(var j = i + 1; j < input.Length; j++)
                if(input[i] + input[j] == summation) return $"{input[i]} + {input[j]} = {summation}";

        return "No combination found";
    }
}