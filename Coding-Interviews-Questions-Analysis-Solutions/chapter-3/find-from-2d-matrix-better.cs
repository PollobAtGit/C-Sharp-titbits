using System;

internal static class Ans
{
    private static int[,] matrix = new int[,]
    {
        { 1, 3, 5 },
        { 7, 9, 11 },
        { 13, 15, 17 }
    };

    private static int searchTerm;

    static Ans()
    {
        searchTerm = int.Parse(Console.ReadLine());
    }

    internal static void Main()
    {
        Console.WriteLine(IsFound() ? (searchTerm + " Found") : "Item Doesn't exist");
    }

    internal static bool IsFound()
    {
        var targetRow = TargetRow;
        if(targetRow < 0) throw new Exception("No Proper Row Found");

        for(var i = 0; i < matrix.GetLength(1); i++)
            if(matrix[targetRow, i] == searchTerm)
                return true;

        return false;
    }

    private static int TargetRow
    {
        get
        {
            for(var i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                if((searchTerm >= matrix[i, 0]) && (searchTerm < matrix[i + 1, 0])) return i;
                if(searchTerm >= matrix[i + 1, 0]) return i + 1;
            }
            return -1;
        }
    }
}