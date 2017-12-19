
object xObj = null;
object yObj = 5;

// POI: Passing null to staitc Equals is not a problem
Console.WriteLine(object.Equals(xObj, yObj));//false

// POI: Interesting. Both null returns null
Console.WriteLine(object.Equals(null, null));//true

// POI: Following throws exception because xObj is null. So static Object.Equals is a better approach
// Console.WriteLine(xObj.Equals(yObj));

class Generic<T>
{
    private T oldValue;

    public void SetValue(T newValue)
    {
        // POI: Equality operator can not be used with generic types because operator overloaded method for == can not be bound during compile time
        // POI: Using static object.Equals ensures that getting null value will not cause any problem
        // POI: Equals is a virtual method. Using that ensures that during comparison the underlying boxed type's (original type) Equal will be invoked

        if (!object.Equals(oldValue, newValue))
            oldValue = newValue;
    }
}

Console.WriteLine(object.ReferenceEquals(null, null));//null
Console.WriteLine(object.ReferenceEquals(new object(), new object()));//false

var newGuid = Guid.NewGuid();
var newStringBuilder = new StringBuilder();
var currentDateTime = DateTime.Now;
var x = 5;

// POI: Referencial Equality only works for reference types (NOT for structs)
Console.WriteLine(object.ReferenceEquals(newGuid, newGuid));//false
Console.WriteLine(object.ReferenceEquals(currentDateTime, currentDateTime));//false

// POI: Int32 is a struct. So referencial equality works differently
Console.WriteLine(object.ReferenceEquals(x, x));//false

Console.WriteLine(object.ReferenceEquals(newStringBuilder, newStringBuilder));//true
Console.WriteLine(object.ReferenceEquals(newStringBuilder, new StringBuilder()));//false

// POI: By default object's static overloaded operator (==) performs Referencial Equality check
