using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Variation_on_Caesar_Cipher
{
    class Program
    {
        // ReSharper disable InconsistentNaming
        public static List<String> movingShift(String s, int shift)
        // ReSharper restore InconsistentNaming
        {
            var encodedStr = "";
            foreach (var ch in s)
            {
                encodedStr += EncodedChar(shift, ch);
                shift = (++shift) % 26;
            }

            //If length can't be evenly divided, we then need first 4 slots to be of higher length
            var charCntInSlot = ((encodedStr.Length%5) != 0) ? ((encodedStr.Length/5) + 1) : (encodedStr.Length/5);

            var lst = new List<string>();

            for (var i = 0; i < encodedStr.Length; i += charCntInSlot)
            {
                var subStrLength = i + charCntInSlot;

                //Ensure sub string length doesn't exceed total length
                if (subStrLength > encodedStr.Length)
                {
                    charCntInSlot = charCntInSlot - (subStrLength - encodedStr.Length);
                }
                lst.Add(encodedStr.Substring(i, charCntInSlot));
            }

            return lst;
        }

        private static char EncodedChar(int shift, char ch)
        {
            if (!Char.IsLetterOrDigit(ch))
                return ch;

            var shiftCnt = ch + shift;
            var maxValue = Char.IsUpper(ch) ? 'Z' : 'z';

            //If shift is larger than max character value then we need to circle back.
            //Circling is done by (shiftCnt - maxValue) and further increment by ((Char.IsUpper(ch)? 'A': 'a')) - 1
            return (shiftCnt <= maxValue)
                ? Convert.ToChar(shiftCnt)
                : Convert.ToChar((shiftCnt - maxValue) + ((Char.IsUpper(ch)
                                                            ? 'A'
                                                            : 'a')) - 1);
        }

        // ReSharper disable InconsistentNaming
        public static String demovingShift(List<String> s, int shift)
        // ReSharper restore InconsistentNaming
        {
            var encodedStr = s.Aggregate("", (current, lstItem) => current + lstItem);

            var decodedStr = "";
            foreach (var ch in encodedStr)
            {
                decodedStr += DeCodedChar(shift, ch);
                shift = (++shift) % 26;
            }

            return decodedStr;
        }

        private static char DeCodedChar(int shift, char ch)
        {
            if (!Char.IsLetterOrDigit(ch))
                return ch;

            var shiftCnt = ch - shift;
            var minValue = Char.IsUpper(ch) ? 'A' : 'a';

            return (shiftCnt >= minValue)
                ? Convert.ToChar(shiftCnt)
                : Convert.ToChar(((Char.IsUpper(ch) ? 'Z' : 'z') - (minValue - shiftCnt) + 1));
        }

        static void Main(string[] args)
        {
            var u = "I should have known that you would have a perfect answer for me!!!";
            Console.WriteLine(demovingShift(movingShift(u, 1), 1));
        }
    }
}
