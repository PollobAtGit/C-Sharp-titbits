using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace makeBackronym
{
    class Program
    {
        private static readonly Dictionary<char, String> Dict = new Dictionary<char, string>()
        {
            {'A', "Aristocratic"}
            , {'B', "Balls"}
            , {'C', "Crimson"}
            , {'D', "Dancing doggy style"}
            , {'E', "Empathy"}
            , {'F', "Fiddle"}
            , {'G', "Genuine"}
            , {'H', "Historic"}
            , {'I', "Irony"}
            , {'J', "Josephus"}
            , {'K', "Karate"}
            , {'L', "Lemon"}
            , {'M', "Masculinity"}
            , {'N', "Nip slip"}
            , {'O', "Opportunity"}
            , {'P', "Promise"}
            , {'Q', "Quarter"}
            , {'R', "Roaster"}
            , {'S', "Submission"}
            , {'T', "Telepathy"}
            , {'U', "University"}
            , {'V', "Verdict"}
            , {'W', "Wedding"}
            , {'X', "Xerox"}
            , {'Y', "Yell"}
            , {'Z', "Zero"}
        };

        public static string MakeBackronym(string str)
        {
            return str.Aggregate("", (current, ch) => current + ((Dict[Char.ToUpper(ch)]) + " ")).Trim();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MakeBackronym("po"));//interesting
            Console.WriteLine(MakeBackronym("zx"));//codewars
        }
    }
}
