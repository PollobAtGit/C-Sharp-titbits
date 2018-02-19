
var num = new int[] { 20, 15, 31, 34, 35, 40, 50, 90, 99, 100 };

IEnumerable<KeyValuePair<int, double>> dictionary = num

                                                    //POI: ToLookup<TKey, TElement> vs Dictionary<TKey, TValue>: In Dictionary for each Key there is only one Value (1 : 1 mapping)
                                                    // In Lookup<TKey, TElement> TElement is a List (from usability perspective)
                                                    //POI: ToLookup receives 2 arguments. Both are Func<TSource, TKey>. So for both lambda is used
                                                    .ToLookup(k => k, k => num.Where(n => n < k))
                                                    
                                                    //POI: To find percentile first multiply the number by 100 than divide that by the number of elements
                                                    //POI: ToLookup contains a List as value which is an IGrouping<TKey, TElement>. So the value is the list itself. No property to get
                                                    //the value is required
                                                    //POI: KeyValuePair contains Key & Value properties but both of them are read-only properties. So constructor is the only way to provide
                                                    //values
                                                    .Select(k => new KeyValuePair<int, double>(k.Key, (double)((100 * k.First().Count()) / num.Length)));

//POI: OrderBy & OrderByDescending both takes one argument of 'Func<TSource, TKey>'
IOrderedEnumerable<int> _rank = num.Distinct<int>().OrderByDescending<int, int>(k => k);

//POI: OrderBy & OrderByDescending returns IOrderedEnumerable<TSource> which some-how (!) maintains the sorted elements with their relative sort index (starting from 0)
//POI: IOrderedEnumerable<TSource> doesn't maintain the index (i). It is done by Select overload
var rank = _rank.Select<int, KeyValuePair<int, int>>((k, i) => new KeyValuePair<int, int>(k, i + 1));

foreach (var group in dictionary) Console.WriteLine(group.Key + " => " + group.Value);

Console.WriteLine();

foreach (var group in rank) Console.WriteLine(group.Key + " => " + group.Value);

Console.WriteLine();

//POI: Index on Select is solely facility given by Select
Console.WriteLine(string.Join(", ", num.Select<int, string>((k, i) => k.ToString() + " => " + (i + 1).ToString())));
