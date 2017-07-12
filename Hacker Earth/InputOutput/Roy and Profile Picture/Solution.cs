using System;

internal static class Solution
{
    internal static void Main()
    {
        var l = Int32.Parse(Console.ReadLine());
        var n = Int32.Parse(Console.ReadLine());

        while(--n >= 0)
        {
            var wh = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Int32.Parse);

            if(wh[0] < l || wh[1] < l)
            {
                Console.WriteLine("UPLOAD ANOTHER");
            }
            else if(wh[0] == wh[1] && wh[0] >= l && wh[1] >= l)
            {
                Console.WriteLine("ACCEPTED");
            }
            else
            {
                Console.WriteLine("CROP IT");
            }
        }
    }
}
