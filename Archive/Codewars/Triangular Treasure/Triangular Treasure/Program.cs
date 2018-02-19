using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangular_Treasure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Triangular(-10));
        }

        public static int Triangular(int n)
        {
            if(n < 0)
                return 0;

            int triangularNumber = 0;
            for (int i = 1; i <= n; i++ )
            {
                triangularNumber += i;
            }

            return triangularNumber;
        }
    }
}
