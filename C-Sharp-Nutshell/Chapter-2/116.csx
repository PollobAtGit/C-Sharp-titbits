var encodings = char.GetUnicodeCategory('A');

Console.WriteLine(encodings);

// POI: Every time invoked NewGuid will create a unique 16 byte GUID
Console.WriteLine(Guid.NewGuid());//16 Byte == 128 bit
Console.WriteLine(Guid.NewGuid().ToString());

var newGuid = Guid.NewGuid();
var guidByteArray = newGuid.ToByteArray();

// POI: Because Guid is 16 byte the byte array representation will take 16 byte elements each having 8 bit storage
Console.WriteLine(string.Join(" | ", guidByteArray));

// POI:We can create Guid from byte array which means (even though might not be desirable) from any byte array we can create a Guid
var oldGuid = new Guid(guidByteArray);

// POI: Guid is struct so during compilation it will do byte by byte comparison
Console.WriteLine(newGuid == oldGuid);

// POI: Following is theoretically correct but in case of GUID the byte array must have exactly 16 elements otherwise Argument Exception is thrown
try { Console.WriteLine(new Guid(new byte[] { })); } catch { }

Console.WriteLine(Guid.Parse("{0d57629c-7d6e-4847-97cb-9e2fc25083fe}"));
Console.WriteLine(new Guid("0d57629c-7d6e-4847-97cb-9e2fc25083fe"));

var emptyGuid = Guid.Empty;
Console.WriteLine(Guid.Empty == emptyGuid);

object x = 5;
object y = 5;

Console.WriteLine(x == y);//false

// POI: Becaue underlying type is int/Int32 which has overloaded the default object.Equal(...) so that byte by byte comparison is done
Console.WriteLine(x.Equals(y));//true

class B
{
    private int x;
    public B(int x) => this.x = x;
}

struct A
{
    private int x;

    // POI: Structs can contain reference types
    private readonly B y;

    // POI: This constructor declaration doesn't prevent invocation of the default constructor. This behavior is true for structs not for class
    // POI: Struct doesn't allow to have a constructor with 0 arguments
    // POI: Every struct member must be initialized in argument based constructor if there's any
    public A(int x, B b)
    {
        this.x = x;
        this.y = b;
    }
}

var oneBObj = new B(10);
object xStruct = new A(10, oneBObj);
object xxStruct = new A(10, oneBObj);
object yStruct = new A(5, new B(10));

Console.WriteLine(xStruct == yStruct);//false

// POI: object.Equal(...) is a virtual method which performs runtime comparison based on runtime object. In this case byte by byte comparison
// is performed (becaue underlying type is of value type) & xStruct is not equal to yStruct because they have different value for private
// variable 'x'
Console.WriteLine(xStruct.Equals(yStruct));//false

Console.WriteLine(xStruct == xxStruct);//false

// POI: Equals using reflection goes through all the properties of a struct (value type) & continuously invokes Equals on those types that's why
// invoking Equals on both xStruct & xxStruct forces invocation of object.Equals(...) which returns true for property 'y' because for these
// two instances they refer to the same instance of B causing referencial equality to be true

// POI: xxStruct has same value as xStruct for private member 'x'
Console.WriteLine(xStruct.Equals(xxStruct));//true

Console.WriteLine("-".PadLeft(50, '-'));

object bStruct = new B(10);
object bbStruct = new B(10);

Console.WriteLine(bStruct == bbStruct);//false

// POI: For any value type this would be true for this example because byte by byte comparison will yield true. But here it's false the underlying
// content's type is a reference type so that content's Equal(...) is being invoked & in this case that happens to be object.Equal(...) which
// by default does Reference Equality
Console.WriteLine(bStruct.Equals(bbStruct));//false
