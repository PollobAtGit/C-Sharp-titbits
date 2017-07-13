using System;

internal static class Solution
{
    internal static void Main()
    {
        try
        {
            var t = int.Parse(Console.ReadLine());

            while(--t >= 0)
            {
                var n = int.Parse(Console.ReadLine());
                var cars = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                var carsAtMaxSpeed = 1;

                for (int i = 1; i < cars.Length; i++)
                {
                    if(cars[i] <= cars[i - 1])
                    {
                        carsAtMaxSpeed = carsAtMaxSpeed + 1;
                    }
                }

                Console.WriteLine(carsAtMaxSpeed);
            }
        }
        catch(Exception)
        {

        }
    }
}
