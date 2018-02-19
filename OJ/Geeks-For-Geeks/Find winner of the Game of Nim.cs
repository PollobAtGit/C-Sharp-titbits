using System;

public class FindWinnerOfTheGameOfNim
{
    static public void Main()
    {
        var t = Int32.Parse(Console.ReadLine());

        while (--t >= 0)
        {
            var n = Int32.Parse(Console.ReadLine());
            Console.WriteLine((n & 1) == 1 ? "Player A" : "Player B");
        }
    }
}