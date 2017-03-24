using System;

namespace Indexer_101
{
    internal class Client
    {
        private class PrinterStore
        {
            private string[] _modelNames = new string[] { "", "", "" };
            public string this[int index]
            {
                get { return _modelNames[index]; }
                set { _modelNames[index] = value; }
            }
        }

        internal static void Main()
        {
            PrinterStore store = new PrinterStore();

            store[0] = "Canon";
            store[1] = "HP";

            Console.WriteLine(store[0]);
            Console.WriteLine(store[1]);

            Console.WriteLine(string.IsNullOrEmpty(store[2]));
        }
    }
}