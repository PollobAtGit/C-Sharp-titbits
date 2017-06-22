using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        IEnumerator intEnumerator = GetEnumerator();

        while(intEnumerator.MoveNext())
        {
            Print<string>("YIELD-ED " + intEnumerator.Current);
            Print<object>(intEnumerator.Current);
            Print<string>(null);
        }
    }

    //POI:  # Every yield will return control to the caller but the callee's state will be stored so that the process can be resumed if required
    //      # IF requested again (via IEnumerator<T>.MoveNext()/IEnumerator.MoveNext()) the callee state
    //          will be re-stored & the process will continue from where the first call left of
    //      # The process is inherently lazy
    public static IEnumerator GetEnumerator()
    {
        Print<string>("WILL YIELD 1");
        //POI: This will return control to the caller
        yield return 1;

        //POI: Control will come back to this point after 2nd MoveNext() is invoked
        Print<string>("WILL YIELD 2");
        //POI: This will return control to the caller
        yield return 2;

        //POI: Control will come back to this point after 3rd MoveNext() is invoked
        Print<string>("WILL YIELD 3");
        //POI: This will return control to the caller
        yield return 3;

        //POI: This print will occur to console. This will occur during the last MoveNext(). After it's invoked
        // process will come to this statement, will print the string & then go back to the caller
        // but as here's nothing is being yield-ed process (while loop) will terminate  
        Print<string>("NOTHING ELSE TO YIELD");
    }

    public static void Print<T>(T msg) => Console.WriteLine(msg);
}