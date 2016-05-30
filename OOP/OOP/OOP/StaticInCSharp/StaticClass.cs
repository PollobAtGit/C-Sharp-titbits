using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.StaticInCSharp
{
    internal static class UtilityToolBox
    {
        //Error CS0708	cannot declare instance members in a static class
        //private int meaningOfLife;

        //Following works because constants are by default static. So the below statement is similar to 
            //'private const static int meaningOfLife = 42;' though this statement won't compile
        private const int meaningOfLife = 42;

        //Error CS0708	cannot declare instance members in a static class
        //Summary: Static class's purpose is to be utility class. (Further research!)
        //public int GetMeaningOfLife()
        //{
        //    return 42;
        //}

        static public int GetMeaningOfLife()
        {
            return meaningOfLife;
        }
    }

    internal class Mobile
    {
        private static int NumberOfMobilesSold { get; set; }
        public string MobileManufacturer { get; set; }
        public bool? IsAndriod { get; set; }

        public Mobile()
        {
            //Non-static method can access static method/property/field
            NumberOfMobilesSold++;

            MobileManufacturer = "UN-KNOWN";
            IsAndriod = null;
        }

        public Mobile(string _mobileManufacturer, bool? _isAndriod)
        {
            NumberOfMobilesSold++;
            MobileManufacturer = _mobileManufacturer;
            IsAndriod = _isAndriod;
        }

        public static int GetSoldMobileCount()
        {
            //Summary: static method can't access non-static field/property/method
            //Error CS0120  An object reference is required for the non-static field, method, or property
            //isSmartPhone = false;
            //string str = GetManufacturerName();
            //isAndriod = false;

            return NumberOfMobilesSold;
        }

        public void SayHelloToWorld()
        {
            Console.WriteLine("ANDROID MOBILE SUCKS");
        }
    }

    class StaticClass
    {
        public static void TestStaticBehavior()
        {
            //Using object initializer notation
            Mobile mblOne = new Mobile
            {
                MobileManufacturer = "Oppo"
                , IsAndriod = true
            };

            Mobile mblTwo = new Mobile
            {
                MobileManufacturer = "Samsung"
                , IsAndriod = true
            };

            //Note: Following syntax to invoke static method doesn't work: 'mblOne.GetSoldMobileCount()'
            //Static method must be invoked by class name unlike C++ where static members should be invoked by object name
            Console.WriteLine("Total number of mobiles sold: " + Mobile.GetSoldMobileCount());

            Console.WriteLine("Meaning of life: " + UtilityToolBox.GetMeaningOfLife());
        }
    }

    public interface IClass
    {
        void DoSomething();
    }

    //Static class can't implement interface
    //Error CS0708  'DoSomething': cannot declare instance members in a static class
    internal class ImplementsIClass : IClass
    {
        //This method implements interface. But this method must be public. Makes sense to me
        public void DoSomething()
        {

        }
    }
}
