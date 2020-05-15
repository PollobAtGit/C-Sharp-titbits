using System.Xml.Serialization;
using ProtoBuf;

namespace serializationoptions.Model
{
    [ProtoContract]
    [XmlRoot("address")]
    public class Address
    {
        [ProtoMember(1)]
        [XmlElement("line")]
        public string Line { get; set; }

        [ProtoMember(2)]
        [XmlElement("zipcode")]
        public string ZipCode { get; set; }
    }
}
