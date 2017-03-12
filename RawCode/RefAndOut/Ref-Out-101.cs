using System;

namespace RefOut_101
{
    internal static class Client
    {
        internal static void Main()
        {
            int x;

            //Poi: Out argument can take uninitialized variables. The idea is that variable is supposed to
            //be initialized from the method
            //Poi: BOTH method argument & method invocation requires 'out' keyword

            Out(out x);
            Console.WriteLine(x);

            //Poi: A variable that will be mapped to a ref argument MUST be initialized beforehand
            //Poi: BOTH method argument & method invocation is required to be decorated with 'ref' keyword

            Ref(ref x);
            Console.WriteLine(x);
        }

        internal static void Out(out int x)
        {
            //Poi: Below assignment is required because compiler sees that an out variable, which can be
            //uninitialized. So any operation on that except initializing first will cause issue.
            x = 100;

            x += 15;
        }

        internal static void Ref(ref int x)
        {
            x += 12;
        }
    }
}
