using System;

namespace Inheritance_101
{
    //Poi: Most probably static class can't be inherited
    internal class IRepository { }
    internal class MongoRepository : IRepository { }
    internal class SqlServerRepository : IRepository { }

    internal static class Client
    {
        private static IRepository _Repository;

        static Client()
        {
            _Repository = new MongoRepository();
        }

        internal static void Main()
        {
            //Poi: Returned type is the INJECTED object (MongoRepository in this case) not the defined
            //Type (IRepository in this case)
            Console.WriteLine(_Repository.GetType());

            //Poi: In this way, type of a instance/static variable can be known
            Console.WriteLine(_Repository.GetType() == typeof(MongoRepository));
            Console.WriteLine(_Repository.GetType() == typeof(IRepository));

            //Poi: Shortcut for equality check maybe (!). Or any other advantage?
            //Poi: Invoking GetType() & typeof on Type is not required here
            Console.WriteLine(_Repository is MongoRepository);
            Console.WriteLine(_Repository is SqlServerRepository);
        }
    }
}