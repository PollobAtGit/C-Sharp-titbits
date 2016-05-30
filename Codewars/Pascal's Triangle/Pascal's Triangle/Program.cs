using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_s_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pascalsTriangle = PascalsTriangle(1);

            foreach(int item in pascalsTriangle)
            {
                Console.WriteLine(item);
            }
        }

        public static List<int> PascalsTriangle(int n)
        {
            List<List<int>> triangleContainer = new List<List<int>>();

            int xAxis = 1;
            while(xAxis <= n)
            {
                List<int> lst = new List<int>();
                
                int yAxis = 1;
                while(yAxis <= xAxis)
                {
                    int addVal = 0;
                    if ((yAxis == 1) || (xAxis == yAxis))
                    {
                        addVal = 1;
                    }

                    lst.Add(addVal);
                    yAxis++;
                }

                triangleContainer.Add(lst);
                xAxis++;
            }

            //Calculate values
            xAxis = 0;
            while(xAxis < n)
            {
                int yAxis = 0;
                while (yAxis <= xAxis)
                {
                    if(triangleContainer[xAxis][yAxis] == 0)
                    {
                        triangleContainer[xAxis][yAxis] = (triangleContainer[xAxis - 1][yAxis - 1] + triangleContainer[xAxis - 1][yAxis]);
                    }

                    yAxis++;
                }

                xAxis++;
            }

            return triangleContainer.SelectMany(d => d).ToList();
        }
    }
}
