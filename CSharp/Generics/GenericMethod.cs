using System;

public class Program
{
    public static void Main()
    {
        Print(Max<int>(10, 11));
        Print(Max<int>(11, 10));

        Print(Max<string>("string", "String"));

        Print(Max<decimal>(13.203m, 13.204m));
        Print(Max<decimal>(14.203m, 13.204m));
    }

    public static T Max<T>(T a, T b) where T : IComparable => (a.CompareTo(b) <= 0) ? b : a;

    public static void Print(object msg) => Console.WriteLine(msg);
}