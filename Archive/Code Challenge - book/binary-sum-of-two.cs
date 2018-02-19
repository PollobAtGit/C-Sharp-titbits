using System;

internal static class Ans
{
    internal static void Main()
    {
        var t = System.Int32.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var summation = System.Int32.Parse(Console.ReadLine());
            var inputArray = Array.ConvertAll(Console.ReadLine().Split(' '), System.Int32.Parse);

            Console.WriteLine(GetOperandsForSummation(inputArray, summation));
        }
    }

    private static System.String GetOperandsForSummation(System.Int32[] input, System.Int32 summation)
    {
        if(input.Length <= 1) return "Insufficient Number Of Elements";
        Array.Sort(input);

        for(var i = 0; i < input.Length - 1; i++)
        {
            var operandToFind = summation - input[i];
            if(IsFound(input, i + 1, input.Length - 1, operandToFind)) return $"{input[i]} + {operandToFind} = {summation}";
        }

        return "No combination found";
    }

    private static bool IsFound(System.Int32[] arr, System.Int32 startIndex, System.Int32 endIndex, System.Int32 searchTerm)
    {
        if(startIndex == arr.Length - 1) return arr[startIndex] == searchTerm;
        var midIndex = (startIndex + arr.Length) / 2;
        if(arr[midIndex] > searchTerm) return IsFound(arr, startIndex, midIndex, searchTerm);
        return IsFound(arr, midIndex, arr.Length - 1, searchTerm);
    }
}