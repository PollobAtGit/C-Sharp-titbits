namespace Tuple
{
    using static System.Console;

    class Program
    {
        // POI: This constructor will be invoked the 1st time any operation regarding this class occurs
        // POI: That will be the only time this constructor will be invoked in the application life time
        // POI: This constructor in this case is invoked because the static method 'Main' is onvoked by runtime

        static Program()
        {
            PrintCoordinates();
            PrintCoordinatesWithDiscard();
            CommonTryParsePattern();

            PatternMatchingIntro(100);

            var (a, b, c) = LookupName(100);

            WriteLine($"A: {a} => B: {b} => C: {c}");
        }

        // TODO: Didn't understand a bit in terms of scoping rule
        private static void PatternMatchingIntro(object o)
        {
            if (o is null) return;
            if (!(o is int i)) return;
            WriteLine(new string('*', i));
        }

        private static (string, string, string) LookupName(long id)
        {
            var s = id.ToString();

            return (s, s, s);
        }
        private static void PrintCoordinatesWithDiscard()
        {
            // POI: Discarding any value if we don't need that
            GetCoordinates(out int x, out _);
            WriteLine($"X: {x} => Y: Is Not Important");

            // POI: Discarding not only works with last parameter but also with first parameter
            GetCoordinates(out _, out var b);
            WriteLine($"A: Is Not Important => B: {b}");

            GetCoordinates(out _, out var d, out _);
            WriteLine($"First & Last : Is Not Important => d: {d}");
        }

        private static void CommonTryParsePattern()
        {
            // Very fluent compared to the previous approach which is to declare the variable first
            if (int.TryParse("10", out int x)) { WriteLine($"Parsed value {x} & Type: {x.GetType()}"); }
            else { WriteLine("Cloudy - no stars tonight!"); }

            if (int.TryParse("1X0", out int y)) { WriteLine($"Parsed value {y} & Type: {y.GetType()}"); }
            else { WriteLine("Cloudy - no stars tonight!"); }
        }

        static void Main(string[] args)
        {
            // POI: static Main doesn't have any invocation. All is in static constructor
        }

        private static void PrintCoordinates()
        {
            // POI: x & y is being declared in this scope
            GetCoordinates(out int x, out int y);
            WriteLine($"X: {x} => Y: {y}");

            // POI: Here we can't declare x & y any more because they are declared already in the scope
            // POI: Because the method has type defined for the arguments we can use 'var' here. Compiler can infer the type
            GetCoordinates(out var a, out var b);
            WriteLine($"A: {a} => B: {b}");
        }

        private static void GetCoordinates(out int x, out int y)
        {
            x = 10;
            y = 20;
        }

        private static void GetCoordinates(out int x, out int y, out int z)
        {
            x = 100;
            y = 200;
            z = 300;
        }
    }
}
