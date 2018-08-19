using System;
using System.IO;
using System.Linq;
using System.Threading;

class T
{
    delegate int BinaryOp(int x, int y);

    private static int Add(int x, int y)
    {
        var startingMessage = $"int Add(int, int): Starting From Thread Id {Thread.CurrentThread.ManagedThreadId}";
        Console.WriteLine(startingMessage);

        Thread.Sleep(5000);

        var endMessage = $"int Add(int, int): Ending From Thread Id {Thread.CurrentThread.ManagedThreadId}";
        Console.WriteLine(endMessage);

        File.WriteAllLines(@".\WriteLines.txt", new string[] { startingMessage, endMessage });

        return x + y;
    }
    
    public static void Main()
    {
        // MainSync();
        MainAsync();
    }

    public static void MainSync()
    {
        var binOp = new BinaryOp(Add);

        Console.WriteLine($"void main(): Starting From Thread Id {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine(binOp(10, 20));

        foreach(var x in Enumerable.Range(1, 5))
        {
            Console.WriteLine($"void main(): Continuing In Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        Console.WriteLine($"void main(): Ending From Thread Id {Thread.CurrentThread.ManagedThreadId}");
    }

    public static void MainAsync()
    {
        var binOp = new BinaryOp(Add);

        Console.WriteLine($"void main(): Starting From Thread Id {Thread.CurrentThread.ManagedThreadId}");

        IAsyncResult asyncAddResult = binOp.BeginInvoke(10, 30, null, null);

        // this .sleep(...) forces main thread to halt which forces scheduler to start binOp before continuing with main thread
        Thread.Sleep(1000);

        foreach(var x in Enumerable.Range(1, 5))
        {
            Console.WriteLine($"void main(): Continuing In Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        // unless we are waiting for returned value main thread exists
        // is the async operation starting even unless we invoke EndInvoke(...) ? 
            // No. The async operation starts whenever we invoke BeginInvoke(...) because of scheduling algorithm/priorities it might seem
            // like the operation hasn't started yet
        // Console.WriteLine(binOp.EndInvoke(asyncAddResult));

        Thread.Sleep(5000 * 2);

        Console.WriteLine($"void main(): Ending From Thread Id {Thread.CurrentThread.ManagedThreadId}");
    }
}

/*
    IAsyncResult

    public interface IAsyncResult
    {
        object AsyncState { get; }
        WaitHandle AsyncWaitHandle { get; }
        bool CompletedSynchronously { get; }
        bool IsCompleted { get; }
    }
*/
