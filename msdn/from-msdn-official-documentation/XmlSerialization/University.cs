using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlSerialization
{
    [Serializable]
    public class University
    {
        public string Name { get; set; }

        [XmlElement("ThisUniversityIsAnEngineeringUniversity")]
        public bool IsEngineeringUniversity { get; set; }

        [XmlElement("UniversityAddress")]
        public Address Location { get; set; }

        [XmlIgnore]
        public List<Department> Departments { get; set; }

        [XmlAttribute("UniversityIdentity")]
        public string UniversityCode { get; set; }
    }
}
