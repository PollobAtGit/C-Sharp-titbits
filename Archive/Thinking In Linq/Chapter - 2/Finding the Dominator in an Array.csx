
// RM: Dominator in an array is the element that's occurence is more than 50% in the array

var array = new int[] { 3, 4, 3, 2, 3, -1, 3, 3 };
var arrayOne = new int[] { 56, -89, 50, 56, 56 };


// POI: First(...) can contain Where condition

// RM: Whenever we need to use LINQ Where & First on after another we can make the statement more readable & efficient
// by putting the 'Where' condition inside First

// POI: Every ILookup<TKey, TSource> returns a IGrouping<TKey, TElement> which contains a property 'Key'. To access Value
// for each Key directly operate on the instance

// POI: Every IDictionary<TKey, TSource> element returns a KeyValuePair<TKey, TElement> which contains
// properties 'Key' & 'Value'

// RM: First(...) throws Exception if there is no element to grab. Better approach is to invoke FirstOrDefault(...)

var query = array.ToLookup(el => el).First(arr => arr.Count() > array.Count() / 2);
var queryOne = arrayOne.ToLookup(el => el).FirstOrDefault(arr => arr.Count() > arrayOne.Length / 2);

Console.WriteLine(query.Key + " exists " + query.Count() + " times");
Console.WriteLine(queryOne.Key + " exists " + queryOne.Count() + " times");
