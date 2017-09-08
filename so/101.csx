
var numRollDices = 10;
var randomGenerator = new Random();

// POI: We can make Look up from Dictionary
var result = Enumerable
                .Range(0, numRollDices)
                .Select(i => randomGenerator.Next(1, 7))
                .GroupBy(n => n)
                .Select(n => new
                            {
                                Num = n.First(),

                                // POI: Using aggregate function over grouped by list
                                Count = n.Count(),
                                Percentile = ((n.Count() * 100) / numRollDices)
                            });

Console.WriteLine(string.Join($"{Environment.NewLine}", result.ToList()));
