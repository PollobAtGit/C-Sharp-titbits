using System;

// POI: Conditional import operation. Example: Based on mode import either pre-production 3rd party library or production 3rd party library
#if NORMAL_MODE
using System.Collections.Generic;
using System.Diagnostics;
#else
using System.Collections;
#endif

namespace Ch_13
{
    static class P_526
    {
        public static void Main()
        {

            // POI: Symbol is defined in Project property & in Build tab as Conditional Compilation Symbols
            // POI: This conditinal compilation switches are for compiler not for runtime, CLR. Compiler sees the environment & 
            // based on that discards or keeps some code in source file

#if RELEASE_BUILD && NORMAL_MODE && !POKEMON
            Console.WriteLine("In Relaease Build Mode");
#else
            Console.WriteLine("In Non Relaease Build Mode");
#endif

            // POI: If RELEASE_BUILD is defined then compilation itself will fail because compiler will parse the 
            // conditional arguments & based on that will compile source. So if RELEASE_BUILD is defined then the method will
            // not exist at all causing compilation failure. See Rlease-Build.PNG
            InvokeConditionalMethodExistence();

            Invoke();
        }

        // POI: Static variables & other C# construct can't reach here (if-else outside method)
#if RELEASE_BUILD
        private static void InvokeConditionalMethodExistence()
        {
            Console.WriteLine("Exists - InvokeConditionalMethodExistenc");
        }
#endif

        // POI: Conditional[...] does the same as above (wrapping a method in #If ... #endif). Additionally if the symbol
        // is defined then compiler removes any invocation to this method which essentially means the method can be removed
        // with the added advantage that if the symbol is not defined then any invocation to the method doesn't have to be removed
        // See Rlease-Build.PNG for comparison
        [Conditional("NON_RELEASE_BUILD")]
        private static void Invoke()
        {
            Console.WriteLine("Exists - Invoke");
        }
    }
}
