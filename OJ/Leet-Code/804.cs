using System;
using System.Linq;
using System.Collections.Generic;

class T
{
    readonly static Dictionary<char, string> _dictionary = new Dictionary<char, string>
    {
        { 'a', ".-" },
        { 'b', "-..." },
        { 'c', "-.-." },
        { 'd', "-.." },
        { 'e', "." },
        { 'f', "..-." },
        { 'g', "--." },
        { 'h', "...." },
        { 'i', ".." },
        { 'j', ".---" },
        { 'k', "-.-" },
        { 'l', ".-.." },
        { 'm', "--" },
        { 'n', "-." },
        { 'o', "---" },
        { 'p', ".--." },
        { 'q', "--.-" },
        { 'r', ".-." },
        { 's', "..." },
        { 't', "-" },
        { 'u', "..-" },
        { 'v', "...-" },
        { 'w', ".--" },
        { 'x', "-..-" },
        { 'y', "-.--" },
        { 'z', "--.." }
    };

    public static int UniqueMorseRepresentations(string[] words)
    {
        var l = new List<string>();

        words
            .ToList()
            .ForEach(x => l.Add(string.Join("", x.ToCharArray().Select(k => _dictionary[k]))));

        return l.Distinct().Count();
    }

    public static void Main()
    {
        Console.WriteLine(UniqueMorseRepresentations(new string[] { "gin", "zen", "gig", "msg" }));
    }
}