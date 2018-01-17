
interface IRepository
{
    int RetValue();
}

interface IUnitOfWork
{
    int RetValue();
}

interface ICrazy
{
    int RetValue();
}

// POI: Only implementation of the method RetValue is enough to satisfy implementation condition for both IRepository & IUnitOfWork
sealed class Implementation : IRepository, IUnitOfWork
{
    // POI: Explicitly implemented method ha no conflict with a general method with same signature

    public int RetValue() => 10;

    // POI: Multiple explicitly implemented methods work as proper overloads

    // POI: Explicitly implemented methods are not private or protected but public by default but that's not required to be mentioned in source code
    int IRepository.RetValue() => 50;

    // POI: Explicitly implemented methods are public by default
    int IUnitOfWork.RetValue() => 150;

    // POI: Proper overload of RetValue() because it's generic
    public int RetValue<T>() => 100;

    // POI: Proper overload of RetValue() & RetValue<T>()
    public int RetValue<T, U>() => 200;
}

Console.WriteLine(new Implementation().RetValue());// 10
Console.WriteLine(new Implementation().RetValue<DateTime>());// 100
Console.WriteLine(new Implementation().RetValue<Type, Action>());// 200

Console.WriteLine((new Implementation() as IRepository).RetValue());// 50
Console.WriteLine((new Implementation() as IUnitOfWork).RetValue());// 150

sealed class AnotherImplementation : IRepository, IUnitOfWork
{
    // POI: Single public implementation for the method means the method can be invoked with reference casted to IRepository or IUnitOfWork or without any cast
    public int RetValue() => 1233;
}

Console.WriteLine();
Console.WriteLine((new AnotherImplementation() as IRepository).RetValue());// 1233
Console.WriteLine((new AnotherImplementation() as IUnitOfWork).RetValue());// 1233

// POI: A public method implementation might work for multiple interfaces if they require the method to be implemented but that's not true for explicit 
// interface implementation. Either individual methods should be implemented for each interface or some explicit implementation but at least one public method
// implementation must be provided

sealed class OneImplementation : IRepository, IUnitOfWork, ICrazy
{
    // POI: Will satisfy implementation requirement for IRepository & ICrazy
    public int RetValue() => 999;

    int IUnitOfWork.RetValue() => 888;
}

Console.WriteLine();
Console.WriteLine(new OneImplementation().RetValue());// 999
Console.WriteLine((new OneImplementation() as IRepository).RetValue());// 999
Console.WriteLine((new OneImplementation() as ICrazy).RetValue());// 999
Console.WriteLine((new OneImplementation() as IUnitOfWork).RetValue());// 888

// POI: Abstract can keep the method abstract that requires implementation
abstract class AbstractRepository : IRepository, ICrazy, IUnitOfWork
{
    // POI: Might work as the implementation for both IRepository & ICrazy if IRepository & ICrazy were not explicitly implemented
    // POI: Working as the implementation for IUnitOfWork
    public abstract int RetValue();

    int IRepository.RetValue() => 10;
    int ICrazy.RetValue() => 200;
}

sealed class AbstractImplementation : AbstractRepository
{
    // POI: override is required for abstract & virtual method (re)implmentation
    public override int RetValue() => 150;
}

Console.WriteLine();
Console.WriteLine(new AbstractImplementation().RetValue());// 150
Console.WriteLine((new AbstractImplementation() as IRepository).RetValue());// 10
Console.WriteLine((new AbstractImplementation() as ICrazy).RetValue());// 200
Console.WriteLine((new AbstractImplementation() as IUnitOfWork).RetValue());// 150

interface IEmployee
{
    string Name { get; set; }

    int Counter { get; }
}

interface IE
{
    string Name { get; }

    // POI: Ensures implementer must have a field that will be set using this setter
    int Counter { set; }
}

internal sealed class Employee : IEmployee, IE
{
    public string Name { get; set; }
    public int Counter { get; set; }
}

internal sealed class EmployeeOne : IEmployee, IE
{
    private int _counter = 10;
    string IEmployee.Name { get; set; }
    int IEmployee.Counter { get; }

    string IE.Name { get; }
    int IE.Counter { set { _counter = value; } }
}

var e = new EmployeeOne();

Console.WriteLine();
Console.WriteLine((e as IE).Name);// Empty
Console.WriteLine((e as IEmployee).Counter);// 0

internal sealed class EmployeeO
{
    // POI: Auto implemented property can have only getter which makes sense because may be that's 
    // hiding some other field value
    // POI: Having only the getter doen't add any value if ther's no underlying value

    public int PropOne { get; }

    // POI: Auto implemented property can not have only setter which makes sense because it's like
    // we can set the value but can't get the value
    // POI: Only setter property must have a backed up field

    // public int PropTwo { set; }

    private int _propTwo = 10;
    public int PropTwo { set { _propTwo = value; } }
}

internal class Running : IRepository
{
    int IRepository.RetValue() => 569;
}

// POI: Compilation error because Running doesn't contain a definition for RetValue rather the RetValue that exists in Running is implemented
// for IRepository. So that method is bound with IRepository not with the class instance
// Console.WriteLine(new Running().RetValue());


// POI: It's not required to implement RetValue for IRepository because base class contains a definition for RetValue which is for IRepository
// and also that method seems to work as protected

// May be it's better not to compare explicit interface implementation with access specifiers!
internal sealed class SRunning : Running, ICrazy, IRepository
{
    // POI: Base class implementation is for IRepository not for ICrazy
    int ICrazy.RetValue() => 56908;
}

// POI: RetValue seems like protected for IRepository (!!!) (though it's accessible publicly when instance of SRunning is casted into
// IRepository) in Running class in terms of inheritence. So in SRunning class no definition for RetValue exists
// Console.WriteLine(new SRunning().RetValue());

interface ICombined : IRepository, ICrazy, IUnitOfWork
{
    void Do();
}

// POI: ICombined merges all interfaces so the implementer of ICombined must implement those methods implicitly or explicitly
internal sealed class CombinedImplementation : ICombined
{
    int IRepository.RetValue() => 10;

    int ICrazy.RetValue() => 56;

    int IUnitOfWork.RetValue() => 456;

    void ICombined.Do() { }
}
