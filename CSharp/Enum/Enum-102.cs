using System;

namespace Thread_102
{
    internal enum DAY
    {
        SAT,
        SUN,
        MON
    }

    internal static class Client
    {
        public static void Main()
        {
            string day = "SAT";
            DAY dayEnum;

            //Poi: Generally, compiler throws compilation error if an unassigned variable of any TYPE is used in a statement. But compiler understands
            //'out' keyword. So if a variable is passed to a method with 'out' keyword specified than it doesn't throw that error
            //Poi: Enum.TryParse is a generic method
            if(Enum.TryParse<DAY>(day, out dayEnum))
                Console.WriteLine(dayEnum);

            string anotherDay = "WED";
            DAY anotherDayEnum;

            //Poi: TryEnum is a static method in Enum & the namespace for Enum is System
            if(Enum.TryParse<DAY>(anotherDay, out anotherDayEnum))
                Console.WriteLine(anotherDayEnum);
            else Console.WriteLine("DAY ENUM DOESN'T CONTAIN ENUMERATION FOR => " + anotherDay);
        }
    }
}