var arr = new int [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10} ;
var windowSize = 2;

// POI: Take doesn't throw exception if required number of elements (to be taken) are not present
var movingAverage = Enumerable.Range(0, arr.Count() - windowSize + 1).Select(i => arr.Skip(i).Take(windowSize).Average()).ToList();

Console.WriteLine();

// POI: ForEach is defined only for List<TModel>
movingAverage.ForEach(i => Console.WriteLine(i));

Console.WriteLine();

Console.WriteLine(movingAverage.Average());
Console.WriteLine(movingAverage.Sum());
Console.WriteLine(movingAverage.Count());
