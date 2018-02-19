
//POI: Weighted sum is the Weight multiplied by value & it's sum

var marks = new int[] { 1, 2, 3 };
var credits = new int[] { 3, 2, 1 };

//POI: Resultant sequence from Zip will contain lowest number of elements among the two sequences
//POI: Sum will work on a sequence of numbers but to make it work with custom type we can use the overloads that takes a delegate (example: Func<TSource, Decimal>) for the custom type
Console.WriteLine(marks.Zip(credits, (mark, weight) => mark * weight).Sum());//10
