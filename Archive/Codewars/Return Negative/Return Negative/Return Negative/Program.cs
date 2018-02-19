using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Return_Negative
{
    class Program
    {
        public static int MakeNegative(int number)
        {
            return (number > 0 ? (-1 * number) : number);
            //return (-1 * Math.Abs(number));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Negative of 23: " + MakeNegative(23));
            Console.WriteLine("Negative of 0: " + MakeNegative(0));
            Console.WriteLine("Negative of -23: " + MakeNegative(-23));
        }
    }
}
