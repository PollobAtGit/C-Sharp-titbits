using System;

namespace Const_101
{
    internal static class Client
    {
        public static void Main()
        {
            Console.WriteLine(Library.BookCount);
            Console.WriteLine(Library.Address);

            //Poi: Following approaches are NOT valid to access 'static' & 'const' member variables (May be in C++ ?)

            // Console.WriteLine(new Library().BookCount);
            // Console.WriteLine(new Library().Address);
        }

        private class Library
        {
            //Poi: BookCount is 'const' NOT static. Still 'BookCount' can be invoked with only class name
            //specified & that's because constants are by definition static (Makes sense !)

            //Poi: Naming convention for C# constants is Pascal casing
            public const int BookCount = 100;
            public static string Address = string.Empty;
        }
    }
}