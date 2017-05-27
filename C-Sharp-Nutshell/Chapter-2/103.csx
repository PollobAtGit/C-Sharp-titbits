
// --------------------------------- DEFAULT ELEMENT INITIALIZATION --------------------------------------------

//POI: Creating an Array pre-initializes (if the initial value is not given) the elements of the array with the
//default value which is the bitwise zero-ing of memory
Console.WriteLine(System.String.Join(", ", new System.Int32[5]));

Console.WriteLine(System.String.Join(", ", new System.Decimal[5]));

Console.WriteLine(System.String.Join(", ", new System.Double[5]));

//POI: string.Join() handles null string, doesn't invoke 'ToString()' directly. Because on 'null' another member can not be invoked
Console.WriteLine(System.String.Join(", ", new System.String[5]));//, , , ,

class Node { }

//POI: System.String.Join literally goes through each element & if the element is null, uses System.String.Empty
Console.WriteLine(System.String.Join<Node>(", ", new Node[5]));//, , , ,

Console.WriteLine((new Node[5]).Where(node => node != null).Count() == 0);//True
Console.WriteLine((new Node[5]).Where(node => node == null).Count() == 5);//True

struct NodeStruct { }

//TODO: Investigate the result
Console.WriteLine(System.String.Join<NodeStruct>(", ", new NodeStruct[5]));