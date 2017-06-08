using System;

internal static class Ans
{
    internal static void Main()
    {
        try
        {
            var queueInstance = new Queue();

            queueInstance.Enqueue("UTF-8");
            queueInstance.Enqueue("UTF-16");

            Debug(queueInstance.Dequeue());
            Debug(queueInstance.Dequeue());

            Debug(queueInstance.IsEmpty());
            Debug(queueInstance.Count);

            queueInstance.Enqueue("Sublime");

            Debug(queueInstance.IsEmpty());
            Debug(queueInstance.Count);
            
            Debug(queueInstance.Dequeue());

            Debug(queueInstance.IsEmpty());
            Debug(queueInstance.Count);

            Debug(queueInstance.Dequeue());
        }
        catch(Exception exp)
        {
            Debug(exp.Message);
        }
    }

    private static void Debug(object msg)
    {
        Console.WriteLine(msg);
    }
}

internal class Queue
{
    private System.String[] _container;
    private System.Int32 _topHook = 0;
    private System.Int32 _downHook = 0;

    public Queue(System.Int32 capacity = 5)
    {
        _container = new System.String[capacity];
    }

    public bool IsEmpty() => Count == 0;

    public System.Int32 Count { get { return _topHook - _downHook; } }

    public void Enqueue(System.String item)
    {
        if(Count == _container.Length) ReSize(Count * 2);
        _container[_topHook++] = item;
    }

    public System.String Dequeue()
    {
        if(IsEmpty()) throw new Exception("No Element In Queue");
        if(Count == _container.Length / 4) ReSize(Count * 2);
        
        var dequeuedValue = _container[_downHook++];

        _container[_downHook - 1] = null;

        return dequeuedValue;
    }

    private void ReSize(System.Int32 capacity)
    {
        System.String[] container = new System.String[capacity];
        var j = 0;

        for(var i = 0; i < _container.Length; i++)
            if(_container[i] != null)
                container[j++] = _container[i];

        _container = container;
        _topHook = Count;//_topHook will point to the NEXT element
        _downHook = 0;
    }

}
