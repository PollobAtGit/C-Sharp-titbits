using System;
using System.Collections.Generic;

internal class Stack
{
    private System.String[] _sequence;

    //POI: Hook can NOT be negative
    private System.UInt32 _hook = 0;

    public Stack(System.UInt32 capacity = 3)
    {
        _sequence = new System.String[capacity];
    }

    public bool IsEmpty() => _hook == 0;

    public void Push(System.String item)
    {
        if(_hook == _sequence.Length - 1) Resize((uint)_sequence.Length * 2);
        _sequence[_hook++] = item;
    }

    public System.String Pop()
    {
        if(IsEmpty()) throw new Exception("Stack Is Empty");
        if(_hook == _sequence.Length / 4) Resize((uint)_sequence.Length / 2);

        //POI: Free Memory
        var popedItem = _sequence[--_hook];
        _sequence[_hook] = null;

        return popedItem;
    }

    private void Resize(System.UInt32 capacity)
    {
        System.String[] sequence = new System.String[capacity];

        //POI: C# have a better way to copy elements from source to destination array
        for(var i = 0; i < _hook; i++) sequence[i] = _sequence[i];

        //TODO: May be another new Stack should be created to make _sequence readonly
        _sequence = sequence;
    }

    //TODO: Expose a read-only iterator
    /*
        public IEnumerable<System.String> Iterator()
        {
            foreach(var item in _sequence) yield item;
        }
    */
}

internal static class Client
{
    internal static void Main()
    {
        var stackInstance = new Stack();

        stackInstance.Push("UTF-8");
        stackInstance.Push("UTF-16");
        stackInstance.Push("ASCII");

        //POI: This will NOT throw Exception because internal container will extend on it's own
        stackInstance.Push("UNICODE");

        //POI: LIFO
        Console.WriteLine(stackInstance.Pop());
        Console.WriteLine(stackInstance.Pop());
        Console.WriteLine(stackInstance.Pop());

        //POI: Following will throw Exception
        Console.WriteLine(stackInstance.Pop());

        var anotherStackInstance = new Stack();

        //POI: This will throw Exception
        //Console.WriteLine(anotherStackInstance.Pop());
    }
}