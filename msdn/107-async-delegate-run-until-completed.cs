using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

public class T
{
    delegate int BinaryOperation(int x, int y);

    static BinaryOperation binOp = new BinaryOperation(Add);

    private static bool IsDone = false;

    public static void Main()
    {
        Console.WriteLine($"from main thread {Thread.CurrentThread.ManagedThreadId}");

        IAsyncResult asyncResult;

        var withCallBack = true;

        if (!withCallBack)
            asyncResult = binOp.BeginInvoke(10, 20, null, null);
        else
            asyncResult = binOp.BeginInvoke(30, 56, new AsyncCallback(AddComplete), null);

        IAsyncResultIsCompletedInAction(asyncResult);

        // invoking ...EndInvoke... after ...AsyncWaitHandle.WaitOne... essentially means we are waiting for the operation to be done
        // after we are done with the operations that should have happened while ...Add... was executing
        // IAsyncResultMaxWaitingTimeInAction(asyncResult);

        // without this main thread will close/end
        while(!IsDone);

        // invoking ...EndInvoke... on the delegate with IAsyncResult here is not that useful may be because the ...Add... method should have
        // a mechanism to deal with the data that is resulted from the async operation
        if(!withCallBack)
            Console.WriteLine(binOp.EndInvoke(asyncResult));
    }

    // note the argument ...IAsyncResult... it hasn't been passed by the user rather by the run time environment itself
    private static void AddComplete(IAsyncResult asyncResult)
    {
        Console.WriteLine($"from add-complete thread {Thread.CurrentThread.ManagedThreadId}");

        var result = asyncResult as AsyncResult;
        if (result != null)
        {
            var asyncDelegate = result.AsyncDelegate as BinaryOperation;
            if(asyncDelegate != null)
                Console.WriteLine($"result of ...Add... {asyncDelegate.EndInvoke(asyncResult)}");
        }

        // if IsDone is set during the execution of ...Add... (even at the end of the method) the callback will not be invoked (imagine
        // two concurrently running threads)
        IsDone = true;
    }

    private static void IAsyncResultMaxWaitingTimeInAction(IAsyncResult asyncResult)
    {
        var i = 1;

        // essentially we are asking scheduler to take control
        while(!asyncResult.AsyncWaitHandle.WaitOne(200, true))
        {
            Console.WriteLine($"[{i}] : working .... !");
            i = i + 1;
        }

    }

    private static void IAsyncResultIsCompletedInAction(IAsyncResult asyncResult)
    {
        // it's impossible to know when ...Add... method will complete it's execution. So if we wanna execute an operation until result
        // is available then we can't do that. the best we can do is to execute the operations we wanna do until ...Add... is done then
        // wait for the result to arrive

        var i = 1;
        while(!asyncResult.IsCompleted)
        {
            Console.WriteLine($"[{i}] : working .... !");
            Thread.Sleep(100);
            i = i + 1;
        }
    }

    private static int Add(int x, int y)
    {
        Console.WriteLine($"from add method {Thread.CurrentThread.ManagedThreadId}");

        Thread.Sleep(550);

        return x + y;
    }
}