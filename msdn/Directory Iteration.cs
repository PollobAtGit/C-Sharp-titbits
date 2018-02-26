using System;
using System.IO;
using System.Linq;

internal static class TDI
{
	static Action<object> cl = (object x) => Console.WriteLine(x);

    	public static void Main()
    	{
		// IterateOverDirectoriesRecursively();
		DisplayFilesAndDirectories(@"C:\Users\pollob\Documents\101");
    	}

	static void DisplayFilesAndDirectories(string dir)
	{
		if(dir == null) return;
		
		// POI: static counterpart simply returns the names as string but the instance method returns a FileInfo
		var files = Directory.GetFiles(dir);

		// POI: static method returns the directory names as string but the instance method returns DirectoryInfo
		var subDirectories = Directory.GetDirectories(dir);

		foreach(var f in files) cl(f);
		foreach(var sDir in subDirectories) DisplayFilesAndDirectories(sDir);

	}

	static void IterateOverDirectoriesRecursively()
	{
		// POI: Logical Drives gets all logical drive names as strings
		var drives = Environment.GetLogicalDrives();

		foreach(var dr in drives)			
			cl(dr);// C:\ ... D:\

		// Iterate over drive names & extract drive information
		foreach(var dr in drives)
		{
			// DriveInfo gets Drive Information
			var driveInfo = new DriveInfo(dr);

			// Drive Info For C:\ => True | C:\
			// Drive Info For D:\ => True | D:\
			cl("Drive Info For " + dr + " => " + driveInfo.IsReady + " | " + driveInfo.RootDirectory.ToString());
		}

		foreach(var dr in drives)
		{
			var dI = new DriveInfo(dr);

			WalkThrough(dI.RootDirectory);
		}
	}

	static void WalkThrough(DirectoryInfo dir)
	{
		FileInfo[] fsI = null;

		try
		{
			fsI = dir.GetFiles("*.*");
		}
		catch(UnauthorizedAccessException e) { }


		if(fsI != null)
		{
			// POI: This operation will throw exception if fsI is null because under the hood GetEnumerator() is invoked on null reference
			foreach(var fI in fsI) cl(fI.FullName);
			foreach(var sDir in dir.GetDirectories()) WalkThrough(sDir);		
		}
	}
}
