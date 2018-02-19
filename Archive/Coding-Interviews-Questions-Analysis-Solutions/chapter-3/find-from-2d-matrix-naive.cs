using System;

internal class Ans
{
    internal static void Main()
    {
        var matrix = new int[,]
        {
            { 1, 3, 5 },
            { 7, 9, 11 },
            { 13, 15, 17 }
        };

        var searchTerm = 9;
        Console.WriteLine(IsFound(matrix, searchTerm) ? (searchTerm + " Found") : "Item Doesn't exist");
    }

    private static bool IsFound(int[,] matrix, int searchTerm)
    {
        for(var i = 0; i < matrix.GetLength(0); i++)
        {
            for(var j = 0; j < matrix.GetLength(1); j++)
            {
                if(matrix[i, j] == searchTerm) return true;
            }
        }

        return false;
    }
}