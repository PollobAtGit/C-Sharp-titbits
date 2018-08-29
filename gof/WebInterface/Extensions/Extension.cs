using System.Collections.Generic;
using System.Linq;

namespace WebInterface.Extensions
{
    internal static class Extension
    {
        internal static double Multiply(this IList<double> nums) => nums.Aggregate(1.0, (acc, cur) => acc * cur);

        internal static int Multiply(this IList<int> nums) => nums.Aggregate(1, (acc, cur) => acc * cur);

        internal static bool IsNull<T>(this T source) => source == null;

        internal static bool IsNotNull<T>(this T source) => !source.IsNull();
    }
}