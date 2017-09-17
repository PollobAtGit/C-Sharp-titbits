using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemTwo.B
{
    public static class Enumerate
    {
        public static void IterateViaConst()
        {
            for (var i = 0; i < Program.ThisYearConst; i = i + 100)
            {
                WriteLine($"{i} => Hello Via Const");
            }
            WriteLine();
        }

        public static void IterateViaReadOnly()
        {
            for (var i = 0; i < new Program().ThisYear; i = i + 100)
            {
                WriteLine($"{i} => Hello Via ReadOnly");
            }
            WriteLine();
        }
    }
}
