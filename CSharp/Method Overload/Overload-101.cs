using System;

namespace Overload_101
{
    internal static class Client
    {
        //Poi: Reasoning for this choice is: int to int conversion is more easier (!) but it's costly to
        //convert int to double (Ref: http://csharpindepth.com/Articles/General/Overloading.aspx)

        //Poi: Apparently, closest /narrower ('int' in this case) will win

        internal static void Main()
        {
            //Poi: This will invoke 'int' overload
            Console.WriteLine(Overload(2));

            //Poi: This will invoke 'double' overload
            Console.WriteLine(Overload(3.2));
        }

        internal static double Overload(double x) => x * x;

        internal static int Overload(int x) => x * x * x;
    }
}