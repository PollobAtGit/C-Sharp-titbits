using System;
using System.Collections.Generic;

internal class Ans
{
    internal static void Main()
    {
        //var intSequence = new int[] {0, 2, 1, 3, 2};
        //var intSequence = new int[] { 0, 2, 1 };
        //var intSequence = new int[] { 0, 0 };
        var intSequence = new int[] {  0, 2, 1, -2, -2 , -9 , 1, -9 };

        var hashSet = new Dictionary<int, int>();

        //POI: Complexity O(n)
        foreach(var element in intSequence)
        {
            //POI: Complexity O(1)
            if(hashSet.ContainsKey(element))
            {
                hashSet[element]++;
                continue;
            }

            hashSet[element] = 1;
        }

        Console.WriteLine(GetDuplicateList(hashSet));
    }

    //TODO: Find a better approach
    private static System.String GetDuplicateList(Dictionary<int, int> hashSet)
    {
        List<int> duplicates = new List<int>();
        foreach(var element in hashSet)
        {
            if(element.Value > 1)
            {
                duplicates.Add(element.Key);
            }
        }
        return string.Join(", ", duplicates);
    }
}