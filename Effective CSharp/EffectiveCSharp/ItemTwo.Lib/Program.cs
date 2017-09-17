namespace ItemTwo
{
    enum DAY
    {
        SUNDAY,
        MONDAY
    }

    public class Program
    {
        // POI: Runtime constant
        // POI: readonly can be used with both reference type & numeric/string types
        public readonly int ThisYear = 200;

        // POI: Following is not valid because const is applicable for only string/number/enumeration
        //private const DateTime CurrentDate = DateTime.Now;

        // POI: This is allowed because internally enumeration is nothing but integers
        private const DAY CurrentDay = DAY.MONDAY;

        // POI: Compile time constant
        // POI: Compile time constants are only useful for numeric & string types
        public const int ThisYearConst = 200;

        private const string StrConst = "CONSTANT STRING";

        //static void Main(string[] args)
        //{
        //    // POI: Consts are available here because they are static by default
        //    WriteLine(ThisYearConst);
        //    WriteLine(StrConst);
        //    WriteLine(CurrentDay);
        //}
    }
}
