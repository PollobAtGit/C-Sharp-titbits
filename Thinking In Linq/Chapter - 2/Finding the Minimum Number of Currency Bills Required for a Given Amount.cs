
class Result
{
    public int Currency { get; set; }
    public int WholeNote { get; set; }

    public override string ToString() => $"Current {Currency} * {WholeNote} notes = {Currency * WholeNote}";
}

int[] currency = { 500, 100, 50, 20, 10, 5, 2, 1 };
int amount = int.Parse(Console.ReadLine());

var minimum = currency
                .Select((n, i) => {
                                        var result = new Result { Currency = n, WholeNote = amount / n };
                                        amount = amount % n;
                                        return result;
                                    });

foreach (var item in minimum.Where(s => s.WholeNote != 0))
{
    Console.WriteLine(item);
}
