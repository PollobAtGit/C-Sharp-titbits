using System;
using System.Linq;
using System.Reflection;

namespace T
{
    internal static class Program
    {
        static Action<object> cl = (x) => Console.WriteLine(x);

        public static void Main()
        {
            // POI: Getting Type definition
            Type tCustomer = Type.GetType("T.Customer");

            cl(tCustomer.Name);//Customer
            cl(tCustomer.Namespace);//T
            cl(tCustomer.FullName);//T.Customer

            // POI: ToString() returns FullName
            cl(tCustomer.ToString());

            // POI: Returned MethodInfo will contain getters & setters. In case of getters, properties are
            // internally methods without any argument

            // POI: Public methods inherited from Object class are
            // 1. string ToString()
            // 2. int GetHashCode()
            // 3. bool Equals()
            // 4. System.Type GetType()

            MethodInfo[] tCustomerPublicMethods = tCustomer
                .GetMethods(BindingFlags.Instance | BindingFlags.Public);

            // POI: Non public methods inherited from Object class are
            // 1. System.Object MemberwiseClone()
            // 2. void Finalize()

            MethodInfo[] tCustomerNonPublicMethods = tCustomer
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            cl(null);
            cl($"Total Public Method Count => {tCustomerPublicMethods.Length}");
            tCustomerPublicMethods.ToList().ForEach(x => cl(x));

            cl(null);
            cl($"Total Non-Public Method Count => {tCustomerNonPublicMethods.Length}");
            tCustomerNonPublicMethods.ToList().ForEach(x => cl(x));

            PropertyInfo[] tCustomerPublicProperties = tCustomer
                .GetProperties(BindingFlags.Instance | BindingFlags.Public);

            cl(null);
            cl($"Total Public Properties = {tCustomerPublicProperties.Length}");
            tCustomerPublicProperties.ToList().ForEach(x => cl(x));

            PropertyInfo[] tCustomerNonPublicProperties = tCustomer
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

            cl(null);
            cl($"Total Non Public Properties = {tCustomerNonPublicProperties.Length}");
            tCustomerNonPublicProperties.ToList().ForEach(x => cl(x));

            ConstructorInfo[] tCustomerCtors = tCustomer.GetConstructors();

            cl(null);
            cl($"Total Constructors = {tCustomerCtors.Length}");

            // POI: Constructors has return type 'void' & name '.ctor' in assembly metadata
            tCustomerCtors.ToList().ForEach(x => cl(x));// void .ctor() & void .ctor(Int32)

            cl(null);
            IRepository repo = new BlogRepository();

            // POI: repo.GetType() will return the runtime Type
            cl(typeof(BlogRepository) == repo.GetType());//True

            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            Type customerType = currentAssembly.GetType("T.Customer");
            MethodInfo customerInstanceMethod = customerType.GetMethod("SayMyName");

            object customerInstance = Activator.CreateInstance(customerType);

            // POI: MethodInfo has a member 'Invoke' which requires value for 'this'
            // POI: Situation is similar to JS's usage of bind/apply & call
            // POI: The method here has no context
            customerInstanceMethod.Invoke(customerInstance, null);// None
        }
    }

    internal interface IRepository { }
    internal class BlogRepository : IRepository { }
    internal class PostRepository : IRepository { }

    internal class Customer
    {
        readonly int _id = 0;
        protected const string name = "NONE";

        public int Id => _id;
        public string Name => name;

        // POI: Setters & getters are converted to methods
        // POI: Getters have no arguments but setters have arguments of the defined Type
        private Type OwnType { get; set; }

        public Customer() { }

        public Customer(int id) { }

        public void SayMyName() => Console.WriteLine($"{this.Name}");

        private void SayMyId() => Console.WriteLine($"{this.Id}");

        protected void SayAll() => Console.WriteLine($"{this.Id} => {this.Name}");
    }
}
