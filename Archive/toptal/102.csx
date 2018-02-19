
internal abstract class Animal
{
    // POI: abstract class can have a constructor
    // POI: This constructor can't be used initialize an instance
    public Animal()
    {

    }
    public void Foo() { }

    // POI: protected is allowed for abstract methods
    protected abstract void XFoo();

    // POI: abstract/virtual methods can't be private
    // abstract void YFoo();
}

internal class Dog : Animal
{
    // POI: Implementing abstract method means overridding that
    // POI: During overridding a method it's default access specifier can't be changed
    // POI: virtual methods can't be private (make sense)
    protected override void XFoo() { }
}

new Dog().Foo();

// POI: abstract class might not contain any abstract method
internal abstract class R
{
    // POI: This constructor will be invoked by both of the A & B instances
    public R()
    {
        WriteLine("R");
    }
}

internal class A : R
{
    // POI: Derived class may override this method
    public virtual void Foo()
    {
        WriteLine("A: Foo");
    }
}

internal class B : A
{
    public override void Foo()
    {
        WriteLine("B: Foo");
    }
}

A _a = new B();
_a.Foo();// B: Foo

_a = new A();
_a.Foo();// A: Foo

internal abstract class P
{
    // POI: Properties can be abstract
    protected abstract int X { get; set; }

    // POI: Properties can be virtual
    protected virtual int S { get; set; }

    // POI: abstract methods can not be static
    // protected static abstract void Foo();
}

internal abstract class X
{
    public abstract int Y { get; }

    public X()
    {

    }
}

internal abstract class Z : X
{
    // POI: As this class is itself abstract not implementing abstract members will be kept abstract
}

internal class K : Z
{
    public override int Y => 0;
}

internal interface IK
{

}

// POI: abstract class inheriting from other concrete class & interface
internal abstract class Ab : Dog, IK
{

}

// POI: abstract class inheriting from other abstract class & interface
internal abstract class Abc : Z, IK
{

}