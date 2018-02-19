using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Data_Type
{
    internal class DemoClass
    {
        public string ThisPropertyHasNoUsage { get; set; }

        public DemoClass()
        {

        }

        public void ThisMethodDoesNoting()
        {
            //Obviously the following wont be printed in console because
            //no real object will be created & this method isn't static
            Console.WriteLine("FROM USELESS METHOD");
        }
    }

    //internal access specifier is default access specifier for class in an assembly/project
    internal class NullableInteger
    {
        public static void NullFeatures()
        {
            DemoClass demoClass = null;

            //Following two statements will throw NullReferenceException because object reference
            //is referencing to nothing (it's null)
            if(demoClass != null)
            {
                demoClass.ThisMethodDoesNoting();
                demoClass.ThisPropertyHasNoUsage = "";
            }

            //Elvis Operator (?.) is in rescue :D
            demoClass?.ThisMethodDoesNoting();

            //Why following works (reading property) but not the statement after that?
            //Because Elvis operator (null conditional operator) only allows program to
            //Access (.ie. read) instance members i.e. it allows program to read property/field/indexers and invoke methods
            Console.WriteLine(demoClass?.ThisPropertyHasNoUsage);
            //demoClass?.ThisPropertyHasNoUsage = bl;
        }

        public static void CoalescingValue()
        {
            Nullable<float> thisFloatIsNull = null;
            float? willItBeNull = thisFloatIsNull ?? 23.023f;//Note the literal 'f'

            Console.WriteLine("Statement: float? willItBeNull = thisFloatIsNull ?? 23.023f;");
            Console.WriteLine("Return result: " + willItBeNull);
        }

        public static void TestNullableIntegerUsage()
        {
            //Following is similar to 'int? numberOfSwords = null;'
            Nullable<Int32> numberOfSwords = 30;

            //Following is similar to 'Nullable<Boolean> isReadyToWar = null;'
            bool? isReadyToWar = null;

            if(!numberOfSwords.HasValue)
            {
                isReadyToWar = false;
            }
            else
            {
                isReadyToWar = true;
            }

            //'Value' property of nullable data type throws exception if value is null.
                //So before using it 'HasValue' must be used. Otherwise there will be chance of
                //unexpected behavior. Interestingly, null is perceived as false directly if that
                //variable is accessed directly rather than using 'Value' property
            if (isReadyToWar.HasValue && isReadyToWar.Value != true)
            {
                Console.WriteLine("Warrior can't go to war");
            }
            else
            {
                Console.WriteLine("Warrior can attack");
            }

        }

        public static void TestNullableVariableInConditionalSituations()
        {
            Nullable<int> nullInteger = null;
            Nullable<int> validInteger = 5;

            Console.WriteLine("Null comparison: " + (nullInteger == null));//Returns TRUE
            Console.WriteLine("Null comparison: " + (nullInteger != null));//Returns FALSE

            #region ARITHMETIC OPERATIONS

            Console.WriteLine("\nARITHMETIC OPERATIONS RESULT:\n");

            Console.WriteLine("nullInteger + validInteger: " + (nullInteger + validInteger));//Returns {EMPTY}
            Console.WriteLine("nullInteger * validInteger: " + (nullInteger * validInteger));//Returns {EMPTY}
            Console.WriteLine("nullInteger / validInteger: " + (nullInteger / validInteger));//Returns {EMPTY}
            Console.WriteLine("nullInteger % validInteger: " + (nullInteger % validInteger));//Returns {EMPTY}

            #endregion

            #region RELATIONAL OPERATION BEHAVIOR ON NULL VALUE
            //Summary: It's meaning-less to compare NULL value with a valid value. So any comparison with NULL
            //will always return FALSE (Except != on NULL & NOT NULL VALUE). {If I were a developer at C# project,
            //I would have forced them to change the decision to return NULL :P }

            Console.WriteLine("\nRELATIONAL OPERATION BEHAVIOR ON NULL VALUE:\n");

            //Compare the following with SQL behavior. In which case, anything done with NULL returns NULL.
            //In C#, that varies (!). In the following scenario, return value NULL would have been much more
            //meaningful but it returns FALSE instead.
            Console.WriteLine("nullInteger == validInteger : " + (nullInteger == validInteger));//Returns FALSE
            Console.WriteLine("nullInteger != validInteger: " + (nullInteger != validInteger));//Returns TRUE
            Console.WriteLine("nullInteger >= validInteger: " + (nullInteger >= validInteger));//Returns FALSE
            Console.WriteLine("nullInteger <= validInteger: " + (nullInteger <= validInteger));//Returns FALSE

            #endregion

            //OR(||) & AND (&&) operation can't be performed on int? types. But what's new about that it's not valid
            //for int type also. It makes no sense.
            //Console.WriteLine("nullInteger && validInteger: " + (nullInteger && validInteger));//Returns FALSE

            #region BITWISE OPERATION

            Console.WriteLine("\nBITWISE OPERATION ON NULL VALUE:\n");

            //Bitwise operation 
            Console.WriteLine("nullInteger | validInteger: " + (nullInteger | validInteger));//Returns {EMPTY}
            Console.WriteLine("nullInteger & validInteger: " + (nullInteger & validInteger));//Returns {EMPTY}

            #endregion

            #region INCREMENT/DECREMENT OPERATOR

            Console.WriteLine("\nINCREMENT/DECREMENT OPERATOR:\n");

            Console.WriteLine("nullInteger++: " + nullInteger++ );//Returns {EMPTY}
            Console.WriteLine("nullInteger--: " + nullInteger-- );//Returns {EMPTY}

            #endregion
        }

    }
}
