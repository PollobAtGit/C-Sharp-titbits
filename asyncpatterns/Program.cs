using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace asyncpatterns
{
    public class Program
    {
        static void Run()
        {
            Thread.Sleep(3000);

            throw new Exception();

            Console.WriteLine($"Inside {nameof(Program.Run)}");
        }

        static async Task Main(string[] args)
        {
            // RanToCompletionAndFaultedState();
            // TaskNotRunIfCanceledBeforeExecution();
            // TaskRunsEvenIfCanceledJustAfterExecutionStart();
            // ConstantCheckingForCancellation(false);
            // ConstantCheckingForCancellation(true);
            // ChainContinueWith();

            // await creates a foreground thread
            // await DoAsync();

            await DoAsync().WithTimeOut(50);
        }

        private static async Task DoAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("done!");
        }

        private static void ChainContinueWith()
        {
            var task = Task.Run(() =>
            {
                Console.WriteLine();
            })
            .ContinueWith(x => Console.WriteLine(nameof(TaskContinuationOptions.OnlyOnFaulted)), TaskContinuationOptions.OnlyOnFaulted)
            .ContinueWith(x => Console.WriteLine(nameof(TaskContinuationOptions.OnlyOnCanceled)), TaskContinuationOptions.OnlyOnCanceled)
            .ContinueWith(x => Console.WriteLine(nameof(TaskContinuationOptions.NotOnFaulted)), TaskContinuationOptions.NotOnFaulted);

            // TODO: is it a thread blocker? UI and etc
            task.Wait(); // OnlyOnCanceled | NotOnFaulted
        }

        private static void ConstantCheckingForCancellation(bool willCancel)
        {
            var cancellationSource = new CancellationTokenSource();

            var latestCount = 0;

            var cancellableTask = Task.Run(() =>
            {
                foreach (var i in Enumerable.Range(1, 50000000))
                {
                    // to get out of the Task cancellation exception must be thrown

                    if (willCancel)
                        if (cancellationSource.IsCancellationRequested)
                            cancellationSource.Token.ThrowIfCancellationRequested();

                    latestCount = i;
                }
            }).ContinueWith(x => Console.WriteLine("Final value of count: " + latestCount));// 9023782, 17215741

            Thread.Sleep(100);

            cancellationSource.Cancel();

            cancellableTask.Wait();
        }

        private static void TaskRunsEvenIfCanceledJustAfterExecutionStart()
        {
            var cancellationSource = new CancellationTokenSource();

            Task.Run(() =>
            {
                Console.WriteLine("Executing task");
            }, cancellationSource.Token);

            Thread.Sleep(100);

            cancellationSource.Cancel();
        }

        private static void TaskNotRunIfCanceledBeforeExecution()
        {
            var tokenSource = new CancellationTokenSource();

            tokenSource.Cancel();

            // Task will not be executed at all because Task has already been cancelled
            Task.Run(() =>
            {
                Console.WriteLine("Executing async method");
            }, tokenSource.Token);
        }

        private static void RanToCompletionAndFaultedState()
        {
            var runner = Task.Run(() => Run());

            runner
                .ContinueWith(x => Console.WriteLine($"Continuing with {nameof(runner)}"),

                    // OnlyOnRanToCompletion is executed when Task is NOT FAULTED
                    TaskContinuationOptions.OnlyOnRanToCompletion);

            runner
                .ContinueWith(x => Console.WriteLine($"Continuing with {nameof(runner)} after exception"),
                    TaskContinuationOptions.OnlyOnFaulted);

            // TODO: implement timeout
            Console.ReadKey();
        }
    }
}
