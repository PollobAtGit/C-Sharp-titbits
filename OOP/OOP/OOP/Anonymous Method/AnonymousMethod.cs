using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Anonymous_Method
{
    internal static class AnonymousMethod
    {
        internal delegate void PrintToConsole(string message);

        private static void PrintMessage(string message)
        {
            Console.WriteLine("FROM ORIGINAL METHOD BODY");
            Console.WriteLine(message + "\n");
        }

        private static void ModifiedPrintMessage(string message = "default message")
        {
            Console.WriteLine("FROM MODIFIED METHOD BODY");
            Console.WriteLine(message + "\n");
        }

        internal static void CheckingAnonymousMethodEvolution()
        {
            //Creating a delegate instance
            PrintToConsole printDelegate = new PrintToConsole(PrintMessage);

            //Adding new method to delegate instance (just like adding new element to list)
            //but notice that the function 'ModifiedPrintMessage' has been created explicitly before
            printDelegate += ModifiedPrintMessage;

            //Adding new method to delegate instance
            //but notice that the function doesn't exist explicitly i.e. is hasn't been created before
            //delegate keyword can be used to convert any statement combination to delegate

            //Note that the following throws CS1065. Apparently, optional value for parameter
            //is not supported when method is being created with delegate keyword.
            //PrintToConsole cSharpVersionTwoPointTwo = delegate (string message = "null")
            printDelegate += delegate (string msg)
            {
                Console.WriteLine("THIS DELEGATE IS CREATED DYNAMICALLY");
                Console.WriteLine(msg + "\n");
            };

            //This invocation subsequently invokes all the functions
            //that had been added in the delegate instance
            //Note that: it works as expected because delegate return type is void
            //If it had other return type then the ultimate return type would have
            //been the return type from the last method invocation
            printDelegate("Passed message to delegates");

            //This is a different delegate instance of 'PrintToConsole'
            //Above statement doesn't invoke the below function that has
            //been converted to delegate because they are different instances
            //Also note that this delegate (method) body is quite big & arithmetic
            //operations can be done here
            PrintToConsole cSharpVersionTwoPointTwo = delegate (string msg)
            {
                int integralValue = 120;
                integralValue <<= 2;

                string message = msg ?? "OUTPUT OF LEFT SHIFTING 2 BITS: ";
                Console.WriteLine(message + integralValue);

            };

            Console.WriteLine();
            cSharpVersionTwoPointTwo(null);
        }

        public static void TestAnonymousMethod()
        {
            List<int> lstOfIntegrals = new List<int>() { 12, 56, 89, 1023, 100 };

            //Using predicate delegate
            int integerValue = lstOfIntegrals.Find(new Predicate<int>(FindIntegerValues));

            //Using lambda expression in function parameter where delegate is expected
            int searchValueWithLambdaExpression = lstOfIntegrals.Find(integer => integer == 200);

            Console.WriteLine("Search result with predicate clause: " + integerValue);
            Console.WriteLine("Search result with lambda expression: " + searchValueWithLambdaExpression);
        }

        public static bool FindIntegerValues(int value)
        {
            return value == 100;
        }
    }
}
