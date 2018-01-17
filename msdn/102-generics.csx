
internal sealed class GenericList<T>
{
    private Node _head;

    // POI: Prepends data
    public void Add(T data)
    {
        var node = new Node(data);
        node.Next = _head;
        _head = node;
    }

    // POI: Implementing a GetEnumerator method without any linkage to IEnumerable<T>. Foreach only requires the presence of the method
    // POIL foreach requires IEnumerator<T> which contains definition for Current, MoveNext(), Reset()
    public IEnumerator<T> GetEnumerator()
    {
        var itr = _head;
        while (itr != null)
        {
            // yield return will return control back to the caller
            yield return itr.Data;
            itr = itr.Next;
        }
    }

    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T d)
        {
            Data = d;
        }
    }
}

var list = new GenericList<int>();

list.Add(56);
list.Add(89);
list.Add(-100);
list.Add(0);

foreach (var i in list)
{
    Console.Write($"{i} ");
}
