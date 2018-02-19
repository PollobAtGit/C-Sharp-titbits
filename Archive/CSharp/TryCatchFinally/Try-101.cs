using System;

namespace Try_101
{
    internal static class Client
    {
        public static void Main()
        {
            Console.WriteLine(Do(new object()));

            Console.WriteLine();
            Console.WriteLine(Do(null));
        }

        //Poi: In a method where there is try-block statement, there method leaving point is multiple,
        //Once via, 'try' & the other is via 'catch'. In both cases, if there is any finally block than
        //that will be invoked first then the return statement, which makes more sense because in that case
        //the method will get chance to release valuable resource, if it's holding any
        private static bool Do(object obj)
        {
            try
            {
                if(obj == null) throw new NotImplementedException();

                //Poi: Before this statement is executed, 'finally' will be invoked
                return true;
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);

                //Poi: In someway this return statement is stored in stack, so that CLR can execute the
                //return statement AFTER finally block is executed
                return false;
            }
            finally
            {
                Console.WriteLine("Releasing Shared Resources");

                //Poi: Following will throw compilation error : "Control cannot leave the body of a finally clause"
                //This happens because if Exception doesn't occur then try { } might include a return statement
                //also finally { } includes a return statement in this case. So method might attempt to return
                //multiple values. So return statement can't be in finally { } block

                // return true;
            }

            //Poi: This code block is unreachable because 'try' & 'catch' both has related return statement
            Console.WriteLine("This code is unreachable");
        }
    }
}