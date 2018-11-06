using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static Barrier _barrier = new Barrier(3, barrier => Console.WriteLine());

        static void Main(string[] args)
        {
            //Barrier();-

            Thread t = new Thread(delegate ()
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("__");
                        Thread.Sleep(1000);
                    }
                }
                catch (ThreadAbortException)
                {
                    Console.WriteLine("aborted");
                }
            });   // Spin forever

            t.Start();
            Thread.Sleep(300);        // Let it run for a second...
            t.Abort();                  // then abort it.
        }

        private static void Barrier()
        {
            new Thread(Speak).Start();
            new Thread(Speak).Start();
            new Thread(Speak).Start();
        }

        static void Speak()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + " ");
                _barrier.SignalAndWait();
            }
        }
    }
}
