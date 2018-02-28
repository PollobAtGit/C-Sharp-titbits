using System;
using System.Net;

internal static class T
{
	public static void Main()
	{
		// var uri = "http://localhost:24106/web-api/0/aemployee/3";
		
		var uri = "http://localhost:24106/web-api/0/traces";

		using(var client = new WebClient())
		{
			var content = client.DownloadString(uri);

			Console.WriteLine(content);// {"Id":3,"Age":50,"Name":"Z","OrgId":30,"DepartmentId":3}
		}
	}
}
