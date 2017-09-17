using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemTwo.B.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Enumerate.IterateViaConst();
            Enumerate.IterateViaReadOnly();

            Console.ReadKey();
        }
    }
}
