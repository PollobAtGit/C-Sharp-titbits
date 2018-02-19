using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_boolean_values_to_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(boolToWord(true));
            Console.WriteLine(boolToWord(false));
        }

        public static string boolToWord(bool isTrue)
        {
            if(isTrue){
                return "Yes";
            }
            return "No";
        }
    }
}
