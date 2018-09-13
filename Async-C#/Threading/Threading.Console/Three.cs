using Th = System.Threading;
using Cn = System.Console;
using System;
using System.Threading;

namespace Threading.Console
{
    class Three
    {
        // EventWaitHandle is not exited unless it's value is set
        private static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            //FinallyIsNotInvokedForThread();
            //FinallyWillNeverBeInvokedFromThreadPool();
            EventWaitHandleDoesntExitUntilTheValueIsSet();
        }

        private static void EventWaitHandleDoesntExitUntilTheValueIsSet()
        {
            // Thread will be started ASAP by the OS
            ThreadPool.QueueUserWorkItem(o =>
            {
                Cn.WriteLine("from ThreadPool Queue ... ");
                Thread.Sleep(500);

                // this Exception will not be caust anywhere
                throw new Exception();
            });

            // EventWaitHandler hasn't been set. So this WaitOne(...) is an infinite
            // loop

            // because of the above reason its advisable to wait for the Thread to be
            // completed for a certain preiod of time

            //_autoResetEvent.WaitOne();

            // best practice
            _autoResetEvent.WaitOne(900);
        }

        private static void FinallyWillNeverBeInvokedFromThreadPool()
        {
            // all threads from ThreadPool are background thread which essentially
            // means generally we can't wait for this Thread atlease via Join(...)
            // because we don't have the reference to the Thread

            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    Cn.WriteLine("from try ... from ThreadPool ... ");
                    Thread.Sleep(100);
                }
                catch { }
                finally
                {
                    Cn.WriteLine("from finally ... from ThreadPool");

                    // alternative to handle/wait for the Thread from ThreadPool
                    // to be completed

                    _autoResetEvent.Set();
                }
            });

            // WaitOne(...) is an infinite loop which doesn't exit unless the
            // AutoResetEvent is Set(...)

            _autoResetEvent.WaitOne();
        }

        private static void FinallyIsNotInvokedForThread()
        {
            var worker = new Thread(() =>
            {
                try
                {
                    Th.Thread.Sleep(500);
                    Cn.WriteLine("from try ...");
                }
                catch { }

                // finally might not get executed because the thread is running in background
                // if finally incorporates logic to free resources it might cause issue. best practice
                // is to wait until this Thread is finished via .Join(...)
                finally { Cn.WriteLine("from finally ..."); }
            })
            {
                IsBackground = true
            };

            worker.Start();

            // waiting to make sure finally gets executed and release necessary resources
            worker.Join();
        }
    }
}
