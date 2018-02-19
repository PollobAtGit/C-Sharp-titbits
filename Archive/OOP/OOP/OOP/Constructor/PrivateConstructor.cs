using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Constructor
{
    internal class MathClass
    {
        //Static behavior between fields & properties is similar to fields & methods. That is to access a static field
        //that property has to be static too
        private static double pi = Math.E;

        public static double Pi
        {
            get
            {
                return pi;
            }
            private set
            {
                pi = value;
            }
        }

        private MathClass()
        {

        }

        //Default method accessability 'private'
        public static void ModifyPiValue()
        {
            //Accessing private setter of property
            Pi = 30.26;
        }
    }

    internal class PrivateConstructor
    {
        public static void PreventInstantiatingClass()
        {
            //Error CS0122  'MathClass.MathClass()' is inaccessible due to its protection level
            //Because constructor is private (Not mentioning access modifier explicitly would behave in this manner too!)
            //MathClass instance = new MathClass();
            Console.WriteLine("Pi: " + MathClass.Pi);
            MathClass.ModifyPiValue();
            Console.WriteLine("\nAfter Modifying value of PI:\n");
            Console.WriteLine("Pi: " + MathClass.Pi);

            //Trying to access private property setter
            //Error CS0272  The property or indexer 'MathClass.Pi' cannot be used in this context because the set accessor is inaccessible
            //MathClass.Pi = 23;
        }
    }
}
