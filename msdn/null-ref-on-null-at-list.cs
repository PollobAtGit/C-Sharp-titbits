using System;
using System.Collections.Generic;

class T
{
    public static void Main()
    {
        // POI: Not initializing any placeholder at all
        var l = new List<T>();

        l.Add(new T());
        l.Add(null);

        // POI: NullReferenceException for 2nd element because that's explicitly null
        l.ForEach(x => Console.WriteLine(x.ToString()));
    }

    public override string ToString() => "T";
}

