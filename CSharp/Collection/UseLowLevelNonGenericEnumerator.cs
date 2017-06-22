using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        Queue queue = new Queue();//Initializing non generic Queue

        queue.Enqueue(12);
        queue.Enqueue(12.32m);
        queue.Enqueue(new X());
        queue.Enqueue(new X());

        IEnumerator queueEnumerator = queue.GetEnumerator();

        while(queueEnumerator.MoveNext())
        {
            //POI: IEnumerator.Current returns 'object' because it's a non generic version
            Print<object>(queueEnumerator.Current);
        }

        Hashtable dic = new Hashtable();

        dic.Add("Greeting", "Hello!");
        dic.Add(23.23m, new X());
        dic.Add(' ', 100f);

        IEnumerator dicEnumerator = dic.GetEnumerator();

        Print<string>(null);
        while(dicEnumerator.MoveNext())
        {
            //POI: DictionaryEntry is a STRUCTURE defined in System.Collections that returns a Hastable's
            // (Dictionary) Key & Value pair
            //POI: IEnumerator.Current returns 'object'
            DictionaryEntry currentDicElem = (DictionaryEntry) dicEnumerator.Current;
            Print<object>("KEY: " + currentDicElem.Key + " || VALUE: " + currentDicElem.Value);
        }

        //POI: Both of the following invocations are VALID but that is risky part
        Iterate(queueEnumerator);
        Iterate(dicEnumerator);
    }

    private class X
    {
        public override string ToString() => this.GetHashCode().ToString();
    }

    public static void Iterate(IEnumerator itr)
    {
        //RISKY PLACE. SOME HOW NEEDS TO KNOW WHAT IS BEING PASSED OTHERWISE INVALID OPERATION CAN CAUSE EXCEPTION
        //CONSIDER HASHTABLE (DICTIONARY) ENUMERATION & QUEUE ENUMERATION CODE. THEY ARE DIFFERENT. HASTABLE NEEDS
        //CASTING TO DictionaryEntry WHICH ISN'T REQUIRED FOR QUEUE 
    }

    public static void Print<T>(T msg) => Console.WriteLine(msg);
}
