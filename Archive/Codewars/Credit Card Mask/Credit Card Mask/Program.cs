using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_Card_Mask
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = "11111";
            Console.WriteLine(Maskify(inputStr));
        }

        private static string Maskify(string inputStr)
        {
            char[] arr = inputStr.ToCharArray();
            int lstLimit = arr.Length - 4;
            for (int i = 0; i < lstLimit; i++ ) {
                arr[i] = '#';
            }

            return new string(arr);
        }
    }
}
