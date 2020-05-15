using System.Collections.Generic;
using serializationoptions.Model;
using serializationoptions.Service;

namespace serializationoptions
{
    partial class Program
    {
        const string ProtoBufferFile = "Xml/persons.xml";

        const string XmlSerializationFile = "Xml/xmlserializationfile.xml";

        const string EmployeeXmlSerializationFile = "Xml/employeexmlserializationfile.xml";

        private static readonly ProtoBuffer _protoBuffer = new ProtoBuffer(ProtoBufferFile);

        private static readonly XmlSerialization<List<Person>> _personsXmlSerialization = new XmlSerialization<List<Person>>(XmlSerializationFile);

        private static readonly XmlSerialization<List<Employee>> _employeeXmlSerialization = new XmlSerialization<List<Employee>>(EmployeeXmlSerializationFile);

        static void Main(string[] args)
        {
            // _protoBuffer.Deserialize();
            // _protoBuffer.Serialize();

            // _personsXmlSerialization.Serialize();
            // _personsXmlSerialization.Deserialize();

            // _employeeXmlSerialization.Serialize();
            // _employeeXmlSerialization.Deserialize();
        }
    }
}
