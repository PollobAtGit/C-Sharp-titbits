using System;

class Ans
{
    internal static void Main()
    {
        var intArr = new int[] { 0, 30, 3, 2, 1, 3, 2, 10 };
        //var intArr = new int[] { 0, 2, 1 };
        //var intArr = new int[] { 0, 0 };

        //CNST: Values are in the range from 0 - (n - 2)
        //var intArr = new int[] {  0, 2, 1, -2, -2 };

        var duplicateValue = GetFirstDuplicateValue(intArr);

        var searchResult = duplicateValue != null ? duplicateValue.ToString() : "No Duplicate Exists";
        Console.WriteLine(searchResult);
    }

    //TODO: Handle negative values & values that will get out of index
    internal static int? GetFirstDuplicateValue(int[] array)
    {
        //TRD-OFF: Using extra memory
        //DRWBK: Can't handle negative numbers
        //DRWBK: Value to check MUST be within array's index range
        var duplicatIndicator = new bool[array.Length];

        //CMPLX: O(n)
        foreach(var element in array)
        {
            //POI: Guard clause (Ignore values out of range)
            if(!IsElementBoundInRange(element, array.Length)) continue;
            if(duplicatIndicator[element]) return element;
            duplicatIndicator[element] = true;
        }

        return null;
    }

    //POI: Check for TIGHT bound
    internal static bool IsElementBoundInRange(int element, int length) => element >= 0 && element < length;
}