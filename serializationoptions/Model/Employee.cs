using System.Xml.Serialization;

namespace serializationoptions.Model
{
    // this root has no impact when (de)serialized to xml
    [XmlRoot("employee")]
    public class Employee : Person
    {
        [XmlElement("nid")]
        public string Nid { get; set; }
    }
}
