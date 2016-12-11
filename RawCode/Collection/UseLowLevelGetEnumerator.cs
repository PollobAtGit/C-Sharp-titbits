using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        /********** ITERATING OVER CHAR SEQUENCE *******************/

        string str = "Greeting!";

        //POI: GetEnumerator for STRING doesn't return classic IEnumerator nor does it return generic IEnumerator<char> but CharEnumerator
        // which is a class defined in System namespace NOT IN System.Collections.Generic namespace
        // But as this CharEnumerator class implements BOTH of IEnumerator & IEnumerator<char>, both of the following statements are
        // true along with the last one

        IEnumerator<char> genericEnumerator = str.GetEnumerator();//Generic version
        IEnumerator nonGenericStringEnumerator = str.GetEnumerator();//Non-generic version
        CharEnumerator strEnumerator = str.GetEnumerator();

        while(strEnumerator.MoveNext())
        {
            Print<char>(strEnumerator.Current);
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


        /********** ITERATING OVER A ARRAY *******************/

        int[] array = new int[] { 0, 1, 2 };

        //POI: Following will throw CE because arrays return classic (non-generic) version of IEnumerator 
        //IEnumerator<int> intArrayEnumerator = array.GetEnumerator();        
        
        IEnumerator nonGenericIntArrayEnumerator = array.GetEnumerator();

        Print<string>(null);
        while(nonGenericIntArrayEnumerator.MoveNext())
        {
            Print(nonGenericIntArrayEnumerator.Current);
        } 

        /********** TYPE RETURNED BY GetEnumerator *******************/

        //POI: All of the following returns generic IEnumerator<T>
        Print<Type>(xLinkedList.GetEnumerator().GetType());//System.Collections.Generic.LinkedList`1+Enumerator[Program+X]
        Print<Type>(xDic.GetEnumerator().GetType());//System.Collections.Generic.Dictionary`2+Enumerator[System.String,Program+X]
        Print<Type>(xStack.GetEnumerator().GetType());//System.Collections.Generic.Stack`1+Enumerator[Program+X]
        Print<Type>(xQueue.GetEnumerator().GetType());//System.Collections.Generic.Queue`1+Enumerator[Program+X]

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