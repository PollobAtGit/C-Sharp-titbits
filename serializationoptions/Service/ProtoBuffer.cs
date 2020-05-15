using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProtoBuf;
using serializationoptions.Model;
using serializationoptions.Util;

namespace serializationoptions.Service
{
    public class ProtoBuffer
    {
        private readonly string _file;

        public ProtoBuffer(string file)
        {
            _file = file;
        }

        public void Deserialize()
        {
            using (var fileStream = File.OpenRead(_file))
            {
                var persons = Serializer.Deserialize<List<Person>>(fileStream);

                if (persons != null)
                {
                    Console.WriteLine(persons.Count);

                    foreach (var person in persons.Take(5))
                        Console.WriteLine(JsonConvert.SerializeObject(person));
                }
            }
        }

        public void Serialize()
        {
            var persons = Mock.Persons();

            using (var f = File.Create(_file))
                Serializer.Serialize(f, persons);

            Console.WriteLine("Done!");
        }
    }
}
