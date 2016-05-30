using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP.Destructor
{
    static class DestructorTester
    {
        public static void DestructorTestMethod()
        {
            DestructorBehaviorDerivedSecondLevel baseClsOuterScope = new DestructorBehaviorDerivedSecondLevel();
            baseClsOuterScope = null;
            long memoryBeforeGCInvocation = GC.GetTotalMemory(false);

            //Following invocation definitely executes GC but why don't it invoke destructor
            //even though GC is being invoked? 
            GC.Collect();
            long memoryAfterGCInvocation = GC.GetTotalMemory(false);

            Console.WriteLine("Total reclaimed memory: " + (memoryBeforeGCInvocation - memoryAfterGCInvocation));
            Console.WriteLine();

            Console.WriteLine("\nHave the destructors been invoked? If not then they will be"
                + "invoked when program terminates or invoked explicitly through GC\n");

            //Following is called 'using statement' (not using directive, which is used to add namespace)
            //& This using statement can be used for a class object only when IDisposable interface is
            //implemented by that class otherwise following error is thrown by compiler:

            //Error CS1674  'DestructorBehaviorBase': type used in a using statement must be implicitly convertible to 'System.IDisposable'

            //And by rule of polymorphism one object can be converted to IDisposable only if that class implements IDisposable
            using (DestructorBehaviorBase baseCls = new DestructorBehaviorDerivedSecondLevel())
            {
                //Note that: invoking Dispose method has no relation with invoking destructor. Destructor for this
                //class is still being invoked only when program terminates though Dispose is being invoked whenever
                //the object goes out of using statement's scope
            }

            Console.WriteLine("\nHas the Dispose been invoked? We expect it to be invoked by now\n");

            //None of the following will work because 'using statement' will only work on reference types not
            //on value types (note the usage of struct)

            //using (int integerToDispose = 10) { }
            //using (float floatToDispose = 10f) { }
            //using (bool boolToDispose = true) { }
            using (DisposableStruct disDtruct = new DisposableStruct()) { }

            Console.WriteLine("\nHas the Dispose been invoked from struct? We don't expect it to be"
                + "invoked because struct is value type in C#\n");
        }
    }

    struct DisposableStruct : IDisposable
    {
        //This is being invoked !!
        public void Dispose()
        {
            Console.WriteLine("=> Olo! Disposing expensive resources from struct");
        }
    }

    class DestructorBehaviorBase : IDisposable
    {
        ~DestructorBehaviorBase()
        {
            Console.WriteLine("Olo! From BASE Destructor");
        }

        //This will have effect only on base class (More research needed)
        public void Dispose()
        {
            Console.WriteLine("=> Olo! Disposing expensive resources");
        }
    }

    class DestructorBehaviorDerived : DestructorBehaviorBase
    {
        ~DestructorBehaviorDerived()
        {
            Console.WriteLine("Olo! From FIRST layer of derived class Destructor");
        }
    }

    class DestructorBehaviorDerivedSecondLevel : DestructorBehaviorDerived
    {
        private SiblingClass siblingCls = new SiblingClass();

        ~DestructorBehaviorDerivedSecondLevel()
        {
            Console.WriteLine("Olo! From SECOND layer of derived class Destructor");
        }
    }

    internal class SiblingClass
    {

    }
}
