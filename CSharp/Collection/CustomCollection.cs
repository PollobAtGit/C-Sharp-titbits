using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        /******** COLLECTION RETURNS ENUMERATOR OF UNDERLYING COLLECTION ******/

        CustomCollection cusCol = new CustomCollection();

        IEnumerator cusColEnumerator = cusCol.GetEnumerator();

        while(cusColEnumerator.MoveNext())
        {
            Print<object>(cusColEnumerator.Current);
        }

        /****** COLLECTION YIELDS VALUES ******/

        CusCollection yieldCusCol = new CusCollection();

        IEnumerator yieldCusColEnumerator = yieldCusCol.GetEnumerator();

        Print<string>(null);
        while(yieldCusColEnumerator.MoveNext())
        {
            Print<string>("YIELDED " + yieldCusColEnumerator.Current);
            Print<string>(null);
        }

        /****** COLLECTION RETURNS ENUMERATOR ******/

        ConCollection conCol = new ConCollection();

        IEnumerator conColEnumerator = conCol.GetEnumerator();

        while(conColEnumerator.MoveNext())
        {
            Print<object>(conColEnumerator.Current);
        }

        Print<string>(null);

        //Qry: Something happens. What's that? 'conCol' GetEnumerator is invoked automatically  But that returns
        // IEnumerator. Then why defining 'content' as decimal works?

        //POI: Everytime foreach is invoked, GetEnumerator() is invoked too which means a new Enumerator will
        //  be created. So unless a explicit reference to a enumerator isn't being hold there's no need to invoke
        //  Reset()

        foreach(double content in conCol)
            Print<double>(content);

        Print<string>(null);
        conColEnumerator.Reset();
        Print<bool>(conColEnumerator.MoveNext() == true);//TRUE

        /****** COLLECTION RETURNS ENUMERATOR ******/

        GenConCollection col = new GenConCollection();

        IEnumerator<int> colEnumerator = col.GetEnumerator();

        Print<string>(null);
        while(colEnumerator.MoveNext())
        {
            Print<int>(colEnumerator.Current);
        }

        Print<string>(null);
        Print<bool>(colEnumerator.MoveNext() == false);//TRUE
        colEnumerator.Reset();
        Print<bool>(colEnumerator.MoveNext() == true);//TRUE
    }

    public static void Print<T>(T msg) => Console.WriteLine(msg);
}

//POI: This collection simply uses an underlying collection & returns that collections Enumerator
public class CustomCollection : IEnumerable
{
    private int[] _collection = new int[] { 0 , 1, 2, 89 };
    public IEnumerator GetEnumerator() => _collection.GetEnumerator();
}

//POI: yield collection content
public class CusCollection : IEnumerable
{
    private decimal[] _collection = new decimal[] { 100.23m, 89.210m };
    public IEnumerator GetEnumerator()
    {
        //QRY: content is decimal but in foreach _collection should return IEnumerator. Shouldn't there be any conflict?
        foreach(decimal content in _collection)
        {
            Program.Print<string>("YIELD " + content);
            yield return content;
        }
    }
}

public class ConCollection : IEnumerable
{
    private double[] _collection = new double[] { 56.0223, 889.52 };
    public IEnumerator GetEnumerator() => new Enumerator(this);

    private class Enumerator : IEnumerator
    {
        private ConCollection _collection;
        private int _index = 0;
        private int _length = 0;
        public Enumerator(ConCollection collection)
        {
            _collection = collection;
            _length = _collection._collection.Length;
        }

        //Interface implementation

        public object Current { get { return _collection._collection[_index++]; } }

        public bool MoveNext() => (_index < _length) ? true : false;

        public void Reset() => _index = 0;
    }
}

public class GenConCollection : IEnumerable <int>
{
    private int[] _bucket = new int[] { 12, 23, 85 };

    //POI: There's an inverse relationship between explicit interface implementation & being public/private

    //Qry: Why is it private?
    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

    //Qry: Why doesn't this implementation need explicit interface name?
    public IEnumerator<int> GetEnumerator() => new Enumerator(this);

    private class Enumerator : IEnumerator<int>
    {
        private GenConCollection _collection;
        private int _length = 0;
        private int _index = 0;
        public Enumerator(GenConCollection collection)
        {
            _collection = collection;
            _length = _collection._bucket.Length;
        }

        public bool MoveNext() => (_index < _length) ? true : false;
        public void Reset() => _index = 0;
        public int Current { get { return _collection._bucket[_index++]; } }

        //Qry: How does this call determines whether it's a recursive call (!!) or a call to another property?
        object IEnumerator.Current { get { return Current; } }

        //POI: Dispose has to be public because resource will ne de-allocated by consumer of this class
        public void Dispose() { }
    }
}
