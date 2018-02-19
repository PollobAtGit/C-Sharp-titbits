using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Which_are_in
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lstStr = inArray(new string[] { "tarp", "mice", "bull" }, new string[] { "lively", "alive", "harp", "sharp", "armstrong" });
            
            foreach(string str in lstStr)
            {
                Console.WriteLine(str);
            }
        }

        public static string[] inArray(string[] array1, string[] array2)
        {
            HashSet<string> retArray = new HashSet<string>();

            foreach(string str in array1)
            {
                foreach(string str_1 in array2)
                {
                    if (str_1.Contains(str))
                    {
                        retArray.Add(str);
                    }
                }
            }

            List<string> retLst = retArray.ToList<string>();
            retLst.Sort();

            return retLst.ToArray();
        }
    }
}
