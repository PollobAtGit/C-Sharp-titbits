
# .NET collections can be categorized into three types
    ## Standard protocols/interfaces
    ## Ready-to use collection class
    ## Base class to write application specific collections

# .NET collection namespaces:
    ## System.Collections
        ### ...
        ### Generic
        ### Specialized
        ### ObjectModel
        ### Concurrent

# Implementation hierarchy (not exact; in terms of granularity)
    ## IEnumerator
    ## IEnumerator<T>   => Also implements IDisposable
        ### IEnumerable
        ### IEnumerable<T>
            #### ICollection
            #### ICollection<T>
                ##### IList
                ##### IList<T>

                ##### IDictionary
                ##### IDictionary<T>

# IEnumerator interface

{code:C#}
    //IDisposable is not implemented for IEnumerator but for IEnumerator<T>
    public interface IEnumerator
    {
        bool MoveNext();
        void Reset();

        //Only getter is needed because the consumer of the IEnumerator class will access
        //only the value it doesn't need to SET it
        object Current { get; }
    }
{code}

# IEnumerable interface

{code:C#}
    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
{code}

# Generic IEnumerator<T>

{code:C#}
    public interface IEnumerator<T> : IEnumerator, IDisposable
    {
        T Current { get; } //IEnumerator returns 'object' instead of T
    }
{code}

# Generic IEnumerable<T>

{code:C#}
    //Both of IEnumerable<T> & IEnumerator<T> implements their non-generic version IEnumerable & IEnumerator
    public interface IEnumerable<T> : IEnumerable
    {
        IEnumerator<T> GetEnumerator();
    }
{code}

# Arrays implement IEnumerable<T>. But documentation doesn't show that because it's done on run time & it's more
    of a special knowledge of CLI. Source (search text: Starting with the .NET Framework 2.0) :
    https://msdn.microsoft.com/en-us/library/system.array.aspx

# Declaration of CharEnumerator. This class is defined in System namespace NOT IN System.Collections.Generic

{code:C#}
    public sealed class CharEnumerator : IEnumerator, IEnumerator<char>, IDisposable, ICloneable
    {
        .....
        .....
    } 
{code}