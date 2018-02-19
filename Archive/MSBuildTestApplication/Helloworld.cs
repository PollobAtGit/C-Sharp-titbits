using System;

class HelloWorld
{
    static void Main()
    {
#if DebugConfig
        Console.WriteLine("WE ARE IN THE DEBUG CONFIGURATION");
#endif

        Console.WriteLine("Hello, world!");
        Console.WriteLine("This line is only for testing 'INCREMENTAL BUILDING'");
    }
}