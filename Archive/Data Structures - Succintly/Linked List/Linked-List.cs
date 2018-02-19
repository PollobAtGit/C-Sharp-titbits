using System;
using System.Collections;
using System.Collections.Generic;

internal class LinkedList<T> : ICollection<T>
{
    public void Add(T item) { throw new NotImplementedException(); }
    public void Clear() { throw new NotImplementedException(); }
    public bool Contains(T item) { throw new NotImplementedException(); }
    public void CopyTo(T[] array, int arrayIndex) { throw new NotImplementedException(); }
    public bool Remove(T item) { throw new NotImplementedException(); }

    public int Count { get; private set; }

    //TODO: Check usage
    public bool IsReadOnly { get; private set; }

    public IEnumerator<T> GetEnumerator() { throw new NotImplementedException(); }
    IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
}

internal static class Client
{
    internal static void Main()
    {

    }
}