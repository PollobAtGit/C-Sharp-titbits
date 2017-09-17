using System;
using System.ServiceModel;
using WCFLibrary;

namespace HostWCFLib
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var service = new ServiceHost(typeof(HelloService)))
            {
                service.Open();
                Console.WriteLine($"Host Has Started @{DateTime.Now}");
                Console.ReadLine();
            }
        }
    }
}
