
//POI: A class must be abstract if it contains one or more abstract members because there will be an inconsistency if that
//class is instantiated & that object invokes the abstract method

//POI: Abstract methods are middle ground between interface & usual class. It can't be instantiated also some members can
//have implementation
internal abstract class ShapeClass
{
    //POI: This method must be overridden in derived class unless that class is not abstract itself
    public abstract void Draw();

    //POI: Non-abstract property in a abstract class
    public int Count { get; set; }

    //POI: Abstract property. Derived class (unless abstract itself) must provide implementation for this property's
    //set & get accessor
    public abstract int X { get; set; }

    //POI: Unlike properties indexers must have a get/set body. Because implicit property declaration is not supported for
    //indexers
    public int this[string key]
    {
        get
        {
            return 0;
        }
    }

    //POI: Indexers don't have any names. So 'this' is used to resolve ambiguity. On that case, to have multiple indexers
    //in a class the only option to overload indexers is to vary the arguments (key in this case).
    //POI: To resolve ambiguity between indexers method overloading mechanism is used
    //POI: Non-abstract member in a abstract class that has implementation. This is the advantage of using abstract class
    //over Interface
    public int this[object key]
    {
        get
        {
            return 0;
        }
    }

    //POI: Indexers can be abstract. Similar to property, only the accessors are mentioned in the indexer that the derived
    //class must implement
    public abstract int this[int x, int y] { get; }

    //POI: non-abstract member in a abstract class
    public void DawBorder() { }
}

internal class Square : ShapeClass
{
    //POI: When implementing abstract method 'override' must be used as a marker for compiler
    //POI: Overriding member must not change the default access modifier. In this case Draw must be 'public' not
    //private/internal/protected
    //POI: During designing an abstract class setting the access modifier is a concern because that can't be changed in a
    //derived class
    public override void Draw() { }

    private int x = 0;

    //POI: To implement abstract property, 'override' is also needed to be used (properties are implemented as methods)
    //POI: The abstract property had get & set both accessors. So the intention was the derived must provide implementation
    //for both of the accessors
    public override int X
    {
        get
        {
            return 0;
        }
        set
        {
            x = value;
        }
    }

    //POI: Indexers are essentially properties. So similar to properties, indexers must use 'override' marker when prividing
    //implementation to a indexer
    public override int this[int x, int y]
    {
        get
        {
            return 0;
        }
    }
}
