using System;

internal static class Ans
{
    private static int[,] _matrix = new int[,]
    {
        { 1, 3, 5 },
        { 7, 9, 11 },
        { 13, 15, 17 }
    };

    private static readonly int searchTerm = 9;

    static Ans()
    {
        searchTerm = int.Parse(Console.ReadLine());
    }

    internal static void Main()
    {
        Console.WriteLine(BinarySearch() ? (searchTerm + " Found") : "Item Doesn't exist");
    }

    private static bool BinarySearch()
    {
        var startIndex = 0;
        var endIndex = _matrix.Length - 1;
        var midIndex = startIndex + (endIndex - startIndex) / 2;
        var midValue = _matrix[DecodeRow(midIndex), DecodeColumn(midIndex)];

        while(startIndex < endIndex)
        {
            if(searchTerm > midValue) startIndex = midIndex + 1;
            if(searchTerm < midValue) endIndex = midIndex - 1;
            if(searchTerm == midValue) return true;

            midIndex = startIndex + (endIndex - startIndex) / 2;
            midValue = _matrix[DecodeRow(midIndex), DecodeColumn(midIndex)];
        }

        return searchTerm == _matrix[DecodeRow(startIndex), DecodeColumn(startIndex)];
    }

    private static int DecodeRow(int index) => index / _matrix.GetLength(0);

    private static int DecodeColumn(int index) => index % _matrix.GetLength(0);
}