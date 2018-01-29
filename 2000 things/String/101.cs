using System;
using System.Text;

namespace OneOOne
{
	class Program
	{
		private static Action<object> cl = (object x) => Console.WriteLine(x);
		public static void Main()
		{
			NinetySix();
			SeventyOne();
		}

		// #96: Comparing String
		// POI: Prefer static method (if available) then instance method because usually static methods can handle null values which by definition 
		// instance methods can't do
		private static void NinetySix()
		{
			// POI: Comparing string is not same as string equality
			// POI: '>' or '<' operators are not overloaded for string
			// POI: Error: Operator '>' cannot be applied to operands of type 'string' and 'string'
			//cl("A" > "B");
			
			// POI: To compare strings use string.Compare(...)
			// POI: Value less than zero indicates 1st string is smaller than 2nd string
			cl(string.Compare("A", "B"));// -1
			cl(string.Compare("B", "A"));// 1
			cl(string.Compare("A", "A"));// 0

			// POI: Negative number indicates 1st string is smaller (comes first) than 2nd string
			// POI: This approach has disadvantage. What if 1st string is null? NullReferenceException will be thrown
			cl("A".CompareTo("B"));// -1
			cl("B".CompareTo("A"));// 1
		}

		// #71: StringBuilder capacity
		// POI: StringBuilder automatically increases capacity by double (2*current-capacity) when current capacity is being fulfilled
		// That's why using StringBuilder is performant in scenarios where rapid string concatenation is required
		private static void SeventyOne()
		{
			// POI: Initial StringBuilder capacity is 16 (2^4). When required it will be increased by power of two (n^2). So 16 -> 32 (2^5)
			// -> 64 (2^6) -> 128 (2^7) -> 256 (2^8)
			var strBuilder = new StringBuilder();

			strBuilder.Append("1234567890123456");
			cl(strBuilder.Length);// 16
			cl(strBuilder.Capacity);// 16

			strBuilder.Append("A");
			cl(strBuilder.Length);// 17

			// POI: Capacity is increased by double (2*previous-capacity)
			cl(strBuilder.Capacity);// 32

			var strBuilderWithInitialCapacity = new StringBuilder(100);
			strBuilderWithInitialCapacity.Append("A");

			cl(strBuilderWithInitialCapacity.Length);// 1
			cl(strBuilderWithInitialCapacity.Capacity);// 100

			var strBuilderWithInitialString = new StringBuilder("INITIAL");
			cl(strBuilderWithInitialString.Length);// 7
			
			// POI: Lowest assigned capacity is 16 for StringBuilder. It's true if no length is given & if initial string is given but length of the
			// string is < 16
			cl(strBuilderWithInitialString.Capacity);// 16

			var strBuilderLargerInitialCapacity = new StringBuilder("12345678901234561234567890123456123456789012356");
			cl(strBuilderLargerInitialCapacity.Length);// 47

			// POI: If initial string length is > 16 then string builder length == string length. Later it will be increased as per requirement
			cl(strBuilderLargerInitialCapacity.Capacity);// 47

			strBuilderLargerInitialCapacity.Append("0");

			// POI: Length is double literally! So capacity increase doesn't occur by power of 2 but direct (2 * previous-capacity)
			cl(strBuilderLargerInitialCapacity.Capacity);// 94
		}
	}
}
