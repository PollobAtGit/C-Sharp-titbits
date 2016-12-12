using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        IEnumerator fibEnumerator = OnlyOdd(Fib(6));

        //POI: This statement is executed at first. That means at this point of time none of OnlyOdd/Fib has been
        // invoked. This will happen only & only when MoveNext() on IEnumerator is invoked.
        // IEnumerator is lazy by nature
        Print<string>("HAVEN'T YIELD-ED ANYTHING\n");

        while(fibEnumerator.MoveNext()) { }
    }

    //POI: This method returns ITERATOR NOT A value
    public static IEnumerable Fib(int nth)
    {
        int prevNumber = 0;
        int currentNumber = 1;
        for(int current = 0; current < nth; current++)
        {
            Print<string>("YIELD FROM Fib & YIELDING " + currentNumber);
            yield return currentNumber;

            int swapHelper = prevNumber;
            prevNumber = currentNumber;
            currentNumber += swapHelper;
        }
    }

    //POI: Everytime this method will get a IEnumerable with only one data in it
    public static IEnumerator OnlyOdd(IEnumerable fibEnumerable)
    {
        IEnumerator fibEnum = fibEnumerable.GetEnumerator();
        Print<string>(null);
        while(fibEnum.MoveNext())
        {
            Print<string>("YIELD FROM OnlyOdd & YIELDING " + fibEnum.Current + "\n");
            if(((int)fibEnum.Current) % 2 != 0) yield return fibEnum.Current;

            //POI: Enabling following code & disabling the above one will ensuring nothing will ever
            // yield. In that case output will show that there are no consecutive text
            // 'YIELD FROM OnlyOdd ....' in output. Which means this method ALWAYS gets a IEnumerable with only
            // one element it's never a full set of data which makes sense because this input is generated from
            // what is yield-ed from method 'Fib'
            //if(false) yield return fibEnum.Current;
        }
    }

    public static void Print<T>(T msg) => Console.WriteLine(msg);
}