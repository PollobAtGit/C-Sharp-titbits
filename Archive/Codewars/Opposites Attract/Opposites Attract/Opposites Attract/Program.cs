using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opposites_Attract
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Lovefunc(0, 1).ToString());
        }

        public static bool Lovefunc(int flower1, int flower2)
        {
            var flowerOneEven = 0;
            var flowerTwoEven = 0;

            Math.DivRem(flower1, 2, out flowerOneEven);//Return type is the quotient. Nice !
            Math.DivRem(flower2, 2, out flowerTwoEven);//Return type is the quotient. Nice !

            return (flowerOneEven != flowerTwoEven);
        }
    }
}
