using System;
using System.Xml.Serialization;

namespace XmlSerialization
{
    [Serializable]
    public class UniversityName
    {
        // POI: XmlText simply makes the property value a content

        [XmlText]
        public string Name { get; set; }

        // There won't be nay runtime error of any sort because we are simply NOT
        // reading that attribute/properties value
        [XmlIgnore]
        public string Culture { get; set; }

        public override string ToString() => $"{Environment.NewLine}University name => {Name}, Culture => {Culture}";
    }
}