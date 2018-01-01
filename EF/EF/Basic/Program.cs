using System;
using Autofac;

namespace Basic
{
    static class Program
    {
        static IContainer Container { get; set; }
        static Action<object> cw = (x) => Console.WriteLine(x);

        static void Main()
        {
            ConfigureAutoFac();
        }

        static void ConfigureAutoFac()
        {
            var builder = new ContainerBuilder();

            Container = builder.Build();
        }
    }
}
