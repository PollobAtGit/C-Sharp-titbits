using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Sum_Strings_as_Numbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sumStrings("9", "-10"));
            //Strip leading zeros
        }

        public static string sumStrings(string a, string b)
        {
            string valA = ExcludeLeadingZeros(a.Trim());
            string valB = ExcludeLeadingZeros(b.Trim());

            //0+X = X; X+0 = X; -X+0 = -X; X-0 = X
            if (valA.Equals("0") || valB.Equals("0"))
            {
                return (valA.Equals("0") ? valB : valA);
            }

            //Subtraction is needed if any of the numbers is negative
            string retResult = "";
            if (isDoSummation(valA, valB))
            {
                retResult = doSumForSameSignedNumbers(valA, valB);
            }
            else
            {
                retResult = doSubtractionForDifferentSignedNumbers(valA, valB);
            }

            return retResult;
        }

        public static string doSubtractionForDifferentSignedNumbers(string valA, string valB)
        {
            string largerAbsoluteNumber = valA;
            string smallerAbsoluteNumber = valB;

            bool islargerNumberNegative = FindLargerNumber(ref largerAbsoluteNumber, ref smallerAbsoluteNumber);

            //Reversed string ensures indx = 0 points to least significant digit
            //Otherwise padding is needed to point LSD for uneven length numbers
            largerAbsoluteNumber = ReverseString(largerAbsoluteNumber);
            smallerAbsoluteNumber = ReverseString(smallerAbsoluteNumber);

            StringBuilder retStr = new StringBuilder();
            int indx = 0;
            int carry = 0;
            while (indx < largerAbsoluteNumber.Length || indx < smallerAbsoluteNumber.Length)
            {
                int largerNumberDigit = ((indx < largerAbsoluteNumber.Length) ? (largerAbsoluteNumber[indx] - 48) : 0);
                int smallerNumberDigit = ((indx < smallerAbsoluteNumber.Length) ? (smallerAbsoluteNumber[indx] - 48) : 0);
                int subResult = ((largerNumberDigit < (smallerNumberDigit + carry)) 
                                            ? (largerNumberDigit + 10) 
                                            : largerNumberDigit)
                                    - (smallerNumberDigit + carry);

                carry = (largerNumberDigit < (smallerNumberDigit + carry)) ? 1 : 0;
                retStr.Append(Convert.ToChar(subResult + 48));
                indx++;
            }

            return (islargerNumberNegative ? ReverseString(retStr.Append('-').ToString()) : ReverseString(retStr.ToString()));
        }

        public static bool FindLargerNumber(ref string largerAbsoluteNumber, ref string smallerAbsoluteNumber)
        {
            //Find length match/mismatch not considering sign
            if (((largerAbsoluteNumber[0] == '-') ? (largerAbsoluteNumber.Length - 1) : largerAbsoluteNumber.Length)
                != ((smallerAbsoluteNumber[0] == '-') ? (smallerAbsoluteNumber.Length - 1) : smallerAbsoluteNumber.Length))
            {
                //Find absolute larger number not considering sign
                string tmp = largerAbsoluteNumber;
                largerAbsoluteNumber = (((largerAbsoluteNumber[0] == '-') ? (largerAbsoluteNumber.Length - 1) : largerAbsoluteNumber.Length)
                                            < ((smallerAbsoluteNumber[0] == '-') ? (smallerAbsoluteNumber.Length - 1) : smallerAbsoluteNumber.Length))
                    ? smallerAbsoluteNumber : largerAbsoluteNumber;
                smallerAbsoluteNumber = (((tmp[0] == '-') ? (tmp.Length - 1) : tmp.Length)
                                            < ((smallerAbsoluteNumber[0] == '-') ? (smallerAbsoluteNumber.Length - 1) : smallerAbsoluteNumber.Length))
                    ? tmp : smallerAbsoluteNumber;

                bool islargerNumberNegative = (largerAbsoluteNumber[0] == '-');

                //Strip off sign if any
                largerAbsoluteNumber = islargerNumberNegative ? largerAbsoluteNumber.Remove(0, 1) : largerAbsoluteNumber;
                smallerAbsoluteNumber = (!islargerNumberNegative) ? smallerAbsoluteNumber.Remove(0, 1) : smallerAbsoluteNumber;

                return islargerNumberNegative;
            }

            //For same lengthed numbers
            return true;
        }

        public static string ExcludeLeadingZeros(string str)
        {
            //Consider sign
            string retStr = str.TrimStart('0');

            return (retStr == string.Empty) ? "0" : retStr;
        }

        public static string doSumForSameSignedNumbers(string valA, string valB)
        {
            bool isBothNegative = (valA[0] == '-');

            //Strip of negative sign if exists
            valA = (valA[0] == '-') ? valA.Remove(0, 1) : valA;
            valB = (valB[0] == '-') ? valB.Remove(0, 1) : valB;

            //Reversed string ensures indx = 0 points to least significant digit
            //Otherwise padding is needed to point LSD for uneven length numbers
            valA = ReverseString(valA);
            valB = ReverseString(valB);

            StringBuilder retStr = new StringBuilder();
            int indx = 0;
            int carry = 0;
            while ((indx < valA.Length) || (indx < valB.Length))
            {
                int sum = ((indx >= valA.Length) ? 0 : (valA[indx] - 48))
                            + ((indx >= valB.Length) ? 0 : (valB[indx] - 48)) + carry;

                carry = (sum >= 10) ? 1 : 0;
                retStr.Append(Convert.ToChar((sum % 10) + 48));

                indx++;
            }

            //For equal lengthed numbers carry needs to be propagated
            retStr.Append((carry == 1) ? "1" : "");

            return (isBothNegative ? ReverseString(retStr.Append('-').ToString()) : ReverseString(retStr.ToString()));
        }

        public static string ReverseString(string str)
        {
            char[] chArray = str.ToCharArray();
            Array.Reverse(chArray);
            return new string(chArray);
        }

        public static void findMaxMinStringForEqualLengthStrings(ref string maxStr, ref string minStr)
        {
            int lngth = maxStr.Length;
            for (int i = 0; i < lngth; i++)
            {
                if (maxStr[i] < minStr[i])
                {
                    minStr = maxStr;
                    break;
                }
            }
        }

        public static bool isDoSummation(string valA, string valB)
        {
            return ((Char.IsDigit(valA[0]) && Char.IsDigit(valB[0]))
                || (valA[0] == '-' && valB[0] == '-'));
        }
    }
}
