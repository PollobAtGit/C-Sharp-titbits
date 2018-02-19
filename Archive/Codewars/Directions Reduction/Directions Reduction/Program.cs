using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directions_Reduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] reducedPath = dirReduc(new string[] { "NORTH", "WEST", "SOUTH", "EAST" });
            
            foreach(string str in reducedPath)
            {
                Console.WriteLine(str);
            }
        }

        public static string[] dirReduc(String[] arr)
        {
            List<string> reducedDirections = new List<string>(arr);
            bool isAllDirectionReduced = false;
            while(!isAllDirectionReduced)
            {
                List<string> lst = new List<string>(reducedDirections);
                reducedDirections.Clear();

                bool reduced = false;
                for(int i =  0; i < lst.Count; )
                {
                    string oppositeStr = GetOppositeStr(lst[i]);
                    if ((i + 1) < lst.Count && oppositeStr.Equals(lst.ElementAt(i + 1)))
                    {
                        i = i + 2;
                        reduced = true;
                    }
                    else
                    {
                        reducedDirections.Add(lst[i]);
                        i++;
                    }
                }

                if (!reduced)
                    isAllDirectionReduced = true;
            }

            return reducedDirections.ToArray<string>();
        }

        public static string GetOppositeStr(string str)
        {
            string retStr = "";
            switch(str)
            {
                case "NORTH":
                    retStr = "SOUTH";
                    break;
                case "SOUTH":
                    retStr = "NORTH";
                    break;
                case "EAST":
                    retStr = "WEST";
                    break;
                case "WEST":
                    retStr = "EAST";
                    break;
            }

            return retStr;
        }
    }
}
