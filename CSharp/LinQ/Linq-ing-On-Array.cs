using System;
using System.Linq;
using System.Collections.Generic;

namespace Client.App
{
	public class Program
	{
		//Linq-ing on in memory collection (array)
		public static void Main()
		{
			//Object array
			object[] objArray = new object[] { 5, "LINQ", 200.23m, 89.2e12, new Program() };
			DisplayLinqIngResults(objArray
					.Select(element => element.GetType().Name));//.OrderBy(element => element);

			//String array
			string[] stringArray = new string[] { "ENTER", "ESCAPE", "SIX", "SEVEN" };
			DisplayLinqIngResults(stringArray.Where(elem => elem.Length > 3).OrderBy(elem => elem.Length).Take(2));
			Console.WriteLine("\nSum of All Selected String Lengths: " + 
					stringArray
						.Where(elem => elem.Length > 3)
							.OrderBy(elem => elem.Length)
								.Take(2)
									.Sum(elem => elem.Length));

			//double array
			decimal[] priceArray = new decimal[] { 20.23m, 56.789m, 20.88e23m };
			DisplayLinqIngResults(priceArray.OrderByDescending(price => price));//Note that here Select isn't being used. So Select can be used to project which means it can be used to selectively chose which elements should be displayed

			//Anonymous array
			var anonymousArray = new [] 
			{ 
				new { Name = "Vim", Type = "Editor" }, 
				new { Name = "Notepad", Type = "Editor"} ,
				new { Name = "Windows", Type = "Operating System"},
				new { Name = "Firefox", Type = "Browser"} 
			};
			DisplayLinqIngResults(anonymousArray
					.Where(ele => ele.Type == "Editor")
						.Select(ele => ele.Name));

			//Anonymous dynamic-ish object array
			
			//CS0826 compilation error will thrown & it says: "No best best type found for implicitly typed arrays"
			//Details: https://msdn.microsoft.com/en-us/library/bb384226.aspx
			var dynamicishArray = new []
			{
				new { Language = "Java Script", Type = "Dynamic" },
				new { Language = "Python", Type = "Dynamic" },
				new { Language = "C++", Type = "Strongly/Statically Typed" },
				new { Language = "Ruby", Type = "Dynamic" }
				//, new { Name = "Java", IsADynamicLanguage = false } // If it's not commented out then error will be thrown. 
				//See comment
			};

			//Take a note of the output format. The whole anonymous type is being outputted (just like printing JSON).
			//We can do otherwise by projection
			DisplayLinqIngResults(dynamicishArray
					.TakeWhile(PLanguage => PLanguage.Type == "Dynamic"));//Note that: Ruby isn't in output

			DisplayLinqIngResults(dynamicishArray
					.Where(PLanguage => PLanguage.Type == "Dynamic"));//Note that: Ruby is in the output

			//Anonymous dynamic-ish object array
			var dynamicishArrayObj = new []
			{
				new { Language = "C++", Type = "Strongly/Statically Typed" },
				new { Language = "Java Script", Type = "Dynamic" },
				new { Language = "Python", Type = "Dynamic" },
				new { Language = "Ruby", Type = "Dynamic" }
			};

			//Note that: Output is EMPTY because TakeWhile immediately found C++ which doesn't satisfy the criteria & then breaks from loop
			DisplayLinqIngResults(dynamicishArrayObj
					.TakeWhile(PLanguage => PLanguage.Type == "Dynamic"));

			DisplayLinqIngResults(dynamicishArrayObj
					.SkipWhile(PLanguage => !PLanguage.Type.Contains("Dynamic")));


			//Anonymous dynamic-ish object array
			var dynamicishArrayOfObj = new []
			{
				new { Language = "C++", Type = "Strongly/Statically Typed" },
				new { Language = "Java Script", Type = "Dynamic" },
				new { Language = "Python", Type = "Dynamic" },
				new { Language = "C#", Type = "Strongly/Statically Typed" },
				new { Language = "Ruby", Type = "Dynamic" }
			};

			//Note that: Output contains 'C#'
			DisplayLinqIngResults(dynamicishArrayOfObj
					.SkipWhile(PLanguage => !PLanguage.Type.Contains("Dynamic")));

			//Zip extension method
			UsingZipLinqExtensionMethod();

			//Cast<T>() extension method
			UsingLinqCastToCastWholeSequence();
		}

		//Note that this is an generic method & T is being referenced in method parameter
		public static void DisplayLinqIngResults<T>(IEnumerable<T> list)
		{
			Console.WriteLine("\n");
			foreach(var element in list)
			{
				Console.WriteLine(element);
			}
		}

		public static void UsingZipLinqExtensionMethod()
		{
			int[] firstSeq = new int[] { 10, 235, 89 };			
			float[] secondSeq = new float[] { 200.23f, 89.008f };//Note that this sequence length if less then the first sequence

			//Note that outout contains only two elements
			DisplayLinqIngResults(firstSeq.Zip(secondSeq, (elemInFirstSeq, elemInSecondSeq) => elemInFirstSeq + elemInSecondSeq));

			//How about zipping multiple sequences?
			double[] thirdSeq = new double[] { 56.02, 556, 789.001 };
			decimal[] fourthSeq = new decimal[] { 0.001m, 20.302m, 999.99m, 101.99m };

			DisplayLinqIngResults<decimal>(firstSeq
					.Zip(secondSeq, (elemInFirstSeq, elemInSecondSeq) => elemInFirstSeq + elemInSecondSeq)
						.Zip(thirdSeq, (elInFirstSeq, elInSecondSeq) => elInFirstSeq + elInSecondSeq)
							//.Cast<decimal>()//Why it doesn't work?
								.Zip(fourthSeq, (elInFirstSeq, elInSecondSeq) => (decimal)elInFirstSeq + elInSecondSeq)
					);
		}

		public static void UsingLinqCastToCastWholeSequence()
		{
			sbyte[] bangladeshBatsmanScoreCardFiveYearsAgo = new sbyte[] { 20, 127 };

			//Following operation isn't particularly useful for casting between numeric types. Why?
			//DisplayLinqIngResults(bangladeshBatsmanScoreCardFiveYearsAgo.Cast<decimal>());
		}
	}
}

