
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

foreach (var group in dictionary) Console.WriteLine(group.Key + " => " + group.Value);

