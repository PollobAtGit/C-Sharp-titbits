
var v1 = new int[] {1, 2, 3};
var v2 = new int[] {3, 2, 1};
var v3 = new int[] {12, 0};

//POI: Linq provided Zip works on the same index on each sequence
var product = v1.Zip(v2, (a, b) => a * b);//3, 4, 3

//POI: If any of the sequence count is smaller than the other one than the resultent sequence will have count equal to the
//smaller sequence
var anotherProduct = v1.Zip(v3, (a, b) => a * b);//12, 0

//POI: string.Join can be used on T[] or on IEnumerable<T>. In both cases ToString() will be invoked
//POI: 1st argument to string.Join is the delimiter
Console.WriteLine(string.Join(", ", product));

Console.WriteLine(string.Join(", ", anotherProduct));
