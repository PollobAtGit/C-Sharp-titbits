using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Inheritance.FunctionOverridingAndHiding
{
    internal interface IFruit
    {
        string AnnounceExistence();
        string DenounceExistence();
    }

    internal class Fruit : IFruit
    {
        public Fruit()
        {

        }

        //Function is marked as virtual. So this function is ready to be overridden
        public virtual string AnnounceExistence()
        {
            return "I am simply a fruit class";
        }

        //Function is marked as virtual. So this function is ready to be overridden
        public virtual string DenounceExistence()
        {
            return "I ain't a fruit class";
        }
    }

    internal class Apple : Fruit
    {
        public Apple()
        {

        }

        //Note: Here function is marked as 'new'. So base class function is being HIDDEN
        public new string AnnounceExistence()
        {
            return "I am a Apple Class";
        }

        //Note: Here function is marked as 'override'. So base class function is being OVERRIDDEN not HIDDEN
        public override string DenounceExistence()
        {
            return "I ain't a Apple class";
        }
    }

    internal class TestClass
    {
        public static void TestOverridingAndHidingFeature()
        {
            //Note that, here there's no necessity of thinking of virtual-ism or polymorphism. Here, object is used in normal terms.
            Apple aApple = new Apple();
            Console.WriteLine(aApple.AnnounceExistence());
            Console.WriteLine(aApple.DenounceExistence()); ;

            #region POLYMORPHISM IN ACTION

            Console.WriteLine();
            Console.WriteLine("POLYMORPHISM IN ACTION");
            Console.WriteLine();

            IFruit aSimplyFruit = new Apple();

            //This method isn't overridden. So it's invoking base class's (fruit) version of the function
            Console.WriteLine("HERE DERIVED CLASS FUNCTION IS MARKED AS 'new'. RESULT ==> " + aSimplyFruit.AnnounceExistence()); ;

            //This method is overridden. So it's invoking Apple class's version of the function
            Console.WriteLine("HERE DERIVED CLASS FUNCTION IS MARKED AS 'override'. RESULT ==> " + aSimplyFruit.DenounceExistence()); ;

            #endregion
        }
    }
}


/*
Summary: 
    1) There's no necessity of thinking of virtual-ism or polymorphism when bucket class is the original object's class
    2) Polymorphism is relevant only when bucket class isn't the original object's class. In that case function hiding
        or function overriding is meaningful.
*/
