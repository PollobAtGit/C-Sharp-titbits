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

        private static bool Do(object obj)
        {
            try
            {
                if(obj == null) throw new NotImplementedException();
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

            Console.WriteLine("Released Shared Resources");

            return true;
        }
    }
}