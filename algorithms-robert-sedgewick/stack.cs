using System;

internal class Stack
{
    private System.String[] _sequence;
    private System.Int32 _hook = 0;

    public Stack(System.Int32 capacity = 3)
    {
        _sequence = new System.String[capacity];
    }

    public bool IsEmpty() => _hook == 0;

    public void Push(System.String item)
    {
        _sequence[_hook++] = item;
    }

    //POI: Will throw exception if invoked after all elements are poped
    public System.String Pop() => _sequence[--_hook];
}

internal static class Client
{
    internal static void Main()
    {
        var stackInstance = new Stack();

        stackInstance.Push("UTF-8");
        stackInstance.Push("UTF-16");
        stackInstance.Push("ASCII");

        //POI: This will throw Exception, because internal container is NOT extendable
        //stackInstance.Push("UNICODE");

        //POI: LIFO
        Console.WriteLine(stackInstance.Pop());
        Console.WriteLine(stackInstance.Pop());
        Console.WriteLine(stackInstance.Pop());

        //POI: Following will throw Exception
        //Console.WriteLine(stackInstance.Pop());

        var anotherStackInstance = new Stack();

        //POI: This will throw Exception
        //Console.WriteLine(anotherStackInstance.Pop());
    }
}