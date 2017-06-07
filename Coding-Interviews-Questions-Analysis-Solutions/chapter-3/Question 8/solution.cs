using System;

internal static class Ans
{
    private static int[,] _matrix = new int[,]
    {
        {1, 2, 8, 7}
        , {2, 4, 9, 12}
        , {4, 7, 10, 13}
        , {6, 8, 11, 15}
    };

    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var searchTerm = int.Parse(Console.ReadLine());
            Console.WriteLine("\nIsFoundBruteForce : " + IsFoundBruteForce(searchTerm));
            Console.WriteLine("IsFoundOptimal : " + IsFoundOptimal(searchTerm) + "\n");
        }
    }

    private static bool IsFoundBruteForce(int searchTerm)
    {
        for(var i = 0; i < _matrix.GetLength(0); i++)
            for(var j = 0; j < _matrix.GetLength(1); j++)
                if(_matrix[i, j] == searchTerm)
                    return true;

        return false;
    }

    private static bool IsFoundOptimal(int searchTerm)
    {
        if(searchTerm < _matrix[0, 0] || searchTerm > _matrix[_matrix.GetLength(0) - 1, _matrix.GetLength(1) - 1])
            return false;

        var maxRowBoundary = FindMaxRowBoundary(searchTerm);
        var maxColBoundary = FindMaxColBoundary(searchTerm);

        for(var i = 0; i <= maxRowBoundary; i++)
            for(var j = 0; j <= maxColBoundary; j++)
                if(_matrix[i, j] == searchTerm)
                    return true;

        return false;
    }

    private static int FindMaxRowBoundary(int searchTerm)
    {
        var rowCount = _matrix.GetLength(0);

        for(var i = 0; i < rowCount; i++)
            if(_matrix[i, 0] > searchTerm)
                return i - 1;

        return rowCount - 1;
    }

    private static int FindMaxColBoundary(int searchTerm)
    {
        var columnCount = _matrix.GetLength(1);

        for(var i = 0; i < columnCount; i++)
            if(_matrix[0, i] > searchTerm)
                return i - 1;

        return columnCount - 1;
    }
}