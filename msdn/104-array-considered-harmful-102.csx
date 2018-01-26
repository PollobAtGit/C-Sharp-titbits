using System.Linq;

Action<object> cl = (object x) => Console.WriteLine(x);
Action<IEnumerable<int>> cli = (IEnumerable<int> l) => 
{
	if(l == null)
	{
		cl("NULL");
	} 
	else
	{
		cl(string.Join(", ", l));
	}
};

int[] evens = new int[] { 2, 4, 6 };

int[] GetEvens() => evens;

IEnumerable<int> IGetEvens() => evens;

cl(string.Join(", ", GetEvens()));// 2, 4, 6

var aEvens = GetEvens();

cli(aEvens);// 2, 4, 6

aEvens[1] = 3;
aEvens = null;

cli(aEvens);// NULL
cli(evens);// 2, 3, 6

var itr = IGetEvens();

cli(itr);// 2, 3, 6
itr = null;
cli(itr);// NULL
cli(evens);// 2, 3, 6


/* Writing readonly class from client */

class IR
{
	// POI: Readonly members are not writable from client not also from inside the class
	// unless it's in constructor or when variables are being initialized
	// This behavior is consistant with const variables

	public static readonly int Sum = 20;

	// POI: const members are essentially static members
	// POI: const members must have values that can be calculated in compile time
	public const int CSum = 3;
	public static int ASum = 100;// static members are obviously writable
}

cl(IR.Sum);// 20
cl(IR.ASum);// 100
cl(IR.CSum);// 3

// POI: Readonly & const variables can't be assigned anywhere (including client) 
// except constructor or variable initializer
// IR.Sum = 10;
// IR.CSum = 200;

IR.ASum = 20;
cl(IR.ASum);// 20

