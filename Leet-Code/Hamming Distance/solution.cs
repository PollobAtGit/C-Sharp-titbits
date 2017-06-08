using System;

internal static class Ans
{
    internal static void Main()
    {
        var x = int.Parse(Console.ReadLine());
        var y = int.Parse(Console.ReadLine());

        Console.WriteLine(HammingDistance(x, y));
    }

    private static int HammingDistance(int x, int y) {

        var xorDistance = x ^ y;
        var distance = 0;

        while(xorDistance != 0)
        {
            if(xorDistance % 2 == 1) distance = distance + 1;
            xorDistance = xorDistance >> 1;
        }

        return distance;
    }
}