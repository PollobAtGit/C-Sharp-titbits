using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        /********** ITERATING OVER CHAR SEQUENCE *******************/

        string str = "Greeting!";

        IEnumerator<char> enumerator = str.GetEnumerator();

        //This will throw CE (CS0305) because exposed GetEnumerator is the generic version
        //IEnumerator nonGenericEnumerator = str.GetEnumerator();

        while(enumerator.MoveNext())
        {
            Print<char>(enumerator.Current);
        }


        /********** ITERATING OVER A LINKED LIST OF X *******************/

        LinkedList<X> xLinkedList = new LinkedList<X>();
        xLinkedList.AddFirst(new X("Hello!"));
        xLinkedList.AddFirst(new X("Olo!"));
        xLinkedList.AddFirst(new X("Melo!"));
        xLinkedList.AddFirst(new X("Hi!"));

        //LinkedList<T> implements IEnumerable<T>
        IEnumerator<X> xEnumerator = xLinkedList.GetEnumerator();

        //POI: Type cannot be inferred from statement 'Print(null)' because type in this case can be
        // any reference type of nullable value type
        Print<string>(null);

        while(xEnumerator.MoveNext())
        {
            Print<string>(xEnumerator.Current.Greeting);
        }

        /********** ITERATING OVER A DICTIONARY OF X *******************/

        Dictionary<string, X> xDic = new Dictionary<string, X>
        {
            { "Traditional Greeting", new X("Hello!") },
            { "Funky Greeting", new X("Olo!") },
            { "Meaningless Greeting", new X("Melo!") },
            { "Modern Greeting", new X("Hi!") }
        };

        IEnumerator<KeyValuePair<string, X>> xDicEnumerator = xDic.GetEnumerator();

        Print<string>(null);
        while(xDicEnumerator.MoveNext())
        {
            KeyValuePair<string, X> xPair = xDicEnumerator.Current;
            Print<string>("KEY: " + xPair.Key + " || VALUE: " + xPair.Value.Greeting);
        }

        /********** ITERATING OVER A STACK OF X *******************/

        Stack<X> xStack = new Stack<X>();

        xStack.Push(new X("Hello!"));
        xStack.Push(new X("Olo!"));
        xStack.Push(new X("Hi!"));

        IEnumerator<X> xStackEnumerator = xStack.GetEnumerator();

        Print<string>(null);
        while(xStackEnumerator.MoveNext())
        {
            Print<string>(xStackEnumerator.Current.Greeting);
        }

        /********** ITERATING OVER A QUEUE OF X *******************/

        Queue<X> xQueue = new Queue<X>();

        xQueue.Enqueue(new X("Hello!"));
        xQueue.Enqueue(new X("Olo!"));
        xQueue.Enqueue(new X("Hi!"));

        IEnumerator<X> xQueueEnumerator = xQueue.GetEnumerator();

        Print<string>(null);
        while(xQueueEnumerator.MoveNext())
        {
            Print<string>(xQueueEnumerator.Current.Greeting);
        }

    }

    private class X
    {
        public string Greeting { get; private set; }

        //What doesn it mean to have a public member in a private nested class?
        public X(string greeting)
        {
            Greeting = greeting;
        }
    }

    public static void Print<T>(T a) => Console.WriteLine(a);
}