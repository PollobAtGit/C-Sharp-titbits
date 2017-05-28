
// --------------------------------- DEFAULT ELEMENT INITIALIZATION --------------------------------------------

//POI: Creating an Array pre-initializes (if the initial value is not given) the elements of the array with the
//default value which is the bitwise zero-ing of memory
Console.WriteLine(System.String.Join(", ", new System.Int32[5]));

Console.WriteLine(System.String.Join(", ", new System.Decimal[5]));

Console.WriteLine(System.String.Join(", ", new System.Double[5]));

//POI: string.Join() handles null string, doesn't invoke 'ToString()' directly. Because on 'null' another member can not be invoked
Console.WriteLine(System.String.Join(", ", new System.String[5]));//, , , ,

class Node
{
    public Node NodeInstance { get; set; }
}

//POI: System.String.Join literally goes through each element & if the element is null, uses System.String.Empty
Console.WriteLine(System.String.Join<Node>(", ", new Node[5]));//, , , ,

Console.WriteLine((new Node[5]).Where(node => node != null).Count() == 0);//True
Console.WriteLine((new Node[5]).Where(node => node == null).Count() == 5);//True

struct NodeStruct
{
    public System.Int32 X { get; set; }
    public Node Y { get; set; }
    public System.Int32[] IntSequence { get; set; }
    public System.String NodeLabel { get; set; }

    //POI: Struct can't take an instance of the same type (!) In that case, can struct be used to create Nodes for a Tree?
    //POI: Reason may be that during compile time all instance properties have to be initialized
    //public NodeStruct StructInstance { get; set; }

    public override System.String ToString() => "STRUCT ";
}

//TODO: Structs are value type not reference type. So none of the instances are 'null' thus ToString() method on the instance will be invoked
Console.WriteLine(System.String.Join<NodeStruct>(", ", new NodeStruct[5]));

//POI: NodeStruct is a struct which is a value type. No comparison can be done on value type for 'null'
//Console.WriteLine((new NodeStruct[5]).Where(node => node == null).Count());

//POI: NodeStruct is a struct which is a value type. No comparison can be done on value type for 'null'
//Console.WriteLine((new NodeStruct[5]).Where(node => node != null).Count());

//POI: Instance property is initialized to default value
Console.WriteLine((new NodeStruct()).X);//0
Console.WriteLine((new NodeStruct()).Y == null);//True
Console.WriteLine((new NodeStruct()).IntSequence == null);//True
Console.WriteLine((new NodeStruct()).NodeLabel == null);//True

Console.WriteLine((new Node[5])[1] == null);//True

//POI: RTE because Node instance's are set to 'null'
//Console.WriteLine((new Node[5])[1].NodeInstance);

// --------------------------------- INITIALIZE REFERENCE TYPE ARRAY ELEMENTS --------------------------------------------

var nodes = new Node[5];
Console.WriteLine(nodes.Where(node => node == null).Count());//5

//POI: Following is not valid because 'foreach' does NOT allow iteration elements to be changed. Using 'new' CHANGES the element's state
//foreach(var node in nodes) node = new Node();

//POI: Following appears to work properly because it doesn't throw any RT or CT Exception but actually the array elements are NOT
//being initialized
nodes.ToList().ForEach(node => node = new Node());
Console.WriteLine(nodes.Where(node => node == null).Count());//5

for(var i = 0; i < nodes.Length; i++) nodes[i] = new Node();
Console.WriteLine(nodes.Where(node => node == null).Count());//0

// --------------------------------- ARRAYS ARE REFERENCE TYPES --------------------------------------------

//POI: Arrays are reference types & reference types can hold 'null' values
System.Int32[] intSequence = null;
Console.WriteLine(intSequence == null);//True

class AnotherNode
{
    //POI: By default this array (sequence) will be initilaized to null
    public System.Int32[] IntSequence { get; set; }
}

Console.WriteLine((new AnotherNode()).IntSequence == null);//True

struct AnotherStructNode
{
    //POI: By default also for struct Array instance will be initialized to 'null'
    public System.Int32[] IntSequence { get; set; }
}

Console.WriteLine((new AnotherStructNode()).IntSequence == null);//True

// --------------------------------- MULTI-DIMENSIONAL ARRAY --------------------------------------------

var multiDimensionalIntSequence = new System.Int32[5, 5];

//POI: Difference between one dimensional & multi-dimensional array declaration is on each side ',' has to be used inside bracket
System.Int32[,] anotherMultiDimensionalIntSequence = new System.Int32[5, 5];
System.String[,] multiDimensionalStringArray = new System.String[10, 9];
System.Double[,] multiDimensionalDoubleArray = null;

//POI: null will be assigned automatically
System.Decimal[,] multiDimensionalDecimalArray;

//POI: Total length of multi-dimensional array is (x * y)
Console.WriteLine(multiDimensionalIntSequence.Length);//25
Console.WriteLine(anotherMultiDimensionalIntSequence.Length);//25
Console.WriteLine(multiDimensionalStringArray.Length);//90

Console.WriteLine(multiDimensionalDoubleArray == null);
Console.WriteLine(multiDimensionalDecimalArray == null);//True

//POI: For shortcut initializer '[]' needs to be mentioned to indicate array
var anArray = new int[] { 20, 30 };
var rectangleArray = new System.Int32[,]
{
    { 1, 2 },
    { 3 , 5 },
    { 7 , 10 },
    { 11, 10 }
};

var aTwoByThreeMatrix = new int[,]
{
    {2, 5, 69},
    {89, 78, 60}
};

Console.WriteLine(rectangleArray.Length);//8

//POI: GetLength operates on dimension (!). Dimension '0' indicates 'row' & '1' indicates 'column' (!!) (Research more)
Console.WriteLine(rectangleArray.GetLength(0));//4
Console.WriteLine(rectangleArray.GetLength(1));//2

// --------------------------------- PRINT ALL FROM MULTI-DIMENSIONAL ARRAY --------------------------------------------

Console.WriteLine();
for(var i = 0; i < rectangleArray.GetLength(0); i++)
{
    List<System.Int32> ints = new List<System.Int32>();

    //POI: To access a individual cell in a multi-dimensional array use the indices & those indices should be separated by comma (,)
    for(var j = 0; j < rectangleArray.GetLength(1); j++) ints.Add(rectangleArray[i, j]);

    Console.WriteLine(System.String.Join(", ", ints));
}

Console.WriteLine(rectangleArray[0, 1]);//2
Console.WriteLine(rectangleArray[3, 1]);//10
