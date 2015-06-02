using System;

namespace sum_of_strings
{
    public enum Sign
    {
        Positive,
        Negative
    };

    public class BigInteger
    {
        private readonly string _strRepresentation = "";
        private readonly Sign _numberSign = Sign.Positive;

        public BigInteger(string str)
        {
            _strRepresentation = str.Trim();
            _numberSign = (_strRepresentation[0] == '-') ? Sign.Negative : Sign.Positive;

            //Strip off negative sign
            if(_numberSign == Sign.Negative)
            {
                _strRepresentation = _strRepresentation.Remove(0, 1);
            }

            //Trim left '0', but if that leads to empty string then original number was '0'
            _strRepresentation = _strRepresentation.TrimStart(new char[] { '0' });
            _strRepresentation = (_strRepresentation == string.Empty) ? "0" : _strRepresentation;
        }

        public string Add(BigInteger valToAdd)
        {
            return _numberSign == valToAdd._numberSign ? Addition(valToAdd).GetStringRepresentation() : Subtraction(valToAdd).GetStringRepresentation();
        }

        private BigInteger Subtraction(BigInteger valToAdd)
        {
            var maxStr = GetString();
            var minStr = valToAdd.GetString();

            //If length is not same then needs padding
            PadNumbers(ref maxStr, ref minStr);

            //Assign max/min string to proper variables
            DetermineMaxStrMinStr(ref  maxStr, ref minStr);

            // ReSharper disable once StringCompareToIsCultureSpecific
            //If max number is of negative sign then needs to append '-' after substraction is found
            var maxNumberSign = (GetString().CompareTo(maxStr) == 0) ? _numberSign : valToAdd._numberSign;

            var subtractionStr = Subtract(maxStr, minStr, maxNumberSign);

            return new BigInteger(ReverseString(subtractionStr));
        }

        private static string Subtract(string maxStr, string minStr, Sign maxNumberSign)
        {
            var subtractionStr = "";
            var borrow = 0;
            for (var indx = (maxStr.Length - 1); indx >= 0; indx--)
            {
                var maxDigit = (int) char.GetNumericValue(maxStr[indx]);
                var minDigit = (int) char.GetNumericValue(minStr[indx]) + borrow;
                maxDigit = (maxDigit < minDigit) ? (10 + maxDigit) : maxDigit;

                var subtraction = maxDigit - minDigit;
                borrow = (maxDigit >= 10) ? 1 : 0;

                subtractionStr += subtraction;
            }

            subtractionStr = AdjustSignToResultantStr(maxNumberSign, subtractionStr);

            return subtractionStr;
        }

        private static string AdjustSignToResultantStr(Sign sign, string str)
        {
            if (sign != Sign.Negative)
                return str;

            str = str.TrimEnd(new char[] {'0'});
            str = (str == string.Empty) ? "0" : str;

            // ReSharper disable once StringCompareToIsCultureSpecific
            if (str.CompareTo("0") != 0)
            {
                str += '-';
            }
            return str;
        }

        private static void DetermineMaxStrMinStr(ref string maxStr, ref string minStr)
        {
            // ReSharper disable once StringCompareToIsCultureSpecific
            var compareNumber = maxStr.CompareTo(minStr);
            if (compareNumber >= 0)
                return;

            var tmp = minStr;
            minStr = maxStr;
            maxStr = tmp;
        }

        private BigInteger Addition(BigInteger valToAdd)
        {
            var thisStr = GetString();
            var valToAddStr = valToAdd.GetString();

            //If length is not same then needs padding
            PadNumbers(ref thisStr, ref valToAddStr);

            var summationStr = Add(thisStr, valToAddStr);

            return new BigInteger(ReverseString(summationStr));
        }

        private string Add(string thisStr, string valToAddStr)
        {
            var summationStr = "";
            var carry = 0;
            for (var indx = (thisStr.Length - 1); (indx >= 0) || (carry == 1); indx--)
            {
                var sum = (indx < 0)
                    ? carry
                    : (int) char.GetNumericValue(thisStr[indx]) + (int) char.GetNumericValue(valToAddStr[indx]) + carry;
                carry = (sum >= 10) ? 1 : 0;
                summationStr = summationStr + (sum - ((carry == 1) ? 10 : 0));
            }

            summationStr = AdjustSignToResultantStr(_numberSign, summationStr);

            return summationStr;
        }

        private static string ReverseString(string str)
        {
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void PadNumbers(ref string thisStr, ref string valToAddStr)
        {
            var paddingCount = Math.Abs(thisStr.Length - valToAddStr.Length);
            if (thisStr.Length < valToAddStr.Length)
            {
                thisStr = thisStr.PadLeft((paddingCount + thisStr.Length), '0');
            }
            else if (GetString().Length > valToAddStr.Length)
            {
                valToAddStr = valToAddStr.PadLeft((paddingCount + valToAddStr.Length), '0');
            }
        }

        private string GetString()
        {
            return _strRepresentation;
        }

        private string GetStringRepresentation()
        {
            return (_numberSign == Sign.Negative) ? ("-" + _strRepresentation) : _strRepresentation;
        }
    }

    public static class Kata
    {
        public static string sumStrings(string a, string b)
        {
            var bgInt = new BigInteger(a);
            return bgInt.Add(new BigInteger(b));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.sumStrings("-0050", "-000050"));
        }
    }
}
