using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Return_the_Missing_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] superImportantArray = new int[] { 0, 5, 1, 3, 2, 9, 7, 6, 4 };
            //int missingVal = GetMissingElement(superImportantArray);
            int missingVal = GetMissingElementSort(superImportantArray);
            Console.WriteLine(missingVal);
        }

        private static int GetMissingElementSort(int[] superImportantArray)
        {
            Array.Sort(superImportantArray);

            int index = 0;
            while (superImportantArray[index] == index) {
                index++;
            }

            return index;
        }

        static int GetMissingElement(int[] superImportantArray)
        {

            bool[] missingValLog = new bool[] { true, true, true, true, true, true, true, true, true, true};
            for (int i = 0; i < superImportantArray.Length; i++ )
            {
                missingValLog[superImportantArray[i]] = false;
            }

            for (int i = 0; i < missingValLog.Length; i++ )
            {
                if(missingValLog[i]){
                    return i;
                }
            }

            return 0;
        }
    }
}
