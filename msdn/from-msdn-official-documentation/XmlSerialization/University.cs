using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlSerialization
{
    [Serializable]
    public class University
    {
        public UniversityName Name { get; set; }

        [XmlElement("ThisUniversityIsAnEngineeringUniversity")]
        public bool IsEngineeringUniversity { get; set; }

        [XmlElement("UniversityAddress")]
        public Address Location { get; set; }

        public List<Department> Departments { get; set; }

        //[XmlIgnore] will not de-serialize the property into the CLR object

        [XmlAttribute("UniversityIdentity")]
        public string UniversityCode { get; set; }

        public override string ToString()
        {
            return $"{Environment.NewLine}University name => {Name}, Code => {UniversityCode} Address => {Location}, Departments => {string.Join(", ", Departments)}";
        }
    }
}
