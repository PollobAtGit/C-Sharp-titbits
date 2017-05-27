
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
