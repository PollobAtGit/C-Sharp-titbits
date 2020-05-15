using System;
using System.Threading.Tasks;

namespace asyncpatterns
{
    public static class AsyncExtensions
    {
        public static async Task WithTimeOut(this Task originalTask, int timeOutInMilliSeconds)
        {
            var timeOutTask = Task.Delay(timeOutInMilliSeconds);

            var completedTask = await Task.WhenAny(originalTask, timeOutTask);

            if (completedTask == timeOutTask)
                Console.WriteLine("TIMED OUT!");
        }
    }
}
