using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Th = System.Threading;
using Cn = System.Console;

namespace Threading.Console
{
    class Two
    {
        static void Main(string[] args)
        {
            //ThreadJoin();
            //ThreadPassValue();
            ImpactOfVariable();
            ImpactOfVariable_Closure();
        }

        private static void ImpactOfVariable_Closure()
        {
            for (var i = 0; i < 10; i++)
            {
                // every thread will HOLD the value of [i]
                var k = i;

                new Th.Thread(() =>
                {
                    Th.Thread.Sleep(1);
                    Cn.WriteLine($"thread value - closured -: {k}");
                }).Start();
            }
        }

        private static void ImpactOfVariable()
        {
            // every thread will take the LATEST value of [i]
            for (var i = 0; i < 10; i++)
            {
                new Th.Thread(() =>
                {
                    Th.Thread.Sleep(1);
                    Cn.WriteLine($"thread value : {i}");
                }).Start();
            }
        }

        private static void ThreadPassValue()
        {
            //ParameterizedThreadStart takes on argument so essentially infinite number
            // of values can be passed
            var t = new Th.Thread((o) =>
            {
                Th.Thread.Sleep(500);
                var e = o as ModelEmployee;
                Cn.WriteLine(e);
            });

            t.Start(new ModelEmployee { Id = 5, NationalId = "some other string" });
        }

        class ModelEmployee
        {
            public int Id { get; set; }

            public string NationalId { get; set; }

            public override string ToString() => $"{Id} : {NationalId}";
        }

        private static void ThreadJoin()
        {
            var t = new Th.Thread(() =>
            {
                // Task.Delay(...) is non-blocking
                //await Task.Delay(500);

                // Thread.Sleep(...) blocks the thread
                Th.Thread.Sleep(500);
                Cn.WriteLine($"Thread Id: {Th.Thread.CurrentThread.ManagedThreadId}");
            });


            // As Thread is running in background this operation will not complete
            // combining the fact that the operation will take 500 ms to complete

            t.IsBackground = true;

            t.Start();

            // Join(...) is forcing the main thread to wait for the worker thread to be completed
            t.Join();
        }
    }
}
