int[] nums = { 20, 15, 31, 34, 35, 40, 50, 90, 99, 100 };

// POI: Problem with dictionary. Multiple students can't have same marks
var dic = nums
            .ToDictionary(n => n, p => (nums.Where(x => x < p).Count() * 100) / nums.Count());

foreach(var pair in dic)
{
    Console.WriteLine($"Key : {pair.Key}; Value : {pair.Value}");
}

Console.WriteLine();

// POI: ToList() on Dictionary returns List<KeyValuePair<T, U>>
var sortedDic = dic.ToList();

// POI: List.Sort(...) doesn't return any value it changes the original list
sortedDic.Sort((pairOne, pairTwo) => pairOne.Value.CompareTo(pairTwo.Value) * -1);

foreach(var obj in sortedDic.Select((pair, i) => new { Num = pair.Key, Rank = i + 1 }))
{
    Console.WriteLine($"Number : {obj.Num}; Rank : {obj.Rank}");
}

