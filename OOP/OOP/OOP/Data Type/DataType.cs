using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OOP.Data_Type
{
    [StructLayout(LayoutKind.Sequential)]
    internal class EmptyClass
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    internal class Programmer
    {
        public int BugFoundByQA { get; set; }
        public int GitCommit { get; set; }
        public string Name { get; set; }

        //Default Constructor accessibility: private (https://msdn.microsoft.com/en-us/library/kcfb85a6.aspx)
        //Search for:  "Note that if you do not use an access modifier"
        //#1 To enable object instantiation that class must have one public constructor
        public Programmer(string _name, int _bugFound, int _commit)
        {
            Name = _name;
            BugFoundByQA = _bugFound;
            GitCommit = _commit;
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    internal class DataType
    {
        public static void AssigningReferenceType()
        {
            Programmer pollob = new Programmer("Pollob", 50, 51);
            Console.WriteLine(pollob.Name + " has committed " + pollob.GitCommit + " times & QA has found " + pollob.BugFoundByQA + " bugs");

            Programmer betterVersionOfPollob = null;
            if (betterVersionOfPollob == null)
                //Following assignment, assigns reference to better pollob. So ultimately,
                //both pollob & better pollob are same person
                betterVersionOfPollob = pollob;

            betterVersionOfPollob.GitCommit = 100;
            betterVersionOfPollob.BugFoundByQA = 0;
            betterVersionOfPollob.Name = "Awesome_Pollob";

            Console.WriteLine(pollob.Name + " has committed " + pollob.GitCommit + " times & QA has found " + pollob.BugFoundByQA + " bugs");
            Console.WriteLine(betterVersionOfPollob.Name + " has committed " + betterVersionOfPollob.GitCommit + " times & QA has found " + betterVersionOfPollob.BugFoundByQA + " bugs");
        }

        public static void GettingClassSize()
        {
            //1 Byte for empty class with no member or method. 1 Byte to hold the reference, I guess
            Console.WriteLine("Empty Class Size: " + Marshal.SizeOf(typeof(EmptyClass)));

            //CLR initially seems to allocate 4 bytes for string
            Console.WriteLine("Class (with members) Size: " + Marshal.SizeOf(typeof(Programmer)));

            //Only 1 Byte. This class contains two method. Conclusion: Method count doesn't contribute to class Size
            Console.WriteLine("Class (with only method) Size: " + Marshal.SizeOf(typeof(DataType)));
        }
    }

    public class ClassWithVarInstanceMemeber
    {
        public int value { get; set; }
        public int intValue = 10;

        //Trying to use var as instance member throws following error
        //Error CS0825  The contextual keyword 'var' may only appear within a local variable declaration or in script code
        //public var varValue = 10;

        public ClassWithVarInstanceMemeber()
        {

        }
    }
}
