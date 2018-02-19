namespace Solution
{
    using System;
    using System.Linq;
    using static System.Console;
    using System.Collections.Generic;

    internal class Program
    {
        internal static void Main()
        {
            ReadLine();

            var harryQueue = new Queue<int>(Array.ConvertAll(ReadLine().Split(' '), int.Parse));
            var qx = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
            var monkStack = new Stack<int>();

            for(var i = 0; i < qx[0] && monkStack.Sum() != qx[1]; i = i + 1)
            {
                var commandTxt = ReadLine();

                if(commandTxt == "Harry")
                {
                    monkStack.Push(harryQueue.Dequeue());
                } else if(commandTxt == "Remove")
                {
                    monkStack.Pop();
                }
            }

            WriteLine(monkStack.Sum() != qx[1] ? -1 : monkStack.Count());
        }
    }
}