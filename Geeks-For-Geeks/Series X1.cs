using System;

public class SeriesX1
{
    static public void Main()
    {
        var t = Int32.Parse(Console.ReadLine());

        while (--t >= 0)
        {
            var i = Int32.Parse(Console.ReadLine());

            var x = 2;
            var y = 3;
            long r = 0;

            for (int ii = 1; ii <= i; ii++)
            {
                x = x + ((ii != 1) ? y : 0);
                r = ii * x;

                if (ii != 1)
                {
                    y = y + 2;
                }
            }

            Console.WriteLine(r);
        }
    }
}