using System.Xml.Serialization;
using ProtoBuf;

namespace serializationoptions.Model
{
    [ProtoContract]
    
    // this root has no impact when (de)serialized to xml
    [XmlRoot("person")]
    public class Person
    {
        [ProtoMember(1)]
        [XmlElement("id")]
        public int Id { get; set; }

        [ProtoMember(2)]
        [XmlElement("name")]
        public string Name { get; set; }

        [ProtoMember(3)]
        [XmlElement("address")]
        public Address Address { get; set; }
    }
}
