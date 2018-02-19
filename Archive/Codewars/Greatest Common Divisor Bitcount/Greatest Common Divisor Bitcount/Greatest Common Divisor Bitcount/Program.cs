using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greatest_Common_Divisor_Bitcount
{
    class Program
    {
        public static int Gcd(int a, int b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        // ReSharper disable InconsistentNaming
        public static int gcdBinary(int x, int y)
        // ReSharper restore InconsistentNaming
        {
            //gcd is always positive: gcd{a,b}=gcd{|a|,b}=gcd{a,|b|}=gcd{|a|,|b|}
            int gcd = Gcd(x < 0 ? (-1 * x) : x, y < 0 ? (-1 * y) : y);

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            int oneCount = 0;

            while (gcd != 0)
            {
                if ((gcd & 1) == 1)
                    oneCount++;

                gcd = gcd >> 1;

            }

            return oneCount;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(gcdBinary(-124, -16));
        }
    }
}
