using System;
using System.Linq;
using System.Collections.Generic;

namespace Array_101
{
    internal static class Client
    {
        private readonly static int[,] twoDimensionalArray;
        private readonly static int[,,] threeDimensionalArray;

        static Client()
        {
            twoDimensionalArray = new int[,]
            {
                { 1, 2, 3}
                , { 10, 20, 30 }
            };

            threeDimensionalArray = new int[,,]
            {
                {
                    { 1, 2, 3 }
                    , { 4, 5, 6 }
                },
                {
                    { 7, 8, 9 }
                    , { 10, 11, 12 }
                }
            };
        }

        public static void Main()
        {
            //Poi: Why 'Cast' Works?
            IEnumerable<int> flattened2DArray = twoDimensionalArray.Cast<int>();

            IEnumerable<int> flattened3DArray = threeDimensionalArray.Cast<int>();

            foreach(int elem in flattened2DArray)
            {
                Console.Write(elem + "\t");
            }

            Console.WriteLine("\nFlattened 3D Array\n");
            foreach(int elem in flattened3DArray)
            {
                Console.Write(elem + "\t");
            }
        }
    }
}