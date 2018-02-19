using System;

internal static class Solution
{
    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            Console.ReadLine();

            var binaryStr = Console.ReadLine();
            var evenCount = 0;
            for(var i = 0; i < binaryStr.Length; i = i + 1)
            {
                //POI: Because of rotation, number of even number is the number of '0's
                //POI: Because of rotation, number of odd number is the number of '1's
                if(binaryStr[i] == '0')
                {
                    evenCount = evenCount + 1;
                }
            }

            Console.WriteLine(evenCount);
        }
    }

    //POI: This formula of Rotate works but one point to look after is 'number of bits' to be used
    internal static int RotateLeft(int n)
    {
        return n << 1 | n >> (32 - 1);
    }
}