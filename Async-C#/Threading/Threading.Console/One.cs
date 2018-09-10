using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Th = System.Threading;

namespace Threading.Console
{
    class One
    {
        // ThreadPool is crazy fast compared to creating individual Threads
        private const int ThreadCount = 200;// 200000

        static List<int> ThreadPoolThreads = new List<int>();

        static void Main(string[] args)
        {
            //ThreadPoolOnlyThreadEtc();
            TaskCompletion();
        }

        private static void TaskCompletion()
        {
            // what is really TaskCompletionSource?
            var tcs = new TaskCompletionSource<bool>();

            var t = Task.Run(async () =>
            {
                // Task.Deplay(...) is non-blocking
                await Task.Delay(1000);

                // Thread.Sleep(...) is blocking
                //Th.Thread.Sleep(1000);

                tcs.TrySetResult(true);

                // result is being rejected
                //tcs.TrySetCanceled();
                //tcs.TrySetException(new ArgumentException());
            });

            // Returns True after sometime
            //Write(t.IsCompleted.ToString());

            // this operation will never complete if tcs is not resolved
            Write(tcs.Task.Result.ToString());
        }

        private static void ThreadPoolOnlyThreadEtc()
        {
            MeasurePerformance(() => Start(10, true));

            Write("working....");

            var threadCreationTime = MeasurePerformance(() => Start(ThreadCount, false));// 00:00:03.2642749
            var threadPoolUsageTime = MeasurePerformance(() => StartWithThreadEnqueue(ThreadCount, false));// 00:00:03.2642749

            Write($"Performance improvement for using Thread Pool: {threadCreationTime - threadPoolUsageTime}");

            Write("performance measurement done....");

            StartWithThreadEnqueue(50, true);

            Write(string.Join(", ", ThreadPoolThreads.Distinct().Select(x => x.ToString())));

            System.Console.ReadKey();

            // only 4 distinct threads are being used here by ThreadPool
            Write(string.Join(", ", ThreadPoolThreads.Distinct().Select(x => x.ToString())));
        }

        private static TimeSpan MeasurePerformance(Action func)
        {
            var dt = DateTime.Now;

            func();

            var executionDuration = DateTime.Now - dt;
            Write(executionDuration);

            return executionDuration;
        }

        private static void StartWithThreadEnqueue(int threadCount, bool isPrintThreadId)
        {
            Enumerable.Range(0, threadCount).ToList().ForEach(x =>
            {
                // Thread Pool is super effective in terms of performance
                // all threads created from ThreadPool are Background Thread

                Th.ThreadPool.QueueUserWorkItem((o) =>
                {
                    if (isPrintThreadId)
                        Write(Th.Thread.CurrentThread);

                    ThreadPoolThreads.Add(Th.Thread.CurrentThread.ManagedThreadId);
                });
            });
        }

        private static void Start(int threadCount, bool isPrintThreadId)
        {
            Enumerable.Range(0, threadCount).ToList().ForEach(x =>
            {
                // All new Threads are background threads
                new Th.Thread(() =>
                {
                    if (isPrintThreadId)
                        Write(Th.Thread.CurrentThread);
                }).Start();
            });
        }

        private static void Write(Th.Thread t)
            => System.Console.WriteLine($"Current Thread: {t.ManagedThreadId}. \tIs running in background: {t.IsBackground}");

        private static void Write(string v) => System.Console.WriteLine(v);

        private static void Write(DateTime time)
            => System.Console.WriteLine($"Current Time: {time}");

        private static void Write(TimeSpan time)
                    => System.Console.WriteLine($"Current Time: {time}");
    }
}
