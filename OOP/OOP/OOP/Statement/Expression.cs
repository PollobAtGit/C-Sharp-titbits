using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Statement
{
    internal struct ExpressionStruct
    {

    }

    internal class Expression
    {
        public static void TestAssignmentOperatorReturnType()
        {
            int variableToAssign = 10;

            //C# Follows definite assignment policy, which says,
            //1) Local variable must be assigned before accessing (Violation of this rule causes: Error CS0165 to be thrown)
            //2) Function arguments must be provided when an function is invoked
            //3) All other custom class instance members will be by default initialized by runtime
            //Error CS0165  Use of unassigned local variable
            Console.WriteLine("VALUES OF VARIABLE BEFORE ASSIGNMENT: " + variableToAssign);
            
            //Wow!! This statement outputs 100 in the console
            Console.WriteLine("RETURN TYPE OF ASSIGNMENT OPERATOR: " + (variableToAssign = 100));

            //Also this statement outputs 100 in the console which means the above statement did two things:
            //1) Assignment EXPRESSION returned 100 because assignment expression isn't a void expression (Research: difference between statement & expression)
            //2) Assignment EXPRESSION assigned 100 to variable
            //From C# Spec: The result of a simple assignment expression is the value assigned to the left operand.
            //The result has the same type as the left operand and is always classified as a value.
            //Reference: https://msdn.microsoft.com/en-us/library/aa691315.aspx
            Console.WriteLine("VALUES OF VARIABLE AFTER ASSIGNMENT: " + variableToAssign);

            //Some more testing
            int page_number = 10;
            int price = 56;

            Console.WriteLine("RETURN TYPE OF ASSIGNMENT OPERATOR: " + (variableToAssign = variableToAssign + page_number + price));
            Console.WriteLine("VALUES OF VARIABLE AFTER ASSIGNMENT: " + variableToAssign);

            Expression expression;

            //Returns class name
            Console.WriteLine("RETURN TYPE OF ASSIGNMENT OPERATOR FOR OBJECTS: " + (expression = new Expression()));

            #pragma warning disable 0219
            ExpressionStruct expressionStrct;
            #pragma warning restore 0219

            //Returns struct name
            Console.WriteLine("RETURN TYPE OF ASSIGNMENT OPERATOR FOR STRUCTS: " + (expressionStrct = new ExpressionStruct()));

            //Following assignment expressions work only because assignment expressions are not void types.
            //It has a value whatever is assigned to it. As assignment expression has value (not void type)
            //it can be used in another expression (see above)

            int finalvalue = 0;
            int firstValue = 0;
            int secondValue = 0;

            finalvalue = firstValue = secondValue = 100;
            Console.WriteLine();
            Console.WriteLine("VALUE OF ASSIGNED VALUES");
            Console.WriteLine("FINAL VALUE: " + finalvalue + " || SECOND VALUE: " + secondValue + " || FIRST VALUE: " + firstValue);
            Console.WriteLine();

            double seed = 0;
            double resultantvalue = 10.26 * (seed = 3.6);

            Console.WriteLine();
            Console.WriteLine("VALUE OF ASSIGNED VALUES IN CASE OF MULTIPLICATION");
            Console.WriteLine("SEED: " + seed + " || RESULTANT VALUE: " + resultantvalue);
            Console.WriteLine();
        }
    }
}
