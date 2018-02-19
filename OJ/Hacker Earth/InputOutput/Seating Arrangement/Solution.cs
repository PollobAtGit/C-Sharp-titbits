using System;

internal static class Solution
{
    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var n = int.Parse(Console.ReadLine());

            var mod = n % 6;

            var seatType = SeatType(mod);
            var facingSeatNumber = FacingSeat(n, mod);

            Console.WriteLine(facingSeatNumber + " " + seatType);
        }
    }

    internal static int FacingSeat(int seatNumber, int mod)
    {
        if((seatNumber / 6) % 2 != 0) return (seatNumber + 1) - (2 * mod);
        if(mod == 0) return (seatNumber + 1) - (2 * (6 - mod));
        return (seatNumber + 1) + (2 * (6 - mod));
    }

    internal static string SeatType(int mod)
    {
        if(mod == 0 || mod == 1) return "WS";
        if(mod == 2 || mod == 5) return "MS";
        return "AS";
    }
}
