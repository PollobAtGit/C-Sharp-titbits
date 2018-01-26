using System.Linq;
using System.Collections.Generic;

Action<object> cl = (object x) => Console.WriteLine(x);

var originalEvens = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

int[] GetFirstTenEvenNums()
{
	return originalEvens;
}

int[] GetAnotherCopyOfEvens()
{
	// POI: This array copying ensures client can mess around with the contents with the 
	// array still the entity which contains this method will not be affected

	// POI: Make fresh copy of the sequence everytime, if the sequence needs to be returned
	return originalEvens.ToArray();
}

IEnumerable<int> GetIterator()
{
	return originalEvens as IEnumerable<int>;
}

var evens = GetFirstTenEvenNums();

cl(string.Join(", ", evens));

// POI: Because the method returned an array we are able to change value of a variable by
// index
// POI: Original array is also being affected because of this change
evens[1] = 3;

cl(string.Join(", ", evens));// 2, 3, 6, 8, 10, 12, 14, 16, 18, 20
cl(string.Join(", ", originalEvens));// 2, 3, 6, 8, 10, 12, 14, 16, 18, 20

var copyOfEvens = GetAnotherCopyOfEvens();

copyOfEvens[1] = 5;

cl(string.Join(", ", copyOfEvens));// 2, 5, 6, 8, 10, 12, 14, 16, 18, 20
cl(string.Join(", ", originalEvens));// 2, 3, 6, 8, 10, 12, 14, 16, 18, 20

var itr = GetIterator();
var itrCasted = GetIterator().ToArray();

// POI: GetType() returns the runtime Type (original) rather than the compile time Type
cl(itr.GetType());// System.Int32[]
cl(itrCasted.GetType());// System.Int32[]

// POI: typeof can be applied on Type(s) only not on any instance of a Type
// cl(typeof(itr));
// cl(typeof(itrCasted));

cl(typeof(IEnumerable<int>));// System.Collections.Generic.IEnumerable`1[System.Int32]
cl(typeof(int[]));// System.Int32[]

itrCasted[0] = 99;

cl(string.Join(", ", itr));
cl(string.Join(", ", itrCasted));
cl(string.Join(", ", originalEvens));

