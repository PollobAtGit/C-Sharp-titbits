using System;
using System.Collections.Generic;

internal static class Ans
{
    internal static void Main()
    {
        var t = System.Int32.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var sumToCheck = Int32.Parse(Console.ReadLine());
            var inputArray = Array.ConvertAll(Console.ReadLine().Split(' '), System.Int32.Parse);

            Console.WriteLine(GetOperandsForSummation(inputArray, sumToCheck));
        }
    }

    internal static System.String GetOperandsForSummation(System.Int32[] inputArray, System.Int32 summation)
    {
        var hashTable = new Dictionary<Int32, Int32>();

        foreach(var aOperand in inputArray)
        {
            if(hashTable.ContainsKey(aOperand)) return $"{hashTable[aOperand]} + {aOperand} = {summation}";
            hashTable[summation - aOperand] = aOperand;
        }

        return "No combination found";
    }
}