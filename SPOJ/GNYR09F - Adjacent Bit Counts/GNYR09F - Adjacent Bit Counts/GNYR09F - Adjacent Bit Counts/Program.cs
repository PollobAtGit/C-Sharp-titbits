using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNYR09F___Adjacent_Bit_Counts
{
    class Program
    {
        static void Main(string[] args)
        {

            int dataSetCnt = Convert.ToInt32(Console.ReadLine());
            while (dataSetCnt > 0)
            {
                var line = Console.ReadLine();
                if (line != null)
                {
                    string[] readLine = line.Split(new []{' '});
                    int caseCnt = Convert.ToInt32(readLine[0]);
                    int n = Convert.ToInt32(readLine[1]);
                    int k = Convert.ToInt32(readLine[2]);

                    List<List<int>> dpLst = PopulateMemorizationTbl(n, k);

                }

                dataSetCnt--;
            }
        }

        private static List<List<int>> PopulateMemorizationTbl(int n, int k)
        {
            ulong  [,] dpLst = new ulong [101, 100];

            for (int i = 0; i < 101; i++)
            {
                ulong  tmp = 0;
                if (i == 0)
                    tmp = 0;
                else if (i == 1)
                    tmp = 2;
                else if (i == 2)
                    tmp = 3;
                else
                    tmp = dpLst[i - 2, 0] + dpLst[i - 1, 0];

                dpLst[i, 0] = tmp;
            }

            for (int i = 0; i < 101; i++)
            {
                Console.WriteLine("Index " + (i + 1) + " : " + dpLst[i, 0]);
            }

            return new List<List<int>>();
        }
    }
}
