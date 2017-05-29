
// --------------------------------- JAGGED ARRAY --------------------------------------------

//POI: First dimension of a jagged array has to be defined
//POI: When declaring jagged array '[Dim_0, Dim_1]' notation can not be used. It has to be like '[][]'
var jaggedMatrix = new int[3][];

//TODO: Why? For multi-dimensional array length is (x * y). Considering that scenario, length should be 0. Is the length calculation is a hack?
Console.WriteLine(jaggedMatrix.Length);//3

//POI: In jagged array, first dimension is defined. GetLength(0) will return proper number of rows even though using 'Length' is fine (but cnonfusing)
Console.WriteLine(jaggedMatrix.GetLength(0));

//POI: All rows are defined but none of those rows have any array associated with it
Console.WriteLine(jaggedMatrix[0] == null);//True
Console.WriteLine(jaggedMatrix[1] == null);//True
Console.WriteLine(jaggedMatrix[2] == null);//True

//POI: Row '0' is defined but NOT any array associated with it
//Console.WriteLine(jaggedMatrix[0][0]);//RTE

for(var i = 0; i < jaggedMatrix.GetLength(0); i++)
{
    if(jaggedMatrix[i] == null)
        //POI: Initializing array for each row
        jaggedMatrix[i] = new int[i + 1];
}

//TODO: Why?
Console.WriteLine(jaggedMatrix.Length);//3

var totalLength = 0;
for(var i = 0; i < jaggedMatrix.GetLength(0); i++)
{
    //POI: Every array associated with each row has a Length property because they are normal array
    totalLength += jaggedMatrix[i].Length;
}

//TODO: Is there any other better way to get the total length of an jagged array?
Console.WriteLine(totalLength);//6

//POI: An array with zero length is acceptable
int[] noLengthArray = new int[0];

//POI: Compilation error
//int[] negativeLengthArray = new int[-10];

Console.WriteLine(noLengthArray.Length);//0

//POI: An array with zero length can be declared but while accessing 0th index, it will throw exception because actually that array has no length
//Console.WriteLine(noLengthArray[0]);//RTE
