﻿using System;
using System.Collections.Generic;

namespace OOP.Delegate
{
    internal static class DelegateBasic
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

        internal static void CheckingAnonymousMethodEvolutionWithMultiCastDelegate()
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

            //Following is the same as 'cSharpVersionTwoPointTwo(null);'
            cSharpVersionTwoPointTwo.Invoke(null);
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

        private delegate char CaseConversion(char ch);

        public static void PluginMethod()
        {
            string str = "Delegate is Awesome";

            Console.WriteLine("ORIGINAL STRING: " + str);

            str = ConvertStringCase(str, Char.ToUpper);
            Console.WriteLine("MODIFIED TO UPPER THROUGH DELEGATE: " + str);

            str = ConvertStringCase(str, Char.ToLower);
            Console.WriteLine("MODIFIED TO LOWER THROUGH DELEGATE: " + str);

            CaseConversion caseConversionDelegate = new CaseConversion(Char.ToUpper);

            //The above is similar to the following
            //CaseConversion caseConversionDelegate = Char.ToUpper;

            //Here we are adding other methods as Target of the delegate. So we are creating a multi-cast delegate
            caseConversionDelegate  += Char.ToLower;

            // Note that, Char.ToUpper has been added previously. So adding same method multiple times is allowed
            caseConversionDelegate += Char.ToUpper;

            //Not sure what the below method does but the focus here is the usage of new.
            //Delegates are immutable. So every-time to create a multi-cast delegate we use '+=' we don't add
            //the new method to the existing delegate instance rather we create another delegate instance that
            //contains the new method and eventually that instance's reference is being assigned to the old
            //delegate variable
            caseConversionDelegate += new CaseConversion(Char.ToLowerInvariant);

            TestDelegatePropertiesAndFeatures(caseConversionDelegate);
            Console.WriteLine();

            //Note that: in this case simply one method is being plugged in into the invoker method which is similar to
            //what has been done in the previous invocation for this method. In that case the whole delegate instance is
            //being to the method
            TestDelegatePropertiesAndFeatures(Char.ToUpper);

            //Now no method is being referenced by the delegate instance
            caseConversionDelegate = null;
            Console.WriteLine("\nSHOWING FEATURES AFTER DELEGATE INSTANCE IS BEING NULLIFIED\n");
            TestDelegatePropertiesAndFeatures(caseConversionDelegate);

            //+= works on null reference. Here before assignment delegate reference is null.
            caseConversionDelegate += new CaseConversion(Char.ToUpper);
            caseConversionDelegate += new CaseConversion(Char.ToLower);

            Console.WriteLine("\nSHOWING FEATURES AFTER METHOD IS ASSIGNED TO DELEGATE INSTANCE\n");
            TestDelegatePropertiesAndFeatures(caseConversionDelegate);

            //Below deletion operation is similar to doing 'caseConversionDelegate -= Char.ToUpper;'
            caseConversionDelegate -= new CaseConversion(Char.ToLower);

            Console.WriteLine("\nSHOWING FEATURES AFTER METHOD IS DELETED (!) FROM DELEGATE INSTANCE\n");
            TestDelegatePropertiesAndFeatures(caseConversionDelegate);
        }

        private static string ConvertStringCase(string strToConvert, CaseConversion csConversionMethod)
        {
            var strToConvertArray = strToConvert.ToCharArray();

            for(int i = 0; i < strToConvertArray.Length; i++)
            {
                //Note the following invocation. Here method 'Char.ToUpper' or 'Char.ToLower'
                //is being invoked through delegate that takes one parameter and returns another parameter
                strToConvertArray[i] = csConversionMethod.Invoke(strToConvertArray[i]);
            }

            return new string(strToConvertArray);
        }

        private static void TestDelegatePropertiesAndFeatures(CaseConversion csConversionMethod)
        {
            if (csConversionMethod == null)
                return;

            Console.WriteLine();

            // Returns EMPTY for Char.ToUpper & Others because they are static methods.
            //From documentation: Gets the class instance on which the current delegate invokes the instance method.
            Console.WriteLine("SHOWING DELEGATE TARGET: " + csConversionMethod.Target);

            Console.WriteLine("SHOWING DELEGATE ToString(): " + csConversionMethod.ToString());// Returns namespace
            Console.WriteLine("SHOWING DELEGATE Method PROPERTY: " + csConversionMethod.Method);// Return: Char.ToUpper because that has been added later
            Console.WriteLine("SHOWING DELEGATE GetType(): " + csConversionMethod.GetType());// Same as ToString()

            //Need fully qualified namespace because this source code's namespace is 'Delegate'
            System.Delegate[] methodsAttachedToThisDelegate = csConversionMethod.GetInvocationList();

            //Following is showing all the subscribed methods to this delegate
            Console.WriteLine("\nSHOWING ALL METHODS THAT HAVE BEEN SUBSCRIBED TO THIS DELEGATE:\n");
            foreach(System.Delegate del in methodsAttachedToThisDelegate)
            {
                Console.WriteLine(del.Method);
            }
        }

        //Following is a proper overload of the method 'TestDelegatePropertiesAndFeatures(CaseConversion csConversionMethod)'
        //Though usage causes compile time error (Research!)
        //private static string ConvertStringCase(string strToConvert, Func<char, char> csConversionMethod)
        //{
        //    var strToConvertArray = strToConvert.ToCharArray();

        //    for (int i = 0; i < strToConvertArray.Length; i++)
        //    {
        //        strToConvertArray[i] = csConversionMethod(strToConvertArray[i]);
        //    }

        //    return new string(strToConvertArray);
        //}
    }
}