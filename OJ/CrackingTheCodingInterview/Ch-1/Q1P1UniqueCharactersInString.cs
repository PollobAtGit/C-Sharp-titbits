using System;
using System.Linq;
using System.Collections.Generic;

internal static class T
{
	
	/// <summary>
	/// Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?
    	/// </summary>

	static Action<object> cl = (object x) => Console.WriteLine(x);

	public static void Main()
	{
		cl(HasUnique_Sort(null));
		cl(HasUnique_Sort(""));
		cl(HasUnique_Sort("a"));
		cl(HasUnique_Sort("aa"));
		cl(HasUnique_Sort("ab"));

		cl("");

		cl(HasUnique_Dictioinary(null));
		cl(HasUnique_Dictioinary(""));
		cl(HasUnique_Dictioinary("a"));
		cl(HasUnique_Dictioinary("aa"));
		cl(HasUnique_Dictioinary("ab"));

		cl("");

		cl(HasUnique_ByDistinct(null));
		cl(HasUnique_ByDistinct(""));
		cl(HasUnique_ByDistinct("a"));
		cl(HasUnique_ByDistinct("aa"));
		cl(HasUnique_ByDistinct("ab"));
	}

	internal static bool HasUnique_Sort(string s)
	{
		if(s == null || s.Trim() == "") return false;

		var a = s.OrderBy(x => x).ToArray();

		for(int i = 0; i < a.Length - 1; i++)
		{
			if(a[i] == a[i + 1]) return false;
		}

		return true;
	}

	internal static bool HasUnique_Dictioinary(string s)
	{
		if(s == null || s.Trim() == "") return false;

		var a = new int[128];

		for(int i = 0; i < s.Length; i++)
		{
			if(a[s[i]] != 0) return false;
			a[s[i]]++;
		}

		return true;
	}

	internal static bool HasUnique_ByDistinct(string s)
	{
		if(s == null || s.Trim() == "") return false;

		return s.Distinct().Count() == s.Length;
	}

	internal static bool HasUnique_HasSet(string s)
	{
		if(s == null || s.Trim() == "") return false;

		var h = new HashSet<char>();

		for(int i = 0; i < s.Length; i++)
		{
			if(h.Contains(s[i])) return false;
			h.Add(s[i]);
		}

		return true;
	}

	internal static bool HasUnique_HasSetShort(string s)
	{
		return new HashSet<char>(s).Count == s.Length;
	}
}
