using System;
using System.Linq;
using System.Collections.Generic;

internal class Ans
{
    internal static void Main()
    {
        var inputArray = new int[] { 2, 3, 1, 0, 2, 5, 3 };

        List<int> duplicates = new List<int>();
        for(var i = 0; i < inputArray.Length; i++)
        {
            //POI: Because of the swap there's chance for more swap
            while(inputArray[i] != i)
            {
                if(inputArray[inputArray[i]] == inputArray[i])
                {
                    duplicates.Add(inputArray[i]);
                    break;
                }
                else
                {
                    var tmp = inputArray[inputArray[i]];
                    inputArray[inputArray[i]] = inputArray[i];
                    inputArray[i] = tmp;
                }
            }
        }

        Console.WriteLine(string.Join(", ", duplicates.Distinct()));
    }
}