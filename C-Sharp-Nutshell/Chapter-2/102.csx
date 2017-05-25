
// -------------------------------------------- C# Array -----------------------------------------------------

char ch = '0';

Console.WriteLine(ch);

//POI: Like 'string' type 'char' is also defined in System namespace
Console.WriteLine(ch.GetType());//System.Char

System.Char[] characters = new System.Char[] { 'a', 'b', 'c' };
System.Char[] chars = { 'A', 'B', 'C' };

//POI: Characters are appended after each other to form a System.String
Console.WriteLine(characters);

//POI: Characters are appended after each other to form a System.String
Console.WriteLine(chars);

//POI: Because by default using System.Char[] creates a System.String, it can be directly assigned to a String variable (Useful feature)
var dummyStr = characters;
var anotherDummyStr = chars;

Console.WriteLine(dummyStr);
Console.WriteLine(anotherDummyStr);

//POI: Invoking ToString() on System.Char[] shows the Type which is 'System.Char[]'
//POI: ToString() of System.Char[] is NOT overridden then. May be this is a feature directly incorporated into CLR
Console.WriteLine(characters.ToString());//System.Char[]
Console.WriteLine(characters.GetType());//System.Char[]

//POI: Following is a shorthand to declare Array
int[] intSequence = { 1, 2, 3 };

//POI: Unlike 'System.Char[]', 'System.Int32[]' doesn't append the elements after each other. So only 'Type' is being shown
Console.WriteLine(intSequence);//System.Int32[]

//POI: System.String.Join automatically invokes ToString() on each Int32 element
Console.WriteLine(System.String.Join(", ", intSequence));//1, 2, 3

System.String[] strSequence = { "1", "2", "3" };

//POI: Unlike 'System.Char[]' & like 'System.Int32[]', System.String[] doesn't append the elements after each other too
//POI: The square bracket ([]) shown indicates the instance is an array of the given Type. It is not associated with the Type
Console.WriteLine(strSequence);//System.String[]

class Node
{
    private static System.Int32 _instanceCount { get; set; }

    public Node()
    {
        _instanceCount++;
    }

    public override string ToString() => "Instance : " + _instanceCount;
}

//POI: Square bracket ([]) indicates the instance is an array of type 'Node'
Console.WriteLine(new Node[5].GetType());//Submission#0+Node[]

var nodes = new Node[] { new Node(), new Node(), new Node() };

//POI: System.String.Join can be used on any array/enumerable/collection that has ToString() method, because that's what ...Join invokes
//POI: Technically, all objects in .NET has ToString() method because that is inherited from Object class. So for custom Type, we need to
//override the ToString() method
Console.WriteLine(System.String.Join<Node>(", ", nodes));//Instance : 3, Instance : 3, Instance : 3
