using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using serializationoptions.Model;
using serializationoptions.Util;

namespace serializationoptions.Service
{
    public class XmlSerialization<T>
    {
        private readonly string _file;
        private readonly XmlSerializer _serializer;

        public XmlSerialization(string file)
        {
            _file = file;
            _serializer = new XmlSerializer(typeof(T));
        }

        public void Deserialize()
        {
            using (var fs = File.OpenRead(_file))
            {
                var deserializedObject = (T)_serializer.Deserialize(fs);

                if (deserializedObject != null)
                {
                    if (deserializedObject is IEnumerable)
                        foreach (var o in deserializedObject as IEnumerable)
                            Console.WriteLine(JsonConvert.SerializeObject(o));
                    else
                        Console.WriteLine(deserializedObject);
                }
            }
        }

        public void Serialize()
        {
            object objectToSerialize = typeof(T) == typeof(Person) ? Mock.Persons() : (object)Mock.Employees();

            using (var fileStream = File.OpenWrite(_file))
                _serializer.Serialize(fileStream, objectToSerialize);
        }
    }
}
