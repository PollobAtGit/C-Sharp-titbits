
// var arr = new int[] {1, 2, 3, 4};
var arr = new int[] {10, -20, 5, 7};

var iKeyValues = arr.Select((n, i) => new KeyValuePair<int, int>(n, arr.Take(i + 1).Sum()));

foreach(var i in iKeyValues)
{
    Console.WriteLine(i.Key + " => " + i.Value);
}
