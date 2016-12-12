
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

# IEnumerator<T> implements IDisposable as such

{code:C#}
    public interface IEnumerator<T> : IEnumerable, IDisposable
    {
        T Current { get; };
    }
{code}

Which means C# 'foreach' statement wraps the following statement with another 'using' statement that is responsible
to free the resource

foreach(int value in ints.GetEnumerator()){ }

Is translated into

using(IEnumerator enumerator = ints.GetEnumerator())
{
    while(enumerator.MoveNext())
    {
        //enumerator.Current;
    }
}

# Implementing IEnumerator<T>, IEnumerator, IEnumerable & IEnumerable<T> might be needed for a custom collection
for various reasons but mainly for the following four reasons:
    ## To allow the collection to be used in foreach statement
    ## To be interoperable with anything that expects a standard collection
    ## To support collection initializers

# Main idea behind implementing IEnumerable, IEnumerable<T>, IEnumerator & IEnumerator<T> is to provide the enumerator
which can be done in any of the following ways
    ## If there is an underlying collection in use then return that collections enumerator
    ## Whatever the implementation is provide an iterator via keyword 'yield'
    ## Implement the collection's own Enumerator

# ITERATOR can be returned using 'yield'

# Compiler creates private class when a method, property or indexer uses yield to return a ITERATOR. That class
will return the IEnumerator