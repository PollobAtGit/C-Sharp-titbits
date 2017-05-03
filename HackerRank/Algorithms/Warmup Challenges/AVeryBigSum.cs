using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution 
{

    //POI: 10^10 can be stored in .NET int
    //POI: 10^11 can be stored into .NET Int64
    //POI: Convert.ToInt64/Convert.ToInt all works on String. So argument has to be String
    
    static void Main(String[] args) 
    {
        Console.ReadLine();
        Console.WriteLine(Console.ReadLine()
                          .Split(' ')
                          .Select(numberStr => Convert.ToInt64(numberStr))
                          .Sum());
    }
}
