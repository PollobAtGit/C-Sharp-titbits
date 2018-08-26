using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

public class T
{
    delegate int BinaryOperation(int x, int y);

    private static bool IsDone;

    private static int Multiply(int x, int y)
    {
        Console.WriteLine($"current thread for ...multiply... is {Thread.CurrentThread.ManagedThreadId}");

        // long awaited task
        Thread.Sleep(300);

        return x * y;
    }

    private static void MultiplyComplete(IAsyncResult asyncResult)
    {
        Console.WriteLine("multiplication is done");

        var result = asyncResult as AsyncResult;
        if(result != null)
        {
            var asyncDelegate = result.AsyncDelegate as BinaryOperation;
            if (asyncDelegate != null)
            {
                // async state contains passed data to the callback method
                var messageFromOtherUniverse = asyncResult.AsyncState as string;

                Console.WriteLine($"multiplication result {asyncDelegate.EndInvoke(asyncResult)}");

                if (!string.IsNullOrEmpty(messageFromOtherUniverse))
                    Console.WriteLine(messageFromOtherUniverse);

                IsDone = true;
            }
        }
    }

    public static void Main()
    {
        // BinaryOperation is a type that's why ...static.../...non-static... doesn't matter in this case
        var binOp = new BinaryOperation(Multiply);

        Console.WriteLine($"current thread for ...main... {Thread.CurrentThread.ManagedThreadId}");

        var application = "own app";

        binOp.BeginInvoke(10, 23, new AsyncCallback(MultiplyComplete), $"thank you for using app: {application}");

        // is completed is true whenever the designated operation is done
        // it doesn't wait for the call back to be invoked
        // while(!asyncResult.IsCompleted);

        while(!IsDone);
    }
}