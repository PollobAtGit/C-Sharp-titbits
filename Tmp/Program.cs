using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication1
{
    class Account
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Amount { get; set; }

        public IList<string> Roles { get; set; }

        public Account() { Roles = new List<string>(); }

        // POI: Awesome
        // POI: Can be used for both ignoring a property from being serialized and ignoring a property conditionally
        // public bool ShouldSerializeAmount() => false;
        // JSON.NET uses reflection to grab this method
        public bool ShouldSerializeAmount() => Amount.CompareTo(0.0m) == 0;

        public override string ToString() => $"{Email} || {IsActive} || {CreatedDate.ToShortDateString()} || {string.Join(", ", Roles)}";
    }

    class Program
    {
        static IContainer Container;
        static JsonSerializer Serializer;

        static Program()
        {
            ConfigureAutofac();

            Serializer = Container.Resolve<JsonSerializer>();
        }

        static void Main()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Account, Account>());

            var account = new Account
            {
                Email = "meet.somebody@gmail.com",
                IsActive = true,
                CreatedDate = DateTime.Now,
                Amount = 100.23m,
                Roles = new List<string> { "User", "Admin" }
            };

            var anotherAccount = new Account()
            {
                Email = "meet.none@gmail.com"
            };

            Mapper.Map(account, anotherAccount);

            Console.WriteLine(JsonConvert.SerializeObject(new List<Account> { account, anotherAccount }, Formatting.Indented));

            Console.WriteLine("LOOKUP");

            Console.WriteLine(JsonConvert.SerializeObject(new List<Account> { account, anotherAccount }.ToLookup(x => x.Email), Formatting.Indented));

            Console.WriteLine("DICTIONARY");

            Console.WriteLine(JsonConvert.SerializeObject(new List<Account> { account }.ToDictionary(x => x.Email), Formatting.None));

#pragma warning disable S1075 // URIs should not be hardcoded
            using (var streamWriter = File.CreateText(@"D:\Archive\Json\sample.json"))
#pragma warning restore S1075 // URIs should not be hardcoded
            {
                var jsonWriter = new JsonTextWriter(streamWriter)
                {
                    Formatting = Formatting.Indented
                };

                Serializer.Serialize(jsonWriter, account);
            }

            var stringComparisons = new List<StringComparison>
            {
                StringComparison.CurrentCulture,
                StringComparison.CurrentCultureIgnoreCase,
                StringComparison.InvariantCulture
            };

            Console.WriteLine(JsonConvert.SerializeObject(stringComparisons));//[0, 1, 2]
            Console.WriteLine(JsonConvert.SerializeObject(stringComparisons, new StringEnumConverter()));
            Console.WriteLine(JsonConvert.SerializeObject(stringComparisons, new StringEnumCustomConverter()));

            var settings = new JavaScriptSettings
            {
                Age = new JRaw(10),
                OnUnloadFunction = new JRaw("function print(e) { console.log(e); }")
            };

            Console.WriteLine(JsonConvert.SerializeObject(settings, Formatting.Indented));

            Console.WriteLine(new JObject(new JProperty("amount", 10)));

            // POI: JRaw can be useful here because the content of the ctor is simply being emitted
            Console.WriteLine(
                new JObject(
                    new JProperty("onLoadFunc", new JRaw("function s() {}")),

                    // POI: In this case we want it to be wrapped as string
                    new JProperty("greeting", "hello !")
                    ));

            Console.WriteLine(JsonConvert.SerializeObject(new List<Account> { account, anotherAccount }, Formatting.None));

            Console.WriteLine(JsonConvert.SerializeObject(new List<Account> { account, anotherAccount }, Formatting.Indented));

            Deserialization();
        }

        static void Deserialization()
        {
            // POI: For proper conversion between DateTime string & DateTime we need to use Converter
            // \"CreatedDate\": \"2018 - 01 - 01\"
            var account = JsonConvert.DeserializeObject<Account>(
                "{ \"Email\": \"meet.somebody@gmail.com\", \"IsActive\": true, \"Roles\": [ \"User\", \"Admin\" ] }");

            Console.WriteLine(account);

            var accounts = JsonConvert.DeserializeObject<List<Account>>("[{\"Email\":\"meet.somebody@gmail.com\",\"IsActive\":true, \"Roles\":[\"User\",\"Admin\"]},{\"Email\":\"meet.somebody@gmail.com\",\"IsActive\":true, \"Roles\":[\"User\",\"Admin\"]}]");

            Console.WriteLine(string.Join(" == ", accounts));

            var accountDic = JsonConvert.DeserializeObject<Dictionary<string, Account>>("{\"meet.somebody@gmail.com\":{\"Email\":\"meet.somebody@gmail.com\",\"IsActive\":true,\"CreatedDate\":\"2018-01-01T19:39:08.1927961+06:00\",\"Roles\":[\"User\",\"Admin\"]}, \"k.somebody@gmail.com\":{\"Email\":\"meet.somebody@gmail.com\",\"IsActive\":true,\"CreatedDate\":\"2018-01-01T19:39:08.1927961+06:00\",\"Roles\":[\"User\",\"Admin\"]}}");
            Console.WriteLine(string.Join(" -- ", accountDic.Select(x => x.Value)));
            Console.WriteLine(accountDic["meet.somebody@gmail.com"]);

            var ano = new { Age = 0 };

            Console.WriteLine(JsonConvert.DeserializeAnonymousType(@"{Age: 10}", ano));//{Age = 10}

            // POI: If property is not found then that properties value is simply default
            Console.WriteLine(JsonConvert.DeserializeAnonymousType(@"{ge: 10}", ano));//{Age = 0}
        }

        static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<JsonSerializer>();

            Container = builder.Build();
        }

        class StringEnumCustomConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType) => true;

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (!CanConvert(value.GetType())) return;

                var list = (value as IEnumerable).OfType<StringComparison>();
                writer.WriteValue($"{string.Join(" >> ", list)} || {string.Join(" || ", list.Cast<int>())}");
            }
        }

        class JavaScriptSettings
        {
            // TODO: Why JSON Raw?
            public JRaw Age { get; set; }
            public JRaw OnUnloadFunction { get; set; }
        }
    }
}
