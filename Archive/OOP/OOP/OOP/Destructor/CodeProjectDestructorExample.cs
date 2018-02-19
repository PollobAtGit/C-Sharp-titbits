using System;

namespace OOP.Destructor
{
    class CodeProjectDestructorExample
    {
    }

    class A : IDisposable
    {
        public A()
        {
            Console.WriteLine("Creating A");
        }
        ~A()
        {
            Console.WriteLine("Destroying A");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("Creating B");
        }
        ~B()
        {
            Console.WriteLine("Destroying B");
        }

    }
    class C : B
    {
        public C()
        {
            Console.WriteLine("Creating C");
        }

        ~C()
        {
            Console.WriteLine("Destroying C");
        }
    }

    internal static class AppExample
    {
        public static void TestGC()
        {
            C c = new C();
            Console.WriteLine("Object Created ");
            c = null;
            GC.Collect();

            Console.WriteLine("\nHave the destructors been invoked? If not then they will be"
                + "invoked when program terminates or invoked explicitly through GC\n");

            Console.Read();
        }

    }
}
