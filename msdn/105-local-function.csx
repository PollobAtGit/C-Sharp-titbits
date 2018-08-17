class T
{
    public IEnumerable<int> Iterable(int n)
    {
        // This function is an iterable

        if (n < 0)
            throw new Exception();

        foreach(var x in Enumerable.Range(n, 10))
        {
            yield return x;
        }
    }

    public IEnumerable<int> IterableLocalMethod(int n)
    {
        // This function is not an iterable by definition and that's because the local function is actually the iterable

        if (n < 0)
            throw new Exception();

        // acessed before referencing
        return LocalIterable();

        // local methods are static by default
        IEnumerable<int> LocalIterable()
        {
            // closure. n is declared in outer scope not in local scope
            foreach(var x in Enumerable.Range(n, 10))
            {
                yield return x;
            }
        }
    }
}


var t = new T();
var iterable = t.Iterable(10);

foreach(var x in iterable)
{
    Console.WriteLine(x);
}


// doesn't throw exception because Iterable hasn't been executed
iterable = t.Iterable(-1);

foreach(var x in t.IterableLocalMethod(10))
    Console.WriteLine(x);

try
{
    t.IterableLocalMethod(-1);
}
catch(Exception)
{
    Console.WriteLine("Error occurred");
}


