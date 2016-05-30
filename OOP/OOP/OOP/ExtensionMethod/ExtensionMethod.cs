using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ExtensionMethod
{
    //Note: Class has been declared as static otherwise compiler throws following exception:
    //Error CS1106 Extension method must be defined in a non-generic static class
    //Reference: https://msdn.microsoft.com/en-us//library/bb383977.aspx
    internal static class ExtensionMethod
    {
        //Extension method signature:
            //1) This method must be a public & static method
            //2) Must reside in a static class
            //3) Return type doesn't matter
            //4) Parameter starts with 'this' then the class for which extension method is being defined
        public static string ToCapitalizeAfterTwoCharacters(this string _str)
        {
            char[] arrayRepresentationOfStr = _str.ToCharArray();
            for (int i = 0; i < arrayRepresentationOfStr.Length; i += 3)
            {
                arrayRepresentationOfStr[i] = Char.ToUpper(arrayRepresentationOfStr[i]);
            }

            return new string(arrayRepresentationOfStr);
        }

        //Important places to focus:
            //1) Return type can be anything. In this case, extension method is created for int but it returns boolean
            //2) 'this int' indicates this method is an extension method for every int value
        public static bool IsEven(this int _integervalue)
        {
            return (_integervalue % 2) == 0;
        }

        public static void CapitalizeAirFreshnerProductName(this AirFreshner _airFreshner)
        {
            //Error CS0272  The property or indexer 'AirFreshner.Manufacturer' cannot be used
            //in this context because the set accessor is inaccessible (!)
            //Shouldn't it be accessible? Extension method is kind of a method of that class.
            //So it should be able to access private setter
            //Research findings: This is C#'s way of ensuring encapsulation for extension methods.
            //Reference: https://msdn.microsoft.com/en-us//library/bb383977.aspx
            //_airFreshner.Manufacturer = _airFreshner.Manufacturer.ToUpper();
            _airFreshner.ProductName = _airFreshner.ProductName.ToUpper();
        }
    }

    internal class AirFreshner
    {
        #region FIELD

        private string manufacturer;
        private string productName;

        #endregion

        #region PROPERTY

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }

            private set
            {
                if(value != null)
                {
                    manufacturer = value;
                }
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                if(value != null)
                {
                    productName = value;
                }
            }
        }

        #endregion

        public AirFreshner()
        {
            //Default constructor
            //Without default constructor object initializer facility doesn't work. Why ?
        }

        public AirFreshner(string _manufacturer, string _productName)
        {
            Manufacturer = _manufacturer;
            ProductName = _productName;
        }
    }

    internal class TestClass
    {
        public static void TestExtensionMethodFacility()
        {
            string nameOfVictim = "Sheikh Ashiqul Islam Pollob";

            Console.WriteLine("Original Name ==> " + nameOfVictim);
            Console.WriteLine("Capitalized Name ==> " + nameOfVictim.ToCapitalizeAfterTwoCharacters());

            int evenVal = 12;
            int oddValue = 13;

            Console.WriteLine();
            Console.WriteLine("EXTENSION METHOD FOR INTEGER DATA TYPE");
            Console.WriteLine();

            Console.WriteLine("evenVal.IsEven() ==> " + evenVal.IsEven().ToString());
            Console.WriteLine("oddValue.IsEven() ==> " + oddValue.IsEven().ToString());

            Console.WriteLine();
            Console.WriteLine("EXTENSION METHOD FOR CUSTOM DATA TYPE");
            Console.WriteLine();

            AirFreshner aAirFreshner = new AirFreshner ("Oliver", "Oslo");

            Console.WriteLine("Manufacturer: " + aAirFreshner.Manufacturer);
            Console.WriteLine("ProductName: " + aAirFreshner.ProductName);

            //Product name will be capitalized by extension method of AirFreshner
            aAirFreshner.CapitalizeAirFreshnerProductName();

            Console.WriteLine();
            Console.WriteLine("PRODUCT NAME IS BEING PROCESSING");
            Console.WriteLine();

            Console.WriteLine("Manufacturer: " + aAirFreshner.Manufacturer);
            Console.WriteLine("ProductName: " + aAirFreshner.ProductName);
        }

        public static void TestCreatingArrayOfCustomClass()
        {
            List<string> arrayOfProductNames = new List<string>
            {
                "OSLO"
                , "POP"
                , "BLUE LADY"
                , "BLUE BEETLE"
                , "RED HORNET"
            };

            //Following statement simply creates reference but doesn't
            //allocate memory in heap for the individual objects. So objects
            //need to be created for all of these array elements
            AirFreshner[] arrayOfAirFreshner = new AirFreshner[10];

            for (int i = 0; i < arrayOfAirFreshner.Length; i++)
            {
                string productName = arrayOfProductNames[i % arrayOfProductNames.Count];

                //Creating objects for the array
                arrayOfAirFreshner[i] = new AirFreshner { ProductName = productName };
            }

            Console.WriteLine("PRINTING PRODUCT NAMES");
            Console.WriteLine();

            //For each is operating on array. So custom class doesn't need to implement
            //interface IEnumerable. Then when is it needed?
            foreach(AirFreshner aAirFreshner in arrayOfAirFreshner)
            {
                Console.WriteLine(aAirFreshner.ProductName);
            }
        }
    }
}
