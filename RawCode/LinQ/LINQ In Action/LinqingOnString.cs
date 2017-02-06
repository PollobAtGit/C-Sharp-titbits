using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqingOnString
{
    public class Client
    {
        public static void Main()
        {
            string str = "39/1, BC DAS ROAD";

            foreach(var ch in str.Where<char>(ch => Char.IsDigit(ch)))
            {
                Console.WriteLine(ch);
            }

            Console.WriteLine();
            IEnumerable<char> specialCharacters = str.Where<char>(ch => !Char.IsDigit(ch) && !Char.IsLetter(ch));
            foreach(var ch in specialCharacters)
            {
                Console.WriteLine(ch);
            }

            Console.WriteLine();
            IEnumerable<char> punctuations = from ch in str where Char.IsPunctuation(ch) select ch;
            foreach(var ch in punctuations)
            {
                Console.WriteLine(ch);
            }

            Console.WriteLine();
            Console.WriteLine("There Are " + (from ch in str where Char.IsWhiteSpace(ch) select ch).Count() + " White Spaces");

            Console.WriteLine();
            Console.WriteLine("There Are " + str.Count<char>(ch => Char.IsLetterOrDigit(ch)) + " Letters Or Digits");
        }
    }
}
