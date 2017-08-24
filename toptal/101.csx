
using System.Threading;

public sealed class Circle
{
    // POI: This variable is not exposed to client
    private double _radius = 10;

    public double Calculate(Func<double, double> operation) => operation(_radius);

}

WriteLine(new Circle().Calculate(v => 2 * Math.PI * v));//62....

// POI: Essentially retriving the private value
WriteLine(new Circle().Calculate(v => v));// 10

class Program
{
    private static string _result;

    public void Main()
    {
        // Do();
        // XDo();
        YDo();
        WriteLine(_result);

        // POI: Foreground thread
        WriteLine(new Thread(XDo).IsBackground);

        // POI: Valid Action
        Action del = () => { };
    }



    private async Task<string> Do()
    {
        // POI: Task creates background thread contrary to Thread
        await Task.Delay(5);
        _result = "Some";
        return null;
    }

    private void XDo()
    {
        // POI: Thread.Sleep sleeps the current thread
        Thread.Sleep(50);
        _result = "Some";
    }

    private void YDo()
    {
        // POI: Foreground Thread
        new Thread(() =>
        {
            Thread.Sleep(100);
            WriteLine("Done with YDo");
        }).Start();

        _result = "YDo";
    }
}

new Program().Main();

delegate void Printer();

public void Main()
{
    var printers = new List<Printer>();

    Enumerable
        .Range(1, 10)
        .ForEach(v => printers.Add(delegate { Console.WriteLine(v); }));

    printers.ForEach();
}

static void ForEach(this IEnumerable<int> nums, Action<int> operation)
{
    foreach (var num in nums)
    {
        operation(num);
    }
}

static void ForEach(this IEnumerable<Printer> printers)
{
    foreach (var printer in printers)
    {
        printer();
    }
}

Main();

static List<Printer> XMain()
{
    List<Printer> printers = new List<Printer>();
    for (int i = 0; i < 10; i++)
    {
        // POI: Bad bevahior because 'i' refers to the same memoryspace rather than different memory spaces
        printers.Add(delegate { Console.WriteLine(i); });
    }
    return printers;
}

foreach (var printer in XMain())
{
    printer();
}